using GenericRepositoryPattern.Entities;
using GenericRepositoryPattern.Models;
using GenericRepositoryPattern.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace GenericRepositoryPattern.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            var model = new ProductDetailModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CreateDate = product.CreateDate.ToShortDateString()
            };
            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateProductModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var Prodcut = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                CreateDate = DateTime.Now.Date
            };
            var res = _productService.Add(Prodcut);
            if (res)
                return Redirect("/Home/Index");
            return View(model);
        }

       
        public ActionResult Edit(int id)
        {
            var product = _productService.GetById(id);
            var model = new EditProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(EditProductModel model)
        {
            if(!ModelState.IsValid) return View(model);
            var product = new Product()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                CreateDate = DateTime.Now.Date
            };
            var res = _productService.Update(product);
            if (res)
                return Redirect("/Home/Index");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
           var product = _productService.GetById(id);   
            _productService.Delete(product);
            return Redirect("/Home/Index");
        }
    }
}
