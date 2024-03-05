using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CriandoRobot.Migrations
{
    public partial class NewDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "LOGROBO");

            migrationBuilder.RenameColumn(
                name: "IdLog",
                table: "LOGROBO",
                newName: "iDlOG");

            migrationBuilder.RenameColumn(
                name: "UsuRob",
                table: "LOGROBO",
                newName: "UsuarioRobo");

            migrationBuilder.RenameColumn(
                name: "Processo",
                table: "LOGROBO",
                newName: "InformacaoLog");

            migrationBuilder.RenameColumn(
                name: "InfLog",
                table: "LOGROBO",
                newName: "Etapa");

            migrationBuilder.RenameColumn(
                name: "IdProd",
                table: "LOGROBO",
                newName: "IdProdutoAPI");

            migrationBuilder.RenameColumn(
                name: "CodRob",
                table: "LOGROBO",
                newName: "CodigoRobo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LOGROBO",
                table: "LOGROBO",
                column: "iDlOG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LOGROBO",
                table: "LOGROBO");

            migrationBuilder.RenameTable(
                name: "LOGROBO",
                newName: "Logs");

            migrationBuilder.RenameColumn(
                name: "iDlOG",
                table: "Logs",
                newName: "IdLog");

            migrationBuilder.RenameColumn(
                name: "UsuarioRobo",
                table: "Logs",
                newName: "UsuRob");

            migrationBuilder.RenameColumn(
                name: "InformacaoLog",
                table: "Logs",
                newName: "Processo");

            migrationBuilder.RenameColumn(
                name: "IdProdutoAPI",
                table: "Logs",
                newName: "IdProd");

            migrationBuilder.RenameColumn(
                name: "Etapa",
                table: "Logs",
                newName: "InfLog");

            migrationBuilder.RenameColumn(
                name: "CodigoRobo",
                table: "Logs",
                newName: "CodRob");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "IdLog");
        }
    }
}
