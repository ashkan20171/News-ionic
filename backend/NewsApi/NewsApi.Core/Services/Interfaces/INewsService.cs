using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsApi.DataLayer.DTOs.News;
using NewsApi.DataLayer.DTOs.NewsCategory;
using NewsApi.DataLayer.Entities.NewsEntities;

namespace NewsApi.Core.Services.Interfaces
{
    public interface INewsService : IAsyncDisposable
    {
        #region categories

        Task<List<NewsCategoryItem>> GetAllActiveNewsCategories();
        Task<List<NewsItemDTO>> GetNewsByCategoryId(long categoryId);
        Task<NewsItemDTO> GetNewsById(long newsId);
        Task<List<NewsItemDTO>> GetLatestNewses();

        #endregion
    }
}