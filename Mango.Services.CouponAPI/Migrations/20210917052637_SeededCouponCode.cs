﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Mango.Services.CouponAPI.Migrations
{
    public partial class SeededCouponCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "coupons",
                columns: new[] { "CouponId", "CouponCode", "DiscountAmount" },
                values: new object[] { 1, "10OFF", 10.0 });

            migrationBuilder.InsertData(
                table: "coupons",
                columns: new[] { "CouponId", "CouponCode", "DiscountAmount" },
                values: new object[] { 2, "20OFF", 30.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "coupons",
                keyColumn: "CouponId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "coupons",
                keyColumn: "CouponId",
                keyValue: 2);
        }
    }
}
