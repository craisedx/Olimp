using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Olimp.Business.Interfaces;
using Olimp.Migrations;
using Olimp.Models;

namespace Olimp.Business.Services
{
    public class SeedDatabaseService : ISeedDatabaseService
    {
        private readonly ApplicationContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public SeedDatabaseService(ApplicationContext db, RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public async Task CreateStartAdmin()
        {
            if (_db.Users.Any(x => x.UserName == "Admin"))
            {
                Console.WriteLine("Админ уже есть");
            }
            else
            {
                var user = new User
                {
                    Email = "admin@olimp.com", UserName = "Admin",
                    UserImage = "https://img.icons8.com/material-outlined/200/000000/user--v1.png"
                };

                await _userManager.CreateAsync(user, "123Snp-");
                await _db.SaveChangesAsync();
                await _userManager.AddToRoleAsync(user, "Admin");
                Console.WriteLine("Админ создан");
            }
        }

        public void CreateStartOrderStatus()
        {
            if (_db.Status.Any(x => x.OrderStatus == "Ждёт обработки"))
            {
                Console.WriteLine("Статус ждёт обработки есть");
            }
            else
            {
                _db.Status.Add(new Status
                { 
                    OrderStatus = "Ждёт обработки"
                });
                _db.SaveChanges();
            }

            if (_db.Status.Any(x => x.OrderStatus == "Оформлен"))
            {
                Console.WriteLine("Статус оформлен есть");
            }
            else
            {
                _db.Status.Add(new Status
                {
                    OrderStatus = "Оформлен"
                });
                _db.SaveChanges();
                Console.WriteLine("Статус оформлен создан");
            }

            if (_db.Status.Any(x => x.OrderStatus == "Выдан"))
            {
                Console.WriteLine("Статус выдан есть");
            }
            else
            {
                _db.Status.Add(new Status
                {
                    OrderStatus = "Выдан"
                });
                _db.SaveChanges();
                Console.WriteLine("Статус выдан создан");
            }
        }

        public async Task CreateStartRole()
        {
            if (_db.Roles.Any(x => x.Name == "Admin"))
            {
                Console.WriteLine("Роль админа есть");
            }
            else
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                Console.WriteLine("Роль админа создана");
            }
        }
    }
}