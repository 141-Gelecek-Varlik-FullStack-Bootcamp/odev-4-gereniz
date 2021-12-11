using System;
using System.Collections.Generic;

#nullable disable

namespace gereniz.Database.Entities
{
    public partial class Products
    {
        public Products()
        {
            Baskets = new HashSet<Baskets>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Idatetime { get; set; }
        public DateTime? Udatetime { get; set; }
        public int Iuser { get; set; }
        public int Uuser { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Users IuserNavigation { get; set; }
        public virtual ICollection<Baskets> Baskets { get; set; }
    }
}
