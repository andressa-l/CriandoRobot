using CriandoRobot.Models;
using CriandoRobot.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

public class MagazineLuizaScraper
{
    public ProdutoScraper ObterPreco(string descricaoProduto, int idProduto)
    {
        try
        {
            // Inicializa o ChromeDriver
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl($"https://www.magazineluiza.com.br/busca/{descricaoProduto}");

                System.Threading.Thread.Sleep(5000);

                IWebElement priceElement = driver.FindElement(By.CssSelector("[data-testid='price-value']"));
                IWebElement titleElement = driver.FindElement(By.CssSelector("[data-testid='product-title']"));
                IWebElement urlElement = driver.FindElement(By.CssSelector("[data-testid='product-card-container']"));


                // Verifica se o elemento foi encontrado
                if (priceElement != null)
                {
                    ProdutoScraper produto = new ProdutoScraper();
                    produto.Price = priceElement.Text;
                    produto.Title = titleElement.Text;
                    produto.Url = urlElement.GetAttribute("href");


                    RegistrandoLogs.RegistrarLog("AL10", "andressalima", DateTime.Now, "WebScraping - Magazine Luiza", "Sucesso", idProduto);

                    return produto;
                }
                else
                {
                    Console.WriteLine("Preço não encontrado.");

                    RegistrandoLogs.RegistrarLog("AL10", "andressalima", DateTime.Now, "WebScraping - Magazine Luiza", "Preço não encontrado", idProduto);

                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao acessar a página: {ex.Message}");

            RegistrandoLogs.RegistrarLog("AL10", "andressalima", DateTime.Now, "Web Scraping - Magazine Luiza", $"Erro: {ex.Message}", idProduto);

            return null;
        }
    }

}
