using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mission8_agraviet.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "quadrants",
                columns: table => new
                {
                    QuadrantId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuadrantName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quadrants", x => x.QuadrantId);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(nullable: false),
                    QuadrantId = table.Column<int>(nullable: false),
                    TaskTitle = table.Column<string>(nullable: false),
                    TaskNotes = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_responses_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_responses_quadrants_QuadrantId",
                        column: x => x.QuadrantId,
                        principalTable: "quadrants",
                        principalColumn: "QuadrantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, "church" });

            migrationBuilder.InsertData(
                table: "quadrants",
                columns: new[] { "QuadrantId", "QuadrantName" },
                values: new object[] { 1, "Urgent, Important" });

            migrationBuilder.InsertData(
                table: "quadrants",
                columns: new[] { "QuadrantId", "QuadrantName" },
                values: new object[] { 2, "Not Urgent, Important" });

            migrationBuilder.InsertData(
                table: "quadrants",
                columns: new[] { "QuadrantId", "QuadrantName" },
                values: new object[] { 3, "Urgent, Not Important" });

            migrationBuilder.InsertData(
                table: "quadrants",
                columns: new[] { "QuadrantId", "QuadrantName" },
                values: new object[] { 4, "Not Urgent, Not Important" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "QuadrantId", "TaskNotes", "TaskTitle" },
                values: new object[] { 1, 1, false, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "These are notes for 1", "Test Task 1" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "QuadrantId", "TaskNotes", "TaskTitle" },
                values: new object[] { 2, 2, false, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "These are notes for 2", "Test Task 2" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "QuadrantId", "TaskNotes", "TaskTitle" },
                values: new object[] { 3, 3, true, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "These are notes for 3", "Test Task 3" });

            migrationBuilder.CreateIndex(
                name: "IX_responses_CategoryId",
                table: "responses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_responses_QuadrantId",
                table: "responses",
                column: "QuadrantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "quadrants");
        }
    }
}
