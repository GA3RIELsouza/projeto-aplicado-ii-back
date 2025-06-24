using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Exceptions;
using Projeto_Aplicado_II_API.Infrastructure.Extensions;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Services
{
    public class AuthService(MainDbContext db,
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor,
        IUserRepository userRepository,
        IBranchRepository branchRepository,
        ICompanyRepository companyRepository)
    {
        private readonly MainDbContext _db = db;
        private readonly IConfiguration _configuration = configuration;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IBranchRepository _branchRepository = branchRepository;
        private readonly ICompanyRepository _companyRepository = companyRepository;

        public async Task<UserDto> RegisterAsync(RegisterDto dto)
        {
            var userWithEmailExists = await _userRepository.ExistsByEmailAsync(dto.Email);

            if (userWithEmailExists)
            {
                throw new BusinessException($"The e-mail \"{dto.Email}\" is already in use.", HttpStatusCode.Conflict);
            }

            var user = User.FromRegisterDto(dto);

            await _db.RunInTransactionAsync(async () =>
            {
                await _userRepository.AddAsync(user);
            });

            return UserDto.FromUser(user);
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
        {
            var incorrectEmailPasswordException = new BusinessException("E-mail e/ou senha incorreto(s).", HttpStatusCode.NotFound);

            var user = await _userRepository.GetByEmailAsync(dto.Email) ?? throw incorrectEmailPasswordException;

            var correctPassword = dto.Password.VerifyPassword(user.PasswordHash, user.PasswordSaltHash);

            if (!correctPassword)
            {
                throw incorrectEmailPasswordException;
            }

            var bearerToken = GenerateBearerToken(user);

            return new()
            {
                UserId = user.Id,
                Token = bearerToken
            };
        }

        private string GenerateBearerToken(User user)
        {
            var claims = new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("email", user.Email),
                new Claim("name", user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:BearerToken"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: creds);

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenStr;
        }

        public uint? GetLoggedUserId()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var user = httpContext?.User;
            var idStr = user?.FindFirstValue("id");

            if (!UInt32.TryParse(idStr, out var id)) return null;

            return id;
        }

        public string? GetLoggedUserEmail()
        {
            var email = _httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtRegisteredClaimNames.Email);

            return email;
        }

        public async Task<User> GetLoggedUserAsync()
        {
            var id = GetLoggedUserId() ?? 0;
            var user = await _userRepository.GetByIdThrowsIfNullAsync(id);

            return user;
        }

        public uint GetLoggedBranchId()
        {
            var loggedBranchIdStr = _httpContextAccessor?.HttpContext?.Request.Headers["X-Logged-Branch"].ToString() ?? string.Empty;

            if (!uint.TryParse(loggedBranchIdStr, out var loggedBranchId))
            {
                throw new BusinessException("Usuário não está logado em nenhuma filial.", HttpStatusCode.Unauthorized);
            }

            return loggedBranchId;
        }

        public async Task<Branch> GetLoggedBranchAsync()
        {
            var loggedBranchId = GetLoggedBranchId();

            var loggedBranch = await _branchRepository.GetByIdThrowsIfNullAsync(loggedBranchId);

            return loggedBranch;
        }

        public string? GetLoggedUserIpv4()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var connection = httpContext?.Connection;
            var ipv4 = connection?.RemoteIpAddress?.ToString();

            return ipv4;
        }
    }
}
