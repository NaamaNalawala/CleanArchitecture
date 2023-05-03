using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalQuotationModule.Infrastructure.Migrations
{
    public partial class AddQuotationIdToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuotationId",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuotationId",
                table: "Customer");
        }
    }
}
