namespace AuthenticationService.Model
{
    public class AuthenticationResponse
    {
        public bool WasSuccessful { get; set; }
        public string Message { get; set; }
        public AuthenticatedSession Session { get; set; }
        public AuthenticatedUser User { get; set; }
    }
}
