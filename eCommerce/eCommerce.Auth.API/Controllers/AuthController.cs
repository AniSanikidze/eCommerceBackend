using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Auth.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok(new { message = "User created successfully" });
                }

                return BadRequest(result.Errors);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    var token = GenerateJwtToken(user);

                    return Ok(new { token });
                }

                return Unauthorized();
            }

            return BadRequest(ModelState);
        }
        //[HttpPost("register")]
        //public async Task<ActionResult<Result>> Register(RegistrationCommand command, CancellationToken cancellationToken)
        //{
        //    var result = await Mediator.Send(command, cancellationToken);
        //    return result.IsSuccess ? CreatedAtAction(nameof(Register), result) : BadRequest(result.Errors);
        //}

        ///// <summary>
        ///// logs in the user with provided username and password
        ///// </summary>
        ///// <remarks>
        ///// Note id is not required
        /////
        /////     POST/login
        /////     
        /////      {
        /////         "username": "11111111111",
        /////         "password": "123456"
        /////      }   
        ///// </remarks>
        ///// <param name="command"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns>Returns user details and jwt token after the user has successfully logged into the system</returns>
        ///// <response code="200">Returns jwt token</response>
        ///// <response code="400">Invalid request coming from user</response>
        ///// <response code="401">If user login failed</response>
        //[HttpPost("login")]
        //public async Task<ActionResult<string>> Login(LoginCommand command, CancellationToken cancellationToken)
        //{
        //    var result = await Mediator.Send(command, cancellationToken);
        //    return result.IsSuccess ? Ok(result.Value) : ResultExtension.ToProblemDetails(result);
        //}

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpPost("user-data")]
        //public async Task<ActionResult<UserModel>> GetUserData()
        //{
        //    return Ok(GetCurrentUser());
        //}
    }
}
