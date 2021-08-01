using FoodBasket.Data.Models;
using FoodBasket.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBasket.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesRepository categoriesRepository = new CategoriesRepository();
        //[Authorize]
        public IActionResult Index(string cn)
        {
            if (!string.IsNullOrEmpty(cn))
            {
                return View(categoriesRepository.TList(x=>x.CategoryName==cn));
            }
            return View(categoriesRepository.TList());
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }

            categoriesRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CategoryGet(int id)
        {
            var x = categoriesRepository.TGet(id);
            Category ct = new Category() 
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,
                Status = x.Status
            };
            return View(ct);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            var x = categoriesRepository.TGet(p.Id);
            x.CategoryName = p.CategoryName;
            x.CategoryDescription = p.CategoryDescription;
            x.Status = true;
            categoriesRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryDelete(int id)
        {
            var x = categoriesRepository.TGet(id);
            x.Status = false;
            categoriesRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
