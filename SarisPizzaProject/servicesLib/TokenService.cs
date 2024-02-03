using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using modelsLib;
using interfacesLib;

namespace servicesLib;

    public  class TokenService:IToken
    {
      private  IWorkers 
      _workerService;
        public TokenService(IWorkers workerService)
        {
            _workerService = workerService;

        }
        private static SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ"));
        private static string issuer = "https://SarisPizzaProject";
        public  SecurityToken GetToken(List<Claim> claims) =>
            new JwtSecurityToken(
                issuer,
                issuer,
                claims,
                expires: DateTime.Now.AddDays(30.0),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

        public static TokenValidationParameters GetTokenValidationParameters() =>
            new TokenValidationParameters
            {
                ValidIssuer = issuer,
                ValidAudience = issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ")),
                ClockSkew = TimeSpan.Zero // remove delay of token when expire
            };
 public SecurityToken Login(User user)
        {
            var workers = _workerService.Get();
            var existWorker = workers.FirstOrDefault(Worker => ((Worker.Name.Equals(user.Name))&&(Worker.Password).Equals(user.Password)));
        
            if (existWorker == null)
                return null;
    //   Console.WriteLine("\n\ni arrived\n\n\n");
            List<Claim> Claims = new List<Claim>
            {
                new Claim("UserType" ,existWorker.Role.ToString()),
                new Claim("userId", existWorker.Id.ToString())
            };
            var token = this.GetToken(Claims);
            return token;
        }
    }
