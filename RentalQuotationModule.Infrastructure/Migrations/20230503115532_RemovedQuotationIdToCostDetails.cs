using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalQuotationModule.Infrastructure.Migrations
{
    public partial class RemovedQuotationIdToCostDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuotationId",
                table: "CostDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuotationId",
                table: "CostDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
