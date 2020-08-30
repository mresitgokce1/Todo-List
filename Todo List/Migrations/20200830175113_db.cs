using Microsoft.EntityFrameworkCore.Migrations;

namespace Todo_List.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    roleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    roleId = table.Column<int>(nullable: false),
                    userRolesroleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_userRolesroleId",
                        column: x => x.userRolesroleId,
                        principalTable: "UserRoles",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TodoHeader",
                columns: table => new
                {
                    headerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(nullable: true),
                    userId = table.Column<int>(nullable: false),
                    UserRolesroleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoHeader", x => x.headerId);
                    table.ForeignKey(
                        name: "FK_TodoHeader_UserRoles_UserRolesroleId",
                        column: x => x.UserRolesroleId,
                        principalTable: "UserRoles",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TodoHeader_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TodoList",
                columns: table => new
                {
                    todoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    todo = table.Column<string>(nullable: true),
                    headerId = table.Column<int>(nullable: false),
                    todoHeaderheaderId = table.Column<int>(nullable: true),
                    userId = table.Column<int>(nullable: false),
                    UserRolesroleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoList", x => x.todoId);
                    table.ForeignKey(
                        name: "FK_TodoList_UserRoles_UserRolesroleId",
                        column: x => x.UserRolesroleId,
                        principalTable: "UserRoles",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TodoList_TodoHeader_todoHeaderheaderId",
                        column: x => x.todoHeaderheaderId,
                        principalTable: "TodoHeader",
                        principalColumn: "headerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TodoList_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoHeader_UserRolesroleId",
                table: "TodoHeader",
                column: "UserRolesroleId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoHeader_userId",
                table: "TodoHeader",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoList_UserRolesroleId",
                table: "TodoList",
                column: "UserRolesroleId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoList_todoHeaderheaderId",
                table: "TodoList",
                column: "todoHeaderheaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoList_userId",
                table: "TodoList",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userRolesroleId",
                table: "Users",
                column: "userRolesroleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoList");

            migrationBuilder.DropTable(
                name: "TodoHeader");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
