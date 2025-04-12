using Interface.Auth;
using Interface.Response;
using Models.Auth;

namespace Repository.Auth {
    public class UserSignupRepository {
        private readonly Models.Auth.UserSignup _userSignup;

        public UserSignupRepository() {
            _userSignup = new Models.Auth.UserSignup();
        }

        public Interface.Response.SignupResponse createUser(Interface.Auth.UserSignupRawRequest userSignUpRequest) {
            string name = userSignUpRequest.Name;
            string username = userSignUpRequest.Username;
            string password = userSignUpRequest.Password;
            string phoneNumber = userSignUpRequest.PhoneNumber;

            Interface.Response.SignupResponse checkIfUserExists = _userSignup.checkExistingUser(username);
            if(checkIfUserExists.Success) {
                return checkIfUserExists;
            }

            Interface.Response.SignupResponse createUser = _userSignup.createUser(name, username, password, phoneNumber);
            return createUser;
        }
    }
}