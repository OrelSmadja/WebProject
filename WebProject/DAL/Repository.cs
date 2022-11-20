using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.DAL
{
    public class Repository : IRepository
    {
        private AnimalContext _data;
        public Repository(AnimalContext data)
        {
            _data = data;
        }


        public void AddAnimal(Animal animal)
        {
            _data.Animals!.Add(animal);
            _data.SaveChanges();
        }
        public void RemoveAnimal(int animalId)
        {
            var fuond = _data.Animals!.Where(a => a.AnimalId == animalId).FirstOrDefault();
            if (fuond != null) _data.Animals!.Remove(fuond);
        }

        public void AddComment(Comment comment)
        {
            if (comment != null)
            {
                _data.Comments!.Add(comment!);
            }
            _data.SaveChanges();
        }
        public IEnumerable<Category> GetCategories() => _data.Categories!;


        public void EditById(Animal animal,int id)
        {
            Animal? temp = _data.Animals!.Where(a => a.AnimalId == id).FirstOrDefault(); ;
            if (temp != null && !temp.Equals(animal))
            {
                temp.Name = animal.Name;
                temp.Description = animal.Description;
                temp.PictureName = animal.PictureName;
                temp.Age = animal.Age;  
                temp.CategoryId = animal.CategoryId;
                _data.SaveChanges();
            }
        }
        public IEnumerable<Animal> GetAnimals() => _data.Animals!.Include(a => a.Comments).AsEnumerable();

        public Animal GetAnimalsById(int animalId) => _data.Animals!.Include(a=>a.Comments).Where(a => a.AnimalId == animalId).FirstOrDefault()!;

        public void RemoveComment(Comment comment) => _data.Comments?.Remove(comment);

        public IEnumerable<Animal> GetAnimalByCategory(int CategoryId) => _data.Animals!.Include(a => a.Comments).Where(a => a.Category!.CategoryId == CategoryId).AsEnumerable();
        public Category GetCategory(int categoryId) => _data.Categories!.Where(c => c.CategoryId == categoryId).FirstOrDefault()!;
        


        public IEnumerable<Animal> GetTwoPopular() => _data.Animals!.Include(a=>a.Comments).OrderByDescending(a => a.Comments!.Count).Take(2);

    }
}
