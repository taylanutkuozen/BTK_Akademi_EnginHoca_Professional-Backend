﻿using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//21.Adım
namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private  IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal; //Dependency Injection
        }
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }
        public List<Product> GetAllProducts()
        {
            return _productDal.GetList();
        }
        public Product GetByID(int id)
        {
            return _productDal.Get(p=>p.ProductId==id);
        }
    }
}