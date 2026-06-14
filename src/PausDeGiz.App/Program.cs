using System;
using System.Collections.Generic;

namespace PausDeGiz
{
    // =========================================================================
    // 1. CONTRATOS / INTERFACES (Definição dos canais de comunicação)
    // =========================================================================

    /// <summary>
    /// Máscara para ocultar o tipo de dados concreto do Produto.
    /// </summary>
    public interface IProduto
    {
        int Id { get; }
        string Nome { get; }
        int Quantidade { get; }
        double Preco { get; }
    }

    /// <summary>
    /// Máscara para o motor de armazenamento, isolando o formato físico dos dados.
    /// </summary>
    public interface ISaveStateManager
    {
        void GravarDados(string caminho, IEnumerable<IProduto> produtos);
        IEnumerable<IProduto> CarregarDados(string caminho);
    }

    // =========================================================================
    // 2. COMPONENTES CONCRETOS (Implementação das classes)
    // =========================================================================

    /// <summary>
    /// Entidade concreta que assina o contrato IProduto.
    /// </summary>
    public class Produto : IProduto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public double Preco { get; private set; }

        public Produto(int id, string nome, int quantidade, double preco)
        {
            Id = id;
            Nome = nome;
            Quantidade = quantidade;
            Preco = preco;
        }
    }

    /// <summary>
    /// Motor de Persistência JSON concreto (Alinhado com a arquitetura do projeto).
    /// </summary>
    public class PersistenciaJson : ISaveStateManager
    {
        public void GravarDados(string caminho, IEnumerable<IProduto> produtos)
        {
            Console.WriteLine($"\n[PERSISTÊNCIA] A abrir canal para o ficheiro: {caminho}");
            Console.WriteLine("[PERSISTÊNCIA] A serializar objetos IProduto para JSON...");
            foreach (var p in produtos)
            {
                Console.WriteLine($" -> [JSON Escreveu]: ID {p.Id} | {p.Nome} | Qtd: {p.Quantidade}");
            }
            Console.WriteLine("[PERSISTÊNCIA] Operação de escrita concluída com sucesso.");
        }

        public IEnumerable<IProduto> CarregarDados(string caminho)
        {
            Console.WriteLine($"\n[PERSISTÊNCIA] A ler fluxo físico de: {caminho}");
            
            // Retorna uma lista simulada que cumpre o contrato da interface
            return new List<IProduto>
            {
                new Produto(1, "Giz Branco Caixa 100", 120, 1.50),
                new Produto(2, "Cera de Modelar Azul", 45, 2.30)
            };
        }
    }

    // =========================================================================
    // 3. LÓGICA DE NEGÓCIO (Demonstração do Acoplamento Fraco)
    // =========================================================================

    /// <summary>
    /// O Model Nuclear da aplicação. Não conhece classes de persistência,
    /// depende exclusivamente do contrato ISaveStateManager.
    /// </summary>
    public class ModelNuclear
    {
        private readonly List<IProduto> _inventario = new List<IProduto>();
        private readonly ISaveStateManager _storage;

        // Injeção de Dependência pelo construtor (Garante o desacoplamento)
        public ModelNuclear(ISaveStateManager storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public void RegistarProduto(IProduto produto)
        {
            _inventario.Add(produto);
            Console.WriteLine($"[MODEL] Core de Negócio processou e aceitou o produto: {produto.Nome}");
        }

        public void GuardarEstado(string localizacao)
        {
            // O Model comunica apenas através da máscara abstrata
            _storage.GravarDados(localizacao, _inventario);
        }
    }

    // =========================================================================
    // 4. ORQUESTRAÇÃO / FLUXO PRINCIPAL
    // =========================================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================================================");
            Console.WriteLine("  PAUS DE GIZ - PROVA DE CONCEITO (INTERFACES EXTRAT) ");
            Console.WriteLine("======================================================\n");

            // 1. Instanciamos a classe concreta do motor de dados
            ISaveStateManager motorJson = new PersistenciaJson();

            // 2. Injetamos o motor no Model. O Model só vê a interface!
            ModelNuclear model = new ModelNuclear(motorJson);

            // 3. Simulação de fluxo de dados vindo do Controller/View
            IProduto novoGiz = new Produto(101, "Giz Antialérgico Cores", 50, 3.10);
            model.RegistarProduto(novoGiz);

            // 4. Guardar dados de forma abstrata
            model.GuardarEstado("stock.json");

            Console.WriteLine("\n======================================================");
            Console.WriteLine("  Demonstração concluída. Acoplamento Fraco Validado! ");
            Console.WriteLine("======================================================");
            Console.ReadLine();
        }
    }
}
