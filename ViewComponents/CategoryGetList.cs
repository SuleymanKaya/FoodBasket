using FoodBasket.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBasket.ViewComponents
{
    public class CategoryGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoriesRepository categoryRepository = new CategoriesRepository();
            var categoryList = categoryRepository.TList();
            return View(categoryList);
        }

    }
}
