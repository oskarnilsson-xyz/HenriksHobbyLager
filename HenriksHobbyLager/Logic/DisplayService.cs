using HenriksHobbyLager.Models;

public class DisplayService : IDisplayService
{
    public void DisplayProduct(Product product)
    {
        Console.WriteLine($"\nID: {product.Id}");
        Console.WriteLine($"Namn: {product.Name}");
        Console.WriteLine($"Pris: {product.Price:C}");
        Console.WriteLine($"Lager: {product.Stock}");
        Console.WriteLine($"Kategori: {product.Category}");
        Console.WriteLine($"Skapad: {product.DateCreated}");
        Console.WriteLine($"Senast uppdaterad: {product.DateUpdated}");
        Console.WriteLine(new string('-', 40));
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}
