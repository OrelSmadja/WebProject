using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using WebProject.DAL;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        
        IRepository _repo;
        public HomeController(IRepository repo) => _repo = repo;

        public IActionResult Index() => View(_repo.GetTwoPopular());

        public IActionResult GerAll() => View(_repo.GetAnimals());

        public IActionResult GetByCategory(int categoryId) => View(_repo.GetAnimalByCategory(categoryId));
    }
}
