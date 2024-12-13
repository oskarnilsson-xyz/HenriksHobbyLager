//Oklart om det är bra eller dåligt att ha console reads här och om bra borde alla writelines också gå genom denna
namespace HenriksHobbyLager.Logic
{


    public class InputHandler : IInputHandler
    {
        private readonly IDisplayService? _displayService;
        private readonly IInputHandler _inputHandler;

        public InputHandler(IDisplayService displayService, IInputHandler inputHandler)
        {
            _displayService = displayService;
            _inputHandler = inputHandler;
        }

        public string? ReadLine()
        {
            return Console.ReadLine();
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }

        public IEnumerable<string> ReadFile()
        {
            _displayService?.DisplayMessage("Ange absolut path till .txt filen");
            var inputFilePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputFilePath))
            {
                _displayService?.DisplayMessage("Ogiltig filväg!");
                return Enumerable.Empty<string>();
            }

            if (!File.Exists(inputFilePath))
            {
                _displayService?.DisplayMessage("Filen hittades inte!");
                return Enumerable.Empty<string>();
            }

            var dataImport = File.ReadAllText(inputFilePath);
            var productBlocks = dataImport.Split(new string[] { "----------------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

            return productBlocks;
        }
    }
}
