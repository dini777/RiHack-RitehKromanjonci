namespace RiHack_RitehKromanjonci.Models;

public class Reply
{
    public int Id { get; set; }
    public int DiscussionPostId { get; set; } // Foreign key to link the reply to a discussion post
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime DatePosted { get; set; }

    public int PostId { get; set; } // Foreign key to the parent discussion post

    public DiscussionPost Post { get; set; }
}
