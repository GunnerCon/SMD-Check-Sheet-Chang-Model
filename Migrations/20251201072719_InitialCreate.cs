using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMDCheckSheet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineChange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PCBver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsedCNcard = table.Column<bool>(type: "bit", nullable: false),
                    RevS15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevMounter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    FeederCheck = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OPAccept = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JIG = table.Column<bool>(type: "bit", nullable: false),
                    CodePCB = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PQCChecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ICPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChecksumReal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChecksumConfirm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Turner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartLCR = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndLCR = table.Column<TimeSpan>(type: "time", nullable: false),
                    NameCheck = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultLCR = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PQCChecks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramChecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrinterProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SPIProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MounterProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointMounter = table.Column<int>(type: "int", nullable: false),
                    MAOIProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAOIProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointSAOI = table.Column<int>(type: "int", nullable: false),
                    ReflowProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReflowSpeed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramChecks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StandardProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumMASK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumMES = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumScanPrinter = table.Column<int>(type: "int", nullable: false),
                    NumScanSignMES = table.Column<int>(type: "int", nullable: false),
                    MLS3Closed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UseOnly = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabelProgram = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardProductions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StandardVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrinterSpecGTAL = table.Column<int>(type: "int", nullable: false),
                    PrinterSpecTDQ = table.Column<int>(type: "int", nullable: false),
                    PrinterSpecTDKC = table.Column<int>(type: "int", nullable: false),
                    PrinterSpecDSL = table.Column<int>(type: "int", nullable: false),
                    PrinterRealGTAL = table.Column<int>(type: "int", nullable: false),
                    PrinterRealTDQ = table.Column<int>(type: "int", nullable: false),
                    PrinterRealTDKC = table.Column<int>(type: "int", nullable: false),
                    PrinterRealDSL = table.Column<int>(type: "int", nullable: false),
                    PrinterQ1 = table.Column<bool>(type: "bit", nullable: false),
                    SPIQ1 = table.Column<bool>(type: "bit", nullable: false),
                    MountQ1 = table.Column<bool>(type: "bit", nullable: false),
                    MountQ2 = table.Column<bool>(type: "bit", nullable: false),
                    ReflowQ1 = table.Column<bool>(type: "bit", nullable: false),
                    ReFlowSettingRail = table.Column<int>(type: "int", nullable: false),
                    ReFlowRealRail = table.Column<int>(type: "int", nullable: false),
                    AOIQ1 = table.Column<bool>(type: "bit", nullable: false),
                    AOICheck = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutputCheck = table.Column<bool>(type: "bit", nullable: false),
                    ModelValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PitchValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PitchReal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAOI = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardVehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeChangeModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CountTime = table.Column<int>(type: "int", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeChangeModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChangeModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckModelId = table.Column<int>(type: "int", nullable: false),
                    ProgramCheckId = table.Column<int>(type: "int", nullable: false),
                    StandardProductionId = table.Column<int>(type: "int", nullable: false),
                    StandardVehicleId = table.Column<int>(type: "int", nullable: false),
                    TimeChangeModelId = table.Column<int>(type: "int", nullable: false),
                    PQCCheckId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExcelFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PdfFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChangeModels_CheckModels_CheckModelId",
                        column: x => x.CheckModelId,
                        principalTable: "CheckModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChangeModels_PQCChecks_PQCCheckId",
                        column: x => x.PQCCheckId,
                        principalTable: "PQCChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChangeModels_ProgramChecks_ProgramCheckId",
                        column: x => x.ProgramCheckId,
                        principalTable: "ProgramChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChangeModels_StandardProductions_StandardProductionId",
                        column: x => x.StandardProductionId,
                        principalTable: "StandardProductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChangeModels_StandardVehicles_StandardVehicleId",
                        column: x => x.StandardVehicleId,
                        principalTable: "StandardVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChangeModels_TimeChangeModels_TimeChangeModelId",
                        column: x => x.TimeChangeModelId,
                        principalTable: "TimeChangeModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeModels_CheckModelId",
                table: "ChangeModels",
                column: "CheckModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeModels_PQCCheckId",
                table: "ChangeModels",
                column: "PQCCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeModels_ProgramCheckId",
                table: "ChangeModels",
                column: "ProgramCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeModels_StandardProductionId",
                table: "ChangeModels",
                column: "StandardProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeModels_StandardVehicleId",
                table: "ChangeModels",
                column: "StandardVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeModels_TimeChangeModelId",
                table: "ChangeModels",
                column: "TimeChangeModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ChangeModels");

            migrationBuilder.DropTable(
                name: "CheckModels");

            migrationBuilder.DropTable(
                name: "PQCChecks");

            migrationBuilder.DropTable(
                name: "ProgramChecks");

            migrationBuilder.DropTable(
                name: "StandardProductions");

            migrationBuilder.DropTable(
                name: "StandardVehicles");

            migrationBuilder.DropTable(
                name: "TimeChangeModels");
        }
    }
}
