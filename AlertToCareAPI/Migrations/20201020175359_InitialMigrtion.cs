using Microsoft.EntityFrameworkCore.Migrations;

namespace AlertToCareAPI.Migrations
{
    public partial class InitialMigrtion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    BedId = table.Column<string>(nullable: false),
                    Value = table.Column<float>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.BedId);
                });

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
                    Location = table.Column<string>(nullable: true),
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
                    PatientModelPatientId = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<float>(nullable: false),
                    LowerLimit = table.Column<float>(nullable: false),
                    UpperLimit = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalsModel", x => new { x.PatientModelPatientId, x.Id });
                    table.ForeignKey(
                        name: "FK_VitalsModel_Patients_PatientModelPatientId",
                        column: x => x.PatientModelPatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BedModel_IcuModelIcuId",
                table: "BedModel",
                column: "IcuModelIcuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BedModel");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "VitalsModel");

            migrationBuilder.DropTable(
                name: "Icu");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
