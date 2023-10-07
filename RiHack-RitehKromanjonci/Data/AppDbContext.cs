using Microsoft.EntityFrameworkCore;
using RiHack_RitehKromanjonci.Models;
using static System.Net.Mime.MediaTypeNames;

namespace RiHack_RitehKromanjonci.Data;

public class AppDbContext : DbContext
{
    public DbSet<DailyGoal> DailyGoals { get; set; }
    public DbSet<EatingPlan> EatingPlans { get; set; }
    public DbSet<TrainingPlan> TrainingPlans { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<YourProgress> YourProgresses { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
}