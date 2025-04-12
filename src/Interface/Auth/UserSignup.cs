namespace Interface.Auth {
    public class UserSignupRawRequest {
        required public string Name { get; set; }
        required public string Username { get; set; }
        required public string Password { get; set; }
        required public string PhoneNumber { get; set; }
    }
}