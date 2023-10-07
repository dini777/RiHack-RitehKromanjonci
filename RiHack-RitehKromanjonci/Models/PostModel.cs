using System.ComponentModel.DataAnnotations.Schema;

namespace RiHack_RitehKromanjonci.Models;

public class PostModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public DateTime EventTime { get; set; } = DateTime.UtcNow;
    public string PostDescription { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
}
