using Microsoft.EntityFrameworkCore;
using UI_MVC.Models.Entities;

namespace UI_MVC.Models.DataBase
{
    public class AppDbContext :DbContext
    {
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-M2BLLND\\SQLEXPRESS;Database=Maktab-135-People-Test;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        }
    }
}
