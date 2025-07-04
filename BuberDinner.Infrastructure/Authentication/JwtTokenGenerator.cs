using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Application.Common.InterFaces.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Microsoft.Extensions.Configuration;
using BuberDinner.Application.Common.InterFaces.Services;
using Microsoft.Extensions.Options;
using BuberDinner.Domain.Entites;

namespace BuberDinner.Infrastructure.Authentication
{
 public class JwtTokenGenerator : IJwtTokenGenerator
 {
  private readonly IDateTimeProvider _dateTimeProvider;  
  private readonly JwtSettings _jwtSettings;
     
        public JwtTokenGenerator( IOptions<JwtSettings> options , IDateTimeProvider dateTimeProvider)
        {
            _jwtSettings = options.Value;
           _dateTimeProvider = dateTimeProvider;
           
        }
        public string GenerateToken(User user)
        {
            var sigingCredentials = new SigningCredentials(
                 new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret))
            ,    SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
          new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
          new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
          new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
           };
            var Securitytoken = new JwtSecurityToken(
                 issuer: _jwtSettings.Issuer,
                 audience: _jwtSettings.Audience,
                 claims: claims,
                 expires: _dateTimeProvider.UtcNow.AddMinutes( _jwtSettings.ExpiryMinutes),
                 signingCredentials: sigingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(Securitytoken);
        }
 }
}