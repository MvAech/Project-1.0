namespace Project_1._0.data
{
    public class Feedback
    {
        public required int Id { get; set; }
        public required string UserName { get; set; }
        public required string Text { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }

}
