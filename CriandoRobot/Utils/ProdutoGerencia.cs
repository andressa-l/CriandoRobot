using CriandoRobot.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriandoRobot.Utils {
    public class ProdutoGerencia {

        public static List<Produto> ObterNovosProdutos(string responseData) {
            
            List<Produto> produtos = JsonConvert.DeserializeObject<List<Produto>>(responseData);
            return produtos;
        }

        public static bool ProdutoJaRegistrado(int idProduto) {
            using (var context = new LogContext()) {
                //return context.LOGROBO.Any(log => log.IdProdutoAPI == idProduto && log.CodigoRobo == "AL10");
                return context.LOGROBO.Any(log => log.IdProdutoAPI == idProduto && log.CodigoRobo == "AL10");
            }
        }
    }
}
