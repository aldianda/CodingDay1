using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ShopperCashier
{
    public class Login
    {
        public String username { get; set; }
        public String password { get; set; }
    }
    public class Employee
    {
        public String name { get; set; }
        public String address { get; set; }
        public String email { get; set; }
        public String placeBirth { get; set; }
        public String phoneNumber { get; set; }
        public String status { get; set; }
    }
}
