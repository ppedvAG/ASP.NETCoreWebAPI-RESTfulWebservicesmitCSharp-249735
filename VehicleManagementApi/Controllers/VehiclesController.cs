using BusinessModel.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using VehicleManagementApi.Mappers;
using VehicleManagementApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleManagementApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<VehiclesController> _logger;

        public VehiclesController(IVehicleService vehicleService, ILogger<VehiclesController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }

        // GET: api/vehicles
        [HttpGet]
        //public async Task<IActionResult> Get()
        public async Task<ActionResult<IEnumerable<VehicleResultDto>>> Get([FromQuery] VehicleSearchParams? searchParams)
        {
            var result = (await _vehicleService.GetVehicles()).AsEnumerable();

            // Besser Filterlogik in dem Service implementieren
            // Oder noch besser: OData verwenden!
            if (searchParams != null)
            {
                if (searchParams.Brand != null)
                {
                    result = result.Where(v => v.Manufacturer == searchParams.Brand);
                }
                if (Enum.TryParse(searchParams.Color, out KnownColor color))
                {
                    result = result.Where(v => v.Color == color);
                }
                if (!string.IsNullOrEmpty(searchParams.FuelType))
                {
                    result = result.Where(v => v.Fuel == searchParams.FuelType);
                }
            }

            return Ok(result.Select(v => v.ToDto()));
        }

        // GET api/vehicles/D0663A37-BC81-49D3-8A2A-5CAA5DBF526B
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<VehicleResultDto>> Get(Guid id)
        {
            var result = await _vehicleService.GetVehicleById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToDto());
        }

        // POST api/vehicles
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateVehicleDto value)
        {
            if (ModelState.IsValid)
            {
                var entity = value.ToEntity();
                await _vehicleService.AddVehicle(entity);
                return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity.ToDto());
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        // PUT api/vehicles/D0663A37-BC81-49D3-8A2A-5CAA5DBF526B
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CreateVehicleDto value)
        {
            if (ModelState.IsValid)
            {
                var entity = value.ToEntity();
                var success = await _vehicleService.UpdateVehicle(id, entity);
                if (!success)
                {
                    return NotFound();
                }
                return Ok(entity.ToDto());
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/vehicles/D0663A37-BC81-49D3-8A2A-5CAA5DBF526B
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) // [FromRoute] ist eigentlich implizit
        {
            var success = await _vehicleService.DeleteVehicle(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
