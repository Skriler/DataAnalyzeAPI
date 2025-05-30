﻿// <auto-generated />
using System;
using DataAnalyzeApi.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAnalyzeApi.Migrations
{
    [DbContext(typeof(DataAnalyzeDbContext))]
    [Migration("20250206203149_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataAnalyzeApi.Models.Entities.DataObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DatasetId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DatasetId");

                    b.ToTable("DataObjects");
                });

            modelBuilder.Entity("DataAnalyzeApi.Models.Entities.Dataset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Datasets");
                });

            modelBuilder.Entity("DataAnalyzeApi.Models.Entities.Parameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DatasetId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DatasetId");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("DataAnalyzeApi.Models.Entities.ParameterValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ObjectId")
                        .HasColumnType("integer");

                    b.Property<int>("ParameterId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ObjectId");

                    b.HasIndex("ParameterId");

                    b.ToTable("ParameterValues");
                });

            modelBuilder.Entity("DataAnalyzeApi.Models.Entities.DataObject", b =>
                {
                    b.HasOne("DataAnalyzeApi.Models.Entities.Dataset", "Dataset")
                        .WithMany("Objects")
                        .HasForeignKey("DatasetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dataset");
                });

            modelBuilder.Entity("DataAnalyzeApi.Models.Entities.Parameter", b =>
                {
                    b.HasOne("DataAnalyzeApi.Models.Entities.Dataset", null)
                        .WithMany("Parameters")
                        .HasForeignKey("DatasetId");
                });

            modelBuilder.Entity("DataAnalyzeApi.Models.Entities.ParameterValue", b =>
                {
                    b.HasOne("DataAnalyzeApi.Models.Entities.DataObject", "Object")
                        .WithMany("Values")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAnalyzeApi.Models.Entities.Parameter", "Parameter")
                        .WithMany()
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Object");

                    b.Navigation("Parameter");
                });

            modelBuilder.Entity("DataAnalyzeApi.Models.Entities.DataObject", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("DataAnalyzeApi.Models.Entities.Dataset", b =>
                {
                    b.Navigation("Objects");

                    b.Navigation("Parameters");
                });
#pragma warning restore 612, 618
        }
    }
}
