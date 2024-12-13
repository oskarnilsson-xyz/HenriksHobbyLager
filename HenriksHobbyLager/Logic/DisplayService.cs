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
    //Gör table i konsolen
    public void DrawTable(IEnumerable<Product> products)
    {
        var headers = new[] { "ID", "Namn", "Pris", "Lager", "Kategori", "Skapad", "Senast uppdaterad" };
        var table = products.Select(p => new object[]
        {
            p.Id, p.Name, p.Price, p.Stock, p.Category, p.DateCreated, p.DateUpdated
        }).ToList();

        Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10} {4,-15} {5,-20} {6,-20}", headers);
        Console.WriteLine(new string('-', 100));

        foreach (var row in table)
        {
            Console.WriteLine("{0,-5} {1,-20} {2,-10:C} {3,-10} {4,-15} {5,-20} {6,-20}", row);
        }
    }
}
