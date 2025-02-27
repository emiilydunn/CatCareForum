namespace CatCareForum.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;

        //Foreign key
        public int DiscussionId { get; set; }

        //Navigation property 
        public Discussion? Discussion { get; set; } //Nav properties should be nullable
    }
}
