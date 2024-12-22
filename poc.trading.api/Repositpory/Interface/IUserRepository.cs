using poc.trading.api.Entities.Dto;

namespace poc.trading.api.Repositpory.Interface
{
    public interface IUserRepository
    {
        public Task<UserDetails> GetUserDetails(string userName);
        public Task<UserDetails> GetUserDetailsByEmailId(string emailId);
    }
}
