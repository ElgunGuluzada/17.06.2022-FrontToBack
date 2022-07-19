using Microsoft.EntityFrameworkCore.Migrations;

namespace _17._06._2022_FrontToBack.Migrations
{
    public partial class addSaleAndSalesProductsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04673540-4499-4d5f-8f4d-96910ad750b6",
                column: "ConcurrencyStamp",
                value: "3cd85441-f3f2-4281-80b2-cbd9443dac0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05248ae5-b5a7-4738-b2c8-10a22a35a133",
                column: "ConcurrencyStamp",
                value: "ea977dfa-2018-4c38-9719-721e41511274");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72a18405-9054-48e1-867b-0a9731fd771c",
                column: "ConcurrencyStamp",
                value: "a2994cbb-a34b-48d5-88cb-38c48cc1b189");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04673540-4499-4d5f-8f4d-96910ad750b6",
                column: "ConcurrencyStamp",
                value: "fdafb958-84f8-4e3c-94c7-ab6324456118");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05248ae5-b5a7-4738-b2c8-10a22a35a133",
                column: "ConcurrencyStamp",
                value: "590b6576-740b-41bc-8dae-c4b22180ad48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72a18405-9054-48e1-867b-0a9731fd771c",
                column: "ConcurrencyStamp",
                value: "2de8c1fd-cfbf-4187-984f-b11992ac1ba7");
        }
    }
}
