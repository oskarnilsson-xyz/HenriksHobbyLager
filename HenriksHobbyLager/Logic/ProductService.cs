using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;
using System.Globalization;

public class ProductService : IProductService
{   //Låt productservice anropa metoder
    private readonly IProductFacade _productFacade;
    private readonly IInputHandler _inputHandler;
    private readonly IDisplayService _displayService;

    public ProductService(IProductFacade productFacade, IInputHandler inputHandler, IDisplayService displayService) //DI initiering
    {
        _productFacade = productFacade;
        _inputHandler = inputHandler;
        _displayService = displayService;
    }

    public void ShowAllProducts()
    {
        var products = _productFacade.GetAllProducts();
        if (!products.Any())
        {
            _displayService.DisplayMessage("Inga produkter finns i lagret.");
        }
        else
        {
            _displayService.DrawTable(products);
        }
    }
    // Lägger till en ny produkt i systemet
    //TODO: Skapa en helper funktion för null/empty checks
    public void AddProduct()
    {
        _displayService.DisplayMessage("=== Lägg till ny produkt ===");

        _displayService.DisplayMessage("Namn: ");
        string? name = _inputHandler.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            _displayService.DisplayMessage("Ogiltigt namn! Försök igen.");
            return;
        }
        //Om inget anges sätts priset till 0, vill ha det i databasen som default värde om jag kan lista ut det.
        _displayService.DisplayMessage("Pris: ");
        var priceInput = _inputHandler.ReadLine()?.Replace(',', '.'); // Används för att hantera svenska decimaler
        decimal? price = null;//TODO: ---Kan vi byta till float?--- Tillåt null för att priset inte ska "få vara 0"
        if (!string.IsNullOrWhiteSpace(priceInput))
        {
            if (!decimal.TryParse(priceInput, out decimal parsedPrice))
            {
                _displayService.DisplayMessage("Ogiltigt pris!");
                return;
            }
            price = parsedPrice;
        }
        // Möjligt att sätta lager till null om inget anges, db har default värde
        _displayService.DisplayMessage("Antal i lager: ");
        var stockInput = _inputHandler.ReadLine();
        int? stock = null;
        if (!string.IsNullOrWhiteSpace(stockInput))
        {
            if (!int.TryParse(stockInput, out int parsedStock))
            {
                _displayService.DisplayMessage("Endast heltal.");
                return;
            }
            stock = parsedStock;
        }

        _displayService.DisplayMessage("Kategori: ");
        var category = _inputHandler.ReadLine();         //Null värde ger misc i databasen med default värde

        var product = new Product
        {
            Name = name,
            Price = (float)(price ?? 0),        //TODO: Vill att denna ska kunna vara null om
            Stock = stock,                      //inget pris anges för att reducera mängden kod(databasen har ett default värde)
            Category = category,                //Kanske flytta var casten händer?
        };

        _productFacade.AddProduct(product);
        _displayService.DisplayMessage("Produkt tillagd!");
    }
    // Uppdaterar en befintlig produkt Funkar inte pga det skickas aldrig till databasen
    public void UpdateProduct()
    {
        ShowAllProducts();
        _displayService.DisplayMessage("Ange produkt-ID att uppdatera: ");
        if (!int.TryParse(_inputHandler.ReadLine(), out int id))
        {
            _displayService.DisplayMessage("Ogiltigt ID!");
            return;
        }

        var product = _productFacade.GetProductById(id);
        if (product == null)
        {
            _displayService.DisplayMessage("Produkt hittades inte!");
            return;
        }

        _displayService.DisplayMessage("Nytt namn eller tryck Enter för att behålla gamla: ");
        var name = _inputHandler.ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
            product.Name = name;

        _displayService.DisplayMessage("Nytt pris eller tryck Enter för att behålla gamla: ");
        var priceInput = _inputHandler.ReadLine()?.Replace(',', '.');
        if (!string.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out decimal price))
            product.Price = (float)price;

        _displayService.DisplayMessage("Ny lagermängd eller tryck Enter för att behålla gamla: ");
        var stockInput = _inputHandler.ReadLine();
        if (!string.IsNullOrWhiteSpace(stockInput) && int.TryParse(stockInput, out int stock))
            product.Stock = stock;

        _displayService.DisplayMessage("Ny kategori eller tryck Enter för att behålla gamla: ");
        var category = _inputHandler.ReadLine();
        if (!string.IsNullOrWhiteSpace(category))
            product.Category = category;

        _productFacade.UpdateProduct(product);
        _displayService.DisplayMessage("Produkt uppdaterad!");
    }
    // Ta bort en produkt
    public void DeleteProduct()
    {
        ShowAllProducts();
        _displayService.DisplayMessage("Ange produkt-ID att tabort: ");
        if (!int.TryParse(_inputHandler.ReadLine(), out int id)) //TODO: Baka ihop med update i egen funktion 
        {
            _displayService.DisplayMessage("Ogiltigt ID!");
            return;
        }

        var product = _productFacade.GetProductById(id);//TODO: Baka ihop med update i egen funktion 
        if (product == null)
        {
            _displayService.DisplayMessage("Produkt hittades inte!");
            return;
        }

        _productFacade.RemoveProduct(product);
        _displayService.DisplayMessage("Produkt borttagen!");
    }
    // Sökfunktion
    public void SearchProducts()
    {
        _displayService.DisplayMessage("Sök på namn eller kategori: ");
        string? searchTerm = _inputHandler.ReadLine()?.ToLower();

        if (string.IsNullOrEmpty(searchTerm))
        {
            _displayService.DisplayMessage("Ogiltigt sökterm!");
            return;
        }

        var results = _productFacade.SearchProducts(searchTerm).ToList();
        if (!results.Any())
        {
            _displayService.DisplayMessage("Inga produkter matchade sökningen.");
            return;
        }

        results.ForEach(_displayService.DisplayProduct);
    }
    //Extraordinärt mkt i denna funktion är Copilot genererat.
    public void ImportFromOldProgram()
    {

        var products = new List<Product>();

        var productBlocks = _inputHandler.ReadFile();

        foreach (var block in productBlocks)
        {
            var product = new Product { Name = string.Empty }; // Fixar så att det inte blir null exception
            var lines = block.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split([':'], 2);
                if (parts.Length < 2) continue;

                var key = parts[0].Trim();
                var value = parts[1].Trim();

                switch (key)
                {
                    case "ID":
                        //product.Id = int.Parse(value);
                        break;
                    case "Namn":
                        product.Name = value;
                        break;
                    case "Pris":
                        product.Price = float.Parse(value.Replace("kr", "").Trim(), CultureInfo.InvariantCulture); //Culture fixar decimal problem
                        break;
                    case "Lager":
                        product.Stock = int.Parse(value);
                        break;
                    case "Kategori":
                        product.Category = value;
                        break;
                    case "Skapad":
                        //product.DateCreated = value;
                        break;
                    case "Senast uppdaterad":
                        //product.DateUpdated = value;
                        break;
                }
            }

            products.Add(product);
        }
        foreach (var product in products)
        {
            Console.Write($"{product.Name} läggs till.");
            _productFacade.AddProduct(product);
        }
        Console.WriteLine("\n\nAlla produkter tillagda!");
    }
}
