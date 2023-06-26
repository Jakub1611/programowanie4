﻿// <auto-generated />
using System;
using LasotaProjekt.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LasotaProjekt.Migrations
{
    [DbContext(typeof(PlanContext))]
    partial class PlanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LasotaProjekt.Model.Grupa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Kierunek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodGrupy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semestr")
                        .HasColumnType("int");

                    b.Property<string>("Stopien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("TrybStud")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypGrupy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Grupy");
                });

            modelBuilder.Entity("LasotaProjekt.Model.PozycjePlanu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Dzien")
                        .HasColumnType("datetime2");

                    b.Property<string>("GodzinaDo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GodzinaOd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GrupaId")
                        .HasColumnType("int");

                    b.Property<int>("PrzedmiotId")
                        .HasColumnType("int");

                    b.Property<string>("Sala")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrupaId");

                    b.HasIndex("PrzedmiotId");

                    b.ToTable("PozycjePlanu");
                });

            modelBuilder.Entity("LasotaProjekt.Model.Przedmiot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Godziny")
                        .HasColumnType("int");

                    b.Property<string>("Kierunek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodPrzedmiotu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazwaPrzedmiotu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RokAkademicki")
                        .HasColumnType("int");

                    b.Property<int>("Semestr")
                        .HasColumnType("int");

                    b.Property<string>("Stopien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrybStud")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Przedmioty");
                });

            modelBuilder.Entity("LasotaProjekt.Model.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrIndeksu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rocznik")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Studenci");
                });

            modelBuilder.Entity("LasotaProjekt.Model.Grupa", b =>
                {
                    b.HasOne("LasotaProjekt.Model.Student", null)
                        .WithMany("GrupyStudenta")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("LasotaProjekt.Model.PozycjePlanu", b =>
                {
                    b.HasOne("LasotaProjekt.Model.Grupa", "Grupa")
                        .WithMany()
                        .HasForeignKey("GrupaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LasotaProjekt.Model.Przedmiot", "Przedmiot")
                        .WithMany()
                        .HasForeignKey("PrzedmiotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupa");

                    b.Navigation("Przedmiot");
                });

            modelBuilder.Entity("LasotaProjekt.Model.Student", b =>
                {
                    b.Navigation("GrupyStudenta");
                });
#pragma warning restore 612, 618
        }
    }
}
