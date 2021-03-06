﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Repository.Migrations
{
    public partial class AddActiveOnUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Publishiers",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("010f8922-7cdd-4025-82fa-d2384105c4a3"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Books",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("4b649073-443b-4eff-ba84-5cff0ebb144e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BookCategoryEntity",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("58f5fa74-6305-4e57-8a04-1132aa321b62"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AuthorsBooks",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("2bacdfed-a0d4-4c01-a25a-a3182fe7fc78"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Authors",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("25262572-f864-425b-957e-5d2cc08d1b6b"));

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Publishiers",
                nullable: false,
                defaultValue: new Guid("010f8922-7cdd-4025-82fa-d2384105c4a3"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Books",
                nullable: false,
                defaultValue: new Guid("4b649073-443b-4eff-ba84-5cff0ebb144e"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BookCategoryEntity",
                nullable: false,
                defaultValue: new Guid("58f5fa74-6305-4e57-8a04-1132aa321b62"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AuthorsBooks",
                nullable: false,
                defaultValue: new Guid("2bacdfed-a0d4-4c01-a25a-a3182fe7fc78"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Authors",
                nullable: false,
                defaultValue: new Guid("25262572-f864-425b-957e-5d2cc08d1b6b"),
                oldClrType: typeof(Guid));
        }
    }
}
