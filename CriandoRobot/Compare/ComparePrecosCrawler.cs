using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using HtmlAgilityPack;
using CriandoRobot.Utils;

namespace CriandoRobot.Compare
{
    class Benchmarking {
        public string CompararPrecos(string firstProductPrice, string secondProductPrice, string nomeProduto, int idProduto) {

            var priceMercado = firstProductPrice.Replace(".", "");
            var priceMagazine = secondProductPrice.Trim(new Char[] { ' ', 'R', '$' }).Replace(".", "");

            var precoMercado = Double.Parse(priceMercado);
            var precoMagalu = Double.Parse(priceMagazine);


            string linkMercado = $"https://mercadolivre.com.br/{nomeProduto}".Replace(' ', '+');
            string linkLuiza = $"https://www.magazineluiza.com.br/busca/{nomeProduto}".Replace(' ', '+');

            if (precoMercado > precoMagalu) {
                RegistrandoLogs.RegistrarLog("AL10", "andressalima", DateTime.Now, "Benchmarking", "Sucesso", idProduto);

                return "O produto na Magazine Luiza está mais em conta - " + linkLuiza;
            }
            else if (precoMagalu > precoMercado) {
                RegistrandoLogs.RegistrarLog("AL10", "andressalima", DateTime.Now, "Benchmarking", "Sucesso", idProduto);
                return "O produto no Mercado Livre está mais em conta - " + linkMercado;
            }
            else {
                RegistrandoLogs.RegistrarLog("AL10", "andressalima", DateTime.Now, "Benchmarking", "Alerta", idProduto);
                return "Os preços são iguais.";
            }
        }


    }
}
