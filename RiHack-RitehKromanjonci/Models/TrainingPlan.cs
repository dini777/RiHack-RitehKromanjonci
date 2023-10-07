using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiHack_RitehKromanjonci.Models;

public class TrainingPlan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int TimesOfTrainingPerWeek { get; set; }
    public int UsersGymExpInYears { get; set; }
    public string? LoseOrGainMass { get; set; }
    public List<string> CardioExercises { get; set; } = new List<string>();
    public List<string> GymExercises { get; set; } = new List<string>();
    public bool IsQuestionaireFilled { get; set; } = false;

}
