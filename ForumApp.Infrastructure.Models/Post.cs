namespace ForumApp.Infrastructure.Models
{
    using ForumApp.Common;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    [Comment("Post table")]
    public class Post
    {
        [Comment("Post id")]
        [Key]
        public int Id { get; init; }

        [Comment("Post title")]
        [Required]
        [MaxLength(GlobalConstants.PostTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Comment("Post content")]
        [Required]
        [MaxLength(GlobalConstants.PostContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}
