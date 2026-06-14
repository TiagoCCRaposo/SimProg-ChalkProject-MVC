namespace PausDeGiz.App.Persistence
{
    public interface ISaveStateManager
    {
        void Gravar(string json);
        string Carregar();
    }
}
