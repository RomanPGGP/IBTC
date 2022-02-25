using Microsoft.EntityFrameworkCore.Migrations;

namespace Rum8s.Data.Migrations
{
    public partial class DBS2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroupR8_groups_GroupR8Id",
                table: "UserGroupR8");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroupR8",
                table: "UserGroupR8");

            migrationBuilder.RenameTable(
                name: "UserGroupR8",
                newName: "userGroupR8s");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroupR8_GroupR8Id",
                table: "userGroupR8s",
                newName: "IX_userGroupR8s_GroupR8Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userGroupR8s",
                table: "userGroupR8s",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userGroupR8s_groups_GroupR8Id",
                table: "userGroupR8s",
                column: "GroupR8Id",
                principalTable: "groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userGroupR8s_groups_GroupR8Id",
                table: "userGroupR8s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userGroupR8s",
                table: "userGroupR8s");

            migrationBuilder.RenameTable(
                name: "userGroupR8s",
                newName: "UserGroupR8");

            migrationBuilder.RenameIndex(
                name: "IX_userGroupR8s_GroupR8Id",
                table: "UserGroupR8",
                newName: "IX_UserGroupR8_GroupR8Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroupR8",
                table: "UserGroupR8",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroupR8_groups_GroupR8Id",
                table: "UserGroupR8",
                column: "GroupR8Id",
                principalTable: "groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
