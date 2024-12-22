using Newtonsoft.Json;
using poc.trading.api.Entities;
using poc.trading.api.Entities.Dto;
using poc.trading.api.Repositpory.Interface;
using poc.trading.api.Services.Interfaces;
using poc.trading.sdk.Authentication;
using System.Text.Json.Serialization;

namespace poc.trading.api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public UserService(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<UserDetails> GetUserDetails(string userName)
        {
            return await _userRepository.GetUserDetails(userName);
        }

        public async Task<UserDetails> GetUserDetailsByEmailId(string emailId)
        {
            return await _userRepository.GetUserDetailsByEmailId(emailId);
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var userDetails = await _userRepository.GetUserDetails(request.UserName);
            if (userDetails == null || (userDetails.UserName == request.UserName && userDetails.Password != request.Password))
            {
                return new LoginResponse { IsSuccess = false };
            }
            
            var user = JsonConvert.SerializeObject(userDetails);
            var Claims = JsonConvert.DeserializeObject<Dictionary<string, string>>(user) ?? new Dictionary<string, string>();
            Claims.Remove("Password");

            var token = _tokenService.GenerateToken(request.UserName, Claims);

            return new LoginResponse { IsSuccess = true, Token = token };
        }
    }
}
