using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ActivityLockerServer.Data.Migrations
{
    public partial class activityDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActiveBeforeDateTime",
                table: "UserActivities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "UserActivities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveBeforeDateTime",
                table: "UserActivities");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "UserActivities");
        }
    }
}
