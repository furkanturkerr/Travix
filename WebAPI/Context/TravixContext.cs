using Microsoft.EntityFrameworkCore;
using WebAPI.Entites;

namespace WebAPI.Context;

public class TravixContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1995;Database=Travix ;User Id=sa;Password=Furkan12*;TrustServerCertificate=True;");
    }
    
    public DbSet<HotelList> HotelLists { get; set; }
}