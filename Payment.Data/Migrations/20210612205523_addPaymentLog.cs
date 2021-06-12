using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payment.Data.Migrations
{
    public partial class addPaymentLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "lastUpdatedAt",
                table: "OrderType",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 913, DateTimeKind.Local).AddTicks(3419),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 238, DateTimeKind.Local).AddTicks(9823));

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "OrderType",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 913, DateTimeKind.Local).AddTicks(3072),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 238, DateTimeKind.Local).AddTicks(9383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "lastUpdatedAt",
                table: "OrderStatus",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 911, DateTimeKind.Local).AddTicks(4916),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 236, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "OrderStatus",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 911, DateTimeKind.Local).AddTicks(4569),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 236, DateTimeKind.Local).AddTicks(8481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "lastUpdatedAt",
                table: "OrderInfor",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 910, DateTimeKind.Local).AddTicks(70),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 234, DateTimeKind.Local).AddTicks(6142));

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "OrderInfor",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 909, DateTimeKind.Local).AddTicks(9670),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 234, DateTimeKind.Local).AddTicks(5381));

            migrationBuilder.AlterColumn<DateTime>(
                name: "lastUpdatedAt",
                table: "Bank",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 906, DateTimeKind.Local).AddTicks(4934),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 228, DateTimeKind.Local).AddTicks(5109));

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "Bank",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 903, DateTimeKind.Local).AddTicks(7139),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 215, DateTimeKind.Local).AddTicks(5539));

            migrationBuilder.CreateTable(
                name: "PaymentLog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tmnCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    bankCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bankTranNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cardType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    orderInfor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    transactionNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    responseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txnRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    secureHas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdByusername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdatedByusername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    lastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentLog", x => x.id);
                    table.ForeignKey(
                        name: "FK_PaymentLog_User_createdByusername",
                        column: x => x.createdByusername,
                        principalTable: "User",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentLog_User_lastUpdatedByusername",
                        column: x => x.lastUpdatedByusername,
                        principalTable: "User",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "code",
                keyValue: "00001",
                columns: new[] { "backgroundColor", "forceColor" },
                values: new object[] { "transparent", "black" });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "code",
                keyValue: "00002",
                columns: new[] { "backgroundColor", "forceColor" },
                values: new object[] { "transparent", "green" });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "code",
                keyValue: "00003",
                columns: new[] { "backgroundColor", "forceColor" },
                values: new object[] { "transparent", "red" });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentLog_createdByusername",
                table: "PaymentLog",
                column: "createdByusername");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentLog_lastUpdatedByusername",
                table: "PaymentLog",
                column: "lastUpdatedByusername");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentLog");

            migrationBuilder.AlterColumn<DateTime>(
                name: "lastUpdatedAt",
                table: "OrderType",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 238, DateTimeKind.Local).AddTicks(9823),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 913, DateTimeKind.Local).AddTicks(3419));

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "OrderType",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 238, DateTimeKind.Local).AddTicks(9383),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 913, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.AlterColumn<DateTime>(
                name: "lastUpdatedAt",
                table: "OrderStatus",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 236, DateTimeKind.Local).AddTicks(8885),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 911, DateTimeKind.Local).AddTicks(4916));

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "OrderStatus",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 236, DateTimeKind.Local).AddTicks(8481),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 911, DateTimeKind.Local).AddTicks(4569));

            migrationBuilder.AlterColumn<DateTime>(
                name: "lastUpdatedAt",
                table: "OrderInfor",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 234, DateTimeKind.Local).AddTicks(6142),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 910, DateTimeKind.Local).AddTicks(70));

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "OrderInfor",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 234, DateTimeKind.Local).AddTicks(5381),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 909, DateTimeKind.Local).AddTicks(9670));

            migrationBuilder.AlterColumn<DateTime>(
                name: "lastUpdatedAt",
                table: "Bank",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 228, DateTimeKind.Local).AddTicks(5109),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 906, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "Bank",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 2, 20, 50, 215, DateTimeKind.Local).AddTicks(5539),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 6, 13, 3, 55, 22, 903, DateTimeKind.Local).AddTicks(7139));

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "code",
                keyValue: "00001",
                columns: new[] { "backgroundColor", "forceColor" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "code",
                keyValue: "00002",
                columns: new[] { "backgroundColor", "forceColor" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "code",
                keyValue: "00003",
                columns: new[] { "backgroundColor", "forceColor" },
                values: new object[] { null, null });
        }
    }
}
