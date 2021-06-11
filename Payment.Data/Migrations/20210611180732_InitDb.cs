using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payment.Data.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    hashkey = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    bankCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    bankName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    bankShortName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    bankLogo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    createdByusername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2021, 6, 12, 1, 7, 31, 828, DateTimeKind.Local).AddTicks(772)),
                    lastUpdatedByusername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    lastUpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2021, 6, 12, 1, 7, 31, 831, DateTimeKind.Local).AddTicks(2309))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.bankCode);
                    table.ForeignKey(
                        name: "FK_Bank_User_createdByusername",
                        column: x => x.createdByusername,
                        principalTable: "User",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bank_User_lastUpdatedByusername",
                        column: x => x.lastUpdatedByusername,
                        principalTable: "User",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    createdByusername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2021, 6, 12, 1, 7, 31, 838, DateTimeKind.Local).AddTicks(2618)),
                    lastUpdatedByusername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    lastUpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2021, 6, 12, 1, 7, 31, 838, DateTimeKind.Local).AddTicks(3114))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.code);
                    table.ForeignKey(
                        name: "FK_OrderStatus_User_createdByusername",
                        column: x => x.createdByusername,
                        principalTable: "User",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderStatus_User_lastUpdatedByusername",
                        column: x => x.lastUpdatedByusername,
                        principalTable: "User",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderType",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    shortName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    createdByusername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2021, 6, 12, 1, 7, 31, 839, DateTimeKind.Local).AddTicks(5779)),
                    lastUpdatedByusername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    lastUpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2021, 6, 12, 1, 7, 31, 839, DateTimeKind.Local).AddTicks(6096))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderType", x => x.code);
                    table.ForeignKey(
                        name: "FK_OrderType_User_createdByusername",
                        column: x => x.createdByusername,
                        principalTable: "User",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderType_User_lastUpdatedByusername",
                        column: x => x.lastUpdatedByusername,
                        principalTable: "User",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderInfor",
                columns: table => new
                {
                    orderId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    orderDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(19,9)", nullable: false),
                    bankCode = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    statuscode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    transactionNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    message = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    responseCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    createdByusername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2021, 6, 12, 1, 7, 31, 836, DateTimeKind.Local).AddTicks(5188)),
                    lastUpdatedByusername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    lastUpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2021, 6, 12, 1, 7, 31, 836, DateTimeKind.Local).AddTicks(5663))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInfor", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_OrderInfor_Bank_bankCode",
                        column: x => x.bankCode,
                        principalTable: "Bank",
                        principalColumn: "bankCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderInfor_OrderStatus_statuscode",
                        column: x => x.statuscode,
                        principalTable: "OrderStatus",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderInfor_User_createdByusername",
                        column: x => x.createdByusername,
                        principalTable: "User",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderInfor_User_lastUpdatedByusername",
                        column: x => x.lastUpdatedByusername,
                        principalTable: "User",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "code", "name" },
                values: new object[,]
                {
                    { "en", "English" },
                    { "vn", "Việt Nam" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "code", "createdByusername", "lastUpdatedByusername", "name" },
                values: new object[,]
                {
                    { "00001", null, null, "Chưa thanh tóan" },
                    { "00002", null, null, "Đã thanh tóan" },
                    { "00003", null, null, "Giao dịch lỗi" }
                });

            migrationBuilder.InsertData(
                table: "OrderType",
                columns: new[] { "code", "createdByusername", "lastUpdatedByusername", "name", "note", "shortName" },
                values: new object[,]
                {
                    { "topup", null, null, "Nạp tiền điện thoại", "TEST", "Nạp tiền điện thoại" },
                    { "billpayment", null, null, "Thanh toán hóa đơn", "TEST", "Thanh toán hóa đơn" },
                    { "fashion", null, null, "Thời trang", "TEST", "Thời trang" },
                    { "other", null, null, "Thanh toán trực tuyến", "TEST", "Thanh toán trực tuyến" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bank_createdByusername",
                table: "Bank",
                column: "createdByusername");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_lastUpdatedByusername",
                table: "Bank",
                column: "lastUpdatedByusername");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfor_bankCode",
                table: "OrderInfor",
                column: "bankCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfor_createdByusername",
                table: "OrderInfor",
                column: "createdByusername");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfor_lastUpdatedByusername",
                table: "OrderInfor",
                column: "lastUpdatedByusername");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfor_statuscode",
                table: "OrderInfor",
                column: "statuscode");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatus_createdByusername",
                table: "OrderStatus",
                column: "createdByusername");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatus_lastUpdatedByusername",
                table: "OrderStatus",
                column: "lastUpdatedByusername");

            migrationBuilder.CreateIndex(
                name: "IX_OrderType_createdByusername",
                table: "OrderType",
                column: "createdByusername");

            migrationBuilder.CreateIndex(
                name: "IX_OrderType_lastUpdatedByusername",
                table: "OrderType",
                column: "lastUpdatedByusername");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "OrderInfor");

            migrationBuilder.DropTable(
                name: "OrderType");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
