using NewsApi.DataLayer.Entities.Common;

namespace NewsApi.DataLayer.DTOs.NewsCategory
{
    public class NewsCategoryItem : BaseDTO
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public string ImageAddress { get; set; }
    }
}
