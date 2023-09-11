using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICMarkets.DeveloperTest.API.Migrations
{
    public partial class AlterTableBlockchainDataAdded_Columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "high_fee_per_kb",
                table: "blockchain_data",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "low_fee_per_kb",
                table: "blockchain_data",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "medium_fee_per_kb",
                table: "blockchain_data",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "high_fee_per_kb",
                table: "blockchain_data");

            migrationBuilder.DropColumn(
                name: "low_fee_per_kb",
                table: "blockchain_data");

            migrationBuilder.DropColumn(
                name: "medium_fee_per_kb",
                table: "blockchain_data");
        }
    }
}
