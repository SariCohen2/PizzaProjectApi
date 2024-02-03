using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using modelsLib;
using interfacesLib;
using System.IdentityModel.Tokens.Jwt;
namespace Login.Controllers;
[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    IToken _token;
    public LoginController(IToken token)
    {
        _token=token;
    }
      [HttpPost]
        [Route("[action]")]
        public ActionResult<String> Login([FromBody] User user)
        {
            var token = _token.Login(user);
            // Console.WriteLine("user:"+user.Name+" Token: "+token);
            if(token == null)
                {
                    
                    throw new UnauthorizedAccessException("Unauthorized");
                }
            return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(token));
        }


}