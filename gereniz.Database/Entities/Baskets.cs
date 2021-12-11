using System;
using System.Collections.Generic;

#nullable disable

namespace gereniz.Database.Entities
{
    public partial class Baskets
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Price { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public DateTime? UpdateDatetime { get; set; }

        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
    }
}
