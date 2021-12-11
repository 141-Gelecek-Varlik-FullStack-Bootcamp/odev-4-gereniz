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

        //Ürünleri getirme
        public List<ProductViewModel> Get()
        {
            //Extensions kullanarak Product ları ProductViewModele çevirdik.
            List<ProductViewModel> list = Extensions.ChangeView(_mapper);
            return list;
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
