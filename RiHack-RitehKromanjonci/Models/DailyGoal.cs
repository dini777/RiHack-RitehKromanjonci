using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiHack_RitehKromanjonci.Models;

public class DailyGoal
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int TrainingPlanId { get; set; }
    public int EatingPlanId { get; set; }
    public TrainingPlan? TrainingPlans { get; set; }
    public EatingPlan? EatingPlans { get; set; }
}
