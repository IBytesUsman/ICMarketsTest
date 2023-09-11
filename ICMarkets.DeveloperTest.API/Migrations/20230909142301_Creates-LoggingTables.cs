using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICMarkets.DeveloperTest.API.Migrations
{
    public partial class CreatesLoggingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exceptions_audit",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    request_id = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    action = table.Column<string>(type: "TEXT", nullable: false),
                    path = table.Column<string>(type: "TEXT", nullable: false),
                    metadata = table.Column<string>(type: "TEXT", nullable: false),
                    exception_message = table.Column<string>(type: "TEXT", nullable: false),
                    stack_trace = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exceptions_audit", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "requests_audit",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    method = table.Column<string>(type: "TEXT", nullable: false),
                    path = table.Column<string>(type: "TEXT", nullable: false),
                    body = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_requests_audit", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exceptions_audit");

            migrationBuilder.DropTable(
                name: "requests_audit");
        }
    }
}
