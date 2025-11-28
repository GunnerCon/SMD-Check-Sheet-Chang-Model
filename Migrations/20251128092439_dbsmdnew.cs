using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMDCheckSheet.Migrations
{
    /// <inheritdoc />
    public partial class dbsmdnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StandardProductId",
                table: "ChangeModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StandardProductId",
                table: "ChangeModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
