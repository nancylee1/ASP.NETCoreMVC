using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View(repo.GetAllProducts());

        }
        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id); // to call one single product
            return View(product);
        }
    }
}
