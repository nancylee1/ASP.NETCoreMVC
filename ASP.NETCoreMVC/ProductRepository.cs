using ASP.NETCoreMVC.Models;
using Dapper;
using System.Data;

namespace ASP.NETCoreMVC
{
    public class ProductRepository: IProductRepository
    {
        private readonly IDbConnection _conn; 
        public ProductRepository(IDbConnection conn)
        {
            _conn = conn; 
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public Product GetProduct(int id)   // calling a single item from the products list. We will use the QuerySingle Dapper method so that we can return a single row
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new { id = id });
        }

    }
}
