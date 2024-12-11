
using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;

namespace HenriksHobbyLager
{
    
public class ConsoleMenuHandler
    {
        private readonly IProductFacade _productFacade;

        public ConsoleMenuHandler(IProductFacade productFacade)
        {
            _productFacade = productFacade ?? throw new ArgumentNullException(nameof(productFacade));
        }

        public void Navigation()
        {
            //Console.Clear();  // Rensar skärmen så det ser proffsigt ut
            Console.WriteLine("=== Henriks HobbyLager™ 1.0 ===");
            Console.WriteLine("1. Visa alla produkter");
            Console.WriteLine("2. Lägg till produkt");
            Console.WriteLine("3. Uppdatera produkt");
            Console.WriteLine("4. Ta bort produkt");
            Console.WriteLine("5. Sök produkter");
            Console.WriteLine("6. Avsluta");  // Använd inte denna om du vill behålla datan!

            var choice = Console.ReadLine();

            // Switch är tydligen bättre än if-else enligt Google
            switch (choice)
            {
                case "1":
                    ShowAllProducts();
                    break;
                case "2":
                    AddProduct();
                    break;
                case "3":
                    UpdateProduct();
                    break;
                case "4":
                    DeleteProduct();
                    break;
                case "5":
                    SearchProducts();
                    break;
                case "6":
                    return;  // OBS! All data försvinner om du väljer denna!
                default:
                    Console.WriteLine("Ogiltigt val! Är du säker på att du tryckte på rätt knapp?");
                    break;
            }

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta... (helst inte ESC)");
            Console.ReadKey();
        }

        // Visar alla produkter som finns i "databasen"
        private void ShowAllProducts()
        {
            var products = _productFacade.GetAllProducts();
            if (!products.Any())
            {
                Console.WriteLine("Inga produkter finns i lagret. Dags att shoppa grossist!");
                return;
            }

            foreach (var product in products)
            {
                DisplayProduct(product);
            }
        }

        // Lägger till en ny produkt i systemet
        private void AddProduct()
        {
            Console.WriteLine("=== Lägg till ny produkt ===");

            Console.Write("Namn: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Ogiltigt namn! Försök igen.");
                return;
            }

            Console.Write("Pris: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Ogiltigt pris! Använd punkt istället för komma (lärde mig den hårda vägen)");
                return;
            }

            Console.Write("Antal i lager: ");
            if (!int.TryParse(Console.ReadLine(), out int stock))
            {
                Console.WriteLine("Ogiltig lagermängd! Hela tal endast (kan inte sälja halva helikoptrar)");
                return;
            }

            Console.Write("Kategori: ");
            var category = Console.ReadLine();

            var product = new Product
            {
                Name = name,
                Price = (float)price,
                Stock = stock,
                Category = category,
            };

            _productFacade.AddProduct(product);
            Console.WriteLine("Produkt tillagd! Glöm inte att hålla datorn igång!");
        }

        // Uppdaterar en befintlig produkt
        private void UpdateProduct()
        {
            Console.Write("Ange produkt-ID att uppdatera (finns i listan ovan): ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID! Bara siffror tack!");
                return;
            }

            var product = _productFacade.GetProductById(id);
            if (product == null)
            {
                Console.WriteLine("Produkt hittades inte! Är du säker på att du skrev rätt?");
                return;
            }

            Console.Write("Nytt namn (tryck bara enter om du vill behålla det gamla): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                product.Name = name;

            Console.Write("Nytt pris (tryck bara enter om du vill behålla det gamla): ");
            var priceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out decimal price))
                product.Price = (float)price;

            Console.Write("Ny lagermängd (tryck bara enter om du vill behålla den gamla): ");
            var stockInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(stockInput) && int.TryParse(stockInput, out int stock))
                product.Stock = stock;

            Console.Write("Ny kategori (tryck bara enter om du vill behålla den gamla): ");
            var category = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(category))
                product.Category = category;


            Console.WriteLine("Produkt uppdaterad! Stäng fortfarande inte av datorn!");
        }

        // Ta bort en produkt (använd med försiktighet!)
        private void DeleteProduct()
        {
            Console.Write("Ange produkt-ID att ta bort (dubbel-check att det är rätt, går inte att ångra!): ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID! Bara siffror är tillåtna här.");
                return;
            }

            var product = _productFacade.GetProductById(id);
            if (product == null)
            {
                Console.WriteLine("Produkt hittades inte! Puh, inget blev raderat av misstag!");
                return;
            }

            _productFacade.RemoveProduct(product);
            Console.WriteLine("Produkt borttagen! (Hoppas det var meningen)");
        }

        // Sökfunktion - Min stolthet! Söker i både namn och kategori
        private void SearchProducts()
        {
            Console.Write("Sök (namn eller kategori - versaler spelar ingen roll!): ");
            var searchTerm = Console.ReadLine().ToLower();

            var results = _productFacade.SearchProducts(searchTerm).ToList();
            if (!results.Any())
            {
                Console.WriteLine("Inga produkter matchade sökningen. Prova med något annat!");
                return;
            }

            foreach (var product in results)
            {
                DisplayProduct(product);
            }
        }

        // Visar en enskild produkt snyggt formaterat
        private void DisplayProduct(Product product)
        {
            Console.WriteLine($"\nID: {product.Id}");
            Console.WriteLine($"Namn: {product.Name}");
            Console.WriteLine($"Pris: {product.Price:C}");
            Console.WriteLine($"Lager: {product.Stock}");
            Console.WriteLine($"Kategori: {product.Category}");
            Console.WriteLine($"Skapad: {product.DateCreated}");
            Console.WriteLine($"Senast uppdaterad: {product.LastUpdated}");
            Console.WriteLine(new string('-', 40));
        }
    }
        }