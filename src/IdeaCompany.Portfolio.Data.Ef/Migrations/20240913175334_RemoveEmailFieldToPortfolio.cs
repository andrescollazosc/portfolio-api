using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdeaCompany.Portfolio.Data.Ef.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEmailFieldToPortfolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Portfolios");

            migrationBuilder.RenameColumn(
                name: "ComanyName",
                table: "WorkExperiences",
                newName: "CompanyName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "WorkExperiences",
                newName: "ComanyName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Portfolios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
