using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdeaCompany.Portfolio.Data.Ef.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailsFieldToPortfolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Emails",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emails",
                table: "Portfolios");
        }
    }
}
