using System.Collections.Generic;

namespace PausDeGiz.App.Models
{
    public class GestorInventario : IInventarioModel
    {
        private Inventario inventario = new Inventario();

        public void AdicionarGiz(Giz giz)
        {
            inventario.AdicionarGiz(giz);
        }

        public List<Giz> ObterGizes()
        {
            return inventario.ObterGizes();
        }
    }
}