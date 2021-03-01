﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Possumus.Infrastructure.Data;

namespace Possumus.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210301024928_initialconfiguration")]
    partial class initialconfiguration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Possumus.Infrastructure.Data.Entities.Candidato", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Apellido")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Candidatos");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Apellido = "Giardina",
                            FechaNacimiento = new DateTime(2021, 2, 28, 23, 49, 27, 475, DateTimeKind.Local).AddTicks(6682),
                            Nombre = "Mariano"
                        });
                });

            modelBuilder.Entity("Possumus.Infrastructure.Data.Entities.Empleo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CandidatoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.ToTable("Empleos");
                });

            modelBuilder.Entity("Possumus.Infrastructure.Data.Entities.Empleo", b =>
                {
                    b.HasOne("Possumus.Infrastructure.Data.Entities.Candidato", null)
                        .WithMany("Empleos")
                        .HasForeignKey("CandidatoId");
                });
#pragma warning restore 612, 618
        }
    }
}