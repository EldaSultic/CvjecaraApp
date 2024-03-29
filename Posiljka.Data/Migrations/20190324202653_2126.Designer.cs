﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Posiljka.Data.EF;

namespace Posiljka.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20190324202653_2126")]
    partial class _2126
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Posiljka.Data.EntityModels.AutorizacijskiToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IpAdresa");

                    b.Property<int>("KorisnickiNalogId");

                    b.Property<string>("Vrijednost");

                    b.Property<DateTime>("VrijemeEvidentiranja");

                    b.Property<string>("deviceInfo");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("AutorizacijskiToken");
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.Boja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Boja");
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.Cijena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("CijenaPoKomadu");

                    b.HasKey("Id");

                    b.ToTable("Cijena");
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.KorisnickiNalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Emaik");

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Lozinka");

                    b.HasKey("Id");

                    b.ToTable("KorisnickiNalog");
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime");

                    b.Property<int?>("KorisnickiNalogId");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.Narudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float?>("KonacnaCijena");

                    b.Property<int>("KorisnickiNalogId");

                    b.Property<int?>("TopPonudaId");

                    b.Property<string>("adresa");

                    b.Property<string>("ime");

                    b.Property<string>("prezime");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.HasIndex("TopPonudaId");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.Narudzba_Stavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KolicinaCvjetova");

                    b.Property<int?>("KolicinaUkrasa");

                    b.Property<string>("Poruka");

                    b.Property<int?>("UkrasId");

                    b.Property<int>("VrstaCvijetaId");

                    b.HasKey("Id");

                    b.HasIndex("UkrasId");

                    b.HasIndex("VrstaCvijetaId");

                    b.ToTable("Narudzba_Stavka");
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.TopPonuda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CijenaId");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.HasIndex("CijenaId");

                    b.ToTable("TopPonuda");
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.Ukras", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CijenaId");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.HasIndex("CijenaId");

                    b.ToTable("Ukras");
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.VrstaCvijeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CijenaId");

                    b.Property<string>("Vrsta");

                    b.HasKey("Id");

                    b.HasIndex("CijenaId");

                    b.ToTable("VrstaCvijeta");
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.VrstaCvijeta_Boja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BojaId");

                    b.Property<int>("VrstaCvijetaId");

                    b.HasKey("Id");

                    b.HasIndex("BojaId");

                    b.HasIndex("VrstaCvijetaId");

                    b.ToTable("VrstaCvijeta_Boja");
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.AutorizacijskiToken", b =>
                {
                    b.HasOne("Posiljka.Data.EntityModels.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.Korisnik", b =>
                {
                    b.HasOne("Posiljka.Data.EntityModels.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId");
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.Narudzba", b =>
                {
                    b.HasOne("Posiljka.Data.EntityModels.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Posiljka.Data.EntityModels.TopPonuda", "TopPonuda")
                        .WithMany()
                        .HasForeignKey("TopPonudaId");
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.Narudzba_Stavka", b =>
                {
                    b.HasOne("Posiljka.Data.EntityModels.Ukras", "Ukras")
                        .WithMany()
                        .HasForeignKey("UkrasId");

                    b.HasOne("Posiljka.Data.EntityModels.VrstaCvijeta", "VrstaCvijeta")
                        .WithMany()
                        .HasForeignKey("VrstaCvijetaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.TopPonuda", b =>
                {
                    b.HasOne("Posiljka.Data.EntityModels.Cijena", "Cijena")
                        .WithMany()
                        .HasForeignKey("CijenaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.Ukras", b =>
                {
                    b.HasOne("Posiljka.Data.EntityModels.Cijena", "Cijena")
                        .WithMany()
                        .HasForeignKey("CijenaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.VrstaCvijeta", b =>
                {
                    b.HasOne("Posiljka.Data.EntityModels.Cijena", "Cijena")
                        .WithMany()
                        .HasForeignKey("CijenaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Posiljka.Data.EntityModels.VrstaCvijeta_Boja", b =>
                {
                    b.HasOne("Posiljka.Data.EntityModels.Boja", "Boja")
                        .WithMany()
                        .HasForeignKey("BojaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Posiljka.Data.EntityModels.VrstaCvijeta", "VrstaCvijeta")
                        .WithMany()
                        .HasForeignKey("VrstaCvijetaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
