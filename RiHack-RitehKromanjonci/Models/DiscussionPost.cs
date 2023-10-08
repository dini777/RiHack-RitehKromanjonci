namespace RiHack_RitehKromanjonci.Models;

public class DiscussionPost
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime DatePosted { get; set; }
    //public User User { get; set; }

    public List<Reply> Replies { get; set; } = new List<Reply>();
}
