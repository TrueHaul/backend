namespace Interface.Response {
    public class LoginResponse {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public LoginResponse(bool success = false, string message = "Login Failed", object data = null) {
            Success = success;
            Message = message;
            Data = data ?? new object();
        }
    }
}