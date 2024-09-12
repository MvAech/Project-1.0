namespace Project_1._0.data
{
    public class News
    {
        public int Id { get; set; }
        public required string Headline { get; set; }
        public required string Content { get; set; }
        public required string ImageUrl { get; set; }
        public required string ArticleLink { get; set; }
        public required string Excerpt { get; set; }
        public DateTime PostedOn { get; set; }
    }

}
