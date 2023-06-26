using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainComponentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1001', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsRoot = table.Column<bool>(type: "boolean", nullable: false),
                    CanAssignQuantity = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainComponentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainComponentBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UniqueNumMask = table.Column<string>(type: "text", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainComponentBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainComponentBrands_TrainComponentTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TrainComponentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainComponentTypeRelation",
                columns: table => new
                {
                    ParentTypeId = table.Column<int>(type: "integer", nullable: false),
                    ChildTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainComponentTypeRelation", x => new { x.ParentTypeId, x.ChildTypeId });
                    table.ForeignKey(
                        name: "FK_TrainComponentTypeRelation_TrainComponentTypes_ChildTypeId",
                        column: x => x.ChildTypeId,
                        principalTable: "TrainComponentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainComponentTypeRelation_TrainComponentTypes_ParentTypeId",
                        column: x => x.ParentTypeId,
                        principalTable: "TrainComponentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.UniqueConstraint("AK_Inventory_SerialNumber", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Inventory_TrainComponentBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "TrainComponentBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    TrainId = table.Column<int>(type: "integer", nullable: false),
                    ParentElementId = table.Column<int>(type: "integer", nullable: true),
                    ModelElementId = table.Column<int>(type: "integer", nullable: false),
                    InventoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainElements_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainElements_TrainElements_ParentElementId",
                        column: x => x.ParentElementId,
                        principalTable: "TrainElements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainModelElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainModelElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainModelElements_TrainComponentBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "TrainComponentBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainModelElements_TrainModelElements_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TrainModelElements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ReadyForUsing = table.Column<bool>(type: "boolean", nullable: false),
                    ParentElementId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainModels_TrainModelElements_ParentElementId",
                        column: x => x.ParentElementId,
                        principalTable: "TrainModelElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    RootElementId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trains_TrainElements_RootElementId",
                        column: x => x.RootElementId,
                        principalTable: "TrainElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trains_TrainModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "TrainModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TrainComponentTypes",
                columns: new[] { "Id", "CanAssignQuantity", "IsRoot", "Name" },
                values: new object[,]
                {
                    { 1, false, true, "Train" },
                    { 2, false, false, "Engine" },
                    { 3, false, false, "Passenger Car" },
                    { 4, false, false, "Freight Car" },
                    { 5, true, false, "Wheel" },
                    { 6, true, false, "Seat" },
                    { 7, true, false, "Window" },
                    { 8, true, false, "Door" },
                    { 9, true, false, "Control Panel" },
                    { 10, true, false, "Light" },
                    { 11, true, false, "Brake" },
                    { 12, true, false, "Bolt" },
                    { 13, true, false, "Nut" },
                    { 14, false, false, "Engine Hood" },
                    { 15, false, false, "Axle" },
                    { 16, false, false, "Piston" },
                    { 17, true, false, "Handrail" },
                    { 18, true, false, "Step" },
                    { 19, false, false, "Roof" },
                    { 20, false, false, "Air Conditioner" },
                    { 21, false, false, "Flooring" },
                    { 22, true, false, "Mirror" },
                    { 23, false, false, "Horn" },
                    { 24, false, false, "Coupler" },
                    { 25, true, false, "Hinge" },
                    { 26, true, false, "Ladder" },
                    { 27, false, false, "Paint" },
                    { 28, true, false, "Decal" },
                    { 29, true, false, "Gauge" },
                    { 30, false, false, "Battery" },
                    { 31, false, false, "Radiator" }
                });

            migrationBuilder.InsertData(
                table: "TrainComponentTypeRelation",
                columns: new[] { "ChildTypeId", "ParentTypeId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 2 },
                    { 14, 2 },
                    { 16, 2 },
                    { 17, 2 },
                    { 18, 2 },
                    { 19, 2 },
                    { 20, 2 },
                    { 21, 2 },
                    { 22, 2 },
                    { 23, 2 },
                    { 24, 2 },
                    { 26, 2 },
                    { 28, 2 },
                    { 29, 2 },
                    { 30, 2 },
                    { 31, 2 },
                    { 7, 3 },
                    { 8, 3 },
                    { 11, 3 },
                    { 17, 3 },
                    { 18, 3 },
                    { 19, 3 },
                    { 20, 3 },
                    { 21, 3 },
                    { 24, 3 },
                    { 26, 3 },
                    { 28, 3 },
                    { 29, 3 },
                    { 6, 4 },
                    { 8, 4 },
                    { 11, 4 },
                    { 17, 4 },
                    { 19, 4 },
                    { 24, 4 },
                    { 26, 4 },
                    { 28, 4 },
                    { 29, 4 },
                    { 12, 5 },
                    { 13, 5 },
                    { 25, 7 },
                    { 27, 7 },
                    { 25, 8 },
                    { 27, 8 },
                    { 27, 19 },
                    { 27, 21 },
                    { 25, 24 },
                    { 5, 29 },
                    { 15, 29 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_BrandId",
                table: "Inventory",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainComponentBrands_Name",
                table: "TrainComponentBrands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainComponentBrands_TypeId",
                table: "TrainComponentBrands",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainComponentTypeRelation_ChildTypeId",
                table: "TrainComponentTypeRelation",
                column: "ChildTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainComponentTypes_Name",
                table: "TrainComponentTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainElements_InventoryId",
                table: "TrainElements",
                column: "InventoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainElements_ModelElementId",
                table: "TrainElements",
                column: "ModelElementId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainElements_ParentElementId",
                table: "TrainElements",
                column: "ParentElementId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainElements_TrainId",
                table: "TrainElements",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainModelElements_BrandId",
                table: "TrainModelElements",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainModelElements_ModelId",
                table: "TrainModelElements",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainModelElements_ParentId",
                table: "TrainModelElements",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainModels_Name",
                table: "TrainModels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainModels_ParentElementId",
                table: "TrainModels",
                column: "ParentElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Trains_ModelId",
                table: "Trains",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Trains_RootElementId",
                table: "Trains",
                column: "RootElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainElements_TrainModelElements_ModelElementId",
                table: "TrainElements",
                column: "ModelElementId",
                principalTable: "TrainModelElements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainElements_Trains_TrainId",
                table: "TrainElements",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainModelElements_TrainModels_ModelId",
                table: "TrainModelElements",
                column: "ModelId",
                principalTable: "TrainModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_TrainComponentBrands_BrandId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainModelElements_TrainComponentBrands_BrandId",
                table: "TrainModelElements");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainElements_Inventory_InventoryId",
                table: "TrainElements");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainElements_TrainModelElements_ModelElementId",
                table: "TrainElements");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainModels_TrainModelElements_ParentElementId",
                table: "TrainModels");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainElements_Trains_TrainId",
                table: "TrainElements");

            migrationBuilder.DropTable(
                name: "TrainComponentTypeRelation");

            migrationBuilder.DropTable(
                name: "TrainComponentBrands");

            migrationBuilder.DropTable(
                name: "TrainComponentTypes");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "TrainModelElements");

            migrationBuilder.DropTable(
                name: "Trains");

            migrationBuilder.DropTable(
                name: "TrainElements");

            migrationBuilder.DropTable(
                name: "TrainModels");
        }
    }
}
