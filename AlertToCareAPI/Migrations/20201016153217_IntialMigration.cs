using Microsoft.EntityFrameworkCore.Migrations;

namespace AlertToCareAPI.Migrations
{
    public partial class IntialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Icu",
                columns: table => new
                {
                    IcuId = table.Column<string>(nullable: false),
                    Layout = table.Column<string>(nullable: true),
                    NoOfBeds = table.Column<int>(nullable: false),
                    MaxBeds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icu", x => x.IcuId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    IcuId = table.Column<string>(nullable: true),
                    BedId = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "BedModel",
                columns: table => new
                {
                    BedId = table.Column<string>(nullable: false),
                    BedOccupancyStatus = table.Column<string>(nullable: true),
                    IcuModelIcuId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedModel", x => x.BedId);
                    table.ForeignKey(
                        name: "FK_BedModel_Icu_IcuModelIcuId",
                        column: x => x.IcuModelIcuId,
                        principalTable: "Icu",
                        principalColumn: "IcuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VitalsModel",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<float>(nullable: false),
                    LowerLimit = table.Column<float>(nullable: false),
                    UpperLimit = table.Column<float>(nullable: false),
                    PatientModelPatientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalsModel", x => x.Name);
                    table.ForeignKey(
                        name: "FK_VitalsModel_Patients_PatientModelPatientId",
                        column: x => x.PatientModelPatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BedModel_IcuModelIcuId",
                table: "BedModel",
                column: "IcuModelIcuId");

            migrationBuilder.CreateIndex(
                name: "IX_VitalsModel_PatientModelPatientId",
                table: "VitalsModel",
                column: "PatientModelPatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BedModel");

            migrationBuilder.DropTable(
                name: "VitalsModel");

            migrationBuilder.DropTable(
                name: "Icu");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
