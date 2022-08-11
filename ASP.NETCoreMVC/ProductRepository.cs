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

        public void UpdateProduct(Product product) // Create the UpdateProduct() ProductRepository Method Implementation:
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id", new { name = product.Name, price = product.Price, id = product.ProductID });
        }

        // Now we will create the implementation of the methods specified inside of the interface, in the ProductRepository:
        //InsertProduct()
        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
                new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
        }

        // GetCategories()
        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }

        // AssignCategory()
        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;
            return product;
        }
    }
}
