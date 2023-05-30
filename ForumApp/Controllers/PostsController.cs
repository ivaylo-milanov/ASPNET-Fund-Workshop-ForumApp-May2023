namespace ForumApp.Controllers
{
    using ForumApp.Core.Services.Contracts;
    using ForumApp.Core.ViewModels.Post;
    using ForumApp.Infrastructure.Models;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : Controller
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<PostViewModel> posts = await this.postService.GetAllPosts();

            return View(posts);
        }

        public IActionResult Add()
        {
            PostFormView model = new PostFormView();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.postService.AddPostAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.postService.DeletePostAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Post post = await this.postService.GetPostByIdAsync(id);

            PostFormView model = new PostFormView
            {
                Title = post.Title,
                Content = post.Content
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.postService.EditPostAsync(id, model);

            return RedirectToAction(nameof(Index));
        }
    }
}
