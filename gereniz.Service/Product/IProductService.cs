using System;
using System.Collections.Generic;
using gereniz.Database.Entities;
using gereniz.Model;
using gereniz.Model.Product;

namespace gereniz.Service.Product
{
    public interface IProductService
    {
        public General<ProductViewModel> Get();
        public General<ProductViewModel> Insert(ProductViewModel productViewModel);
        public General<ProductViewModel> Update(int id,ProductViewModel productViewModel);
        public bool Remove(int id);
        public General<ProductViewModel> Sorting(string sortType);
        public General<ProductViewModel> Filtering(string filterType,string filter);
        public General<ProductViewModel> Paging(int pageCount, int productCount);

    }
}
