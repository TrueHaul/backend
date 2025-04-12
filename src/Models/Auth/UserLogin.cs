using MySql.Data.MySqlClient;
using DotNetEnv;
using Interface.Response;

namespace Models.Auth {
    public class UserLogin {
        private static readonly string _connectionString;

        static UserLogin() {
            Env.Load();
            _connectionString = Env.GetString("MYSQL_CONNECTION_STRING");
        }

        public Interface.Response.LoginResponse checkExistingUser(string username, string password) {
            Interface.Response.LoginResponse _loginResponse = new Interface.Response.LoginResponse();

            try {
                using var connection = new MySqlConnection(_connectionString);
                connection.Open();

                var query = "select _id from users where username = @username and password = @password";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                using var reader = command.ExecuteReader();
                if(reader.Read()) {
                    var userId = reader["_id"];
                    _loginResponse.Success = true;
                    _loginResponse.Message = "Login Successful";
                    _loginResponse.Data = new { UserId = userId };
                }
                else {
                    _loginResponse.Message = "User Not Found";
                }
            }
            catch (Exception error) {
                _loginResponse.Message = error.Message;
            }
            
            return _loginResponse;
        }
    }
}