using FoodBasket.Data;
using FoodBasket.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBasket.Controllers
{
    public class ChartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }

        public List<Chart> ProList()
        {
            List<Chart> ct = new List<Chart>();
            ct.Add(new Chart()
            {
                ProName = "Computer",
                Stock = 215
            });

            ct.Add(new Chart()
            {
                ProName = "Mobile Phone",
                Stock = 200
            });

            ct.Add(new Chart()
            {
                ProName = "Mouse",
                Stock = 320
            });

            return ct;
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult VisualizeFoodResult()
        {
            return Json(FoodList());
        }

        public List<Chart> FoodList()
        {
            List<Chart> ct2 = new List<Chart>();
            using (var c = new Context())
            {
                ct2 = c.Foods.Select(x => new Chart
                {
                    ProName = x.Name,
                    Stock = x.Stock
                }).ToList();
            }
            return ct2;
        }

        public IActionResult Statistics()
        {
            Context c = new Context();

            var value1 = c.Foods.Count();
            ViewBag.d1 = value1;

            var value2 = c.Categories.Count();
            ViewBag.d2 = value2;

            var value3 = c.Foods.Where(x=>x.CategoryId==1).Count();
            ViewBag.d3 = value3;

            var ctid = c.Categories.Where(x => x.CategoryName == "Vegetable").Select(y => y.Id).FirstOrDefault();
            var value4 = c.Foods.Where(x => x.CategoryId == ctid).Count();
            ViewBag.d4 = value4;

            var value5 = c.Foods.Sum(x => x.Stock);
            ViewBag.d5 = value5;

            var ctid2 = c.Categories.Where(x => x.CategoryName == "Grain").Select(y => y.Id).FirstOrDefault();
            var value6 = c.Foods.Where(x => x.CategoryId == ctid2).Count();
            ViewBag.d6 = value6;

            var value7 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d7 = value7;

            var value8 = c.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d8 = value8;

            var value9 = c.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d9 = value9;

            var ctid3 = c.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.Id).FirstOrDefault();
            var value10 = c.Foods.Where(z => z.CategoryId == ctid3).Sum(k=>k.Stock);
            ViewBag.d10 = value10;

            var ctid4 = c.Categories.Where(x => x.CategoryName == "Vegetable").Select(y => y.Id).FirstOrDefault();
            var value11 = c.Foods.Where(z => z.CategoryId == ctid4).Sum(k => k.Stock);
            ViewBag.d11 = value11;

            var value12 = c.Foods.OrderByDescending(x => x.Price).Select(y => y.Name).FirstOrDefault();
            ViewBag.d12 = value12;

            return View();
        }
    }
}
