using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using CriandoRobot.Models;
using System.Net.Mail;
using System.Net;
using System.Reflection.Metadata;
using HtmlAgilityPack;
using CriandoRobot.Send;
using CriandoRobot.Compare;
using CriandoRobot.Utils;

class Program
{

    public static void Main(string[] args)
    {
        Console.WriteLine("Iniciando Projeto...");
        string contactEmail = VerificarEmail.OpcaoMsgEmail();
        while (contactEmail == null) {
            Console.WriteLine("Vamos digitar um email válido!");
            contactEmail = VerificarEmail.OpcaoMsgEmail();
        }
        string phoneNumber = EnviarZap.OpcaoMsgZap();
        
        int intervalo = 300000;

        Timer timer = new Timer(state => VerificarProduto.VerificarNovoProduto(phoneNumber, contactEmail), null, 0, intervalo);
        
        while (true) {
            Thread.Sleep(Timeout.Infinite);
        };

    }

}