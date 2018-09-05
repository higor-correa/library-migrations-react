using Library.Bll.Settings.Interfaces;
using Library.Bll.User.Token.Interfaces;
using Library.Domain.DTO.User.Login.Token;
using Library.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.Bll.User.Token
{
    public class TokenManager : ITokenManager
    {
        private readonly IAppSettings _appSettings;

        public TokenManager(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public TokenResponseDTO Generate(UserEntity user)
        {
            var key = Encoding.UTF8.GetBytes(_appSettings.PrivateKey);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddSeconds(_appSettings.TokenExpiresIn),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenResponseDTO
            {
                Expires = tokenDescriptor.Expires.Value,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
