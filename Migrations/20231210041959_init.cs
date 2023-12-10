using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenThumb_Henrik.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instruction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instruction_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gardens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GardenPlant",
                columns: table => new
                {
                    GardensId = table.Column<int>(type: "int", nullable: false),
                    PlantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenPlant", x => new { x.GardensId, x.PlantsId });
                    table.ForeignKey(
                        name: "FK_GardenPlant_Gardens_GardensId",
                        column: x => x.GardensId,
                        principalTable: "Gardens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenPlant_Plants_PlantsId",
                        column: x => x.PlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Oak" },
                    { 2, "Dandelion" },
                    { 3, "Venus Flytrap" },
                    { 4, "Sunflower" },
                    { 5, "Hemp" },
                    { 6, "Barrel Cactus" },
                    { 7, "Bamboo" },
                    { 8, "Wheat" },
                    { 9, "Spider Plant" },
                    { 10, "Strawberry" },
                    { 11, "Jade Plant" },
                    { 12, "Banana" }
                });

            migrationBuilder.InsertData(
                table: "Instruction",
                columns: new[] { "Id", "Name", "PlantId" },
                values: new object[,]
                {
                    { 1, "Give water", 3 },
                    { 2, "Give sunlight", 1 },
                    { 3, "Repot plant when its gotten bigger", 3 },
                    { 4, "Distribute pesticide", 3 },
                    { 5, "Monitor temperature and humidity", 3 },
                    { 6, "Provide support so plant stays upright", 1 },
                    { 7, "Repot plant when its gotten bigger", 1 },
                    { 8, "Repot plant when its gotten bigger", 12 },
                    { 9, "Distribute pesticide", 2 },
                    { 10, "Distribute pesticide", 5 },
                    { 11, "Provide support so plant stays upright", 4 },
                    { 12, "Give water", 5 },
                    { 13, "Give sunlight", 5 },
                    { 14, "Monitor temperature and humidity", 5 },
                    { 15, "Give sunlight", 6 },
                    { 16, "Monitor Temperature and humidity", 7 },
                    { 17, "Give water", 8 },
                    { 18, "Distribute pesticide", 8 },
                    { 19, "Give water", 9 },
                    { 20, "Monitor temperature and humidity", 9 },
                    { 21, "Give sunlight", 10 },
                    { 22, "Distribute pesticide", 10 },
                    { 23, "Give water", 11 },
                    { 24, "Give sunlight", 12 },
                    { 25, "Distribute pesticide", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenPlant_PlantsId",
                table: "GardenPlant",
                column: "PlantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_UserId",
                table: "Gardens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instruction_PlantId",
                table: "Instruction",
                column: "PlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenPlant");

            migrationBuilder.DropTable(
                name: "Instruction");

            migrationBuilder.DropTable(
                name: "Gardens");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
