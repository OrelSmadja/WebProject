using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace WebProject.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "Must enter least 1 char")]
        [MinLength(1)]
        public string? CommentString { get; set; }

        public override string ToString()
        {
            return CommentString!;
        }
    }
}
