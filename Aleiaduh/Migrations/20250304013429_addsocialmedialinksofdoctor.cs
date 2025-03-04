using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aleiaduh.Migrations
{
    /// <inheritdoc />
    public partial class addsocialmedialinksofdoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookURL",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramURL",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterURL",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookURL",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "InstagramURL",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "TwitterURL",
                table: "Doctors");
        }
    }
}
