using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Core.Services.Interfaces;

namespace NewsApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        #region cosntructor

        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        #endregion

        #region get all categories

        [HttpGet("news-categories")]
        public async Task<IActionResult> GetNewsCategories()
        {
            var categories = await _newsService.GetAllActiveNewsCategories();

            return new JsonResult(new
            {
                categories
            });
        }

        #endregion

        #region news by category

        [HttpGet("news-by-category/{categoryId}")]
        public async Task<IActionResult> GetNewsByCategory(long categoryId)
        {
            return new JsonResult(new
            {
                news = await _newsService.GetNewsByCategoryId(categoryId)
            });
        }

        #endregion

        #region news detail

        [HttpGet("news-detail/{newsId}")]
        public async Task<IActionResult> NewsDetail(long newsId)
        {
            return new JsonResult(new
            {
                news = await _newsService.GetNewsById(newsId)
            });
        }

        #endregion

        #region news by category

        [HttpGet("latest-newses")]
        public async Task<IActionResult> LatestNewses()
        {
            return new JsonResult(new
            {
                newses = await _newsService.GetLatestNewses()
            });
        }

        #endregion
    }
}
