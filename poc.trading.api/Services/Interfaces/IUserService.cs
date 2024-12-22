using poc.trading.api.Entities;
using poc.trading.api.Entities.Dto;

namespace poc.trading.api.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDetails> GetUserDetails(string userName);
        public Task<UserDetails> GetUserDetailsByEmailId(string emailId);
        public Task<LoginResponse> Login(LoginRequest request);
    }
}
