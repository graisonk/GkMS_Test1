﻿// <auto-generated />
using System;
using GkMS_Test1.Printers.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GkMS_Test1.Printers.Data.Migrations
{
    [DbContext(typeof(PrinterDbContext))]
    [Migration("20201003072558_modelUpd1")]
    partial class modelUpd1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GkMS_Test1.Printers.Domain.Models.Printer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cgst")
                        .HasColumnType("float");

                    b.Property<string>("Hsn")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("SearchableName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Serial")
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Sgst")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Printers");
                });

            modelBuilder.Entity("GkMS_Test1.Printers.Domain.Models.UserPrinter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateInstall")
                        .HasColumnType("datetime2");

                    b.Property<double>("DepositAmt")
                        .HasColumnType("float");

                    b.Property<string>("Period")
                        .HasColumnType("varchar(15)");

                    b.Property<int>("PrinterId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrinterId");

                    b.ToTable("UserPrinters");
                });

            modelBuilder.Entity("GkMS_Test1.Printers.Domain.Models.UserPrinter", b =>
                {
                    b.HasOne("GkMS_Test1.Printers.Domain.Models.Printer", "Printer")
                        .WithMany()
                        .HasForeignKey("PrinterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}