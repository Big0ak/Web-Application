using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_lab.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdExecuter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NunberOrders = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CurrentOrder",
                columns: new[] { "Id", "IdCustomer", "IdExecuter", "Price", "Status", "Topic", "description" },
                values: new object[] { new Guid("d0c1355d-44cc-4554-a4b1-da63e831c35b"), new Guid("3b62472e-4f66-49fa-a20f-e7685b9565d8"), new Guid("00000000-0000-0000-0000-000000000000"), 500, 0, "Сочинение", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "NunberOrders", "Surname", "Type" },
                values: new object[] { new Guid("3b62472e-4f66-49fa-a20f-e7685b9565d8"), "Вася", 0, "Белов", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "NunberOrders", "Surname", "Type" },
                values: new object[] { new Guid("6f72f4dd-2243-4851-af60-dc393a203e27"), "Петя", 1, "Петров", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentOrder");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
