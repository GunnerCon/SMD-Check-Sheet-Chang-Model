using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMDCheckSheet.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumMASk",
                table: "StandardProductions",
                newName: "NumMASK");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "ChangeModels",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "TimeChangeModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "QC",
                table: "TimeChangeModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "History",
                table: "TimeChangeModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CountTime",
                table: "TimeChangeModels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "WorkOrder",
                table: "CheckModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Qty",
                table: "CheckModels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PCBver",
                table: "CheckModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "CheckModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LineChange",
                table: "CheckModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FCode",
                table: "CheckModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CodePCB",
                table: "CheckModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                name: "IX_ChangeModels_StandardProductId",
                table: "ChangeModels",
                column: "StandardProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeModels_StandardVehicleId",
                table: "ChangeModels",
                column: "StandardVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeModels_TimeChangeModelId",
                table: "ChangeModels",
                column: "TimeChangeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeModels_CheckModels_CheckModelId",
                table: "ChangeModels",
                column: "CheckModelId",
                principalTable: "CheckModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeModels_PQCChecks_PQCCheckId",
                table: "ChangeModels",
                column: "PQCCheckId",
                principalTable: "PQCChecks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeModels_ProgramChecks_ProgramCheckId",
                table: "ChangeModels",
                column: "ProgramCheckId",
                principalTable: "ProgramChecks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeModels_StandardProductions_StandardProductId",
                table: "ChangeModels",
                column: "StandardProductId",
                principalTable: "StandardProductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeModels_StandardVehicles_StandardVehicleId",
                table: "ChangeModels",
                column: "StandardVehicleId",
                principalTable: "StandardVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeModels_TimeChangeModels_TimeChangeModelId",
                table: "ChangeModels",
                column: "TimeChangeModelId",
                principalTable: "TimeChangeModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeModels_CheckModels_CheckModelId",
                table: "ChangeModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeModels_PQCChecks_PQCCheckId",
                table: "ChangeModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeModels_ProgramChecks_ProgramCheckId",
                table: "ChangeModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeModels_StandardProductions_StandardProductId",
                table: "ChangeModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeModels_StandardVehicles_StandardVehicleId",
                table: "ChangeModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeModels_TimeChangeModels_TimeChangeModelId",
                table: "ChangeModels");

            migrationBuilder.DropIndex(
                name: "IX_ChangeModels_CheckModelId",
                table: "ChangeModels");

            migrationBuilder.DropIndex(
                name: "IX_ChangeModels_PQCCheckId",
                table: "ChangeModels");

            migrationBuilder.DropIndex(
                name: "IX_ChangeModels_ProgramCheckId",
                table: "ChangeModels");

            migrationBuilder.DropIndex(
                name: "IX_ChangeModels_StandardProductId",
                table: "ChangeModels");

            migrationBuilder.DropIndex(
                name: "IX_ChangeModels_StandardVehicleId",
                table: "ChangeModels");

            migrationBuilder.DropIndex(
                name: "IX_ChangeModels_TimeChangeModelId",
                table: "ChangeModels");

            migrationBuilder.RenameColumn(
                name: "NumMASK",
                table: "StandardProductions",
                newName: "NumMASk");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ChangeModels",
                newName: "status");

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "TimeChangeModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QC",
                table: "TimeChangeModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "History",
                table: "TimeChangeModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountTime",
                table: "TimeChangeModels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WorkOrder",
                table: "CheckModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Qty",
                table: "CheckModels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PCBver",
                table: "CheckModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "CheckModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LineChange",
                table: "CheckModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FCode",
                table: "CheckModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodePCB",
                table: "CheckModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
