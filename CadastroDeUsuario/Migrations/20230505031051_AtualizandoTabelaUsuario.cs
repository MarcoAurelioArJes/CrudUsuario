using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeUsuario.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "UsuarioModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "UsuarioModel");
        }
    }
}
