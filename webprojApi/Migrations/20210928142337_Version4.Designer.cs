﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webproj.Models;

namespace webproj.Migrations
{
    [DbContext(typeof(SahovskaFederacijaContext))]
    [Migration("20210928142337_Version4")]
    partial class Version4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("webproj.Models.Partija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BeliSahistaId")
                        .HasColumnType("int");

                    b.Property<int?>("CrniSahistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ishod")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Trajanje")
                        .HasColumnType("int");

                    b.Property<int?>("TurnirId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Vreme")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BeliSahistaId");

                    b.HasIndex("CrniSahistaId");

                    b.HasIndex("TurnirId");

                    b.ToTable("Partije");
                });

            modelBuilder.Entity("webproj.Models.Sahista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Broj")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Grad")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Ime")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Prezime")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Rejting")
                        .HasColumnType("int");

                    b.Property<string>("Titula")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Ulica")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Sahisti");
                });

            modelBuilder.Entity("webproj.Models.Turnir", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Grad")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("Kraj")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naziv")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("Pocetak")
                        .HasMaxLength(255)
                        .HasColumnType("datetime2");

                    b.Property<string>("Zemlja")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Turniri");
                });

            modelBuilder.Entity("webproj.Models.Partija", b =>
                {
                    b.HasOne("webproj.Models.Sahista", "BeliSahista")
                        .WithMany()
                        .HasForeignKey("BeliSahistaId");

                    b.HasOne("webproj.Models.Sahista", "CrniSahista")
                        .WithMany()
                        .HasForeignKey("CrniSahistaId");

                    b.HasOne("webproj.Models.Turnir", "Turnir")
                        .WithMany("OdigranePartije")
                        .HasForeignKey("TurnirId");

                    b.Navigation("BeliSahista");

                    b.Navigation("CrniSahista");

                    b.Navigation("Turnir");
                });

            modelBuilder.Entity("webproj.Models.Turnir", b =>
                {
                    b.Navigation("OdigranePartije");
                });
#pragma warning restore 612, 618
        }
    }
}