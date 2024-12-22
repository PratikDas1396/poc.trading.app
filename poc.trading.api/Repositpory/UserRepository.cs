using poc.trading.api.Entities;
using poc.trading.api.Entities.Dto;
using poc.trading.api.Repositpory.Interface;
using poc.trading.db.Connector;

namespace poc.trading.api.Repositpory
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlConnector _connector;

        public UserRepository(ISqlConnector connector)
        {
            _connector = connector;
        }

        public async Task<UserDetails> GetUserDetails(string userName)
        {
            return await _connector.GetSingleData<UserDetails>(DbConstants.GET_USER_DETAILS, new { p_username = userName });
        }

        public async Task<UserDetails> GetUserDetailsByEmailId(string emailId)
        {
            return await _connector.GetSingleData<UserDetails>(DbConstants.GET_USER_DETAILS_BY_EMAIL, new { p_emailId = emailId });
        }
    }
}