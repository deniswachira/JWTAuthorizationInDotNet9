using JWTAuthorizationInDotNet9.DTO;
using JWTAuthorizationInDotNet9.Entities;

namespace JWTAuthorizationInDotNet9.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<TokenResponseDto?> LoginAsync(UserDto request);
        Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);
    }
}
