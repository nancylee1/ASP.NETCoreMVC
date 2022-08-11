using ASP.NETCoreMVC.Models;

namespace ASP.NETCoreMVC
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts(); // all products
        public Product GetProduct(int id); // to View one product at a time, add a new stubbed out method- GetProduct() - to the IProductRepository Interface
        public void UpdateProduct(Product product); // Now that we can view an individual product, let’s give the user the ability to make updates to that product: add the UpdateProduct stubbed out Method
        public void InsertProduct(Product productToInsert); // to Create a product
        public IEnumerable<Category> GetCategories();       // "
        public Product AssignCategory();                    // "

    }

}
