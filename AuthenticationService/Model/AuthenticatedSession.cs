namespace AuthenticationService.Model
{
    public class AuthenticatedSession
    {
        public string Token { get; set; }
        public string ExpiresAt { get; set; }
    }
}
