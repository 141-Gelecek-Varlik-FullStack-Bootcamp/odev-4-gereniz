using System;
using System.Collections.Generic;

#nullable disable

namespace gereniz.Database.Entities
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime Idatetime { get; set; }
        public DateTime? Udatetime { get; set; }
        public int Iuser { get; set; }
        public int? Uuser { get; set; }

        public virtual Users IuserNavigation { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
