namespace WebProject.Models
{
    public class Category
    {
       public virtual ICollection<Animal>? Animals { get; set; } 
        public int CategoryId { get; set; }
        public string? Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if(obj.GetType() != typeof(Category)) return false;
            var other = obj as Category;
            if (other == null) return false;
            if (this.CategoryId != other.CategoryId) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
