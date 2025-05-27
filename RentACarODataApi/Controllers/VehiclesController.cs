using BusinessModel.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace RentACarODataApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VehiclesController : ODataController
    {
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<VehiclesController> _logger;

        public VehiclesController(IVehicleService vehicleService, ILogger<VehiclesController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }

        [HttpGet, EnableQuery]
        public async Task<IActionResult> Get()
            => Ok(await _vehicleService.GetVehicles());
    }
}
