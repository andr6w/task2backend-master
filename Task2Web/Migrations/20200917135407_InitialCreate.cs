using Microsoft.EntityFrameworkCore.Migrations;

namespace Task2Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    HId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseNumber = table.Column<int>(nullable: false),
                    HouseCity = table.Column<string>(nullable: false),
                    HouseCountry = table.Column<string>(nullable: false),
                    HousePostIndex = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.HId);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    FlatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatNumber = table.Column<int>(nullable: false),
                    FlatFloor = table.Column<int>(nullable: false),
                    FlatRoomsAmmount = table.Column<int>(nullable: false),
                    FlatResidentsAmmount = table.Column<int>(nullable: false),
                    FlatFullArea = table.Column<double>(nullable: false),
                    FlatLivingSpaceArea = table.Column<double>(nullable: false),
                    HouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.FlatId);
                    table.ForeignKey(
                        name: "FK_Flats_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "HId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Residents",
                columns: table => new
                {
                    ResidentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentName = table.Column<string>(nullable: false),
                    ResidentSurname = table.Column<string>(nullable: false),
                    ResidentPersonalID = table.Column<string>(nullable: false),
                    ResidentBirthday = table.Column<string>(nullable: false),
                    ResidentPhoneNumber = table.Column<string>(nullable: false),
                    ResidentEmail = table.Column<string>(nullable: false),
                    FlatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residents", x => x.ResidentId);
                    table.ForeignKey(
                        name: "FK_Residents_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "FlatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flats_HouseId",
                table: "Flats",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_FlatId",
                table: "Residents",
                column: "FlatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Residents");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
