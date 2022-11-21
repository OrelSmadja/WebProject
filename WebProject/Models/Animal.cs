using Castle.Components.DictionaryAdapter;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace WebProject.Models
{
    public class Animal
    {
        [Key]
        [Display (Name = "id:")]
        [Required(ErrorMessage =  "Must have id")]
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [Display(Name = "Name:")]
        public string? Name { get; set; }

        [Display(Name = "Age:")]
        [Required(ErrorMessage = "Please enter age") ,Range(0,250)]
        public int Age { get; set; }

        [Display(Name = "Description:")]
        [Required(ErrorMessage = "Please enter Description")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please enter CategoryId")]
        [Display(Name = "CategoryId:")]
        public int CategoryId { get; set; }
        public string? PictureName { get; set; }
        
        public Category? Category { get; set; }
        public ICollection<Comment>? Comments { get; set; }


        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Animal)) return false;
            var other = obj as Animal;
            if (this.Name != other.Name) return false;
            if (this.Age != other.Age) return false;
            if (this.Description != other.Description) return false;
            if (this.CategoryId != other.CategoryId) return false;
            return true;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();  
        }
    }
}
