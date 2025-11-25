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
                name: "CheckModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineChange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCBver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsedCNcard = table.Column<bool>(type: "bit", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    FeederCheck = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OPAccept = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JIG = table.Column<bool>(type: "bit", nullable: false),
                    CodePCB = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckModels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckModels");
        }
    }
}
