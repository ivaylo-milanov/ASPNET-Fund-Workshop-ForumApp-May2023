namespace ForumApp.Core.Services
{
    using ForumApp.Core.Services.Contracts;
    using ForumApp.Core.ViewModels.Post;
    using ForumApp.Infrastructure.Common;
    using ForumApp.Infrastructure.Models;
    using Microsoft.EntityFrameworkCore;

    public class PostService : IPostService
    {
        private readonly IRepository repository;

        public PostService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddPostAsync(PostFormView model)
        {
            Post post = new Post
            {
                Title = model.Title,
                Content = model.Content
            };

            await this.repository.AddAsync(post);
            await this.repository.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            await this.repository.DeleteAsync<Post>(id);
            await this.repository.SaveChangesAsync();
        }

        public async Task EditPostAsync(int id, PostFormView model)
        {
            Post post = await this.repository.GetByIdAsync<Post>(id);

            post.Title = model.Title;
            post.Content = model.Content;

            await this.repository.SaveChangesAsync();
        }

        public async Task<IList<PostViewModel>> GetAllPosts()
            => await this.repository
                .AllReadonly<Post>()
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToListAsync();

        public async Task<Post> GetPostByIdAsync(int id)
            => await this.repository.GetByIdAsync<Post>(id);
    }
}
