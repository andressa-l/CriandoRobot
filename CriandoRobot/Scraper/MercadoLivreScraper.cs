using CriandoRobot.Models;
using CriandoRobot.Utils;
using HtmlAgilityPack;
using System;

public class MercadoLivreScraper
{
    public ProdutoScraper ObterPreco(string descricaoProduto, int idProduto)
    {
        string url = $"https://lista.mercadolivre.com.br/{descricaoProduto}";

        try
        {
            // Inicializa o HtmlWeb do HtmlAgilityPack
            HtmlWeb web = new HtmlWeb();

            HtmlDocument document = web.Load(url);
            HtmlNode firstProductPriceNode = document.DocumentNode.SelectSingleNode("//span[@class='andes-money-amount__fraction']");
            HtmlNode firstProductTitleNode = document.DocumentNode.SelectSingleNode("//h2[@class='ui-search-item__title']");
            HtmlNode firstProductUrlNode = document.DocumentNode.SelectSingleNode("//a[contains(@class, 'ui-search-link__title-card')]");

            if (firstProductPriceNode != null)
            {
                string firstProductPrice = firstProductPriceNode.InnerText.Trim();
                string firstProductTitle = firstProductTitleNode.InnerText.Trim();
                string firstProductUrl = firstProductUrlNode.GetAttributeValue("href", "");

                RegistrandoLogs.RegistrarLog("AL10", "andressalima", DateTime.Now, "WebScraping - Mercado Livre", "Sucesso", idProduto);

                ProdutoScraper produto = new ProdutoScraper();
                produto.Title = firstProductTitle;
                produto.Price = firstProductPrice;
                produto.Url = firstProductUrl;

                return produto;
            }
            else
            {
                Console.WriteLine("Preço não encontrado.");

                RegistrandoLogs.RegistrarLog("AL10", "andressalima", DateTime.Now, "WebScraping - Mercado Livre", "Preço não encontrado", idProduto);

                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao acessar a página: {ex.Message}");

            RegistrandoLogs.RegistrarLog("AL10", "andressalima", DateTime.Now, "Web Scraping - Mercado Livre", $"Erro: {ex.Message}", idProduto);

            return null;
        }
    }

}





