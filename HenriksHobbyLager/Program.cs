using HenriksHobbyLager.Facade;
using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Logic;

namespace HenriksHobbyLager
{
    class Program
    {
        static void Main()
        {
            var connectionString = @"Data Source=.\HenriksHobbyLager.db"; //Relativ path till databasfilen

            // Instanser av klasser,finns nog bättre sätt att göra detta på
            IProductFacade productFacade = new ProductFacade(connectionString);
            IDisplayService displayService = new DisplayService();
            IInputHandler inputHandler = new InputHandler(displayService, new InputHandler(displayService, null)); //TODO: Fixa null varning
            IProductService productService = new ProductService(productFacade, inputHandler, displayService);

            // Initiera och calla meny
            var consoleMenuHandler = new ConsoleMenuHandler(productService);
            consoleMenuHandler.Navigation();
        }
    }
}