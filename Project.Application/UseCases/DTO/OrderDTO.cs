using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.DTO
{
    public class OrderDTO
    {
        public string CreditCardNumber { get; set; }
        public IEnumerable<int> AlbumIDs { get; set; }

    }
}
