using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinances.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class TransactionObservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "Transactions",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observation",
                table: "Transactions");
        }
    }
}
