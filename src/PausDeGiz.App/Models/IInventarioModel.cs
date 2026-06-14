using System.Collections.Generic;

namespace PausDeGiz.App.Models
{
    public interface IInventarioModel
    {
        void AdicionarGiz(Giz giz);
        List<Giz> ObterGizes();
    }
}
