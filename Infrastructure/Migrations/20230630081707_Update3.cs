using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobHistories",
                table: "JobHistories");

            migrationBuilder.DropIndex(
                name: "IX_JobHistories_DepartmentId",
                table: "JobHistories");

            migrationBuilder.DropColumn(
                name: "DeparmentId",
                table: "JobHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobHistories",
                table: "JobHistories",
                columns: new[] { "DepartmentId", "JobId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobHistories",
                table: "JobHistories");

            migrationBuilder.AddColumn<int>(
                name: "DeparmentId",
                table: "JobHistories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobHistories",
                table: "JobHistories",
                columns: new[] { "DeparmentId", "JobId" });

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_DepartmentId",
                table: "JobHistories",
                column: "DepartmentId");
        }
    }
}
