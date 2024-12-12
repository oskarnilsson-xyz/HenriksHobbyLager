
using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;
using System.Globalization;



//Det finns nog mkt kod  att optimera i funktionerna där Console.ReadLine() används + Flytta ut funktioner till andra klasser
namespace HenriksHobbyLager
{

    public class ConsoleMenuHandler(IProductFacade productFacade)
    {
        private readonly IProductFacade _productFacade = productFacade ?? throw new ArgumentNullException(nameof(productFacade));

        public void Navigation()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("=== Henriks HobbyLager™ 2.0 ===");
                Console.WriteLine("1. Visa alla produkter");
                Console.WriteLine("2. Lägg till produkt");
                Console.WriteLine("3. Uppdatera produkt");
                Console.WriteLine("4. Ta bort produkt");
                Console.WriteLine("5. Sök produkter");
                Console.WriteLine("6. Avsluta");
                Console.WriteLine("\n0. Import från Henriks HobbyLager™ 1.0");




                switch (Console.ReadLine())
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
                        return;
                    case "0":
                        ImportFromOldProgram();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val!");
                        break;
                }

                Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }

        // Visar alla produkter som finns i databasen
        private void ShowAllProducts()
        {
            var products = _productFacade.GetAllProducts();
            if (!products.Any())
            {
                Console.WriteLine("Inga produkter finns i lagret.");
                return;  //Potential för att tabort en return med if else
            }
            Console.Clear();
            //Table!
            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10} {4,-15} {5,-20} {6,-20}", "ID", "Namn", "Pris", "Lager", "Kategori", "Skapad", "Senast uppdaterad");
            Console.WriteLine(new string('-', 100));

            foreach (var product in products)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-10:C} {3,-10} {4,-15} {5,-20} {6,-20}",
                    product.Id,
                    product.Name,
                    product.Price,
                    product.Stock,
                    product.Category,
                    product.DateCreated,
                    product.DateUpdated);
            }
        }

        // Lägger till en ny produkt i systemet
        private void AddProduct()
        {
            Console.WriteLine("=== Lägg till ny produkt ===");

            Console.Write("Namn: ");  // Kan plocka ut Write/Read till en egen funktion för att reducera kod.
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Ogiltigt namn! Försök igen.");
                return;
            }

            //Om inget anges sätts priset till 0, vill ha det i databasen som default värde om jag kan lista ut det.
            Console.Write("Pris: ");
            var priceInput = Console.ReadLine()?.Replace(',', '.'); // Används för att hantera svenska decimaler
            decimal? price = null; //---Kan vi byta till float?--- Tillåt null för att priset inte ska "få vara 0"
            if (!string.IsNullOrWhiteSpace(priceInput))
            {
                if (!decimal.TryParse(priceInput, out decimal parsedPrice))
                {
                    Console.WriteLine("Ogiltigt pris!");
                    return;
                }
                price = parsedPrice;
            }
            // Möjligt att sätta lager till null om inget anges, db har default värde
            Console.Write("Antal i lager: ");
            var stockInput = Console.ReadLine();
            int? stock = null;
            if (!string.IsNullOrWhiteSpace(stockInput))
            {
                if (!int.TryParse(stockInput, out int parsedStock))
                {
                    Console.WriteLine("Endast heltal.");
                    return;
                }
                stock = parsedStock;
            }

            //Null värde ger misc i databasen med default värde
            Console.Write("Kategori: ");
            var category = Console.ReadLine();

            var product = new Product
            {
                Name = name,
                Price = (float)(price ?? 0), //TODO: Vill att denna ska kunna vara null om
                                             //inget pris anges för att reducera mängden kod(databasen har ett default värde)
                                             //Kanske flytta var casten händer?
                Stock = stock,
                Category = category,
            };

            _productFacade.AddProduct(product);
            Console.WriteLine("Produkt tillagd!");
        }

        // Uppdaterar en befintlig produkt
        private void UpdateProduct()
        {
            ShowAllProducts();
            Console.Write("Ange produkt-ID att uppdatera: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID!");
                return;
            }

            var product = _productFacade.GetProductById(id);
            if (product == null)
            {
                Console.WriteLine("Produkt hittades inte!");
                return;
            }
            //Kolla på {} https://www.reddit.com/r/programming/comments/1z65j2/reflections_on_curly_braces_apples_ssl_bug_and/?rdt=46866
            //Kolla på att flytta ut repititiv kod till en egen funktion
            Console.Write("Nytt namn eller tryck Enter för att behålla gamla: ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                product.Name = name;

            Console.Write("Nytt pris eller tryck Enter för att behålla gamla: ");
            var priceInput = Console.ReadLine()?.Replace(',', '.');
            if (!string.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out decimal price)) // kan vi bättre än string.isnullorwhitespace?
                product.Price = (float)price;

            Console.Write("Ny lagermängd eller tryck Enter för att behålla gamla: ");
            var stockInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(stockInput) && int.TryParse(stockInput, out int stock))
                product.Stock = stock;

            Console.Write("Ny kategori eller tryck Enter för att behålla gamla: ");
            var category = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(category))
                product.Category = category;


            Console.WriteLine("Produkt uppdaterad!"); //BUGGGGG ny info skickas inte till databasen
        }

        // Ta bort en produkt
        private void DeleteProduct()
        {
            ShowAllProducts();
            Console.Write("Ange produkt-ID att tabort: ");
            if (!int.TryParse(Console.ReadLine(), out int id))  //Baka ihop med update i egen funktion 
            {
                Console.WriteLine("Ogiltigt ID!");
                return;
            }

            var product = _productFacade.GetProductById(id);//Baka ihop med update i egen funktion 
            if (product == null)
            {
                Console.WriteLine("Produkt hittades inte!");
                return;
            }

            _productFacade.RemoveProduct(product);
            Console.WriteLine("Produkt borttagen!");
        }

        // Sökfunktion
        private void SearchProducts()
        {
            Console.Write("Sök på namn eller kategori: ");
            string? searchTerm = Console.ReadLine()?.ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                Console.WriteLine("Ogiltigt sökterm!");
                return;
            }

            var results = _productFacade.SearchProducts(searchTerm).ToList();
            if (!results.Any())
            {
                Console.WriteLine("Inga produkter matchade sökningen.");
                return;
            }

            results.ForEach(DisplayProduct);
        }

        // Visar en enskild produkt -- Kolla på hur många svar och välj tabell om det är många
        private void DisplayProduct(Product product) 
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
        public List<Product> ImportFromOldProgram()  //Extraordinärt mkt i denna funktion är Copilot genererat.
        {
            Console.WriteLine("Klistra in innehållet från visa allt och tryck Enter:");
            var dataImport = Console.ReadLine(); //läs en textfil med datan
            var products = new List<Product>();
            var productBlocks = dataImport.Split(new string[] { "----------------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var block in productBlocks)
            {
                var product = new Product { Name = string.Empty }; // Fixar så att det inte blir null exception
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
}