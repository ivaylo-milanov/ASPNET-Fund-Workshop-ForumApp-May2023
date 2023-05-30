namespace ForumApp.Core.Services.Contracts
{
    using ForumApp.Core.ViewModels.Post;
    using ForumApp.Infrastructure.Models;

    public interface IPostService
    {
        Task<IList<PostViewModel>> GetAllPosts();

        Task AddPostAsync(PostFormView model);

        Task DeletePostAsync(int id);

        Task<Post> GetPostByIdAsync(int id);

        Task EditPostAsync(int id, PostFormView model);
    }
}
