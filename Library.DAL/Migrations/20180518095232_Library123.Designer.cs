﻿// <auto-generated />
using Library.DAL.Context;
using Library.Enums.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Library.DAL.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20180518095232_Library123")]
    partial class Library123
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Models.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("Name");

                    b.Property<int>("YearOfPublishing");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Models.Models.Brochure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfPages");

                    b.Property<int>("TypeOfCover");

                    b.HasKey("Id");

                    b.ToTable("Brochures");
                });

            modelBuilder.Entity("Library.Models.Models.Magazine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Number");

                    b.Property<int>("YearOfPublishing");

                    b.HasKey("Id");

                    b.ToTable("Magazines");
                });

            modelBuilder.Entity("Library.Models.Models.PublicationHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PublicationHouses");
                });

            modelBuilder.Entity("Library.Models.Models.PublicationHouseBook", b =>
                {
                    b.Property<int>("PublicationHouseId");

                    b.Property<int>("BookId");

                    b.HasKey("PublicationHouseId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("PublicationHouseBook");
                });

            modelBuilder.Entity("Library.Models.Models.PublicationHouseBook", b =>
                {
                    b.HasOne("Library.Models.Models.Book", "Book")
                        .WithMany("PublicationHouseBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Models.Models.PublicationHouse", "PublicationHouse")
                        .WithMany("PublicationHouseBooks")
                        .HasForeignKey("PublicationHouseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
