using System;

namespace Project.Domen
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreateBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
    }
}
