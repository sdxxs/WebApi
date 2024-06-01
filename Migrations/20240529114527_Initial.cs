using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OwnListOfObservationsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chatId = table.Column<long>(type: "bigint", nullable: false),
                    speciesCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    comName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sciName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    obsDt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    howMany = table.Column<int>(type: "int", nullable: false),
                    lat = table.Column<float>(type: "real", nullable: false),
                    lng = table.Column<float>(type: "real", nullable: false),
                    obsValid = table.Column<bool>(type: "bit", nullable: false),
                    obsReviewed = table.Column<bool>(type: "bit", nullable: false),
                    locationPrivate = table.Column<bool>(type: "bit", nullable: false),
                    subId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnListOfObservationsInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionsUkraie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionsUkraie", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnListOfObservationsInfo");

            migrationBuilder.DropTable(
                name: "RegionsUkraie");
        }
    }
}
