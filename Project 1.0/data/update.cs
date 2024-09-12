namespace Project_1._0.data
{
    public class Update
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
