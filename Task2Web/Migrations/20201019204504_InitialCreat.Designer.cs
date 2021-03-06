﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task2Web.Models;

namespace Task2Web.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20201019204504_InitialCreat")]
    partial class InitialCreat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Task2Web.Models.Flat", b =>
                {
                    b.Property<int>("FlatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlatFloor")
                        .HasColumnType("int");

                    b.Property<double>("FlatFullArea")
                        .HasColumnType("float");

                    b.Property<double>("FlatLivingSpaceArea")
                        .HasColumnType("float");

                    b.Property<int>("FlatNumber")
                        .HasColumnType("int");

                    b.Property<int>("FlatResidentsAmmount")
                        .HasColumnType("int");

                    b.Property<int>("FlatRoomsAmmount")
                        .HasColumnType("int");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.HasKey("FlatId");

                    b.HasIndex("HouseId");

                    b.ToTable("Flats");
                });

            modelBuilder.Entity("Task2Web.Models.House", b =>
                {
                    b.Property<int>("HId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HouseCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("HousePostIndex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HId");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("Task2Web.Models.Resident", b =>
                {
                    b.Property<int>("ResidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlatId")
                        .HasColumnType("int");

                    b.Property<string>("ResidentBirthday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentPersonalID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResidentId");

                    b.HasIndex("FlatId");

                    b.ToTable("Residents");
                });

            modelBuilder.Entity("Task2Web.Models.Flat", b =>
                {
                    b.HasOne("Task2Web.Models.House", "House")
                        .WithMany("Flats")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Task2Web.Models.Resident", b =>
                {
                    b.HasOne("Task2Web.Models.Flat", "Flat")
                        .WithMany("Residents")
                        .HasForeignKey("FlatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
