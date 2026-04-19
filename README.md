# ChalkInventory Manager

![C#](https://img.shields.io/badge/C%23-.NET-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-6.0+-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Newtonsoft.Json](https://img.shields.io/badge/Newtonsoft.Json-JSON-black?style=for-the-badge&logo=json&logoColor=white)
![Status](https://img.shields.io/badge/Status-Em%20Desenvolvimento-orange?style=for-the-badge)
![LDS](https://img.shields.io/badge/LDS-2025%2F2026-blue?style=for-the-badge&logo=academia&logoColor=white)

> Protótipo de aplicação para gestão de inventário de paus de giz, desenvolvido no âmbito da unidade curricular de **Laboratório de Desenvolvimento de Software 2025** — SimProgramming.

---

## 👥 Equipa — Paus de Giz

| Função | Nome |
|---|---|
| Líder | Tiago Raposo |
| Desenvolvedor | Nuno Barros |
| Verificador | Luís Teixeira |

---

## 📋 Sobre o Projeto

O **ChalkInventory Manager** é uma aplicação de consola desenvolvida em C# que permite gerir um inventário de paus de giz de forma persistente. O projeto segue os princípios de engenharia de software abordados nas fases de análise e desenho arquitetónico, com especial enfoque na separação de responsabilidades através do padrão MVC.

---

## 🛠️ Detalhes Técnicos

| Aspeto | Detalhe |
|---|---|
| **Linguagem** | C# (.NET) |
| **Arquitetura** | MVC — Krasner & Pope (1988) |
| **Persistência** | Newtonsoft.Json (ficheiros `.json`) |
| **Interface** | Consola (CLI) |

### Arquitetura MVC

O projeto segue o padrão **Model–View–Controller** conforme definido por Krasner & Pope:

- **Model** — Define as entidades de dados do domínio (e.g., `ChalkItem`, `Inventory`).
- **Controller** — Centraliza todo o processamento de input e orquestra a lógica de negócio. É o ponto de entrada de todas as ações do utilizador.
- **View** — Responsável exclusivamente pela apresentação na consola e pelas operações físicas de leitura/escrita de ficheiros, via integração com a biblioteca **Newtonsoft.Json**.

---

## 📂 Estrutura do Repositório

```
ChalkInventoryManager/
├── src/
│   ├── Models/          # Entidades de dados (classes de negócio)
│   ├── Controllers/     # Lógica de controlo, orquestração e integração Newtonsoft.Json
│   └── Views/           # Interface de consola e operações de I/O físico
├── docs/                # Diagramas de Sequência e de Componentes (imagens e ficheiros de suporte)
├── .gitignore           # Exclusão de ficheiros temporários de compilação
└── README.md            # Guia de apresentação e instruções do projeto
```

---

## 🚀 Como Executar

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado (versão 6.0 ou superior recomendada)

### Passos

```bash
# 1. Clonar o repositório
git clone https://github.com/TiagoCCRaposo/chalkinventory-manager.git

# 2. Entrar na pasta do projeto
cd ChalkInventoryManager

# 3. Executar a aplicação
dotnet run
```

---

## 📚 Contexto Académico

| Campo | Detalhe |
|---|---|
| **Unidade Curricular** | Laboratório de Desenvolvimento de Software |
| **Ano Letivo** | 2025/2026 |
| **Empresa Fictícia** | SimProgramming |
| **Equipa** | Paus de Giz |
