using Microsoft.EntityFrameworkCore;
using RiHack_RitehKromanjonci.Models;


namespace RiHack_RitehKromanjonci.Data;

public class AppDbContext : DbContext
{
    public DbSet<Test> Tests { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
}