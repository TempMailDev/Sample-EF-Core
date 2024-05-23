using Microsoft.EntityFrameworkCore;

namespace CodeWith_EFCore.EF_ORM
{
    public class EFC_DbContext : DbContext
    {
        public EFC_DbContext(DbContextOptions<EFC_DbContext> options): base(options)
        {
                
        }

        public DbSet<Book> books { get; set; }
    }
}
