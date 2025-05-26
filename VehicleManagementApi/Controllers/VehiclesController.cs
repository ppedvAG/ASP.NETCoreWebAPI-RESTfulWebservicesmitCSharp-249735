using BusinessModel.Contracts;
using BusinessModel.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<Auto>>> Get()
        {
            var result = await _vehicleService.GetVehicles();
            return Ok(result);
        }

        // GET api/vehicles/D0663A37-BC81-49D3-8A2A-5CAA5DBF526B
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Auto>> Get(Guid id)
        {
            var result = await _vehicleService.GetVehicleById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/vehicles
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Auto value)
        {
            await _vehicleService.AddVehicle(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        // PUT api/vehicles/D0663A37-BC81-49D3-8A2A-5CAA5DBF526B
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Auto value)
        {
            var success = await _vehicleService.UpdateVehicle(id, value);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
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
