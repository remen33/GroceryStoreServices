﻿// <auto-generated />
using System;
using GroceryStoreServices.Api.Autor.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GroceryStoreServices.Api.Autor.Migrations
{
    [DbContext(typeof(AuthorContext))]
    [Migration("20210927202324_MigrationPostgresInitial")]
    partial class MigrationPostgresInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GroceryStoreServices.Api.Autor.Model.AuthorBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AuthorBookGuid")
                        .HasColumnType("text");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("GroceryStoreServices.Api.Autor.Model.DegreeLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AuthorBookId")
                        .HasColumnType("integer");

                    b.Property<string>("College")
                        .HasColumnType("text");

                    b.Property<DateTime>("DegreeDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DegreeLevelGuid")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorBookId");

                    b.ToTable("DegreeLevel");
                });

            modelBuilder.Entity("GroceryStoreServices.Api.Autor.Model.DegreeLevel", b =>
                {
                    b.HasOne("GroceryStoreServices.Api.Autor.Model.AuthorBook", "AuthorBook")
                        .WithMany("DegreeLevelList")
                        .HasForeignKey("AuthorBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
