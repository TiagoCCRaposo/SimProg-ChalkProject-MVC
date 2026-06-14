using System.Collections.Generic;

namespace PausDeGiz.App.Models
{
    public class Inventario
    {
        // lista interna (não exposta diretamente)
        private readonly List<Giz> gizes = new List<Giz>();

        // adicionar giz
        public void AdicionarGiz(Giz giz)
        {
            gizes.Add(giz);
        }

        // obter lista (apenas leitura externa)
        public List<Giz> ObterGizes()
        {
            return new List<Giz>(gizes);
        }

        // opcional (útil para carregamento JSON)
        public void Limpar()
        {
            gizes.Clear();
        }
    }
}