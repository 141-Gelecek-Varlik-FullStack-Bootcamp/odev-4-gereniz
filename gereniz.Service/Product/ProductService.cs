using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using gereniz.Core.Extensions;
using gereniz.Database.Entities;
using gereniz.Database.Entities.DomainContext;
using gereniz.Model;
using gereniz.Model.Product;

namespace gereniz.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }


        //Ürün Filtreleme
        //api/Product/Filter?filterType=Name&filter=a
        public General<ProductViewModel> Filtering(string filterType,string filter)
        {
            var result = new General<ProductViewModel>() { IsSuccess = false };
            using (var srv = new DomainContext())
            {
                var products = srv.Products.ToList();
                if (filterType == "Name")
                {
                    products = (srv.Products.Where(p => p.Name.Contains(filter))).ToList();

                }
                else if (filterType == "CategoryId")
                {
                    products = (srv.Products.Where(p => p.CategoryId == Convert.ToInt32(filter))).ToList();

                }
                else if (filterType == "Price")
                {
                    products = (srv.Products.Where(p => p.Price == Convert.ToInt32(filter))).ToList();

                }
                else if (filterType == "Stock")
                {
                    products = (srv.Products.Where(p => p.Stock == Convert.ToDouble(filter))).ToList();

                }
               var model = _mapper.Map<List<ProductViewModel>>(products);
                result.IsSuccess = true;
                result.List = model;
                return result;
            }
        }

        //Ürünleri getirme
        public General<ProductViewModel> Get()
        {
            var result = new General<ProductViewModel>() { IsSuccess = false };
            using (var srv = new DomainContext())
            {
                var products = srv.Products.ToList();
                var model = _mapper.Map<List<ProductViewModel>>(products);
                result.IsSuccess = true;
                result.List = model;
                return result;
            }
        }

        //Ürün ekleme
        public General<ProductViewModel> Insert(ProductViewModel productViewModel)
        {
            var result = new General<ProductViewModel>() { IsSuccess = false };
            var model = _mapper.Map<Products>(productViewModel);

            using (var srv = new DomainContext())
            {
                model.Idatetime = DateTime.Now;
                model.Iuser = 2;  //Ekleyen kişiyi sabit belirledik
                srv.Products.Add(model);

                srv.SaveChanges();

                result.IsSuccess = true;
                result.Entity = _mapper.Map<ProductViewModel>(model);
            }
            return result;
        }

        //Ürün Sayfalama
        public General<ProductViewModel> Paging(int pageCount, int productCount) 
        {

            var result = new General<ProductViewModel>() { IsSuccess = false };
            int pageSumCount;
            int skipSize = (pageCount * productCount) - productCount;
            using (var srv = new DomainContext())
            {
                var productsCount = srv.Products.Count(); 
                pageSumCount = productsCount / productCount; 
                if (productsCount % productCount != 0)
                {
                    pageSumCount++;  
                }

                var products = srv.Products.Skip(skipSize).Take(productCount);
                var model = _mapper.Map<List<ProductViewModel>>(products);
                result.IsSuccess = true;
                result.List = model;
                return result;
            }
        }

        //Ürün silme
        public bool Remove(int id)
        {
            bool result = false;
            using (var srv = new DomainContext())
            {
                Products product = srv.Products.FirstOrDefault(p => p.Id == id);

                product.IsDeleted = true;  //Tamamen silmek yerine Kullanıcıya göstermiyoruz
                product.IsActive = false;  //Pasif hale getirildi

                srv.Products.Update(product);
                srv.SaveChanges();

                result = true;
            }
            return result;
        }
        //Ürün Sıralama
        ///api/Product/Sort?sortType=Name
        public General<ProductViewModel> Sorting(string sortType)
        {
            var result = new General<ProductViewModel>() { IsSuccess = false};
      
            using (var srv = new DomainContext())
            {
                var products = srv.Products.Where(p => p.Id >0).ToList();
                if (sortType == "Name")
                {
                    products = (srv.Products.OrderBy(p => p.Name)).ToList();

                }
                else if (sortType == "CategoryId")
                {
                     products = (srv.Products.OrderBy(p => p.CategoryId)).ToList();

                }
                else if (sortType == "Price")
                {
                     products = (srv.Products.OrderBy(p => p.Price)).ToList();

                }
                else if (sortType == "Stock")
                {
                     products = (srv.Products.OrderBy(p => p.Stock)).ToList();

                }
                var model = _mapper.Map<List<ProductViewModel>>(products);
                result.IsSuccess = true;
                result.List = model;
                return result;
            }
        }

        //Ürün güncelleme
        public General<ProductViewModel> Update(int id,ProductViewModel productViewModel)
        {
            var result = new General<ProductViewModel>() { IsSuccess = false };
            var model = _mapper.Map<Products>(productViewModel);

            using (var srv = new DomainContext())
            {
                Products product = srv.Products.FirstOrDefault(p => p.Id == id);

                //Gelen değerler varsa değeri yoksa veri tabanındaki değeri almasını sağladık
                product.Name = model.Name == null ? product.Name = product.Name : product.Name = model.Name;
                product.CategoryId = model.CategoryId == 0 ? product.CategoryId = product.CategoryId : product.CategoryId = model.CategoryId;
                product.Stock = model.Stock == 0 ? product.Stock = product.Stock : product.Stock = model.Stock;
                product.Price = model.Price == 0 ? product.Price = product.Price : product.Price = model.Price;
                product.Udatetime = DateTime.Now;
                product.Iuser = 2;

                srv.Products.Update(product);
                srv.SaveChanges();

                result.IsSuccess = true;
                result.Entity = _mapper.Map<ProductViewModel>(product);
            }
            return result;
        }
    }
}
