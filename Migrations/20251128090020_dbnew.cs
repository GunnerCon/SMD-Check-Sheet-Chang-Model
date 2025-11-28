using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMDCheckSheet.Migrations
{
    /// <inheritdoc />
    public partial class dbnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeModels_StandardProductions_StandardProductId",
                table: "ChangeModels");

            migrationBuilder.DropIndex(
                name: "IX_ChangeModels_StandardProductId",
                table: "ChangeModels");

            migrationBuilder.AddColumn<int>(
                name: "StandardProductionId",
                table: "ChangeModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChangeModels_StandardProductionId",
                table: "ChangeModels",
                column: "StandardProductionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeModels_StandardProductions_StandardProductionId",
                table: "ChangeModels",
                column: "StandardProductionId",
                principalTable: "StandardProductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeModels_StandardProductions_StandardProductionId",
                table: "ChangeModels");

            migrationBuilder.DropIndex(
                name: "IX_ChangeModels_StandardProductionId",
                table: "ChangeModels");

            migrationBuilder.DropColumn(
                name: "StandardProductionId",
                table: "ChangeModels");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeModels_StandardProductId",
                table: "ChangeModels",
                column: "StandardProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeModels_StandardProductions_StandardProductId",
                table: "ChangeModels",
                column: "StandardProductId",
                principalTable: "StandardProductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
