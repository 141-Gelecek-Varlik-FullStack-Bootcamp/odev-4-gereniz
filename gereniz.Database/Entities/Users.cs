using System;
using System.Collections.Generic;

#nullable disable

namespace gereniz.Database.Entities
{
    public partial class Users
    {
        public Users()
        {
            Baskets = new HashSet<Baskets>();
            Categories = new HashSet<Categories>();
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime IdateTime { get; set; }
        public DateTime? UdateTime { get; set; }
        public int Iuser { get; set; }
        public int? Uuser { get; set; }

        public virtual ICollection<Baskets> Baskets { get; set; }
        public virtual ICollection<Categories> Categories { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
