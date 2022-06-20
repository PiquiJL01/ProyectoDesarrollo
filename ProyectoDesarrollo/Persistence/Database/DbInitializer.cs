using ProyectoDesarrollo.Models;
using System;
using System.Linq;

namespace ProyectoDesarrollo.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataBaseContext context)
        {
            context.Database.EnsureCreated();
            /*
            // Look for any class instance in the database.
            if (context.Classes.Any())
            {
                return;   // DB has been seeded
            }

            var classes = new Class[]
            {
            new Class{Attributte1="Example1",Attributte2="Example1",DateAttribute=DateTime.Parse("2005-09-01")},
            new Class{Attributte1="Example1",Attributte2="Example1",DateAttribute=DateTime.Parse("2005-09-01")},
            new Class{Attributte1="Example1",Attributte2="Example1",DateAttribute=DateTime.Parse("2005-09-01")},
            };
            foreach (Class c in classes)
            {
                context.Classes.Add(c);
            }
            context.SaveChanges();
            */
        }
    }
}