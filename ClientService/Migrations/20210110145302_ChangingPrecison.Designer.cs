﻿// <auto-generated />
using System;
using ClientService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClientService.Migrations
{
    [DbContext(typeof(ClientContext))]
    [Migration("20210110145302_ChangingPrecison")]
    partial class ChangingPrecison
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ClientService.Models.Entity.ClientDetailsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PensionTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PensionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ClientDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
