using FoodBasket.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodBasket.Repositories
{
    public class GenericRepository<Table> where Table:class, new ()
    {
        Context cnt = new Context();

        public List<Table> TList()
        {
            return cnt.Set<Table>().ToList();
        }

        public List<Table> TList(string cn)
        {
            return cnt.Set<Table>().Include(cn).ToList();
        }

        public List<Table> TList(Expression<Func<Table, bool>> Filter)
        {
            return cnt.Set<Table>().Where(Filter).ToList();
        }

        public void TAdd(Table tb)
        {
            cnt.Set<Table>().Add(tb);
            cnt.SaveChanges();
        }

        public void TDelete(Table tb)
        {
            cnt.Set<Table>().Remove(tb);
            cnt.SaveChanges();
        }

        public void TUpdate(Table tb)
        {
            cnt.Set<Table>().Update(tb);
            cnt.SaveChanges();
        }

        public Table TGet(int id)
        {
            return cnt.Set<Table>().Find(id);
        }

        
    }
}
