using System.IO;

namespace PausDeGiz.App.Persistence
{
    public class PersistenciaJson : ISaveStateManager
    {
        private string caminho = "inventario.json";

        public void Gravar(string json)
        {
            File.WriteAllText(caminho, json);
        }

        public string Carregar()
        {
            if (!File.Exists(caminho))
                return "";

            return File.ReadAllText(caminho);
        }
    }
}