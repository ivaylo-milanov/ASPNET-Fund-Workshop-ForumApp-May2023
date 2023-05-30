namespace ForumApp.Core.ViewModels.Post
{
    using ForumApp.Common;
    using System.ComponentModel.DataAnnotations;

    public class PostFormView
    {
        [MinLength(GlobalConstants.PostTitleMinLength)]
        [MaxLength(GlobalConstants.PostTitleMaxLength)]
        public string Title { get; set; } = null!;

        [MinLength(GlobalConstants.PostContentMinLength)]
        [MaxLength(GlobalConstants.PostContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}
