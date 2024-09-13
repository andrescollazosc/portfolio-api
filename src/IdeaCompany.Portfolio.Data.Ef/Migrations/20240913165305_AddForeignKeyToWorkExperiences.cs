using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdeaCompany.Portfolio.Data.Ef.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToWorkExperiences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PortfolioId1",
                table: "WorkExperiences",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_PortfolioId1",
                table: "WorkExperiences",
                column: "PortfolioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_Portfolios_PortfolioId1",
                table: "WorkExperiences",
                column: "PortfolioId1",
                principalTable: "Portfolios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_Portfolios_PortfolioId1",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperiences_PortfolioId1",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "PortfolioId1",
                table: "WorkExperiences");
        }
    }
}
