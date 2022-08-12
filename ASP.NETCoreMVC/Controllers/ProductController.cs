using ASP.NETCoreMVC.Models;
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

        public IActionResult UpdateProduct(int id) // Create the UpdateProduct() Controller Method in the ProductController & add using directive, then create view cshtml razor empty file in Projects folder
        {
            Product prod = repo.GetProduct(id);
            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }

        public IActionResult UpdateProductToDatabase(Product product)  // Add UpdateProductToDatabase() Method to Product Controller:

        {
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        // InsertProduct()

        public IActionResult InsertProduct()
        {
            var prod = repo.AssignCategory();
            return View(prod);
        }

        //InsertProductToDatabase()

        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);
            return RedirectToAction("Index");
        }

        // Create DeleteProduct(Product product) method in the ProductController to delete a product
        public IActionResult DeleteProduct(Product product)
        {
            repo.DeleteProduct(product);
            return RedirectToAction("Index");
        }
    }
}
