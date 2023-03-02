using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")] //Must be admin 
    public class UsersController : ControllerBase
    {
        private readonly UsersLogic UsersLogic = new UsersLogic();

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                List<UserModel> users = UsersLogic.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOneUser(int id)
        {
            try
            {
                UserModel? User = UsersLogic.GetUser(id);
                if (User == null)
                    return NotFound($"User ID:{id} not found");
                return Ok(User);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddUser(UserModel UserModel)
        {
            try
            {
                UserModel addedUser = UsersLogic.AddUser(UserModel);
                return Created($"api/Users/{addedUser.UserID}", addedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult FullUserUpdate(UserModel UserModel, int id)
        {
            try
            {
                UserModel.UserID = id;
                UserModel? updatedUser = UsersLogic.FullUserUpdate(UserModel);
                if (updatedUser == null)
                    return NotFound($"User ID:{id} not found");
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult PartialUserUpdate(UserModel UserModel, int id)
        {
            try
            {
                UserModel.UserID = id;
                UserModel? updatedUser = UsersLogic.PartialUserUpdate(UserModel);
                if (updatedUser == null)
                    return NotFound($"User ID:{id} not found");
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                UsersLogic.RemoveUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public void Dispose()
        {
            UsersLogic.Dispose();
        }
    }
}
