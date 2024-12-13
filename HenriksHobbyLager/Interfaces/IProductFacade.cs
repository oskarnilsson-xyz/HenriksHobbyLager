using HenriksHobbyLager.Models;


namespace HenriksHobbyLager.Interfaces
{
    public interface IProductFacade
    {
        string connectionString { get; }
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        void UpdateProduct(Product product);
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        IEnumerable<Product> SearchProducts(string searchTerm);
    }
}
