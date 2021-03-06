﻿// <auto-generated />
using System;
using GkMS_Test1.Invoice.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GkMS_Test1.Invoice.Data.Migrations
{
    [DbContext(typeof(InvoiceDbContext))]
    partial class InvoiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GkMS_Test1.Invoice.Domain.Models.Invoices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AmtTotal")
                        .HasColumnType("float");

                    b.Property<int>("InvNo")
                        .HasColumnType("int");

                    b.Property<int>("PrinterId")
                        .HasColumnType("int");

                    b.Property<int>("ReadingCurr")
                        .HasColumnType("int");

                    b.Property<int>("ReadingPrev")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrinterId");

                    b.HasIndex("UserId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("GkMS_Test1.Invoice.Domain.Models.Ref_Printer", b =>
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

                    b.Property<int>("RefDbId")
                        .HasColumnType("int");

                    b.Property<string>("SearchableName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Serial")
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Sgst")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Printers");
                });

            modelBuilder.Entity("GkMS_Test1.Invoice.Domain.Models.Ref_PrinterRates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PrinterId")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("RefDbId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ValFrom")
                        .HasColumnType("int");

                    b.Property<int>("ValTo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrinterId");

                    b.HasIndex("UserId");

                    b.ToTable("PrinterRates");
                });

            modelBuilder.Entity("GkMS_Test1.Invoice.Domain.Models.Ref_User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GstNo")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .HasColumnType("Varchar(30)");

                    b.Property<string>("PanNo")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("RefDbId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GkMS_Test1.Invoice.Domain.Models.Ref_UserPrinter", b =>
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

                    b.Property<int>("RefDbId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrinterId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPrinters");
                });

            modelBuilder.Entity("GkMS_Test1.Invoice.Domain.Models.Invoices", b =>
                {
                    b.HasOne("GkMS_Test1.Invoice.Domain.Models.Ref_Printer", "Ref_Printer")
                        .WithMany()
                        .HasForeignKey("PrinterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GkMS_Test1.Invoice.Domain.Models.Ref_User", "Ref_User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GkMS_Test1.Invoice.Domain.Models.Ref_PrinterRates", b =>
                {
                    b.HasOne("GkMS_Test1.Invoice.Domain.Models.Ref_Printer", "Ref_Printer")
                        .WithMany()
                        .HasForeignKey("PrinterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GkMS_Test1.Invoice.Domain.Models.Ref_User", "Ref_User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GkMS_Test1.Invoice.Domain.Models.Ref_UserPrinter", b =>
                {
                    b.HasOne("GkMS_Test1.Invoice.Domain.Models.Ref_Printer", "Ref_Printer")
                        .WithMany()
                        .HasForeignKey("PrinterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GkMS_Test1.Invoice.Domain.Models.Ref_User", "Ref_User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
