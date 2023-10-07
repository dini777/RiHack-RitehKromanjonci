using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiHack_RitehKromanjonci.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int TrainingPlanId { get; set; }
    public int EatingPlanId { get; set; }
    public int DailyGoalId { get; set; }
    public int YourProgressId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public TrainingPlan? TrainingPlans { get; set; }
    public EatingPlan? EatingPlans { get; set; }
    public DailyGoal? DailyGoals { get; set; }
    public YourProgress? Progress { get; set; }
}
