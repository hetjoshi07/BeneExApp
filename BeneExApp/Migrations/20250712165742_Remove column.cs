using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeneExApp.Migrations
{
    /// <inheritdoc />
    public partial class Removecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Beneficiaries");

            migrationBuilder.RenameColumn(
                name: "EmailID",
                table: "Beneficiaries",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Beneficiaries",
                newName: "EmailID");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Beneficiaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}