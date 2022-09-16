using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines_App.Model
{
    public class AdminModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public AdminModel() : this(string.Empty,
                string.Empty)
        {
        }

        public AdminModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
