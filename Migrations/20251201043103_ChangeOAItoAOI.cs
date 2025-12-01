using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMDCheckSheet.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOAItoAOI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SOAIProgram",
                table: "ProgramChecks",
                newName: "SAOIProgram");

            migrationBuilder.RenameColumn(
                name: "PointSOAI",
                table: "ProgramChecks",
                newName: "PointSAOI");

            migrationBuilder.RenameColumn(
                name: "MOAIProgram",
                table: "ProgramChecks",
                newName: "MAOIProgram");

            migrationBuilder.AddColumn<string>(
                name: "ModelValue",
                table: "StandardVehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "OutputCheck",
                table: "StandardVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PitchReal",
                table: "StandardVehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PitchValue",
                table: "StandardVehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RevMounter",
                table: "CheckModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RevS15",
                table: "CheckModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExcelFileUrl",
                table: "ChangeModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PdfFileUrl",
                table: "ChangeModels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelValue",
                table: "StandardVehicles");

            migrationBuilder.DropColumn(
                name: "OutputCheck",
                table: "StandardVehicles");

            migrationBuilder.DropColumn(
                name: "PitchReal",
                table: "StandardVehicles");

            migrationBuilder.DropColumn(
                name: "PitchValue",
                table: "StandardVehicles");

            migrationBuilder.DropColumn(
                name: "RevMounter",
                table: "CheckModels");

            migrationBuilder.DropColumn(
                name: "RevS15",
                table: "CheckModels");

            migrationBuilder.DropColumn(
                name: "ExcelFileUrl",
                table: "ChangeModels");

            migrationBuilder.DropColumn(
                name: "PdfFileUrl",
                table: "ChangeModels");

            migrationBuilder.RenameColumn(
                name: "SAOIProgram",
                table: "ProgramChecks",
                newName: "SOAIProgram");

            migrationBuilder.RenameColumn(
                name: "PointSAOI",
                table: "ProgramChecks",
                newName: "PointSOAI");

            migrationBuilder.RenameColumn(
                name: "MAOIProgram",
                table: "ProgramChecks",
                newName: "MOAIProgram");
        }
    }
}
