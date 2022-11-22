using Microsoft.AspNetCore.Mvc;
using WebProject.DAL;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class CatalogController : Controller
    {
        IRepository _repo;
        public CatalogController(IRepository repo) => _repo = repo;
        public IActionResult Index()
        {
            IEnumerable<Animal> animals = _repo.GetAnimals();
            IEnumerable<Category> categories = _repo.GetCategories();
            var contain = new Contain(animals, categories);
            return View(contain);
        }
        public IActionResult GetByCategory(int categoryId)
        {
            IEnumerable<Animal> animals = _repo.GetAnimalByCategory(categoryId);
            IEnumerable<Category> categories = _repo.GetCategories();
            var contain = new Contain(animals, categories);
            return View(contain);
        }
        public IActionResult Details(int id, int categoryId)
        {
            var animal = _repo.GetAnimalsById(id);
            var category = _repo.GetCategory(categoryId);
            if (animal != null && category != null)
                return View(new Tuple<Category, Animal, Comment>(category, animal, new Comment()));
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult PostComment(string commentText, int animalId, int categoryId)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment()
                {
                    AnimalId = animalId,
                    CommentString = commentText
                };
                _repo.AddComment(comment);

            }
            return RedirectToAction("Details", "Catalog", new { id = animalId , categoryId = categoryId });


        }
    }
}
