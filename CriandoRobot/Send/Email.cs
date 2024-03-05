using CriandoRobot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CriandoRobot.Send
{
    public class VerificarEmail {

        public static bool EnviarEmail(string destinoEmail, string nomeProdutoMercadoLivre, string precoProdutoMercadoLivre, string nomeProdutoMagazineLuiza, string precoProdutoMagazineLuiza, string verificarValor, string nomeProduto, int idProduto) {
            // Configurações do servidor SMTP do Hotmail
            string smtpServer = "smtp-mail.outlook.com"; // Servidor SMTP do Hotmail
            int porta = 587; // Porta SMTP do Hotmail para TLS/STARTTLS
            string remetente = "testinho_para_robot@outlook.com"; // Seu endereço de e-mail do Hotmail
            string senha = "robot*123"; // Sua senha do Hotmail

            // Configurar cliente SMTP
            using (SmtpClient client = new SmtpClient(smtpServer, porta)) {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(remetente, senha);
                client.EnableSsl = true; // Habilitar SSL/TLS

                // Construir mensagem de e-mail
                MailMessage mensagem = new MailMessage(remetente, destinoEmail) {
                    Subject = $"Benchmarking {nomeProduto}",
                    Body = $"Mercado Livre\n" +
                           $"Produto: {nomeProduto}\n" +
                           $"Preço: R$ {precoProdutoMercadoLivre}\n\n" +
                           $"Magazine Luiza\n" +
                           $"Produto: {nomeProduto}\n" +
                           $"Preço: R$ {precoProdutoMagazineLuiza}\n\n" +
                           $"Melhor compra: {verificarValor}" +
                                   "\n" +
                                   "Robo: AL10\n" +
                                   "Usuario: andressalima"
                };

                Console.WriteLine(nomeProdutoMercadoLivre);
                Console.WriteLine(precoProdutoMercadoLivre);
                Console.WriteLine(nomeProdutoMagazineLuiza);
                Console.WriteLine(precoProdutoMagazineLuiza);

                try {

                    // Enviar e-mail
                    client.Send(mensagem);
                    RegistrandoLogs.RegistrarLog("AL10", "andressalima", DateTime.Now, "Envio de Email", "Sucesso", idProduto);
                    Console.WriteLine($"Email enviado com sucesso! ");
                    return true;

                }catch (Exception ex) {
                    Console.WriteLine("Deu erro no Email: " + ex.Message);
                    return false;
                }

                

            }
        }

        public static string OpcaoMsgEmail() {
            Console.WriteLine("Você Deseja Receber as melhores oportunidades de compra pelo Email? Sim ou Nao");
            string opcoes = Console.ReadLine();
            string endereco = "";
            if (opcoes.ToUpper().Equals("SIM")) {
                Console.WriteLine("Insira o seu Email - Ex: limak@hotmail.com");
                endereco = Console.ReadLine();
                return endereco;
            }
            return null;
        }

    }
}
