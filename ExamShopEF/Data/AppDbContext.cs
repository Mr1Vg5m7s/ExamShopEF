using Microsoft.EntityFrameworkCore;
using ExamShopEF.Models;


public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Avtor> Avtors { get; set; }
    public DbSet<Ganr> Ganrs { get; set; }
    public DbSet<Publisher> Publishers { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
        "Data Source=ASUSROGSTRIX\\SQLEXPRESS;Initial Catalog=BookShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().Property(b => b.Id).ValueGeneratedNever();

        modelBuilder.Entity<Book>().Property(b => b.CostPrice).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Book>().Property(b => b.SellPrice).HasColumnType("decimal(18,2)");
    }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<WriteOff> WriteOffs { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public AppDbContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
        
    }
}