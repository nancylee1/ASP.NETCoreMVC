using ASP.NETCoreMVC.Models;

namespace ASP.NETCoreMVC
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts(); 
    }
}
