using Microsoft.AspNetCore.Mvc;
using poc.trading.api.Entities;
using poc.trading.api.Entities.Dto;
using poc.trading.api.Services.Interfaces;

namespace poc.trading.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController 
    {
        private IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            return await _service.Login(request);
        }


        [HttpPost("token")]
        public async Task<LoginResponse> token(LoginRequest request)
        {
            return await _service.Login(request);
        }


        [HttpGet("{userName}")]
        public async Task<UserDetails> Login(string userName)
        {
            return await _service.GetUserDetails(userName);
        }
    }
}
