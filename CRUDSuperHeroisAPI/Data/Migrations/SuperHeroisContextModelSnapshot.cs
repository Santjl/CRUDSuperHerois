﻿// <auto-generated />
using System;
using CRUDSuperHeroisAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRUDSuperHeroisAPI.Migrations
{
    [DbContext(typeof(SuperHeroisContext))]
    partial class SuperHeroisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRUDSuperHeroisAPI.Domain.Models.Herois", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Altura")
                        .HasColumnType("float");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("NomeHeroi")
                        .IsRequired()
                        .HasColumnType("nvarchar(120)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Herois");
                });

            modelBuilder.Entity("CRUDSuperHeroisAPI.Domain.Models.HeroisSuperpoderes", b =>
                {
                    b.Property<int>("HeroiId")
                        .HasColumnType("int");

                    b.Property<int>("SuperpoderId")
                        .HasColumnType("int");

                    b.HasKey("HeroiId", "SuperpoderId");

                    b.HasIndex("SuperpoderId");

                    b.ToTable("HeroisSuperpoderes");
                });

            modelBuilder.Entity("CRUDSuperHeroisAPI.Domain.Models.Superpoderes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Superpoder")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Superpoderes");
                });

            modelBuilder.Entity("CRUDSuperHeroisAPI.Domain.Models.HeroisSuperpoderes", b =>
                {
                    b.HasOne("CRUDSuperHeroisAPI.Domain.Models.Herois", "Herois")
                        .WithMany("HeroisSuperpoderes")
                        .HasForeignKey("HeroiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CRUDSuperHeroisAPI.Domain.Models.Superpoderes", "Superpoderes")
                        .WithMany("HeroisSuperpoderes")
                        .HasForeignKey("SuperpoderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Herois");

                    b.Navigation("Superpoderes");
                });

            modelBuilder.Entity("CRUDSuperHeroisAPI.Domain.Models.Herois", b =>
                {
                    b.Navigation("HeroisSuperpoderes");
                });

            modelBuilder.Entity("CRUDSuperHeroisAPI.Domain.Models.Superpoderes", b =>
                {
                    b.Navigation("HeroisSuperpoderes");
                });
#pragma warning restore 612, 618
        }
    }
}