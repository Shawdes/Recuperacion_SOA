using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CURP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero_Empleado = table.Column<int>(type: "int", nullable: true),
                    Fecha_Ingreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activo-Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Empleado = table.Column<int>(type: "int", nullable: false),
                    Id_Activo = table.Column<int>(type: "int", nullable: false),
                    Fecha_Asignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Liberacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Entrega = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activo-Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activo-Empleado_Activos_Id_Activo",
                        column: x => x.Id_Activo,
                        principalTable: "Activos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activo-Empleado_Personas_Id_Empleado",
                        column: x => x.Id_Empleado,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activo-Empleado_Id_Activo",
                table: "Activo-Empleado",
                column: "Id_Activo");

            migrationBuilder.CreateIndex(
                name: "IX_Activo-Empleado_Id_Empleado",
                table: "Activo-Empleado",
                column: "Id_Empleado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activo-Empleado");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Activos");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
