namespace ForumApp.Infrastructure.Common
{
    using ForumApp.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class Repository : IRepository
    {
        private readonly ForumAppDbContext context;

        public Repository(ForumAppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync<T>(T model) where T : class
            => await this.DbSet<T>()
                .AddAsync(model);

        public IQueryable<T> All<T>() where T : class
            => this.DbSet<T>()
                .AsQueryable();

        public IQueryable<T> AllReadonly<T>() where T : class
            => this.DbSet<T>()
                .AsQueryable()
                .AsNoTracking();

        public DbSet<T> DbSet<T>() where T : class
            => this.context.Set<T>();

        public async Task DeleteAsync<T>(int id) where T : class
        {
            T model = await this.DbSet<T>().FindAsync(id);

            this.DbSet<T>().Remove(model);
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : class
            => await this.DbSet<T>().FindAsync(id);

        public async Task SaveChangesAsync()
            => await this.context.SaveChangesAsync();
    }
}
