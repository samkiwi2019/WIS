using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WIS.Data;

namespace WIS.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }

                // context.Users.AddRange(
                //     new User
                //     {
                //         FirstName = "Bin",
                //         LastName = "Liu",
                //         Email = "sam@sam.com",
                //         Nickname = "Sam",
                //         CreatedAt = DateTime.Parse("2021-03-18"),
                //     }
                // );
                // context.SaveChanges();
            }
        }
    }
}