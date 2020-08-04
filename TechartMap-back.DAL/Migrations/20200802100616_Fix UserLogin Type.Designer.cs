﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TechartMap_back.DAL.Context;

namespace TechartMap_back.DAL.Migrations
{
    [DbContext(typeof(Context.Context))]
    [Migration("20200802100616_Fix UserLogin Type")]
    partial class FixUserLoginType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TechartMap_back.DAL.Models.BannedUser", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("character varying(15)");

                    b.Property<DateTime>("BanDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Period")
                        .HasColumnType("integer");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Login");

                    b.ToTable("BannedUsers");
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AgeLimit")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Genre")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CinemaId")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("RowId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RowId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.RefreshToken", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("character varying(15)");

                    b.Property<string>("Token")
                        .HasColumnType("varchar(2000)");

                    b.HasKey("Login");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.Row", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("HallId")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.ToTable("Rows");
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("FilmId")
                        .HasColumnType("integer");

                    b.Property<int>("HallId")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.HasIndex("HallId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Place")
                        .HasColumnType("integer");

                    b.Property<int>("PlaceId")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("Row")
                        .HasColumnType("integer");

                    b.Property<int>("SessionId")
                        .HasColumnType("integer");

                    b.Property<string>("TransactionType")
                        .HasColumnType("text");

                    b.Property<string>("UserLogin")
                        .HasColumnType("character varying(15)");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.HasIndex("UserLogin");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.User", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("character varying(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Login");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.BannedUser", b =>
                {
                    b.HasOne("TechartMap_back.DAL.Models.User", "User")
                        .WithOne("Banned")
                        .HasForeignKey("TechartMap_back.DAL.Models.BannedUser", "Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.Cinema", b =>
                {
                    b.HasOne("TechartMap_back.DAL.Models.City", "City")
                        .WithMany("Cinemas")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.Hall", b =>
                {
                    b.HasOne("TechartMap_back.DAL.Models.Cinema", "Cinema")
                        .WithMany("Halls")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.Place", b =>
                {
                    b.HasOne("TechartMap_back.DAL.Models.Row", "Row")
                        .WithMany("Places")
                        .HasForeignKey("RowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.RefreshToken", b =>
                {
                    b.HasOne("TechartMap_back.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.Row", b =>
                {
                    b.HasOne("TechartMap_back.DAL.Models.Hall", "Hall")
                        .WithMany("Rows")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.Session", b =>
                {
                    b.HasOne("TechartMap_back.DAL.Models.Film", "Film")
                        .WithMany("Sessions")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechartMap_back.DAL.Models.Hall", "Hall")
                        .WithMany("Sessions")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechartMap_back.DAL.Models.Transaction", b =>
                {
                    b.HasOne("TechartMap_back.DAL.Models.Session", "Session")
                        .WithMany("Transactions")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechartMap_back.DAL.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserLogin");
                });
#pragma warning restore 612, 618
        }
    }
}
