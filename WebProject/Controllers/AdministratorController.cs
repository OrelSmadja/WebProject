using Microsoft.AspNetCore.Mvc;
using WebProject.DAL;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AdministratorController : Controller
    {
        IRepository _repo;
        private readonly IWebHostEnvironment _webHost;
        public AdministratorController(IRepository repo, IWebHostEnvironment webHost)
        {
            _repo = repo;
            _webHost = webHost;
        }
        public IActionResult AddAnimal() => View(new Tuple<IEnumerable<Category>, Animal>(_repo.GetCategories(), new Animal()));


           
        
        public IActionResult AnimalEdit(int id) => View(new Tuple<IEnumerable<Category>, Animal>(_repo.GetCategories(), _repo.GetAnimalsById(id)));

        [HttpPost]
        public async Task<IActionResult> EditAnimal(string name, int age, IFormFile file, string description, int categoryId, int id)
        {
            ModelState.Remove("file");
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var savePic = Path.Combine(_webHost.WebRootPath, "Assets", file.FileName);
                    using (var upload = new FileStream(savePic, FileMode.Create))
                    {
                        await file.CopyToAsync(upload);
                    }
                    var animal = new Animal { Name = name, Age = age, CategoryId = categoryId, Description = description, PictureName = "Assets/" + file.FileName };
                    _repo.EditById(animal, id);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var temp = _repo.GetAnimalsById(id);
                    var newAnimal = new Animal { Name = name, Age = age, CategoryId = categoryId, Description = description, PictureName = temp.PictureName };
                    _repo.EditById(newAnimal, id);
                }             
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> AddNew(string name, int age, IFormFile file, string description, int categoryId)
        {

            if (ModelState.IsValid)
            {
                var savePic = Path.Combine(_webHost.WebRootPath, "Assets", file.FileName);
                using (var upload = new FileStream(savePic, FileMode.Create))
                {
                    await file.CopyToAsync(upload);
                }
                var animal = new Animal { Name = name, Age = age, CategoryId = categoryId, Description = description, PictureName = "Assets/" + file.FileName };
                _repo.AddAnimal(animal);
                return RedirectToAction("AddAnimal", "Administrator");
            }


            return RedirectToAction("AddAnimal", "Administrator");

        }

       

    }
}
