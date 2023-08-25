using AutoMapper;
using Infrastructure.Security.JWT;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using PROJE.Business.Interfaces;
using PROJE.Model.Dtos.AdminPanelUser;

namespace PROJE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
            private readonly IAdminPanelUserBs _adminPanelUserBs;
            private readonly IConfiguration _configuration;
            public AuthController(IAdminPanelUserBs adminPanelUserBs, IConfiguration configuration)
            {
                _adminPanelUserBs = adminPanelUserBs;
                _configuration = configuration;
            }



        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AccessToken>))]
        [HttpGet("gettoken")]
        public async Task<ActionResult> GetToken()
        {
            var accessToken = new JwtGenerator(_configuration).GenerateAccessToken();
            var response = new ApiResponse<AccessToken>();
            response.Data = accessToken;
            response.StatusCode = 200;

            return SendResponse(response);

        }    



        #region
        [Produces("application/json", "text/plain")]
            [ProducesResponseType(200, Type = typeof(ApiResponse<List<AdminPanelUserDto>>))]
            [ProducesResponseType(404, Type = typeof(string))]
            #endregion
            [HttpGet("login")]
            public async Task<ActionResult> LogIn([FromQuery] string userName, string password)
            {
                var response = await _adminPanelUserBs.LogInAsync(userName, password);
                return SendResponse(response);
            }
        
    }
}
