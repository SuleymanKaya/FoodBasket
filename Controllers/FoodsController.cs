using FoodBasket.Data.Models;
using FoodBasket.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace FoodBasket.Controllers
{
    public class FoodsController : Controller
    {
        FoodsRepository foodsRepository = new FoodsRepository();
        Context cnt = new Context();
        public IActionResult Index(int page=1)
        {
            return View(foodsRepository.TList("Category").ToPagedList(page, 3));
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> categoryValues = (from x in cnt.Categories.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.ctv = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult FoodAdd(ImageAdd p)
        {
            Food f = new Food();
            if (p.ImageURL != null)
            {
                var extension = Path.GetExtension(p.ImageURL.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageURL.CopyTo(stream);
                f.ImageURL = newimagename;
            }
            f.Name = p.Name;
            f.Description = p.Description;
            f.Price = p.Price;
            f.Stock = p.Stock;
            f.CategoryId = p.CategoryId;
            foodsRepository.TAdd(f);
            return RedirectToAction("Index");
        }

        public IActionResult FoodDelete(int id)
        {
            foodsRepository.TDelete(new Food {Id=id});
            return RedirectToAction("Index");
        }

        public IActionResult FoodGet(int id)
        {
            var x = foodsRepository.TGet(id);
            List<SelectListItem> categoryValues = (from y in cnt.Categories.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = y.CategoryName,
                                                       Value = y.Id.ToString()
                                                   }).ToList();
            ViewBag.ctv = categoryValues;
            Food fd = new Food() 
            { 
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                ImageURL = x.ImageURL,
                Stock = x.Stock,
                CategoryId = x.CategoryId
            };
            return View(fd);
        }
        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var x = foodsRepository.TGet(p.Id);
            x.Name = p.Name;
            x.Description = p.Description;
            x.Price = p.Price;
            x.ImageURL = p.ImageURL;
            x.Stock = p.Stock;
            x.CategoryId = p.CategoryId;
            foodsRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

    }
}
