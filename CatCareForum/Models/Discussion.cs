namespace CatCareForum.Models
{
    public class Discussion
    {
        //Primary key
        public int DiscussionId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? ImageFileName { get; set; } //Nullable?
        public DateTime CreateDate { get; set; } = DateTime.Now;

        //Navigation property
        public List<Comment>? Comments { get; set; } //Nav properties should be nullable

    }
}
