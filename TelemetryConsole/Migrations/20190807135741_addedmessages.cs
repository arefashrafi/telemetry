using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelemetryConsole.Migrations
{
    public partial class addedmessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Messages",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Prefix = table.Column<string>(nullable: true),
                    MessageId = table.Column<byte>(),
                    Length = table.Column<byte>(),
                    Text = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>()
                },
                constraints: table => { table.PrimaryKey("PK_Messages", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Messages");
        }
    }
}