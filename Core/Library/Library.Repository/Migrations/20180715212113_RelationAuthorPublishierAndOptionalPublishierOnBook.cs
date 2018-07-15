using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Repository.Migrations
{
    public partial class RelationAuthorPublishierAndOptionalPublishierOnBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Publishiers_PublishierEntityId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishiers_PublishierId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PublishierEntityId",
                table: "Authors",
                newName: "PublishierId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_PublishierEntityId",
                table: "Authors",
                newName: "IX_Authors_PublishierId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublishierId",
                table: "Books",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Publishiers_PublishierId",
                table: "Authors",
                column: "PublishierId",
                principalTable: "Publishiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishiers_PublishierId",
                table: "Books",
                column: "PublishierId",
                principalTable: "Publishiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Publishiers_PublishierId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishiers_PublishierId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PublishierId",
                table: "Authors",
                newName: "PublishierEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_PublishierId",
                table: "Authors",
                newName: "IX_Authors_PublishierEntityId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublishierId",
                table: "Books",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Publishiers_PublishierEntityId",
                table: "Authors",
                column: "PublishierEntityId",
                principalTable: "Publishiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishiers_PublishierId",
                table: "Books",
                column: "PublishierId",
                principalTable: "Publishiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
