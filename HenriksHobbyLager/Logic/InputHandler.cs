using HenriksHobbyLager.Interfaces;

namespace HenriksHobbyLager.Logic
{


    public class InputHandler : IInputHandler
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }
    }
}
