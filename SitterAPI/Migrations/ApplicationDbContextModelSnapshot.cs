﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SitterAPI.Models;

namespace SitterAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SitterAPI.Models.Baby", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("City");

                    b.Property<string>("Gender");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("SpecialNeeds");

                    b.Property<string>("Username");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Babies");
                });

            modelBuilder.Entity("SitterAPI.Models.Sitter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("City");

                    b.Property<string>("Gender");

                    b.Property<double>("HourlyWage");

                    b.Property<string>("Name");

                    b.Property<bool>("NoChildRecord");

                    b.Property<bool>("NoCriminalRecord");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Sitters");
                });
#pragma warning restore 612, 618
        }
    }
}
