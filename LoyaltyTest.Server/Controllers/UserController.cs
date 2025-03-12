using loyaltytest.Domain.dtos.Request;
using loyaltytest.Infrastructure.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoyaltyTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        
        public UserController(IUserRepository userRepository) { 
            _userRepository = userRepository;
        }

        [HttpPost("Login")]
        public ApiResult Login([FromBody] UserRequest request)
        {
            ApiResult result = new ApiResult() { Status = 200};

            try
            {
                var user = _userRepository.Login(request);
                if (user == null)
                {
                    result.Message = "Usuario incorrecto";
                    result.Status = 500;
                } else
                    result.Data = user;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = 500;
            }

            return result;
        }
    }
}
