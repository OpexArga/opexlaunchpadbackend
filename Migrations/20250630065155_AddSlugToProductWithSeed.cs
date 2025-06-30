using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendopexlaunchpad.Migrations
{
    /// <inheritdoc />
    public partial class AddSlugToProductWithSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Slug" },
                values: new object[] { "Unlock AI-powered efficiency by connecting your ERP and enterprise systems seamlessly.", "/images/products/opexai.jpg", "opexai" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Slug" },
                values: new object[] { "Digitize your invoicing process with legally compliant e-Invoicing integrated with your system.", "/images/products/einvoice.jpg", "opexeinvoice" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Slug" },
                values: new object[] { "Simplify digital stamping with seamless e-Meterai issuance, legally valid and efficient.", "/images/products/emeterai.jpg", "opexemeterai" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Slug" },
                values: new object[] { "Unlock AI-powered...", "/assets/products1.jpg", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Slug" },
                values: new object[] { "Digitize your invoicing...", "/assets/products2.jpg", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Slug" },
                values: new object[] { "Simplify digital stamping...", "/assets/products3.jpg", "" });
        }
    }
}
