using System;
using System.Collections.Generic;
using System.Text;
using Politiker.Core.Enum;

namespace Politiker.Core.Entity
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public UserRole UserRole { get; set; }
    }
}
