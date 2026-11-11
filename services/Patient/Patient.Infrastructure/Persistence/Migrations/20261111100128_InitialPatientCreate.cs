using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialPatientCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "patients");

            migrationBuilder.CreateTable(
                name: "PATIENTS",
                schema: "patients",
                columns: table => new
                {
                    PATIENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FILE_NO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NATIONAL_ID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DATE_OF_BIRTH = table.Column<DateOnly>(type: "date", nullable: false),
                    GENDER = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    BLOOD_GROUP = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    PHONE_NUMBER = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    CREATION_USER = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    MODIFICATION_USER = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PATIENTS", x => x.PATIENT_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PATIENTS_FILE_NO",
                schema: "patients",
                table: "PATIENTS",
                column: "FILE_NO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PATIENTS_PHONE_NUMBER",
                schema: "patients",
                table: "PATIENTS",
                column: "PHONE_NUMBER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PATIENTS",
                schema: "patients");
        }
    }
}
