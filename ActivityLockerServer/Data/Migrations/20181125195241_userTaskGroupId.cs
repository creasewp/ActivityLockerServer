using Microsoft.EntityFrameworkCore.Migrations;

namespace ActivityLockerServer.Data.Migrations
{
    public partial class userTaskGroupId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserGroupId",
                table: "UserActivities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "UserActivities");
        }
    }
}
