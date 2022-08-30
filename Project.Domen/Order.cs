using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domen
{
    public class Order : Entity
    {
        public int UserID { get; set; }
        public string CreditCard { get; set; }

        public User User { get; set; }
    }
}
