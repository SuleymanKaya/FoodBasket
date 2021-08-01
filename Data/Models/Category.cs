using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBasket.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name cannot be empty!")]
        [StringLength(21, ErrorMessage = "Please enter between 4-21 characters!", MinimumLength = 4)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
        public bool Status { get; set; }
    }
}
