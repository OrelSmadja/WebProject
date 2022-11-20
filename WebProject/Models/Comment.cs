namespace WebProject.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        public string? CommentString { get; set; }

        public override string ToString()
        {
            return CommentString!;
        }
    }
}
