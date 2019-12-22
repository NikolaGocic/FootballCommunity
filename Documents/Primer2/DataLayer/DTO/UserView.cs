using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.DTO
{
    public class UserView
    {
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public UserView()
        {

        }

        public UserView(User user)
        {
            this.user_id = user.user_id;
            this.first_name = user.first_name;
            this.last_name = user.last_name;
            this.password = user.password;
            this.email = user.email;
        }

    }
}
