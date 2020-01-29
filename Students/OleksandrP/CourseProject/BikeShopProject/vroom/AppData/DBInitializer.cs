using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vroom.AppDbContext;
using vroom.Helpers;
using vroom.Models;

namespace vroom.AppData
{
    public class DBInitializer : IDBInitializer
    {
        private readonly VroomDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DBInitializer(VroomDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void Initialize()
        {
            //Add pending migration if exists
            if (_context.Database.GetPendingMigrations().Count() > 0)
            {
                _context.Database.Migrate();
            }

            //Exit if role already exists
            if (_context.Roles.Any(r => r.Name == Helpers.Static.Admin)) return;
            //Create Admin Role
            _roleManager.CreateAsync(new IdentityRole(Static.Admin)).GetAwaiter().GetResult();
            //Create User
            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "Admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
            }, "Admin@123").GetAwaiter().GetResult();

            //Assign role to Admin user
            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync("Admin"), Static.Admin);
        }
    }
}
