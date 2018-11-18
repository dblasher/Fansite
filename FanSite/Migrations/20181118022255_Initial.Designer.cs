﻿// <auto-generated />
using System;
using FanSite.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FanSite.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20181118022255_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FanSite.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("PubDate");

                    b.Property<string>("Title");

                    b.HasKey("BookID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("FanSite.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentText")
                        .IsRequired();

                    b.Property<int>("CommenterUserID");

                    b.Property<int?>("StoryResponseID");

                    b.HasKey("CommentID");

                    b.HasIndex("CommenterUserID");

                    b.HasIndex("StoryResponseID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("FanSite.Models.Link", b =>
                {
                    b.Property<int>("LinkID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.Property<string>("URL");

                    b.HasKey("LinkID");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("FanSite.Models.StoryResponse", b =>
                {
                    b.Property<int>("StoryResponseID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorUserID");

                    b.Property<string>("Date")
                        .IsRequired();

                    b.Property<int>("Rating");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("StoryResponseID");

                    b.HasIndex("AuthorUserID");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("FanSite.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FanSite.Models.Comment", b =>
                {
                    b.HasOne("FanSite.Models.User", "Commenter")
                        .WithMany("Comments")
                        .HasForeignKey("CommenterUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FanSite.Models.StoryResponse")
                        .WithMany("Comments")
                        .HasForeignKey("StoryResponseID");
                });

            modelBuilder.Entity("FanSite.Models.StoryResponse", b =>
                {
                    b.HasOne("FanSite.Models.User", "Author")
                        .WithMany("Stories")
                        .HasForeignKey("AuthorUserID");
                });
#pragma warning restore 612, 618
        }
    }
}
