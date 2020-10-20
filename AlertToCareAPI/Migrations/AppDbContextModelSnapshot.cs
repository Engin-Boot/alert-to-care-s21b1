﻿// <auto-generated />
using AlertToCareAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlertToCareAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("AlertToCareAPI.Models.BedModel", b =>
                {
                    b.Property<string>("BedId")
                        .HasColumnType("TEXT");

                    b.Property<string>("BedOccupancyStatus")
                        .HasColumnType("TEXT");

                    b.Property<string>("IcuModelIcuId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.HasKey("BedId");

                    b.HasIndex("IcuModelIcuId");

                    b.ToTable("BedModel");
                });

            modelBuilder.Entity("AlertToCareAPI.Models.BedOnAlert", b =>
                {
                    b.Property<string>("BedId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<float>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("BedId");

                    b.ToTable("Beds");
                });

            modelBuilder.Entity("AlertToCareAPI.Models.IcuModel", b =>
                {
                    b.Property<string>("IcuId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Layout")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxBeds")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NoOfBeds")
                        .HasColumnType("INTEGER");

                    b.HasKey("IcuId");

                    b.ToTable("Icu");
                });

            modelBuilder.Entity("AlertToCareAPI.Models.PatientModel", b =>
                {
                    b.Property<string>("PatientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BedId")
                        .HasColumnType("TEXT");

                    b.Property<string>("IcuId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("AlertToCareAPI.Models.VitalsModel", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<float>("LowerLimit")
                        .HasColumnType("REAL");

                    b.Property<string>("PatientModelPatientId")
                        .HasColumnType("TEXT");

                    b.Property<float>("UpperLimit")
                        .HasColumnType("REAL");

                    b.Property<float>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Name");

                    b.HasIndex("PatientModelPatientId");

                    b.ToTable("Vitals");
                });

            modelBuilder.Entity("AlertToCareAPI.Models.BedModel", b =>
                {
                    b.HasOne("AlertToCareAPI.Models.IcuModel", null)
                        .WithMany("Beds")
                        .HasForeignKey("IcuModelIcuId");
                });

            modelBuilder.Entity("AlertToCareAPI.Models.VitalsModel", b =>
                {
                    b.HasOne("AlertToCareAPI.Models.PatientModel", null)
                        .WithMany("Vitals")
                        .HasForeignKey("PatientModelPatientId");
                });
#pragma warning restore 612, 618
        }
    }
}
