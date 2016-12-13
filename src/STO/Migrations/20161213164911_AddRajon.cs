using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STO.Migrations
{
    public partial class AddRajon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rajon",
                table: "STO",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rajon",
                table: "STO");
        }
    }
}
