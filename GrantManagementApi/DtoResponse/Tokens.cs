using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrantManagementApi.DtoResponse
{
    public class Tokens: MasterResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
