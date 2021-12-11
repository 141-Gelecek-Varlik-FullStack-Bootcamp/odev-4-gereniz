using System;
namespace gereniz.Model.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Stock { get; set; }
        public double Price { get; set; }
    }
}
