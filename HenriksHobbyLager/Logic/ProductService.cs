using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;
using System.Globalization;

public class ProductService : IProductService
{
    private readonly IProductFacade _productFacade;
    private readonly IInputHandler _inputHandler;
    private readonly IDisplayService _displayService;

    public ProductService(IProductFacade productFacade, IInputHandler inputHandler, IDisplayService displayService)
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
            return;
        }

        _displayService.DisplayMessage("{0,-5} {1,-20} {2,-10} {3,-10} {4,-15} {5,-20} {6,-20}", "ID", "Namn", "Pris", "Lager", "Kategori", "Skapad", "Senast uppdaterad");
        _displayService.DisplayMessage(new string('-', 100));

        foreach (var product in products)
        {
            _displayService.DisplayProduct(product);
        }
    }

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

        _displayService.DisplayMessage("Pris: ");
        var priceInput = _inputHandler.ReadLine()?.Replace(',', '.');
        decimal? price = null;
        if (!string.IsNullOrWhiteSpace(priceInput))
        {
            if (!decimal.TryParse(priceInput, out decimal parsedPrice))
            {
                _displayService.DisplayMessage("Ogiltigt pris!");
                return;
            }
            price = parsedPrice;
        }

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
        var category = _inputHandler.ReadLine();

        var product = new Product
        {
            Name = name,
            Price = (float)(price ?? 0),
            Stock = stock,
            Category = category,
        };

        _productFacade.AddProduct(product);
        _displayService.DisplayMessage("Produkt tillagd!");
    }

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

    public void DeleteProduct()
    {
        ShowAllProducts();
        _displayService.DisplayMessage("Ange produkt-ID att tabort: ");
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

        _productFacade.RemoveProduct(product);
        _displayService.DisplayMessage("Produkt borttagen!");
    }

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

    public List<Product> ImportFromOldProgram()
    {
        _displayService.DisplayMessage("Klistra in innehållet från visa allt och tryck Enter:");
        var dataImport = _inputHandler.ReadLine();
        var products = new List<Product>();
        var productBlocks = dataImport.Split(new string[] { "----------------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var block in productBlocks)
        {
            var product = new Product { Name = string.Empty };
            var lines = block.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split(new[] { ':' }, 2);
                if (parts.Length < 2) continue;

                var key = parts[0].Trim();
                var value = parts[1].Trim();

                switch (key)
                {
                    case "ID":
                        product.Id = int.Parse(value);
                        break;
                    case "Namn":
                        product.Name = value;
                        break;
                    case "Pris":
                        product.Price = float.Parse(value.Replace("kr", "").Trim(), CultureInfo.InvariantCulture);
                        break;
                    case "Lager":
                        product.Stock = int.Parse(value);
                        break;
                    case "Kategori":
                        product.Category = value;
                        break;
                    case "Skapad":
                        product.DateCreated = value;
                        break;
                    case "Senast uppdaterad":
                        product.DateUpdated = value;
                        break;
                }
            }

            products.Add(product);
        }

        return products;
    }
}
