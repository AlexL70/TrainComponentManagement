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
                        .Annotation("Npgsql:IdentitySequenceOptions", "'501', '1', '', '', 'False', '1'")
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
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1001', '1', '', '', 'False', '1'")
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
                    Id = table.Column<int>(type: "integer", nullable: false),
                    TrainId = table.Column<int>(type: "integer", nullable: false),
                    ParentElementId = table.Column<int>(type: "integer", nullable: true),
                    ModelElementId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainElements_Inventory_Id",
                        column: x => x.Id,
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
                    RootComponentId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trains_TrainElements_RootComponentId",
                        column: x => x.RootComponentId,
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
                table: "TrainComponentBrands",
                columns: new[] { "Id", "Name", "TypeId", "UniqueNumMask" },
                values: new object[,]
                {
                    { 1, "Train", 1, "TR******" },
                    { 2, "Alan Keef", 2, "ENGAK******" },
                    { 3, "Bombardier Transportation", 2, "ENGBT******" },
                    { 4, "Clayton Equipment Company", 2, "ENGCEC******" },
                    { 5, "CAF Newport", 3, "PCARCAF******" },
                    { 6, "Dick, Kerr & Co", 3, "PCARDKC******" },
                    { 7, "Dick, Kerr & Co", 4, "FCARDKC******" },
                    { 8, "Swindon Works", 4, "FCARSW******" },
                    { 9, "Leonard Machine Tool Systems", 5, "WLLMTS******" },
                    { 10, "Stucki Industrial", 5, "WLSI******" },
                    { 11, "GRAMMER AG", 6, "SEATGRAM******" },
                    { 12, "Magna International, Inc.", 6, "SEATMII******" },
                    { 13, "Freedman Seating Company", 6, "SEATFSC******" },
                    { 14, "ProCurve Glass", 7, "WNDPCG******" },
                    { 15, "Dellner Romag Ltd", 7, "WNDDRL******" },
                    { 16, "Train Door Solutions", 8, "DOORTDS******" },
                    { 17, "Railway Technology", 8, "DOORRT******" },
                    { 18, "Adbro Controls", 9, "CPLAC******" },
                    { 19, "Sella Controls", 9, "CPLSC******" },
                    { 20, "Imigy Led", 10, "LGHTIL******" },
                    { 21, "Wildlife Friendly Lighting", 10, "LGHTWFL******" },
                    { 22, "Knorr-Bremse Group", 11, "BRKKBG******" },
                    { 23, "Railway Weelset & Break LTD", 11, "BRKRWB******" },
                    { 24, "Bolt & Nut Manufacturing Ltd", 12, "BLTBNM******" },
                    { 25, "RCF Bolt & Nut Co.", 12, "BLTRCFBNC******" },
                    { 26, "Bolt & Nut Manufacturing Ltd", 13, "NUTBNM******" },
                    { 27, "RCF Bolt & Nut Co.", 13, "NUTRCFBNC******" },
                    { 28, "John Deere UK & IE", 14, "EHDJDUK******" },
                    { 29, "Rapido Trains INC", 14, "EHDRTI******" },
                    { 30, "Lucchini UK", 15, "AXLLCI******" },
                    { 31, "Railway Wheelset and Brake Ltd", 15, "AXLRWBL******" },
                    { 32, "HP Rings", 16, "PSTHPR******" },
                    { 33, "The Handrail People Ltd", 17, "HRLTHP******" },
                    { 34, "Lyte Ladders & Towers", 18, "STPLLT******" },
                    { 35, "Rapid Ramp", 18, "STPRR******" },
                    { 36, "Dick, Kerr & Co", 19, "ROOFDKC******" },
                    { 37, "Swindon Works", 19, "ROOFSW******" },
                    { 38, "Trane", 20, "ACNDTRN******" },
                    { 39, "Dick, Kerr & Co", 21, "FLRDKC******" },
                    { 40, "Mirrorfit UK", 22, "MRRMFUK******" },
                    { 41, "Mimtec Limited", 22, "MRRMTL******" },
                    { 42, "Trent Instruments LTD", 23, "HRNTI******" },
                    { 43, "Kuda Automotive", 23, "HRNKA******" },
                    { 44, "Knorr-Bremse", 24, "CPLKB******" },
                    { 45, "Dellner Limited", 24, "CPLDL******" },
                    { 46, "Prokraft", 25, "HNGPKFT******" },
                    { 47, "Chase Ladders", 26, "LDRCHLD******" },
                    { 48, "Bratts Ladders", 26, "LDRBRLD******" },
                    { 49, "Unitech Machinery", 27, "PNTUM******" },
                    { 50, "Decals & Transfers", 28, "DCLDT******" },
                    { 51, "Trent Instruments LTD", 29, "GGTI******" },
                    { 52, "Railway Weelset & Break LTD", 29, "GGRWBL******" },
                    { 53, "Hitachi Rail", 30, "BTRHR******" },
                    { 54, "Alstom", 30, "BTRALST******" },
                    { 55, "Myson", 31, "RDRMSN******" }
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
                name: "IX_TrainComponentBrands_TypeId",
                table: "TrainComponentBrands",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainComponentBrands_TypeId_Name",
                table: "TrainComponentBrands",
                columns: new[] { "TypeId", "Name" },
                unique: true);

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
                column: "ParentElementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trains_ModelId",
                table: "Trains",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Trains_RootComponentId",
                table: "Trains",
                column: "RootComponentId",
                unique: true);

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
                name: "FK_TrainElements_Inventory_Id",
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
