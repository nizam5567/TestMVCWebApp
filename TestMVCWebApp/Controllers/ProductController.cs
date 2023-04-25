using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestMVCWebApp.Data;
using TestMVCWebApp.Models;

namespace TestMVCWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext context;

        public ProductController(ProductDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var products = this.context.Products.Select(m => new ProductViewModel
            {
                Id = m.Id.ToString(),
                Name = m.Name,
                Description = m.Description,
                Price = m.Price.ToString(),
            });

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product prodObj)
        {
            if (ModelState.IsValid)
            {
                var cdate = DateTime.Now;

                this.context.Products.Add(prodObj);
                this.context.SaveChanges();
                

                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(prodObj);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var prodfromdb = context.Products.Find(id);

            if (prodfromdb == null)
            {
                return NotFound();
            }
            return View(prodfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int? id)
        {
            var deleterecord = context.Products.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            context.Products.Remove(deleterecord);
            context.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }
    }
}