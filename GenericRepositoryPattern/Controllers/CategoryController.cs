using GenericRepositoryPattern.Entities;
using GenericRepositoryPattern.Models;
using GenericRepositoryPattern.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryPattern.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService  categoryService)
        {
           _categoryService=categoryService;
        }

        public ActionResult Details(int id)
        {
            var product = _categoryService.GetById(id);
            var model = new categoryDetailsModel
            {
                Id = product.Id,
                Name = product.Name,
                CreateDate = product.CreateDate.ToShortDateString()
            };
            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var Prodcut = new Category()
            {
                Name = model.Name,
                CreateDate = DateTime.Now.Date
            };
            var res = _categoryService.Add(Prodcut);
            if (res)
                return Redirect("/Home/Index");
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var product = _categoryService.GetById(id);
            var model = new EditCategoryModel
            {
                Id = product.Id,
                Name = product.Name,
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(EditCategoryModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var product = new Category()
            {
                Id = model.Id,
                Name = model.Name,
                CreateDate = DateTime.Now.Date
            };
            var res = _categoryService.Update(product);
            if (res)
                return Redirect("/Home/Index");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var product = _categoryService.GetById(id);
            _categoryService.Delete(product);
            return Redirect("/Home/Index");
        }
    }
}
