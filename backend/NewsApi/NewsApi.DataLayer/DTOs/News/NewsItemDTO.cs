namespace NewsApi.DataLayer.DTOs.News
{
    public class NewsItemDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImageName { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Text { get; set; }
    }
}
