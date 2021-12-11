using System;
using System.Collections.Generic;
using gereniz.Database.Entities;
using gereniz.Model;
using gereniz.Model.Product;

namespace gereniz.Service.Product
{
    public interface IProductService
    {
        public List<ProductViewModel> Get();
        public General<ProductViewModel> Insert(ProductViewModel productViewModel);
        public General<ProductViewModel> Update(int id,ProductViewModel productViewModel);
        public bool Remove(int id);
    }
}
