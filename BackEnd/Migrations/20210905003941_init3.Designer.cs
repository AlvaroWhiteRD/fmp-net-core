﻿// <auto-generated />
using AlvaroFacturacionApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlvaroFacturacionApi.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20210905003941_init3")]
    partial class init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AlvaroFacturacionApi.Domain.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("PriceOfTheProduct")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("ProductCode")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}