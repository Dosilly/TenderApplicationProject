using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models.Modules
{
    public class AuthenticationModule
    {
        private readonly UserRepository _userRepository;

        public AuthenticationModule(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public LoginResponse Login(LoginRequest request)
        {
            var user = Authenticate(request);
            return BuildToken(user);
        }

        private LoginResponse BuildToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("keykeykeykeykeykeykeykeykeykey"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            int.TryParse("20", out var expirationTime);
            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                expires: DateTime.Now.AddMinutes(expirationTime),
                claims: new List<Claim>
                {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("UserName", user.Username)
                },
                signingCredentials: creds);

            var response = new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Username = user.Username,
                ExpirationDate = token.ValidTo,
                Role = null
            };

            return response;
        }

        private User Authenticate(LoginRequest request)
        {
            var potentialUser = _userRepository.SelectUserByUsername(request.Username);
            if (potentialUser == null)
                throw new UnauthorizedAccessException();

            if (request.Password == "123qwe")
                return potentialUser;

            throw new UnauthorizedAccessException();
        }
    }
}
