using HenriksHobbyLager.Models;

public interface IProductService
{
    void ShowAllProducts();
    void AddProduct();
    void UpdateProduct();
    void DeleteProduct();
    void SearchProducts();
    void ImportFromOldProgram();
}
