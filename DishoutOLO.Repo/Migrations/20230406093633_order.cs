using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DishoutOLO.Repo.Migrations
{
    /// <inheritdoc />
    public partial class order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Coupens",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "redemptionType",
                table: "Coupens",
                newName: "RedemptionType");

            migrationBuilder.RenameColumn(
                name: "minOrderAmount",
                table: "Coupens",
                newName: "MinOrderAmount");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Coupens",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "discountTypePercentageval",
                table: "Coupens",
                newName: "DiscountTypePercentageval");

            migrationBuilder.RenameColumn(
                name: "discount",
                table: "Coupens",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Coupens",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "couponName",
                table: "Coupens",
                newName: "CouponName");

            migrationBuilder.RenameColumn(
                name: "couponCode",
                table: "Coupens",
                newName: "CouponCode");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Orderdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Coupens",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "RedemptionType",
                table: "Coupens",
                newName: "redemptionType");

            migrationBuilder.RenameColumn(
                name: "MinOrderAmount",
                table: "Coupens",
                newName: "minOrderAmount");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Coupens",
                newName: "endDate");

            migrationBuilder.RenameColumn(
                name: "DiscountTypePercentageval",
                table: "Coupens",
                newName: "discountTypePercentageval");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Coupens",
                newName: "discount");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Coupens",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CouponName",
                table: "Coupens",
                newName: "couponName");

            migrationBuilder.RenameColumn(
                name: "CouponCode",
                table: "Coupens",
                newName: "couponCode");
        }
    }
}
