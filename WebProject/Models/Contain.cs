namespace WebProject.Models
{
    public class Contain
    {
        public IEnumerable<Animal>? animals { get; set; }
        public IEnumerable<Category>? categories { get; set; }
        public Contain(IEnumerable<Animal>? animals, IEnumerable<Category>? categories)
        {
            this.animals = animals;
            this.categories = categories;
        }
    }
}
