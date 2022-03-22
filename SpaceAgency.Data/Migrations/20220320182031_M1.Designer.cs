﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaceAgency.Data.Data;

#nullable disable

namespace SpaceAgency.Data.Migrations
{
    [DbContext(typeof(SpaceAgencyContext))]
    [Migration("20220320182031_M1")]
    partial class M1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SpaceAgency.Data.Data.CMS.Mission", b =>
                {
                    b.Property<int>("IdMission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMission"), 1L, 1);

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMission");

                    b.ToTable("Mission");
                });

            modelBuilder.Entity("SpaceAgency.Data.Data.CMS.Pioneer", b =>
                {
                    b.Property<int>("IdPioneer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPioneer"), 1L, 1);

                    b.Property<string>("CurrentPlanet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPioneer");

                    b.ToTable("Pioneer");
                });

            modelBuilder.Entity("SpaceAgency.Data.Data.CMS.Structure", b =>
                {
                    b.Property<int>("IdStructure")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStructure"), 1L, 1);

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Planet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdStructure");

                    b.ToTable("Structure");
                });

            modelBuilder.Entity("SpaceAgency.Data.Data.Rockets.Engine", b =>
                {
                    b.Property<int>("IdEngine")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEngine"), 1L, 1);

                    b.Property<int>("IdRocket")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RocketIdRocket")
                        .HasColumnType("int");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEngine");

                    b.HasIndex("RocketIdRocket");

                    b.ToTable("Engine");
                });

            modelBuilder.Entity("SpaceAgency.Data.Data.Rockets.Rocket", b =>
                {
                    b.Property<int>("IdRocket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRocket"), 1L, 1);

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRocket");

                    b.ToTable("Rocket");
                });

            modelBuilder.Entity("SpaceAgency.Data.Data.Rockets.Engine", b =>
                {
                    b.HasOne("SpaceAgency.Data.Data.Rockets.Rocket", "Rocket")
                        .WithMany("Engine")
                        .HasForeignKey("RocketIdRocket")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rocket");
                });

            modelBuilder.Entity("SpaceAgency.Data.Data.Rockets.Rocket", b =>
                {
                    b.Navigation("Engine");
                });
#pragma warning restore 612, 618
        }
    }
}
