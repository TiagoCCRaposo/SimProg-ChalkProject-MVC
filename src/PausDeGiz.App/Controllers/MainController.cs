using System;
using Newtonsoft.Json;
using PausDeGiz.App.Models;
using PausDeGiz.App.Views;

namespace PausDeGiz.App.Controllers
{
    public class MainController
    {
        private ConsoleView view = new ConsoleView();
        private Inventario inventario = new Inventario();

        public void Iniciar()
        {
            view.MostrarMensagem("Sistema iniciado...");

            while (true)
            {
                view.MostrarMensagem("\n1 - Adicionar Giz");
                view.MostrarMensagem("2 - Guardar");
                view.MostrarMensagem("3 - Carregar");
                view.MostrarMensagem("4 - Listar Gizes");
                view.MostrarMensagem("0 - Sair");

                string opcao = view.LerInput();

                switch (opcao)
                {
                    case "1":
                        AdicionarGiz();
                        break;
                    case "2":
                        Guardar();
                        break;
                    case "3":
                        Carregar();
                        break;
                    case "0":
                        return;
                    case "4":
                        ListarGizes();
                        break;
                }
            }
        }

        private void AdicionarGiz()
        {
            view.MostrarMensagem("Cor do giz:");
            string cor = view.LerInput();

            if (string.IsNullOrWhiteSpace(cor))
            {
                view.MostrarMensagem("Cor inválida!");
                return;
            }

            view.MostrarMensagem("Quantidade:");
            int quantidade;
            bool valido = int.TryParse(view.LerInput(), out quantidade);

            if (!valido)
            {
                view.MostrarMensagem("Quantidade inválida!");
                return;
            }

            Giz giz = new Giz { Cor = cor, Quantidade = quantidade };
            inventario.Gizes.Add(giz);

            view.MostrarMensagem("Giz adicionado!");
        }

        private void Guardar()
        {
            string json = JsonConvert.SerializeObject(inventario, Formatting.Indented);
            view.GuardarFicheiro(json);

            view.MostrarMensagem("Inventário guardado!");
        }

        private void Carregar()
        {
            try
            {
                string json = view.LerFicheiro();

                if (string.IsNullOrEmpty(json))
                {
                    view.MostrarMensagem("Ficheiro vazio ou inexistente.");
                    return;
                }

                inventario = JsonConvert.DeserializeObject<Inventario>(json) ?? new Inventario();

                view.MostrarMensagem("Inventário carregado!");
            }
            catch (Exception)
            {
                view.MostrarMensagem("Erro ao carregar ficheiro JSON. O ficheiro pode estar corrompido.");
                inventario = new Inventario(); // evita crash
            }
        }

        private void ListarGizes()
        {
            if (inventario.Gizes.Count == 0)
            {
                view.MostrarMensagem("Inventário vazio.");
                return;
            }

            view.MostrarMensagem("Lista de Gizes:");

            foreach (var giz in inventario.Gizes)
            {
                view.MostrarMensagem($"Cor: {giz.Cor}, Quantidade: {giz.Quantidade}");
            }
        }
    }
}