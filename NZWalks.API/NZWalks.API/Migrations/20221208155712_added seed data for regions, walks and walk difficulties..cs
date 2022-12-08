using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    public partial class addedseeddataforregionswalksandwalkdifficulties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1cd8c4a5-7ebc-4a47-9414-4af84fad5ae5"));

            migrationBuilder.DeleteData(
                table: "User_Roles",
                keyColumn: "Id",
                keyValue: new Guid("0189240d-1d52-4bde-8856-206e9cd78092"));

            migrationBuilder.DeleteData(
                table: "User_Roles",
                keyColumn: "Id",
                keyValue: new Guid("b95a9565-77ef-4b68-a200-576cb0bdfce7"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("fb6e3ca3-684e-4e07-ae57-cadff8241657"));

            migrationBuilder.DeleteData(
                table: "WalksDifficulty",
                keyColumn: "Id",
                keyValue: new Guid("3d5d1cd1-c8b2-45e4-a6a4-7807e9a0ffa2"));

            migrationBuilder.DeleteData(
                table: "WalksDifficulty",
                keyColumn: "Id",
                keyValue: new Guid("636c376e-d42a-4b12-9638-2c16a81cc2a1"));

            migrationBuilder.DeleteData(
                table: "WalksDifficulty",
                keyColumn: "Id",
                keyValue: new Guid("ceafb2d9-b082-4caf-9255-30ca136a4469"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5ea0adbb-c6b2-4e5c-8a77-f119f054b6a3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d82bd387-2a7d-4332-ab88-fd6c06a4916d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaab4840-cc75-4233-b342-138a9a22cba9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69fb3dc-51e1-46ec-8308-7ee74c9f3e42"));

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Area", "Code", "Lat", "Long", "Name", "Population" },
                values: new object[,]
                {
                    { new Guid("5573d920-00f8-4723-b69b-1940d9a7b926"), 13789.0, "NRTHL", -35.370830400000003, 172.57178250000001, "Northland Region", 194600L },
                    { new Guid("8f0fa5b3-7892-4aa1-8940-52b45e17e868"), 4894.0, "AUCK", -36.525320700000002, 173.77857040000001, "Auckland Region", 1718982L },
                    { new Guid("b5083949-5c56-47a6-8e14-d50e9a1d1449"), 12230.0, "BAYP", -37.532825899999999, 175.7642701, "Bay of Plenty Region", 345400L },
                    { new Guid("b9034866-b467-4663-9cb5-b49bc1121513"), 8970.0, "WAIK", -37.514458400000002, 174.54051279999999, "Waikato Region", 496700L }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("239a4ee9-6d0b-4549-9427-4c7a1381a424"), "writer" },
                    { new Guid("7b0a60a6-f14e-4b2c-b50f-76e7c8bdb0b1"), "reader" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("22881732-88b5-4653-9fbf-ad60f1c55360"), "joe@doe.com", "Joe", "Doe", "sdFD78s.s#*Flfs-ww", "joedoe" },
                    { new Guid("9a7b4530-7a8b-4c65-aa22-ef902bd2a928"), "joeline@doelina.com", "Joelina", "Doeina", "sdFD78s.s#*Flfs-ww", "joelinadoelina" }
                });

            migrationBuilder.InsertData(
                table: "WalksDifficulty",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { new Guid("140f9559-7359-430b-90b2-b3881c1c924a"), "Hard" },
                    { new Guid("5cdc193b-b319-4bb5-967d-408582cfd73c"), "Medium" },
                    { new Guid("94e7794f-00a9-4071-a0ee-034dd6e217eb"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "User_Roles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0f42ed23-2796-4687-b91c-b67ed2deadad"), new Guid("239a4ee9-6d0b-4549-9427-4c7a1381a424"), new Guid("9a7b4530-7a8b-4c65-aa22-ef902bd2a928") },
                    { new Guid("8bca6750-40b6-45af-a3d6-ad430f9ef558"), new Guid("7b0a60a6-f14e-4b2c-b50f-76e7c8bdb0b1"), new Guid("22881732-88b5-4653-9fbf-ad60f1c55360") }
                });

            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Length", "Name", "RegionId", "WalkDifficultyId" },
                values: new object[,]
                {
                    { new Guid("02bb8ca3-d9cd-4f12-9c2d-64b5a8f2b56c"), 1.2, "Lonely Bay", new Guid("b9034866-b467-4663-9cb5-b49bc1121513"), new Guid("94e7794f-00a9-4071-a0ee-034dd6e217eb") },
                    { new Guid("11803224-9dec-47b8-ac88-1dcae1b286b3"), 1.5, "Waiotemarama Loop Track", new Guid("5573d920-00f8-4723-b69b-1940d9a7b926"), new Guid("5cdc193b-b319-4bb5-967d-408582cfd73c") },
                    { new Guid("1e4f2b92-b698-4429-b78b-20e96086dd93"), 32.0, "Mt Te Aroha To Wharawhara Track Walk", new Guid("b5083949-5c56-47a6-8e14-d50e9a1d1449"), new Guid("140f9559-7359-430b-90b2-b3881c1c924a") },
                    { new Guid("8eee7a75-6525-4cea-b943-917b90fb592f"), 3.5, "One Tree Hill Walk", new Guid("8f0fa5b3-7892-4aa1-8940-52b45e17e868"), new Guid("94e7794f-00a9-4071-a0ee-034dd6e217eb") },
                    { new Guid("9d3264f1-3d42-4afe-a521-724d0ae495cf"), 3.5, "Rainbow Mountain Reserve Walk", new Guid("b5083949-5c56-47a6-8e14-d50e9a1d1449"), new Guid("140f9559-7359-430b-90b2-b3881c1c924a") },
                    { new Guid("c601a364-6330-4e00-a180-c121a0e052d0"), 2.0, "Mt Eden Volcano Walk", new Guid("8f0fa5b3-7892-4aa1-8940-52b45e17e868"), new Guid("94e7794f-00a9-4071-a0ee-034dd6e217eb") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User_Roles",
                keyColumn: "Id",
                keyValue: new Guid("0f42ed23-2796-4687-b91c-b67ed2deadad"));

            migrationBuilder.DeleteData(
                table: "User_Roles",
                keyColumn: "Id",
                keyValue: new Guid("8bca6750-40b6-45af-a3d6-ad430f9ef558"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("02bb8ca3-d9cd-4f12-9c2d-64b5a8f2b56c"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("11803224-9dec-47b8-ac88-1dcae1b286b3"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("1e4f2b92-b698-4429-b78b-20e96086dd93"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("8eee7a75-6525-4cea-b943-917b90fb592f"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("9d3264f1-3d42-4afe-a521-724d0ae495cf"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("c601a364-6330-4e00-a180-c121a0e052d0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5573d920-00f8-4723-b69b-1940d9a7b926"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8f0fa5b3-7892-4aa1-8940-52b45e17e868"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b5083949-5c56-47a6-8e14-d50e9a1d1449"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b9034866-b467-4663-9cb5-b49bc1121513"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("239a4ee9-6d0b-4549-9427-4c7a1381a424"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7b0a60a6-f14e-4b2c-b50f-76e7c8bdb0b1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22881732-88b5-4653-9fbf-ad60f1c55360"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9a7b4530-7a8b-4c65-aa22-ef902bd2a928"));

            migrationBuilder.DeleteData(
                table: "WalksDifficulty",
                keyColumn: "Id",
                keyValue: new Guid("140f9559-7359-430b-90b2-b3881c1c924a"));

            migrationBuilder.DeleteData(
                table: "WalksDifficulty",
                keyColumn: "Id",
                keyValue: new Guid("5cdc193b-b319-4bb5-967d-408582cfd73c"));

            migrationBuilder.DeleteData(
                table: "WalksDifficulty",
                keyColumn: "Id",
                keyValue: new Guid("94e7794f-00a9-4071-a0ee-034dd6e217eb"));

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Area", "Code", "Lat", "Long", "Name", "Population" },
                values: new object[] { new Guid("1cd8c4a5-7ebc-4a47-9414-4af84fad5ae5"), 13789.0, "NRTHL", -35.370830400000003, 172.57178250000001, "Northland Region", 194600L });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5ea0adbb-c6b2-4e5c-8a77-f119f054b6a3"), "reader" },
                    { new Guid("d82bd387-2a7d-4332-ab88-fd6c06a4916d"), "writer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("aaab4840-cc75-4233-b342-138a9a22cba9"), "joeline@doelina.com", "Joelina", "Doeina", "sdFD78s.s#*Flfs-ww", "joelinadoelina" },
                    { new Guid("f69fb3dc-51e1-46ec-8308-7ee74c9f3e42"), "joe@doe.com", "Joe", "Doe", "sdFD78s.s#*Flfs-ww", "joedoe" }
                });

            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Length", "Name", "RegionId", "WalkDifficultyId" },
                values: new object[] { new Guid("fb6e3ca3-684e-4e07-ae57-cadff8241657"), 1.5, "Waiotemarama Loop Track", new Guid("68bbb660-b89b-4aea-8621-201169ddc208"), new Guid("9307a3b1-f03e-41bb-9e39-db5be20e9c88") });

            migrationBuilder.InsertData(
                table: "WalksDifficulty",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { new Guid("3d5d1cd1-c8b2-45e4-a6a4-7807e9a0ffa2"), "Easy" },
                    { new Guid("636c376e-d42a-4b12-9638-2c16a81cc2a1"), "Hard" },
                    { new Guid("ceafb2d9-b082-4caf-9255-30ca136a4469"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "User_Roles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("0189240d-1d52-4bde-8856-206e9cd78092"), new Guid("5ea0adbb-c6b2-4e5c-8a77-f119f054b6a3"), new Guid("f69fb3dc-51e1-46ec-8308-7ee74c9f3e42") });

            migrationBuilder.InsertData(
                table: "User_Roles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("b95a9565-77ef-4b68-a200-576cb0bdfce7"), new Guid("d82bd387-2a7d-4332-ab88-fd6c06a4916d"), new Guid("aaab4840-cc75-4233-b342-138a9a22cba9") });
        }
    }
}
