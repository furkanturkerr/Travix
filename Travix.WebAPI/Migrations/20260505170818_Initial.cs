using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelLists",
                columns: table => new
                {
                    HotelListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeHotelCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeHotelCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeHotelLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeHotelAdults = table.Column<int>(type: "int", nullable: false),
                    HomeHotelRoom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelLists", x => x.HotelListId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelLists");
        }
    }
}
