using Microsoft.EntityFrameworkCore;

namespace CodeWith_EFCore.EF_ORM
{
    public class EFC_DbContext : DbContext
    {
        public EFC_DbContext(DbContextOptions<EFC_DbContext> options): base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { ID=1,Title="INR",Description="Indian INR" },
                new Currency() { ID=2,Title="Dollar", Description="USA Dollar"},
                new Currency() { ID=3, Title="Euro",Description="Euro"},
                new Currency() { ID=4,Title="Yen",Description= "Japanese yen" }
                
                );
            modelBuilder.Entity<Language>().HasData(
                new Language() { ID = 1, Title = "Hindi", Description = "Hin Hindi" },
                new Language() { ID = 2, Title = "English", Description = "en English" },
                new Language() { ID = 3, Title = "Telugu", Description = "Telugu" },
                new Language() { ID = 4, Title = "Nihongo", Description = "Japanese" }
                );
        }

        public DbSet<Book> books { get; set; }
        public DbSet<Language> languages { get; set; }
        public DbSet<BookPrice> bookPrices { get; set; }
        public DbSet<Currency> currency { get; set; }
    }
}
