using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instagram.Dal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "AccountAccount",
                columns: table => new
                {
                    FollowersAccountId = table.Column<long>(type: "bigint", nullable: false),
                    FollowingAccountId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAccount", x => new { x.FollowersAccountId, x.FollowingAccountId });
                    table.ForeignKey(
                        name: "FK_AccountAccount_Account_FollowersAccountId",
                        column: x => x.FollowersAccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountAccount_Account_FollowingAccountId",
                        column: x => x.FollowingAccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    PostId = table.Column<long>(type: "bigint", nullable: false),
                    ParentComentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ParentComentId",
                        column: x => x.ParentComentId,
                        principalTable: "Comment",
                        principalColumn: "CommentId");
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserName",
                table: "Account",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountAccount_FollowingAccountId",
                table: "AccountAccount",
                column: "FollowingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AccountId",
                table: "Comment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentComentId",
                table: "Comment",
                column: "ParentComentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_AccountId",
                table: "Post",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAccount");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
