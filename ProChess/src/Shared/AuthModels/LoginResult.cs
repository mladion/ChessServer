namespace Shared.AuthModel
{
    public class LoginResult
    {
        public bool Successful { get; set; }
        public string? Token { get; set; }
        public string? Error { get; set; }
    }
}
