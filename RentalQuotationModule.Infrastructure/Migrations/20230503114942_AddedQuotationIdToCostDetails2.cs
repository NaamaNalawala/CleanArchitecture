using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalQuotationModule.Infrastructure.Migrations
{
    public partial class AddedQuotationIdToCostDetails2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostDetailId",
                table: "Quotation");

            migrationBuilder.AddColumn<int>(
                name: "QuotationId",
                table: "CostDetails",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuotationId",
                table: "CostDetails");

            migrationBuilder.AddColumn<int>(
                name: "CostDetailId",
                table: "Quotation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
