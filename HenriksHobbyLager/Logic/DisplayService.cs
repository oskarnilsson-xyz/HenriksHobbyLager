using HenriksHobbyLager.Models;

public class DisplayService : IDisplayService
{

    // Visar en enskild produkt -- Potentiell Feature: Kolla på hur många svar och välj tabell om det är många

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
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Error no message display");
        }
        Console.WriteLine(message);
    }

    public void DrawTable(string v1, string v2, string v3, string v4, string v5, string v6, string v7, string v8)
    {
        Console.WriteLine(v1, v2, v3, v4, v5, v6, v7, v8);
    }
}
