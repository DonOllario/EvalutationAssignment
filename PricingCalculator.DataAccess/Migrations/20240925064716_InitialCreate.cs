using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PricingCalculator.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FreeDays = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    IsWorkingDayService = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(4,2)", nullable: true, defaultValue: 0m),
                    DiscountStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscountEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerPrice = table.Column<decimal>(type: "decimal(4,2)", nullable: true, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerServices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FreeDays" },
                values: new object[] { new Guid("3aeb3a2f-0e8d-4b88-b33c-5bc15b68b98b"), 200 });

            migrationBuilder.InsertData(
                table: "Customers",
                column: "Id",
                value: new Guid("d7b2c1b1-84c3-4e51-ade6-d2ab5043ed15"));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "BasePrice", "IsWorkingDayService", "Name" },
                values: new object[,]
                {
                    { new Guid("5e162f58-1f6d-4db0-b59f-c82e50aa7b4b"), 0.2m, true, "Service A" },
                    { new Guid("a063fe8d-78e4-4fd5-86a2-57e9f8c5b44e"), 0.24m, true, "Service B" },
                    { new Guid("b597eaab-7ab2-4c67-9fd0-c44b9c8b79e0"), 0.4m, false, "Service C" }
                });

            migrationBuilder.InsertData(
                table: "CustomerServices",
                columns: new[] { "Id", "CustomerId", "Discount", "DiscountEnd", "DiscountStart", "ServiceId", "ServiceStartDate" },
                values: new object[,]
                {
                    { new Guid("b9e1eb9e-0bb1-41f0-a7aa-bd140421f7c0"), new Guid("3aeb3a2f-0e8d-4b88-b33c-5bc15b68b98b"), 0.30m, new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b597eaab-7ab2-4c67-9fd0-c44b9c8b79e0"), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dc1f0d4c-ac34-4aa2-aa95-6f07def2de2e"), new Guid("d7b2c1b1-84c3-4e51-ade6-d2ab5043ed15"), 0.20m, new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b597eaab-7ab2-4c67-9fd0-c44b9c8b79e0"), new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CustomerServices",
                columns: new[] { "Id", "CustomerId", "DiscountEnd", "DiscountStart", "ServiceId", "ServiceStartDate" },
                values: new object[] { new Guid("f2817f57-5f7b-49ef-ba34-adf98a832e3f"), new Guid("d7b2c1b1-84c3-4e51-ade6-d2ab5043ed15"), null, null, new Guid("5e162f58-1f6d-4db0-b59f-c82e50aa7b4b"), new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "CustomerServices",
                columns: new[] { "Id", "CustomerId", "Discount", "DiscountEnd", "DiscountStart", "ServiceId", "ServiceStartDate" },
                values: new object[] { new Guid("fff67807-cc3e-4c43-b38f-3b7afd71d6d1"), new Guid("3aeb3a2f-0e8d-4b88-b33c-5bc15b68b98b"), 0.30m, new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a063fe8d-78e4-4fd5-86a2-57e9f8c5b44e"), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServices_CustomerId",
                table: "CustomerServices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServices_ServiceId",
                table: "CustomerServices",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerServices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
