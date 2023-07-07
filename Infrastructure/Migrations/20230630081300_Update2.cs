using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobHistories",
                table: "JobHistories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "JobHistories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobHistories",
                table: "JobHistories",
                columns: new[] { "DeparmentId", "JobId" });

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_EmployeeId",
                table: "JobHistories",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobHistories",
                table: "JobHistories");

            migrationBuilder.DropIndex(
                name: "IX_JobHistories_EmployeeId",
                table: "JobHistories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "JobHistories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobHistories",
                table: "JobHistories",
                columns: new[] { "EmployeeId", "JobId" });
        }
    }
}
