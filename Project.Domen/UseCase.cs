using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domen
{
    public class UseCase : Entity
    {
        public int UserID { get;set;}
        public int UseCaseID { get; set; }

        public User User { get; set; }
        
    }
}
