using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenThumb_Henrik.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.Id);
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
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_Instructions_InstructionId",
                        column: x => x.InstructionId,
                        principalTable: "Instructions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GardenModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GardenModel_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GardenModelPlantModel",
                columns: table => new
                {
                    GardensId = table.Column<int>(type: "int", nullable: false),
                    PlantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenModelPlantModel", x => new { x.GardensId, x.PlantsId });
                    table.ForeignKey(
                        name: "FK_GardenModelPlantModel_GardenModel_GardensId",
                        column: x => x.GardensId,
                        principalTable: "GardenModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenModelPlantModel_Plants_PlantsId",
                        column: x => x.PlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GardenPlantModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GardenId = table.Column<int>(type: "int", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenPlantModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GardenPlantModel_GardenModel_GardenId",
                        column: x => x.GardenId,
                        principalTable: "GardenModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenPlantModel_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Give water" },
                    { 2, "Give sunlight" },
                    { 3, "Repot plant when its gotten bigger" },
                    { 4, "Distribute pesticide" },
                    { 5, "Monitor temperature and humidity" },
                    { 6, "Provide support so plant stays upright" }
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "InstructionId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Oak" },
                    { 2, 2, "Dandelion" },
                    { 3, 3, "Venus Flytrap" },
                    { 4, 4, "Sunflower" },
                    { 5, 5, "Hemp" },
                    { 6, 6, "Barrel Cactus" },
                    { 7, 1, "Bamboo" },
                    { 8, 2, "Wheat" },
                    { 9, 3, "Spider Plant" },
                    { 10, 4, "Strawberry" },
                    { 11, 5, "Jade Plant" },
                    { 12, 6, "Banana" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenModel_UserId",
                table: "GardenModel",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GardenModelPlantModel_PlantsId",
                table: "GardenModelPlantModel",
                column: "PlantsId");

            migrationBuilder.CreateIndex(
                name: "IX_GardenPlantModel_GardenId",
                table: "GardenPlantModel",
                column: "GardenId");

            migrationBuilder.CreateIndex(
                name: "IX_GardenPlantModel_PlantId",
                table: "GardenPlantModel",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_InstructionId",
                table: "Plants",
                column: "InstructionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenModelPlantModel");

            migrationBuilder.DropTable(
                name: "GardenPlantModel");

            migrationBuilder.DropTable(
                name: "GardenModel");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Instructions");
        }
    }
}
