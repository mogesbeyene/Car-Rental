using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtHelper jwtHelper;
        private readonly UsersLogic userLogic;

        public AuthController(JwtHelper jwtHelper, UsersLogic userLogic)
        {
            this.jwtHelper = jwtHelper;
            this.userLogic = userLogic;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(CredentialsModel credentials)
        {
            try
            {
                UserModel? user = userLogic.GetUserByCredentials(credentials);

                if (user == null)
                    return Unauthorized("Incorrect username or password");

                user.JwtToken = jwtHelper.GetJwtToken(user.Username, user.Role);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserModel userModel)
        {
            try
            {
                if (userLogic.IsUsernameExists(userModel.Username))
                    return BadRequest("Username already taken");

                userLogic.AddUser(userModel);
                userModel.JwtToken = jwtHelper.GetJwtToken(userModel.Username, userModel.Role);

                return Ok(userModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
    }

}
