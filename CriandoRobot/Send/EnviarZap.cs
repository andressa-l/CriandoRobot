using CriandoRobot.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriandoRobot.Send
{
    public class EnviarZap {
        public async static void EnviarMsg(int produtoid, string phoneNumber, string nomeProduto, string precoProdutoMagazineLuiza, string precoProdutoMercadoLivre, string verificarValor) {



            try {

                var parameters = new System.Collections.Specialized.NameValueCollection();
                var client = new System.Net.WebClient();

                var url = "https://app.whatsgw.com.br/api/WhatsGw/Send/";

                parameters.Add("apikey", "0ef0b672-fe36-4af2-b697-c61223ec2651");
                parameters.Add("phone_number", "5579998146345");
                parameters.Add("contact_phone_number", phoneNumber);
                parameters.Add("message_custom_id", "teste");
                parameters.Add("message_type", "text");
                parameters.Add("message_body",
                               $"*Benchmarking* {nomeProduto}\n" +
                               $"*Mercado Livre*\n" +
                               $"*Produto*: {nomeProduto}\n" +
                               $"*Preço*: R$ {precoProdutoMercadoLivre}\n\n" +
                               $"*Magazine Luiza*\n" +
                               $"*Produto*: {nomeProduto}\n" +
                               $"*Preço*: R$ {precoProdutoMagazineLuiza}\n\n" +
                               $"*Melhor compra*: {verificarValor}" +
                               "\n" +
                               "Robo: AL10\n" +
                               "Usuario: andressalima"
                 );


                byte[] response_data;
                string responseString = "";

                response_data = await client.UploadValuesTaskAsync(url, "POST", parameters);
                responseString = Encoding.UTF8.GetString(response_data);
                Console.WriteLine("Response String: " + responseString);
                RegistrandoLogs.RegistrarLog("AL10", "andressalima", DateTime.Now, "EnviarZap", "Sucesso", produtoid);
                Console.WriteLine($"Zap enviado com sucesso! ");


            }
            catch (Exception ex) {
                RegistrandoLogs.RegistrarLog("AL10", "andressalima", DateTime.Now, "EnviarZap", "Erro", produtoid);
                Console.WriteLine($"Erro na Mensagem: {ex.Message}");
                Console.WriteLine("Conferir se o WhatssapWeb está Incluido no navegador!");
            }



        }

        public static string OpcaoMsgZap() {
            Console.WriteLine("Você Deseja Receber os Dados pelo telefone? Sim ou Nao");
            string options = Console.ReadLine();
            string numero = "";
            if (options.ToUpper().Equals("SIM")) {
                Console.WriteLine("Insira o seu Número do Whatssap - Ex: 79999999991");
                numero = "55" + Console.ReadLine();
                return numero;
            }
            return null;
        }


    }
}
