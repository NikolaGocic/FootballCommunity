using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    class AccountViewModel
    {
    }

    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Register
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class Response
    {
        public string Status { set; get; }
        public string Message { set; get; }
    }
}
