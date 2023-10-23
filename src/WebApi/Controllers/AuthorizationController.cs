using Application.Repository;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAuthorization = Application.Services.Interfaces;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly ServiceAuthorization.IAuthorizationService _authorizationService;
        private readonly ITokenRepository _tokenRepository;
        public AuthorizationController(ServiceAuthorization.IAuthorizationService authorizationService, ITokenRepository tokenRepository)
        {
            _authorizationService = authorizationService;
            _tokenRepository = tokenRepository;
        }

    
        [HttpGet("Login")]
        public IActionResult Login([FromQuery] Authorization authorization)
        {
           var reponse = _authorizationService.Login(authorization);
            return Ok(reponse);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromQuery] Authorization usersdata)
        {
            var token = _tokenRepository.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

    }
}
