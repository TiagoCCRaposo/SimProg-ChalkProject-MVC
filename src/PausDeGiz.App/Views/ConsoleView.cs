using System;
using System.IO;

namespace PausDeGiz.App.Views
{
    public class ConsoleView
    {
        private string caminhoFicheiro = "inventario.json";

        public string LerInput()
        {
            return Console.ReadLine() ?? "";
        }

        public void MostrarMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        public void GuardarFicheiro(string conteudo)
        {
            File.WriteAllText(caminhoFicheiro, conteudo);
        }

        public string LerFicheiro()
        {
            if (!File.Exists(caminhoFicheiro))
                return "";

            return File.ReadAllText(caminhoFicheiro);
        }
    }
}