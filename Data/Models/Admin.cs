using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBasket.Data.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(20)]
        public string Password { get; set; }
        [StringLength(10)]
        public string Role { get; set; }
    }
}
