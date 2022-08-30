using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domen
{
    public class Like : Entity
    {
        public int UserID { get; set; }
        public int AlbumID { get; set; }
        public DateTime LikedAt { get; set; }

        public User User { get; set; }
        public Album Album { get; set; }
    }
}
