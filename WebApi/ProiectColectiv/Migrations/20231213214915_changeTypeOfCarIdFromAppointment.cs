using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectColectiv.Migrations
{
    /// <inheritdoc />
    public partial class changeTypeOfCarIdFromAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
    

            migrationBuilder.AlterColumn<string>(
                name: "CarId",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AlterColumn<Guid>(
                name: "CarId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
