namespace Interface.Response {
    public class SignupResponse {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public SignupResponse(bool success = false, string message = "Cannot create Account", object data = null) {
            Success = success;
            Message = message;
            Data = data ?? new object();
        }
    }
}