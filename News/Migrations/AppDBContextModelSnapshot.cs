﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using News.Domain;

namespace News.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("News.Domain.Entities.PostCategory", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("postCategories");
                });

            modelBuilder.Entity("News.Models.PostItem", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("categoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("longDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("showFlag")
                        .HasColumnType("bit");

                    b.Property<string>("titele")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.ToTable("postItems");
                });

            modelBuilder.Entity("News.Models.PostItem", b =>
                {
                    b.HasOne("News.Domain.Entities.PostCategory", "category")
                        .WithMany("posts")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("News.Domain.Entities.PostCategory", b =>
                {
                    b.Navigation("posts");
                });
#pragma warning restore 612, 618
        }
    }
}