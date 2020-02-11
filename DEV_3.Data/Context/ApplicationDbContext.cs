using Dev.Data.Entities;
using DEV_3.Data.Interface;
using DEV_3.MVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3.Data
{

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
         public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

        public DbSet<Person> Persons { get; set; }
    //    public DbSet<Person> people { get; set; }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

      // public System.Data.Entity.DbSet<DEV_3.Model._AccountViewModel> _AccountViewModel { get; set; }

        //public System.Data.Entity.DbSet<DEV_3.Model._AccountViewModel> _AccountViewModel { get; set; }
    }
}
