using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Net.Mail;
using HtmlAgilityPack;
using CriandoRobot.Models;

namespace CriandoRobot.Compare
{
    internal class ComparePrecosCrawler
    {
    }
}


class ComparePrecosCrawler
{
    static async Task Main(string[] args)
    {
        // URLs dos produtos 
        var urlMagalu = "URL_DO_PRODUTO_MAGAZINE_LUIZA";
        var urlMercadoLivre = "URL_DO_PRODUTO_MERCADO_LIVRE";

        // Obtenha os dados dos produtos
        var productMagalu = await GetProductData(urlMagalu);
        var productMercadoLivre = await GetProductData(urlMercadoLivre);

        // Determine o melhor preço e construa a mensagem do e-mail
        var bestPriceInfo = GetBestPriceEmailBody(productMagalu, productMercadoLivre);

        // Envie o e-mail
        SendEmail(bestPriceInfo);

        var priceMagalu = GetPriceFromMagalu(urlMagalu);
        var priceMercadoLivre = GetPriceFromMercadoLivre(urlMercadoLivre);

        Console.WriteLine($"Preço Magazine Luiza: R${priceMagalu}");
        Console.WriteLine($"Preço Mercado Livre: R${priceMercadoLivre}");

        if (priceMagalu < priceMercadoLivre)
        {
            Console.WriteLine("O produto está mais barato na Magazine Luiza.");
        }
        else if (priceMagalu > priceMercadoLivre)
        {
            Console.WriteLine("O produto está mais barato no Mercado Livre.");
        }
        else
        {
            Console.WriteLine("Os preços são iguais.");
        }
    }

    static decimal GetPriceFromMagalu(string url)
    {
        var web = new HtmlWeb();
        var doc = web.Load(url);
        var node = doc.DocumentNode.SelectSingleNode("//SELETOR_DO_PRECO_MAGALU");
        var priceText = node.InnerText.Trim();
        return Convert.ToDecimal(priceText.Substring(3).Replace(",", "."));
    }

    static decimal GetPriceFromMercadoLivre(string url)
    {
        var web = new HtmlWeb();
        var doc = web.Load(url);
        var node = doc.DocumentNode.SelectSingleNode("//SELETOR_DO_PRECO_MERCADO_LIVRE");
        var priceText = node.InnerText.Trim();
        return Convert.ToDecimal(priceText.Substring(3).Replace(",", "."));
    }

    static async Task<Produto> GetProductData(string url)
    {
        // Implemente a lógica para extrair os dados do produto usando HttpClient e HtmlAgilityPack
        // Retorne um objeto Product com os dados extraídos
    }

    static string GetBestPriceEmailBody(Produto productMagalu, Produto productMercadoLivre)
    {
        // Implemente a lógica para comparar os preços e construir o corpo do e-mail
        // Retorne a string formatada para o corpo do e-mail
    }


}