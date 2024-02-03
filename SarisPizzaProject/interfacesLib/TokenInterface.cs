using modelsLib;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace interfacesLib;
public interface IToken
{

     public  SecurityToken GetToken(List<Claim> claims);
    // public TokenValidationParameters GetTokenValidationParameters();
    public SecurityToken Login(User user);

  
}