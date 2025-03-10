using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyMVCApp.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribedToNewsletter",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "MembershipTypeId",
                table: "Customers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "MembershipTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignUpFee = table.Column<short>(type: "smallint", nullable: false),
                    DurationInMonths = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscountRate = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MembershipTypes",
                columns: new[] { "Id", "DiscountRate", "DurationInMonths", "Name", "SignUpFee" },
                values: new object[,]
                {
                    { (byte)1, (byte)0, (byte)0, "Pay as You Go", (short)0 },
                    { (byte)2, (byte)10, (byte)1, "Monthly", (short)30 },
                    { (byte)3, (byte)15, (byte)3, "Quarterly", (short)90 },
                    { (byte)4, (byte)20, (byte)12, "Annual", (short)300 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "Name", "Price", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "Comedy", "Shrek", 10m, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Family", "Wall-E", 8m, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Crime", "The Godfather", 9m, new DateTime(1972, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Action", "The Dark Knight", 12m, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Romcom", "Love Next Door", 11m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Sci-Fi", "The Matrix", 13m, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Drama", "The Shawshank Redemption", 14m, new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthdate", "IsSubscribedToNewsletter", "MembershipTypeId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, (byte)1, "Yoo Jae Yi" },
                    { 2, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, (byte)2, "Woo Seul Gi" },
                    { 3, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, (byte)3, "Jung Hae In" },
                    { 4, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, (byte)4, "Jung So Min" },
                    { 5, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, (byte)1, "Nam Joo Hyuk" },
                    { 6, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, (byte)2, "Kim Seon Ho" },
                    { 7, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, (byte)3, "Lee Do Hyun" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipTypes_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipTypes_MembershipTypeId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "MembershipTypes");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MembershipTypeId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsSubscribedToNewsletter",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
