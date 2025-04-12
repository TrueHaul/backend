using Microsoft.AspNetCore.Mvc;
using RoutePaths = Utils.Routes.Route;
using Interface.Auth;
using Repository.Auth;

namespace Controllers.Auth {
    [Route(RoutePaths.EmailLogin)]
    [ApiController]

    public class UserLoginController : ControllerBase {
        private readonly Repository.Auth.UserLoginRepository _userLoginRepository;

        public UserLoginController() {
            _userLoginRepository = new UserLoginRepository();
        }

        [HttpPost]
        public IActionResult UserLogin([FromBody] Interface.Auth.UserLoginRawRequest userLoginRequest) {
            Console.WriteLine(userLoginRequest);

            return Ok("Login successful");
        }

    }
}
