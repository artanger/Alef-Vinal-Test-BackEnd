﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AlefVinalDbContext))]
    [Migration("20211125191922_Create database")]
    partial class Createdatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.Code", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("value")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.ToTable("Codes");
                });
#pragma warning restore 612, 618
        }
    }
}
