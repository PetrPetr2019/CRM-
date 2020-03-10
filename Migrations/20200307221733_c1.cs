using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyMailingList.Migrations
{
    public partial class c1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Addressees = table.Column<string>(nullable: true),
                    RecipientsNNN = table.Column<string>(nullable: true),
                    CustomsPost = table.Column<string>(nullable: true),
                    NotificationType = table.Column<string>(nullable: true),
                    Entry = table.Column<bool>(nullable: false),
                    Exit = table.Column<bool>(nullable: false),
                    CargoPlacement = table.Column<bool>(nullable: false),
                    Sacrifieces = table.Column<bool>(nullable: false),
                    ThemachineTP = table.Column<bool>(nullable: false),
                    NumberTC = table.Column<string>(nullable: true),
                    Tyre = table.Column<bool>(nullable: false),
                    TimeEvents = table.Column<bool>(nullable: false),
                    DescriptionCargo = table.Column<string>(nullable: true),
                    Recipient = table.Column<string>(nullable: true),
                    TheconditionSeals = table.Column<bool>(nullable: false),
                    ContentState = table.Column<bool>(nullable: false),
                    RadiationControl = table.Column<bool>(nullable: false),
                    PhoneNumberDrive = table.Column<string>(nullable: true),
                    TimeTransmissionDocumentsDriver = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Informations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(nullable: true),
                    Dynamic = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    TypeInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Informations");
        }
    }
}
