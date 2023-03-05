using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProDigiMVC.Infrastructure.Migrations
{
    public partial class dev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customerContactInformation_Customers_CustomerRef",
                table: "customerContactInformation");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customerContactInformation",
                table: "customerContactInformation");

            migrationBuilder.DropColumn(
                name: "CustomerContactInformationRef",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "customerContactInformation",
                newName: "CustomerContactInformation");

            migrationBuilder.RenameIndex(
                name: "IX_customerContactInformation_CustomerRef",
                table: "CustomerContactInformation",
                newName: "IX_CustomerContactInformation_CustomerRef");

            migrationBuilder.AddColumn<string>(
                name: "CEOFirstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CEOLastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "LogoPicture",
                table: "Customers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "REGON",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerContactInformation",
                table: "CustomerContactInformation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuldingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlatNumber = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContactInformation_Customers_CustomerRef",
                table: "CustomerContactInformation",
                column: "CustomerRef",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContactInformation_Customers_CustomerRef",
                table: "CustomerContactInformation");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerContactInformation",
                table: "CustomerContactInformation");

            migrationBuilder.DropColumn(
                name: "CEOFirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CEOLastName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LogoPicture",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "REGON",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "CustomerContactInformation",
                newName: "customerContactInformation");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerContactInformation_CustomerRef",
                table: "customerContactInformation",
                newName: "IX_customerContactInformation_CustomerRef");

            migrationBuilder.AddColumn<int>(
                name: "CustomerContactInformationRef",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_customerContactInformation",
                table: "customerContactInformation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AdressType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuldingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlatNumber = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_CustomerId",
                table: "Adresses",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_customerContactInformation_Customers_CustomerRef",
                table: "customerContactInformation",
                column: "CustomerRef",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
