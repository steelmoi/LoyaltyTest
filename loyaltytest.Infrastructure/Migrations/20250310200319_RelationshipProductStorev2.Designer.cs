﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using loyaltytest.Infrastructure;

#nullable disable

namespace loyaltytest.Infrastructure.Migrations
{
    [DbContext(typeof(LoyaltyDBContext))]
    [Migration("20250310200319_RelationshipProductStorev2")]
    partial class RelationshipProductStorev2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductStore", b =>
                {
                    b.Property<long>("ProductsProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("StoresStoreId")
                        .HasColumnType("int");

                    b.HasKey("ProductsProductId", "StoresStoreId");

                    b.HasIndex("StoresStoreId");

                    b.ToTable("ProductStore");
                });

            modelBuilder.Entity("loyaltytest.Domain.Entities.Address", b =>
                {
                    b.Property<long>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AddressId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Colony")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumExt")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NumInt")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("loyaltytest.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("loyaltytest.Domain.Entities.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProductId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SKUProduct")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("loyaltytest.Domain.Entities.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StoreCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("StoreId");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("ProductStore", b =>
                {
                    b.HasOne("loyaltytest.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("loyaltytest.Domain.Entities.Store", null)
                        .WithMany()
                        .HasForeignKey("StoresStoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
