using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFramework.Northwind.Entities.Concrete;
/*
43.Adım 
*/
namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        } //MVC parametresiz constructor blokları çalışır. Burası parametreli olduğu için hata almaktayız.Ancak ninject kullanarak inject çözebileceğiz.
        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products=_productService.GetAllProducts()
            };
            return View(model);//View'a bir model gönderirken _productService.GetAllProducts yerine böyle degisken ile gondermek daha dogru olacaktir. Cunku yeni bir veri gondermek istenildiginde ProductListViewModel tanımlanıp gonderilmesi daha dogru olacaktir.
        }
        public string Added()
        {
            Product product = new Product { CategoryId = 1, ProductName = "GSM222", QuantityPerUnit = "1", UnitPrice = 25 };
            _productService.Add
                (
                product
                );
            return "Added";
        }
    }
}