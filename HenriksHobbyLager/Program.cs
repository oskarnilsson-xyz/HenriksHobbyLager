using HenriksHobbyLager.Facade;
using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Logic;
using HenriksHobbyLager.Repository;
using HenriksHobbyLager.Models;
namespace HenriksHobbyLager
{
    class Program
    {
        static void Main()
        {
            var connectionString = @"Data Source=.\HenriksHobbyLager.db"; // Relativ path till databasfilen

            // Instanser av klasser, finns nog bättre sätt att göra detta på
            IRepository<Product> productRepository = new ProductRepository(connectionString);
            IProductFacade productFacade = new ProductFacade(productRepository); // Use the correct constructor
            IDisplayService displayService = new DisplayService();
            IInputHandler inputHandler = new InputHandler(displayService, null); // Simplified initialization
            IProductService productService = new ProductService(productFacade, inputHandler, displayService);

            // Initiera databas
            productRepository.InitDatabase(connectionString);

            // Initiera och calla meny
            var consoleMenuHandler = new ConsoleMenuHandler(productService, connectionString);
            consoleMenuHandler.Navigation();
        }
    }
}