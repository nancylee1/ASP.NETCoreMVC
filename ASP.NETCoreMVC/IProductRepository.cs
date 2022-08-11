using ASP.NETCoreMVC.Models;

namespace ASP.NETCoreMVC
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts(); // all products
        public Product GetProduct(int id); // to View one product at a time, add a new stubbed out method- GetProduct() - to the IProductRepository Interface
    }
}
