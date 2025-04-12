using Microsoft.AspNetCore.Mvc;
using RoutePaths = Utils.Routes.Route;
using Interface.Auth;
using Interface.Response;
using Repository.Auth;

namespace Controllers.Auth {
    [Route(RoutePaths.EmailSignup)]
    [ApiController]

    public class UserSignupController : ControllerBase {
        private readonly Repository.Auth.UserSignupRepository _userSignupRepository;

        public UserSignupController() {
            _userSignupRepository = new Repository.Auth.UserSignupRepository();
        }

        [HttpPost]
        public IActionResult UserSignup([FromBody] Interface.Auth.UserSignupRawRequest userSignupRequest) {
            Interface.Response.SignupResponse createUser = _userSignupRepository.createUser(userSignupRequest);

            return Ok(createUser);
        }

    }
}
