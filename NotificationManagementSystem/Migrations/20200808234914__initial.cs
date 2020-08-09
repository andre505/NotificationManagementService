using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationManagementSystem.Migrations
{
    public partial class _initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    To = table.Column<string>(maxLength: 20, nullable: false),
                    From = table.Column<string>(maxLength: 20, nullable: true),
                    SenderName = table.Column<string>(maxLength: 100, nullable: true),
                    Subject = table.Column<string>(maxLength: 255, nullable: true),
                    Body = table.Column<string>(maxLength: 8192, nullable: false),
                    MessageType = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messages");
        }
    }
}
