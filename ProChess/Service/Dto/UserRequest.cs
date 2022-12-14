using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dto
{
    public class UserRequest
    {
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string? Country { get; set; }
        public string? Biography { get; set; }
        public int ELO { get; set; }
    }
}
