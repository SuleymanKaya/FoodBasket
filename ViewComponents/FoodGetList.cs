using FoodBasket.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBasket.ViewComponents
{
    public class FoodGetList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FoodsRepository foodRepository = new FoodsRepository();
            var foodList = foodRepository.TList();
            return View(foodList);
        }
    }
}
