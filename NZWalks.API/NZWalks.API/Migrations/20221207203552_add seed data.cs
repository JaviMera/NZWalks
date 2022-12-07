using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    public partial class addseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("589382f2-19bc-4fa9-b457-3e952fe5a264"), "writer" },
                    { new Guid("f7970f5f-113c-4b42-a5e0-5e8ac0c828d3"), "reader" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("53e4baf5-aa77-497a-9993-e1c2327f065f"), "joe@doe.com", "Joe", "Doe", "sdFD78s.s#*Flfs-ww", "joedoe" },
                    { new Guid("f8027c67-58b6-465f-9a25-39775e7a1a69"), "joeline@doelina.com", "Joelina", "Doeina", "sdFD78s.s#*Flfs-ww", "joelinadoelina" }
                });

            migrationBuilder.InsertData(
                table: "User_Roles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("3c9a62de-94c0-4743-955d-e763341f7845"), new Guid("589382f2-19bc-4fa9-b457-3e952fe5a264"), new Guid("f8027c67-58b6-465f-9a25-39775e7a1a69") });

            migrationBuilder.InsertData(
                table: "User_Roles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("f76a79c7-d2d7-427d-ba7f-14b33bb5fe8e"), new Guid("f7970f5f-113c-4b42-a5e0-5e8ac0c828d3"), new Guid("53e4baf5-aa77-497a-9993-e1c2327f065f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User_Roles",
                keyColumn: "Id",
                keyValue: new Guid("3c9a62de-94c0-4743-955d-e763341f7845"));

            migrationBuilder.DeleteData(
                table: "User_Roles",
                keyColumn: "Id",
                keyValue: new Guid("f76a79c7-d2d7-427d-ba7f-14b33bb5fe8e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("589382f2-19bc-4fa9-b457-3e952fe5a264"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f7970f5f-113c-4b42-a5e0-5e8ac0c828d3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("53e4baf5-aa77-497a-9993-e1c2327f065f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f8027c67-58b6-465f-9a25-39775e7a1a69"));
        }
    }
}
