using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Politiker.Core.Engine
{
    public class JwtOptions
    {
        public string Key { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
        public int Expires { get; set; }

    }
}
