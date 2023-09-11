using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICMarkets.DeveloperTest.API.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blockchain_data",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    height = table.Column<long>(type: "INTEGER", nullable: false),
                    hash = table.Column<string>(type: "TEXT", nullable: false),
                    time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    latest_url = table.Column<string>(type: "TEXT", nullable: false),
                    previous_hash = table.Column<string>(type: "TEXT", nullable: false),
                    previous_url = table.Column<string>(type: "TEXT", nullable: false),
                    peer_count = table.Column<int>(type: "INTEGER", nullable: false),
                    unconfirmed_count = table.Column<int>(type: "INTEGER", nullable: false),
                    high_gas_price = table.Column<long>(type: "INTEGER", nullable: false),
                    medium_gas_price = table.Column<long>(type: "INTEGER", nullable: false),
                    low_gas_price = table.Column<long>(type: "INTEGER", nullable: false),
                    high_priority_fee = table.Column<long>(type: "INTEGER", nullable: false),
                    medium_priority_fee = table.Column<long>(type: "INTEGER", nullable: false),
                    low_priority_fee = table.Column<long>(type: "INTEGER", nullable: false),
                    base_fee = table.Column<long>(type: "INTEGER", nullable: false),
                    last_fork_height = table.Column<long>(type: "INTEGER", nullable: false),
                    last_fork_hash = table.Column<string>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_blockchain_data", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blockchain_data");
        }
    }
}
