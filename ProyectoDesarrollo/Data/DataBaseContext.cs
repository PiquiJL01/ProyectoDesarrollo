using ProyectoDesarrollo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ProyectoDesarrollo.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        //public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Class>().ToTable("TableName");
        }
    }
}