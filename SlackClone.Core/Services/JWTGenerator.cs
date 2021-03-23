using Microsoft.IdentityModel.Tokens;
using SlackClone.Contract.Dtos;
using SlackClone.Core.Models;
using SlackClone.Core.Settings;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SlackClone.Core.Services
{
    public class JWTGenerator :
        ITokenGenerator
    {
        private readonly IJWTSettings _settings;
        private readonly IDateRangeProvider _dateRangeProvider;

        public JWTGenerator(
            IJWTSettings settings,
            IDateRangeProvider dateRangeProvider)
        {
            _settings = settings;
            _dateRangeProvider = dateRangeProvider;
        }

        public TokenDto Generate(User user)
        {
            var secret = _settings.GetSecretAsBytes();
            var tokenDateRange = _dateRangeProvider.Provide();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = CreateClaimsIdentity(user),
                NotBefore = tokenDateRange.From.UtcDateTime,
                IssuedAt = tokenDateRange.From.UtcDateTime,
                Expires = tokenDateRange.To.UtcDateTime,
                SigningCredentials = CreateSigningCredentials(secret),
            };

            return new TokenDto
            {
                Type = "Bearer",
                Value = CreateToken(tokenDescriptor),
                ExpiresAt = tokenDateRange.To
            };
        }

        private static string CreateToken(
            SecurityTokenDescriptor tokenDescriptor)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        protected static ClaimsIdentity CreateClaimsIdentity(User user)
            => new ClaimsIdentity(CreateClaims(user));

        private static IEnumerable<Claim> CreateClaims(User user)
        {
            yield return new Claim("UserId", user.Id.ToString());
        }

        protected static SigningCredentials CreateSigningCredentials(
            byte[] key)
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
