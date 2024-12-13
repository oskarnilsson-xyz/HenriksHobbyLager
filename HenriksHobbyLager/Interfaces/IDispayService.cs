using HenriksHobbyLager.Models;

public interface IDisplayService
{
    void DisplayProduct(Product product);
    void DisplayMessage(string message);
    void DrawTable(IEnumerable<Product> products);
}
