using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyCenterCore.Migrations
{
    public partial class faca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "FacturaDetalles");

            migrationBuilder.AddColumn<string>(
                name: "Servicios",
                table: "FacturaDetalles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Servicios",
                table: "FacturaDetalles");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "FacturaDetalles",
                nullable: false,
                defaultValue: 0);
        }
    }
}
