public interface IInputHandler
{
    string? ReadLine();
    void ReadKey();
    IEnumerable<string> ReadFile();
}