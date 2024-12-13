namespace HenriksHobbyLager
{

    public class ConsoleMenuHandler
    {

        private readonly IProductService _productService;

        public ConsoleMenuHandler(IProductService productService)
        {

            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

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
                        _productService.ShowAllProducts();
                        break;
                    case "2":
                        _productService.AddProduct();
                        break;
                    case "3":
                        _productService.UpdateProduct();
                        break;
                    case "4":
                        _productService.DeleteProduct();
                        break;
                    case "5":
                        _productService.SearchProducts();
                        break;
                    case "6":
                        return;
                    case "0":
                        _productService.ImportFromOldProgram();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val!");
                        break;
                }

                Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }
    }
}