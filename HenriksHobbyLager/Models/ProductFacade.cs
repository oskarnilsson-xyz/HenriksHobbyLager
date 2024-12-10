using HenriksHobbyLager.Interfaces;
using System;
using System.Collections.Generic;

namespace HenriksHobbyLager.Models
{
    public class ProductFacade : IProductFacade
    {
        private readonly IRepository<Product> _productRepository;

        public ProductFacade(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _productRepository.Delete(product.Id);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>(_productRepository.GetAll());
        }

        public IEnumerable<Product> SearchProducts(string searchTerm)
        {
            return _productRepository.Search(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                                  (p.Category != null && p.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
