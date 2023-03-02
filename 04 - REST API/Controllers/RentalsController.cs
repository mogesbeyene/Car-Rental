using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")] //Must be admin 
    public class RentalsController : ControllerBase
    {
        private readonly RentalsLogic rentalLogic = new RentalsLogic();

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllRentals()
        {
            try
            {
                List<RentalModel> rentals = rentalLogic.GetAllRentals();
                return Ok(rentals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOneRentals(int id)
        {
            try
            {
                RentalModel? rental = rentalLogic.GetRental(id);
                if (rental == null)
                    return NotFound($"Car ID:{id} not found");
                return Ok(rental);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        //[AllowAnonymous]
        //[Authorize] //Must be logged-in
        public IActionResult AddRental(RentalModel rentalModel)
        {
            try
            {
                RentalModel addedrental = rentalLogic.AddRental(rentalModel);
                return Created($"api/rentals/{addedrental.RentalID}", addedrental);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult FullRentalUpdate(RentalModel rentalModel, int id)
        {
            try
            {
                rentalModel.RentalID = id;
                RentalModel? updatedRental = rentalLogic.FullRentalUpdate(rentalModel);
                if (updatedRental == null)
                    return NotFound($"Rental ID:{id} not found");
                return Ok(updatedRental);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult PartialRentalUpdate(RentalModel rentalModel, int id)
        {
            try
            {
                rentalModel.RentalID = id;
                RentalModel? updatedRental = rentalLogic.PartialRentalUpdate(rentalModel);
                if (updatedRental == null)
                    return NotFound($"Car ID:{id} not found");
                return Ok(updatedRental);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteRental(int id)
        {
            try
            {
                rentalLogic.RemoveRental(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public void Dispose()
        {
            rentalLogic.Dispose();
        }
    }
}
