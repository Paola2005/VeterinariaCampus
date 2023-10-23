using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Ciudad_CiudadId",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "CiudadId",
                table: "Cliente",
                newName: "CiudadesId");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_CiudadId",
                table: "Cliente",
                newName: "IX_Cliente_CiudadesId");

            migrationBuilder.AddColumn<int>(
                name: "IdCiudad",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Ciudad_CiudadesId",
                table: "Cliente",
                column: "CiudadesId",
                principalTable: "Ciudad",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Ciudad_CiudadesId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "IdCiudad",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "CiudadesId",
                table: "Cliente",
                newName: "CiudadId");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_CiudadesId",
                table: "Cliente",
                newName: "IX_Cliente_CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Ciudad_CiudadId",
                table: "Cliente",
                column: "CiudadId",
                principalTable: "Ciudad",
                principalColumn: "Id");
        }
    }
}
