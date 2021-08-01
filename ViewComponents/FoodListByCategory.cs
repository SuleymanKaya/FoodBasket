using FoodBasket.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBasket.ViewComponents
{
    public class FoodListByCategory:ViewComponent
    {
        public IViewComponentResult Invoke(int id=1)
        {
            FoodsRepository foodRepository = new FoodsRepository();
            var foodList = foodRepository.TList(x=>x.CategoryId==id);
            return View(foodList);
        }
    }
}
