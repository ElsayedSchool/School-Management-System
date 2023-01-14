using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class mod1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "UserProfile",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 10, 7, 8, 48, 41, 608, DateTimeKind.Local).AddTicks(4810),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 10, 1, 18, 13, 50, 918, DateTimeKind.Local).AddTicks(2346));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Session",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "UserProfile",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 10, 1, 18, 13, 50, 918, DateTimeKind.Local).AddTicks(2346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 10, 7, 8, 48, 41, 608, DateTimeKind.Local).AddTicks(4810));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Session",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);
        }
    }
}
