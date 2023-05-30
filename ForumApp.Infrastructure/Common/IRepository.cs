namespace ForumApp.Infrastructure.Common
{
    using Microsoft.EntityFrameworkCore;

    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        DbSet<T> DbSet<T>() where T : class;

        IQueryable<T> AllReadonly<T>() where T : class;

        Task SaveChangesAsync();

        Task AddAsync<T>(T model) where T : class;

        Task DeleteAsync<T>(int id) where T : class;

        Task<T> GetByIdAsync<T>(int id) where T : class;
    }
}
