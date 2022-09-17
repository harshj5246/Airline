//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Customer_WPF.Model
//{

//    public class CustomerModel
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public double Creadit_limit { get; set; }
//        public string Com_Address { get; set; }
//        public string Billing_Address { get; set; }


//        public CustomerModel() : this(0, string.Empty,0, string.Empty, string.Empty)
//        {

//        }

//        public CustomerModel(int id, string name, double creadit_Limit, string com_Address, string billing_Address)
//        {
//            Id = id;
//            Name = name;
//            Creadit_limit = creadit_Limit;
//            Com_Address = com_Address;
//            Billing_Address = billing_Address;
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_WPF.Model
{

    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Creadit_limit { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string supliyer_type { get; set; }





        public CustomerModel() : this(0, string.Empty, 0, string.Empty, string.Empty,string.Empty)
        {

        }

        public CustomerModel(int id, string name, double creadit_limit, string address, string email, string supliyer_type)
        {
            Id = id;
            Name = name;
            Creadit_limit = creadit_limit;
            Address = address;
            Email = email;
            this.supliyer_type = supliyer_type;
        }
    }
}
