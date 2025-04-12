using Microsoft.AspNetCore.Mvc;
using RoutePaths = Utils.Routes.Route;
using Interface.Auth;
using Interface.Response;
using Repository.Auth;

namespace Controllers.Auth {
    [Route(RoutePaths.EmailLogin)]
    [ApiController]

    public class UserLoginController : ControllerBase {
        private readonly Repository.Auth.UserLoginRepository _userLoginRepository;

        public UserLoginController() {
            _userLoginRepository = new Repository.Auth.UserLoginRepository();
        }

        [HttpPost]
        public IActionResult UserLogin([FromBody] Interface.Auth.UserLoginRawRequest userLoginRequest) {
            Interface.Response.LoginResponse checkIfUserExists = _userLoginRepository.checkExistingUser(userLoginRequest);

            return Ok(checkIfUserExists);
        }

    }
}
