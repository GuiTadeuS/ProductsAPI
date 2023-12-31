﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsAPI.Data;

#nullable disable

namespace ProductsAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductsAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 11, 23, 22, 26, 37, 150, DateTimeKind.Local).AddTicks(7460),
                            Description = "Luva tamanho 9",
                            ImageURL = "https://img.irroba.com.br/filters:fill(fff):quality(80)/soaquife/catalog/luva-profissional-ldi/luva-mecanico-02safetytato-alta-sensibilidade-pu-8010.jpg",
                            Name = "Luva",
                            Price = 25f
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 11, 23, 22, 26, 37, 150, DateTimeKind.Local).AddTicks(7473),
                            Description = "Mascara descartavel",
                            ImageURL = "https://cdn.awsli.com.br/2126/2126528/produto/135495613/f871fa1a82.jpg",
                            Name = "Mascara",
                            Price = 5f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
