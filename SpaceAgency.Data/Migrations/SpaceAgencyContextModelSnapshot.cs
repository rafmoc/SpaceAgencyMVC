﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaceAgency.Data.Data;

#nullable disable

namespace SpaceAgency.Data.Migrations
{
    [DbContext(typeof(SpaceAgencyContext))]
    partial class SpaceAgencyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SpaceAgency.Data.Data.CMS.MainContent", b =>
                {
                    b.Property<int>("IdMainContent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMainContent"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMainContent");

                    b.ToTable("MainContent");
                });

            modelBuilder.Entity("SpaceAgency.Data.Data.CMS.Page", b =>
                {
                    b.Property<int>("IdPage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPage"), 1L, 1);

                    b.Property<string>("BotContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPage");

                    b.ToTable("Page");
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
