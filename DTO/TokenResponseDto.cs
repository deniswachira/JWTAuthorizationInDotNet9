namespace JWTAuthorizationInDotNet9.DTO
{
    public class TokenResponseDto
    {
        public required string AccesToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}
