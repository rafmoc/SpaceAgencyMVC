using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceAgency.Data.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelOrder",
                columns: table => new
                {
                    IdTravelOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTravelSesion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTravel = table.Column<int>(type: "int", nullable: false),
                    TravelIdTravel = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelOrder", x => x.IdTravelOrder);
                    table.ForeignKey(
                        name: "FK_TravelOrder_Travel_TravelIdTravel",
                        column: x => x.TravelIdTravel,
                        principalTable: "Travel",
                        principalColumn: "IdTravel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelOrder_TravelIdTravel",
                table: "TravelOrder",
                column: "TravelIdTravel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelOrder");
        }
    }
}
