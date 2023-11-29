using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SortDataUsingHeapSort.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Firstmigartion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbSensorDataSamples",
                columns: table => new
                {
                    SensorDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SensorDataName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SensorDataValue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSensorDataSamples", x => x.SensorDataId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbSensorDataSamples");
        }
    }
}
