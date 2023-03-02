using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental
{
    [Route("api/[controller]")]
    [ApiController]
    //Free for all
    public class VehiclesController : ControllerBase
    {
        private readonly VehiclesLogic vehicleLogic = new VehiclesLogic();

        [HttpGet]
        public IActionResult GetAllVehicles()
        {
            try
            {
                List<VehicleModel> vehicles = vehicleLogic.GetAllVehicles();
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOneVehicles(int id)
        {
            try
            {
                VehicleModel? vehicle = vehicleLogic.GetVehicle(id);
                if (vehicle == null)
                    return NotFound($"Car ID:{id} not found");
                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddVehicle(VehicleModel vehicleModel)
        {
            try
            {
                VehicleModel addedVehicle = vehicleLogic.AddVehicle(vehicleModel);
                return Created($"api/vehicles/{addedVehicle.VehicleID}", addedVehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult FullVehicleUpdate(VehicleModel vehicleModel, int id)
        {
            try
            {
                vehicleModel.VehicleID = id;
                VehicleModel? updatedVehicle = vehicleLogic.FullVehicleUpdate(vehicleModel);
                if (updatedVehicle == null)
                    return NotFound($"Car ID:{id} not found");
                return Ok(updatedVehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult PartialVehicleUpdate(VehicleModel vehicleModel, int id)
        {
            try
            {
                vehicleModel.VehicleID = id;
                VehicleModel? updatedVehicle = vehicleLogic.PartialVehicleUpdate(vehicleModel);
                if (updatedVehicle == null)
                    return NotFound($"Car ID:{id} not found");
                return Ok(updatedVehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            try
            {
                vehicleLogic.RemoveVehicle(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public void Dispose()
        {
            vehicleLogic.Dispose();
        }
    }
}
