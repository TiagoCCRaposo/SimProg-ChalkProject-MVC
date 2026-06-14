using System;

namespace PausDeGiz.App.Views
{
    public class ConsoleView : IInventarioView
    {
        public string LerInput()
        {
            return Console.ReadLine() ?? "";
        }

        public void MostrarMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}