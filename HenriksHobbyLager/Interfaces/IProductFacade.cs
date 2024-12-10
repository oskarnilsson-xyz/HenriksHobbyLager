using System;

namespace HenriksHobbyLager.Interfaces
{
    public interface IProductFacade
    {
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        void UpdateProduct(Product product);
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        IEnumerable<Product> SearchProducts(string searchTerm);
    }
}
