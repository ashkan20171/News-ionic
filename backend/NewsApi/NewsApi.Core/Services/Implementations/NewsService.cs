using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsApi.Core.Extensions;
using NewsApi.Core.Services.Interfaces;
using NewsApi.DataLayer.DTOs.News;
using NewsApi.DataLayer.DTOs.NewsCategory;
using NewsApi.DataLayer.Entities.NewsEntities;
using NewsApi.DataLayer.Repositories;

namespace NewsApi.Core.Services.Implementations
{
    public class NewsService : INewsService
    {
        #region constructor

        private readonly IGenericRepository<NewsCategory> _newsCategoryRepository;
        private readonly IGenericRepository<News> _newsRepository;

        public NewsService(IGenericRepository<NewsCategory> newsCategoryRepository, IGenericRepository<News> newsRepository)
        {
            _newsCategoryRepository = newsCategoryRepository;
            _newsRepository = newsRepository;
        }

        #endregion

        #region news categories

        public async Task<List<NewsCategoryItem>> GetAllActiveNewsCategories()
        {
            return await _newsCategoryRepository.GetEntitiesQuery().AsQueryable()
                .Where(s => !s.IsDelete)
                .OrderBy(s => s.Order)
                .Select(s => new NewsCategoryItem
                {
                    Order = s.Order,
                    Id = s.Id,
                    Name = s.Name,
                    ImageAddress = PathTools.NewsCategoryImageAddress + s.ImageName
                }).ToListAsync();
        }

        public async Task<List<NewsItemDTO>> GetNewsByCategoryId(long categoryId)
        {
            return await _newsRepository.GetEntitiesQuery().AsQueryable()
                .Include(s => s.NewsCategory)
                .Where(s => s.NewsCategoryId == categoryId)
                .Select(s => new NewsItemDTO
                {
                    Id = s.Id,
                    ImageName = PathTools.NewsImageAddress + s.ImageName,
                    Author = s.Author,
                    Title = s.Title,
                    CategoryId = s.NewsCategoryId,
                    CategoryName = s.NewsCategory.Name,
                    Text = s.Text
                })
                .ToListAsync();
        }

        public async Task<NewsItemDTO> GetNewsById(long newsId)
        {
            var news = await _newsRepository.GetEntitiesQuery().AsQueryable()
                .Include(s => s.NewsCategory)
                .SingleOrDefaultAsync(s => s.Id == newsId);

            return new NewsItemDTO
            {
                Author = news.Author,
                CategoryId = news.NewsCategoryId,
                CategoryName = news.NewsCategory.Name,
                Id = news.Id,
                ImageName = PathTools.NewsImageAddress + news.ImageName,
                Text = news.Text,
                Title = news.Title
            };
        }

        public async Task<List<NewsItemDTO>> GetLatestNewses()
        {
            return await _newsRepository.GetEntitiesQuery().AsQueryable()
                .Include(s => s.NewsCategory)
                .OrderByDescending(s => s.CreateDate)
                .Select(s => new NewsItemDTO
                {
                    Id = s.Id,
                    ImageName = PathTools.NewsImageAddress + s.ImageName,
                    Author = s.Author,
                    Title = s.Title,
                    CategoryId = s.NewsCategoryId,
                    CategoryName = s.NewsCategory.Name,
                    Text = s.Text
                }).ToListAsync();
        }

        #endregion

        #region dispose

        public async ValueTask DisposeAsync()
        {
            await _newsCategoryRepository.DisposeAsync();
        }

        #endregion
    }
}
