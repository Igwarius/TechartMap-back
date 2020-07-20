﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TechartMap_back.DAL.Context;

namespace TechartMap_back.DAL.Migrations
{
    [DbContext(typeof(Context.Context))]
    [Migration("20200717105753_AddRefreshToken")]
    partial class AddRefreshToken
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TechartMap_back.DAL.Models.RefreshToken", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("character varying(15)");

                    b.Property<string>("Token")
                        .HasColumnType("varchar(2000)");

                    b.HasKey("Login");

                    b.ToTable("RefreshTokens");
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

            modelBuilder.Entity("TechartMap_back.DAL.Models.RefreshToken", b =>
                {
                    b.HasOne("TechartMap_back.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
