using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace GrantManagementApi.BusinessModel
{
    public class AuthorizationModel
    {
        public static string DecodeJWT(string strJWT)
        {
            var stream = strJWT.Replace("Bearer",string.Empty).Trim();
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            var jti = tokenS.Claims.First(claim => claim.Type == "unique_name").Value;
            return jti;
        }
    }
}
