﻿// <auto-generated />
using System;
using Library.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Library.Repository.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20180725001856_NullablePublishierOnBook")]
    partial class NullablePublishierOnBook
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Library.Domain.Entities.AuthorBookEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorId");

                    b.Property<Guid>("BookId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorsBooks");
                });

            modelBuilder.Entity("Library.Domain.Entities.AuthorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<Guid?>("PublishierId");

                    b.HasKey("Id");

                    b.HasIndex("PublishierId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Library.Domain.Entities.BookCategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BookId");

                    b.Property<int>("Category");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("BookCategoryEntity");
                });

            modelBuilder.Entity("Library.Domain.Entities.BookEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.Property<Guid?>("PublishierId");

                    b.HasKey("Id");

                    b.HasIndex("PublishierId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Domain.Entities.PublishierEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Publishiers");
                });

            modelBuilder.Entity("Library.Domain.Entities.AuthorBookEntity", b =>
                {
                    b.HasOne("Library.Domain.Entities.AuthorEntity", "Author")
                        .WithMany("BooksAuthor")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Domain.Entities.BookEntity", "Book")
                        .WithMany("AuthorsBook")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Library.Domain.Entities.AuthorEntity", b =>
                {
                    b.HasOne("Library.Domain.Entities.PublishierEntity", "Publishier")
                        .WithMany("Authors")
                        .HasForeignKey("PublishierId");
                });

            modelBuilder.Entity("Library.Domain.Entities.BookCategoryEntity", b =>
                {
                    b.HasOne("Library.Domain.Entities.BookEntity", "Book")
                        .WithMany("BookCategories")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Library.Domain.Entities.BookEntity", b =>
                {
                    b.HasOne("Library.Domain.Entities.PublishierEntity", "Publishier")
                        .WithMany("PublishedBooks")
                        .HasForeignKey("PublishierId");
                });
#pragma warning restore 612, 618
        }
    }
}
