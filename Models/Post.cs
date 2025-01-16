namespace PostApi.Models
{
    public class Post
    {
         public string Id { get; set; } = string.Empty; 
        public string Title { get; set; } 
        public string Content { get; set; } 
       public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
