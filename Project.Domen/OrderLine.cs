using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domen
{
    public class OrderLine : Entity
    {
        public int OrderID { get; set; }
        public int AlbumID { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Album Album { get; set; }
    }

}
