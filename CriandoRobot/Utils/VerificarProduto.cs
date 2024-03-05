using CriandoRobot.Compare;
using CriandoRobot.Models;
using CriandoRobot.Send;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CriandoRobot.Utils {
    public class VerificarProduto {
        static List<Produto> produtosVerificados = new List<Produto>();
        public static async void VerificarNovoProduto(object state, object state2) {
            string contactEmail = state2 as string;
            string phoneNumber = state as string;
            string username = "11164448";
            string senha = "60-dayfreetrial";
            string url = "http://regymatrix-001-site1.ktempurl.com/api/v1/produto/getall";

            try {
                using (HttpClient client = new HttpClient()) {
                    var byteArray = Encoding.ASCII.GetBytes($"{username}:{senha}");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode) {
                        string responseData = await response.Content.ReadAsStringAsync();

                        List<Produto> novosProdutos = ProdutoGerencia.ObterNovosProdutos(responseData);
                        foreach (Produto produto in novosProdutos) {
                            if (!produtosVerificados.Exists(p => p.Id == produto.Id)) {
                                Console.WriteLine($"Novo produto encontrado: ID {produto.Id}, Nome: {produto.Nome}");
                                produtosVerificados.Add(produto);

                                if (!ProdutoGerencia.ProdutoJaRegistrado(produto.Id)) {

                                    RegistrandoLogs.RegistrarLog("AL10", "andressalima", DateTime.Now, "Consultar Dados - Verificar", "Sucesso", produto.Id);

                                    MagazineLuizaScraper magazineLuizaScraper = new MagazineLuizaScraper();
                                    MercadoLivreScraper mercadoLivreScraper = new MercadoLivreScraper();
                                    Benchmarking benchmarking = new Benchmarking();

                                    var precoMagazineLuiza = magazineLuizaScraper.ObterPreco(produto.Nome, produto.Id);
                                    var precoMercadoLivre = mercadoLivreScraper.ObterPreco(produto.Nome, produto.Id);
                                    var precoComparado = benchmarking.CompararPrecos(precoMercadoLivre.Price, precoMagazineLuiza.Price, produto.Nome, produto.Id);


                                    if (phoneNumber != null && contactEmail != null) {
                                        VerificarEmail.EnviarEmail(contactEmail, produto.Nome, precoMercadoLivre.Price, produto.Nome, precoMagazineLuiza.Price, precoComparado, produto.Nome, produto.Id);
                                        EnviarZap.EnviarMsg(produto.Id, phoneNumber, produto.Nome, precoMagazineLuiza.Price, precoMercadoLivre.Price, precoComparado);
                                    }

                                }
                            }
                        }
                    }
                    else {
                        // Imprimir mensagem de erro caso a requisição falhe
                        Console.WriteLine($"Erro: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex) {
                // Imprimir mensagem de erro caso ocorra uma exceção
                Console.WriteLine($"Erro ao fazer a requisição: {ex.Message}");
            }
        }
    }
}
