using Microsoft.EntityFrameworkCore.Migrations;

namespace ActivityLockerServer.Data.Migrations
{
    public partial class codeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "UserActivities",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "UserActivities",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
