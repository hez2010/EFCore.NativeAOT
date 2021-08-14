using Microsoft.EntityFrameworkCore;

namespace EFCore.NativeAOT
{
    public class Table1
    {
        public int Id { get; set; }
        public string Message { get; set; } = default!;
    }
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        
        public DbSet<Table1> Table1 { get; set; } = default!;
    }
}