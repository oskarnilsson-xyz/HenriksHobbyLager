
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



    }
}