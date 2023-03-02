using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental
{
    [Route("api/[controller]")]
    [ApiController]
    //?
    public class VehicleTypesController : ControllerBase
    {
        private readonly VehicleTypesLogic vehicleTypeLogic = new VehicleTypesLogic();

        [HttpGet]
        public IActionResult GetAllVehicleTypes()
        {
            try
            {
                List<VehicleTypeModel> vehicleType = vehicleTypeLogic.GetAllVehicleTypes();
                return Ok(vehicleType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOneVehicleType(int id)
        {
            try
            {
                VehicleTypeModel? vehicleType = vehicleTypeLogic.GetVehicleType(id);
                if (vehicleType == null)
                    return NotFound($"Car Type ID:{id} not found");
                return Ok(vehicleType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddVehicleType(VehicleTypeModel vehicleTypeModel)
        {
            try
            {
                VehicleTypeModel addedVehicleType = vehicleTypeLogic.AddVehicleType(vehicleTypeModel);
                return Created($"api/vehicleTypes/{addedVehicleType.VehicleTypeID}", addedVehicleType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult FullVehicleTypeUpdate(VehicleTypeModel vehicleTypeModel, int id)
        {
            try
            {
                vehicleTypeModel.VehicleTypeID = id;
                VehicleTypeModel? updatedVehicleType = vehicleTypeLogic.FullVehicleTypeUpdate(vehicleTypeModel);
                if (updatedVehicleType == null)
                    return NotFound($"Car Type ID:{id} not found");
                return Ok(updatedVehicleType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult PartialVehiclTypeeUpdate(VehicleTypeModel vehicleTypeModel, int id)
        {
            try
            {
                vehicleTypeModel.VehicleTypeID = id;
                VehicleTypeModel? updatedVehicleType = vehicleTypeLogic.PartialVehicleTypeUpdate(vehicleTypeModel);
                if (updatedVehicleType == null)
                    return NotFound($"Car Type ID:{id} not found");
                return Ok(updatedVehicleType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteVehicleType(int id)
        {
            try
            {
                vehicleTypeLogic.RemoveVehicleType(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public void Dispose()
        {
            vehicleTypeLogic.Dispose();
        }
    }
}
