using System;
using Newtonsoft.Json;
using PausDeGiz.App.Models;
using PausDeGiz.App.Views;
using PausDeGiz.App.Persistence;

namespace PausDeGiz.App.Controllers
{
    public class MainController
    {
        private readonly IInventarioView view;
        private readonly IInventarioModel model;
        private readonly PausDeGiz.App.Persistence.ISaveStateManager persistencia;

        public MainController(
            IInventarioView view,
            IInventarioModel model,
            PausDeGiz.App.Persistence.ISaveStateManager persistencia)
        {
            this.view = view;
            this.model = model;
            this.persistencia = persistencia;
        }

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
            model.AdicionarGiz(giz);

            view.MostrarMensagem("Giz adicionado!");
        }

        private void Guardar()
        {
            var lista = model.ObterGizes();

            string json = JsonConvert.SerializeObject(lista, Formatting.Indented);

            persistencia.Gravar(json);

            view.MostrarMensagem("Inventário guardado!");
        }

        private void Carregar()
        {
            try
            {
                string json = persistencia.Carregar();

                if (string.IsNullOrEmpty(json))
                {
                    view.MostrarMensagem("Ficheiro vazio ou inexistente.");
                    return;
                }

                var lista = JsonConvert.DeserializeObject<List<Giz>>(json);

                if (lista != null)
                {
                    foreach (var giz in lista)
                    {
                        model.AdicionarGiz(giz);
                    }
                }

                view.MostrarMensagem("Inventário carregado!");
            }
            catch (Exception)
            {
                view.MostrarMensagem("Erro ao carregar ficheiro JSON.");
            }
        }

        private void ListarGizes()
        {
            var lista = model.ObterGizes();

            if (lista.Count == 0)
            {
                view.MostrarMensagem("Inventário vazio.");
                return;
            }

            foreach (var giz in lista)
            {
                view.MostrarMensagem($"Cor: {giz.Cor}, Quantidade: {giz.Quantidade}");
            }
        }
    }
}