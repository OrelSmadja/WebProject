using WebProject.Models;

namespace WebProject.DAL
{
    public interface IRepository    {
        IEnumerable<Animal> GetAnimalByCategory(int CategoryId);
        IEnumerable<Animal> GetTwoPopular();
        IEnumerable<Animal> GetAnimals();
        IEnumerable<Category> GetCategories();
        Animal GetAnimalsById(int animalid);
        Category GetCategory(int categoryId); 
        void AddAnimal(Animal animal);
        void RemoveAnimal(int animalId);
        void EditById(Animal animal, int id);
        void AddComment(Comment comment);
        void RemoveComment(Comment comment);


    }
}
