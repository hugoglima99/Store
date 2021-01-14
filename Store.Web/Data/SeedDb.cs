using Microsoft.AspNetCore.Identity;
using Store.Web.Data.Entities;
using Store.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("hugoglima1999@gmail.com");
            if(user == null)
            {
                user = new User
                {
                    FirstName = "Hugo",
                    LastName = "Lima",
                    Email = "hugoglima1999@gmail.com",
                    UserName = "hugoglima1999@gmail.com",
                    PhoneNumber = "912345678"
                };

                var result = await this.userHelper.AddUserAsync (user, "123456");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!this.context.Products.Any())
            {
                this.AddProduct("Equipamento Oficial SCP", user);
                this.AddProduct("Equipamento Oficiais", user);
                this.AddProduct("Leão pequeno", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(200),
                IsAvailable = true,
                Stock = this.random.Next(100),
                User = user
            }) ;
        }
    }
}
