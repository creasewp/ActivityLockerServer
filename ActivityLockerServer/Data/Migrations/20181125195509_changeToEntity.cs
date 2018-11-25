using Microsoft.EntityFrameworkCore.Migrations;

namespace ActivityLockerServer.Data.Migrations
{
    public partial class changeToEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserGroupId",
                table: "UserActivities",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserActivities_UserGroupId",
                table: "UserActivities",
                column: "UserGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivities_UserGroups_UserGroupId",
                table: "UserActivities",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserActivities_UserGroups_UserGroupId",
                table: "UserActivities");

            migrationBuilder.DropIndex(
                name: "IX_UserActivities_UserGroupId",
                table: "UserActivities");

            migrationBuilder.AlterColumn<string>(
                name: "UserGroupId",
                table: "UserActivities",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
