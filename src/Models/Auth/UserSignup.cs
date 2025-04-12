using MySql.Data.MySqlClient;
using DotNetEnv;
using Interface.Response;

namespace Models.Auth
{
    public class UserSignup
    {
        private static readonly string _connectionString;

        static UserSignup()
        {
            Env.Load();
            _connectionString = Env.GetString("MYSQL_CONNECTION_STRING");
        }

        public Interface.Response.SignupResponse checkExistingUser(string username)
        {
            Interface.Response.SignupResponse _signupResponse = new Interface.Response.SignupResponse();

            try
            {
                using var connection = new MySqlConnection(_connectionString);
                connection.Open();

                var query = "select _id from users where username = @username";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var userId = reader["_id"];
                    _signupResponse.Success = true;
                    _signupResponse.Message = "Account already exists";
                    _signupResponse.Data = new { UserId = userId };
                }
                else
                {
                    _signupResponse.Message = "Proceed for account creation";
                }
            }
            catch (Exception error)
            {
                _signupResponse.Message = error.Message;
            }

            return _signupResponse;
        }

        public Interface.Response.SignupResponse createUser(string name, string username, string password, string phoneNumber)
        {
            Interface.Response.SignupResponse _signupResponse = new Interface.Response.SignupResponse();
            var _id = Guid.NewGuid().ToString();

            try
            {
                using var connection = new MySqlConnection(_connectionString);
                connection.Open();

                using var transaction = connection.BeginTransaction();

                var query = "INSERT INTO users (_id, name, username, password, phone_number) VALUES (@id, @name, @username, @password, @phoneNumber)";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", _id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);

                int result = command.ExecuteNonQuery();

                if (result > 0) {
                    transaction.Commit();
                    _signupResponse.Success = true;
                    _signupResponse.Message = "Account created successfully";
                }
                else {
                    transaction.Rollback();
                    _signupResponse.Success = false;
                    _signupResponse.Message = "Account creation failed.";
                }
            }
            catch (Exception error) {
                _signupResponse.Message = error.Message;
            }

            return _signupResponse;
        }
    }
}