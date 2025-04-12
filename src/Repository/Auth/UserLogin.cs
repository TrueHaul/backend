using Interface.Auth;
using Interface.Response;
using Models.Auth;

namespace Repository.Auth {
    public class UserLoginRepository {
        private readonly Models.Auth.UserLogin _userLogin;

        public UserLoginRepository() {
            _userLogin = new Models.Auth.UserLogin();
        }

        public Interface.Response.LoginResponse checkExistingUser(Interface.Auth.UserLoginRawRequest userLoginRequest) {
            string username = userLoginRequest.Username;
            string password = userLoginRequest.Password;

            Interface.Response.LoginResponse checkIfUserExists = _userLogin.checkExistingUser(username, password);

            return checkIfUserExists;
        }
    }
}