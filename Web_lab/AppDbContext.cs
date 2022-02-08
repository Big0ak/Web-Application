using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_lab.Models;

namespace Web_lab
{
    public class AppDbContext : DbContext
    { 
        public AppDbContext(DbContextOptions options) :base (options)
        {
            Database.EnsureCreated();  // создаем бд с новой схемой
        }

        // экземпляры функций (связь таблицы c объектами)
        public DbSet<Order> CurrentOrder { get; set; }
        public DbSet<User> Users { get; set;  }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Website;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = new Guid("3b62472e-4f66-49fa-a20f-e7685b9565d8"),
                Name = "Вася",
                Surname = "Белов",
                NunberOrders = 0,
                Type = TypeUser.customer
            }) ;

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = new Guid("6f72f4dd-2243-4851-af60-dc393a203e27"),
                Name = "Петя",
                Surname = "Петров",
                NunberOrders = 1,
                Type = TypeUser.executor
            });

            modelBuilder.Entity<Order>().HasData(
            new Order
            {
                Id = Guid.NewGuid(),
                Topic = "Сочинение",
                Status = StatusOrder.open,
                Price = 500,
                IdCustomer= new Guid("3b62472e-4f66-49fa-a20f-e7685b9565d8"),
                IdExecuter = new Guid()
            }) ;
        }
    }
}
