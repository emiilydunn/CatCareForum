using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatCareForum.Models
{
    public class Discussion
    {
        //Primary key
        public int DiscussionId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? ImageFileName { get; set; } //Nullable?

        //Property for file upload, not mapped in EF
        //NotMapped - can be used to exclude a property from the model/db
        [NotMapped]
        [Display(Name = "Image")]
        public IFormFile? ImageFile { get; set; } //Nullable


        public DateTime CreateDate { get; set; } = DateTime.Now;

        //Navigation property
        public List<Comment>? Comments { get; set; } //Nav properties should be nullable

    }
}
