using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FormsApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string searchString, string category)
        {
            List<Product> products = Repository.Products;

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(searchString.ToLower())).ToList();
                ViewBag.SearchString = searchString;
            }

            if (!string.IsNullOrEmpty(category) && category != "0")
            {
                int categoryId = int.Parse(category);
                products = products.Where(p => p.CategoryId == categoryId).ToList();
            }

            var model = new ProductViewModel
            {
                Products = products,
                Categories = Repository.Categories,
                SelectedCategory = category
            };

            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    var extension = Path.GetExtension(model.ImageFile.FileName);
                    var randomFileName = string.Format($"{Guid.NewGuid()}{extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    model.Image = randomFileName;
                }

                model.ProductId = Repository.Products.Count + 1;
                Repository.CreateProduct(model);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(model);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);

            if (entity == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product model)
        {
            if (id != model.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);
                if (entity == null)
                {
                    return NotFound();
                }


                if (model.ImageFile != null)
                {
                    var extension = Path.GetExtension(model.ImageFile.FileName);
                    var randomFileName = $"{Guid.NewGuid()}{extension}";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }

                    // Yeni dosya yolunu güncelle
                    entity.Image = randomFileName;
                }
                // Repository ile güncelleme işlemi
                Repository.EditProduct(entity);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);
            if (entity == null)
            {
                return NotFound();
            }

            Repository.DeleteProduct(entity);
            return RedirectToAction("Index");
        }


    }
}
