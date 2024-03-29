﻿using CarpoolApi.Api.Hashing;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarpoolApi.Api.Authentication
{
    public class TokenAuthenticationService : IAuthenticateService
    {
        private readonly IUserManagementService userManagementService;
        private readonly TokenManagement tokenManagement;
        private IHashingService hashingService;

        public TokenAuthenticationService(
            IUserManagementService userManagementService, 
            IOptions<TokenManagement> tokenManagement, 
            IHashingService hashingService)
        {
            this.userManagementService = userManagementService;
            this.tokenManagement = tokenManagement.Value;
            this.hashingService = hashingService;
        }
        public object GetToken(AuthenticationRequest request)
        {
            if (!userManagementService.IsValidUser(request.Username, request.Password))
                return null;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenManagement.Secret));

            var jwt = new JwtSecurityToken(
                issuer: tokenManagement.Issuer,
                audience: tokenManagement.Audience,
                claims: new[] { new Claim(ClaimTypes.Name, request.Username) },
                expires: DateTime.UtcNow.AddMinutes(tokenManagement.AccessExpiration),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new
            {
                token = new JwtSecurityTokenHandler().WriteToken(jwt),
                expiration = jwt.ValidTo.ToString(),
            };
        }
    }
}
