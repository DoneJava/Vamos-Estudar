using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VamosEstudar.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCPF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Estudante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Estudante");
        }
    }
}
