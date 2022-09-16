using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines_App.Model
{
    public class UsersModel
    {
        
        public String UserName { get; set; }
        public String FullName { get; set; }
        public String EmailId { get; set; }
        public long PhoneNo { get; set; }
        public String Gender { get; set; }
        public String Password { get; set; }
        public String ConfirmPassword { get; set; }

        public String DOB { get; set; }

        public UsersModel() : this(string.Empty,
                string.Empty,
                string.Empty,
                0,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty)
        {
        }

        public UsersModel(string userName,
                          string fullName,
                          string emailId,
                          long phoneNo,
                          string gender,
                          string password,
                          string confirmPassword,
                          string dob)
        {
            UserName = userName;
            FullName = fullName;
            EmailId = emailId;
            PhoneNo = phoneNo;
            Gender = gender;
            Password = password;
            ConfirmPassword = confirmPassword;
            DOB = dob;
        }
    }
}

