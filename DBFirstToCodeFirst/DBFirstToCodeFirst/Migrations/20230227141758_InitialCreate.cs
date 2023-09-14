using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBFirstToCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    amountPayable = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    salesLimit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    registrationDate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__B611CB7D890203F2", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    itemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    price = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    quantity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    creationDate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    updateDate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__56A128AA7C26E468", x => x.itemId);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    saleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerId = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    amountPaid = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    amountLeft = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    totalAmount = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__FAE8F4F55070ED17", x => x.saleId);
                    table.ForeignKey(
                        name: "FK__Sale__customerId__3B75D760",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "customerId");
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    receiptNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    receiptDate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    saleId = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__CAA7A1A4B20CE74F", x => x.receiptNo);
                    table.ForeignKey(
                        name: "FK__Receipt__saleId__3A81B327",
                        column: x => x.saleId,
                        principalTable: "Sale",
                        principalColumn: "saleId");
                });

            migrationBuilder.CreateTable(
                name: "SaleLineItem",
                columns: table => new
                {
                    lineNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    saleId = table.Column<int>(type: "int", nullable: true),
                    itemId = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    amount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__3249B90F56D5DA30", x => x.lineNo);
                    table.ForeignKey(
                        name: "FK__SaleLineI__itemI__3D5E1FD2",
                        column: x => x.itemId,
                        principalTable: "Item",
                        principalColumn: "itemId");
                    table.ForeignKey(
                        name: "FK__SaleLineI__saleI__3C69FB99",
                        column: x => x.saleId,
                        principalTable: "Sale",
                        principalColumn: "saleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_saleId",
                table: "Receipt",
                column: "saleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_customerId",
                table: "Sale",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleLineItem_itemId",
                table: "SaleLineItem",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleLineItem_saleId",
                table: "SaleLineItem",
                column: "saleId");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
