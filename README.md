# CriandoRobot 🤖

O **CriandoRobot** é um utilitário de automação de tarefas e extração de dados da web (*Web Scraping / Crawler*), desenvolvido para monitorar preços e notificar o usuário em tempo real sobre variações e oportunidades.

## 🚀 Sobre o Projeto

Este projeto consiste em um "robô" de monitoramento inteligente desenvolvido em **C#** sobre a plataforma **.NET 6.0**. Ele automatiza o processo de navegação em grandes e-commerces, extrai informações de produtos e gerencia notificações automáticas via e-mail ou WhatsApp.

## 🛠️ Tecnologias Utilizadas

* **Linguagem:** C#
* **Framework:** .NET 6.0
* **ORM:** Entity Framework Core (para persistência de dados e logs)
* **Web Scraping:** Técnicas de crawling para navegação e extração de dados estruturados.

## 📁 Estrutura do Projeto

A arquitetura do projeto é organizada de forma modular para facilitar a manutenção e a escala:

* **`Scraper/`**: Contém a lógica de extração específica para cada site (ex: `MagazineLuizaScraper.cs`, `MercadoLivreScraper.cs`).
* **`Context/` & `Migrations/`**: Gerenciamento da camada de dados e histórico de versões do banco de dados (EF Core).
* **`Models/`**: Definição das entidades de negócio, como `Produto.cs` e `Log.cs`.
* **`Send/`**: Módulos de comunicação responsáveis pelos alertas via `Email.cs` e `EnviarZap.cs`.
* **`Compare/`**: Lógica de processamento para comparar preços capturados (`ComparePrecosCrawler.cs`).
* **`Utils/`**: Classes utilitárias e funções de suporte ao sistema.

## ⚙️ Funcionalidades Principais

1.  **Monitoramento Ativo:** Varredura automatizada em sites de e-commerce.
2.  **Persistência de Dados:** Armazenamento de preços históricos para análise de variação.
3.  **Logs de Execução:** Registro detalhado de cada rotina de scraping no banco de dados.
4.  **Sistema de Alertas Multi-canal:**
    * 📧 Notificações via E-mail.
    * 💬 Alertas diretos via WhatsApp (Zap).

## 🚀 Como Executar

### Pré-requisitos
* [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
* IDE (Visual Studio 2022 ou VS Code)

### Instalação
1. Clone o repositório:
   ```bash
   git clone [https://github.com/seu-usuario/CriandoRobot.git](https://github.com/seu-usuario/CriandoRobot.git)
   ```
   
2. Acesse a pasta do projeto:

Bash
cd CriandoRobot
3. Restaure as dependências e atualize o banco de dados:

Bash
dotnet restore
dotnet ef database update
4. Execute o robô:

Bash
dotnet run

📝 Notas de Versão
O projeto utiliza a estrutura de diretórios do Visual Studio e está configurado para rodar nativamente em ambientes Windows/Linux que suportem .NET 6.0.

Desenvolvido com foco em automação e eficiência.

   <div align="center">Feito com 💜 por <a href="https://github.com/andressa-l">Andressa</a>. Desenvolvido com foco em automação e eficiência.</div>
<br />
