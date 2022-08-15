using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoAppWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoList",
                columns: table => new
                {
                    ToDoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoList", x => x.ToDoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoList");
        }
    }
}
