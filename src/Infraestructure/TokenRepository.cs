using Application.Repository;
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Infraestructure
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        private readonly OrganizationDbContext _context;
        public TokenRepository(OrganizationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public Tokens Authenticate(Domain.Authorization authorization)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserEmail == authorization.UserEmail
                                                     && x.UserPassword == authorization.UserPassword);
            if (user == null)
            {
                return null;
            }

            //We have Authenticated
            //Generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, authorization.UserEmail)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }

    }
}
