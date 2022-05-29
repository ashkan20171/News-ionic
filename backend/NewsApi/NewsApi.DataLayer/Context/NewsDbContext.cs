using Microsoft.EntityFrameworkCore;
using NewsApi.DataLayer.Entities.NewsEntities;

namespace NewsApi.DataLayer.Context
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options)
        {

        }

        #region dbsets

        public DbSet<NewsCategory> NewsCategories { get; set; }

        public DbSet<News> Newses { get; set; }

        #endregion
    }
}
