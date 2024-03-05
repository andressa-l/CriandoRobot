﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CriandoRobot.Models;

namespace CriandoRobot.Utils
{
    public class RegistrandoLogs
    {

        // Método para registrar um log no banco de dados
        public static void RegistrarLog(string codRob, string usuRob, DateTime dateLog, string processo, string infLog, int idProd)
        {
            using (var context = new LogContext())
            {
                var log = new Log
                {
                    CodigoRobo = codRob,
                    UsuarioRobo = usuRob,
                    DateLog = dateLog,
                    Etapa = processo,
                    InformacaoLog = infLog,
                    IdProdutoAPI = idProd
                };
                context.LOGROBO.Add(log);
                context.SaveChanges();
            }
        }
    }
}
