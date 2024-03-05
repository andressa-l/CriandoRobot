using CriandoRobot.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


// Classe de contexto do banco de dados
public class LogContext : DbContext {
    public DbSet<Log> LOGROBO { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //optionsBuilder.UseSqlServer("Server=ANDRESSA-LAPTOP\\SQLEXPRESS; Database=WebScrapingDb; Trusted_Connection=TRUE");
        optionsBuilder.UseSqlServer(
                                    @"Data Source=SQL9001.site4now.net;" + 
                                    "Initial Catalog=db_aa5b20_apialmoxarifado;" + 
                                    "User id=db_aa5b20_apialmoxarifado_admin;" +
                                    "Password=master@123" );
    }
}