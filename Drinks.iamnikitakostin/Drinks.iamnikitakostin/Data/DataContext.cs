using Drinks.iamnikitakostin.Models;
using Microsoft.EntityFrameworkCore;

namespace Drinks.iamnikitakostin.Data;

internal class DataContext : DbContext
{
    public DataContext() { }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<DrinkDetail> FavoriteCocktails { get; set; }
    public DbSet<HistoryItem> History {  get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Drinks;Trusted_Connection=True;Encrypt=false;");
        }
    }

}
