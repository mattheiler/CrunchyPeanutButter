﻿// <auto-generated />
using System;
using CrunchyPeanutButter.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrunchyPeanutButter.Infrastructure.Migrations
{
    [DbContext(typeof(CrunchyPeanutButterDbContext))]
    [Migration("20210816133556_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrunchyPeanutButter.Core.Models.Bars.Ack", b =>
                {
                    b.Property<Guid>("BarId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BarId");

                    b.ToTable("Ack");
                });

            modelBuilder.Entity("CrunchyPeanutButter.Core.Models.Bars.Bar", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bars");
                });

            modelBuilder.Entity("CrunchyPeanutButter.Core.Models.Foos.Baz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FooId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FooId");

                    b.ToTable("Baz");
                });

            modelBuilder.Entity("CrunchyPeanutButter.Core.Models.Foos.Foo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Foos");
                });

            modelBuilder.Entity("CrunchyPeanutButter.Core.Models.Foos.FooBar", b =>
                {
                    b.Property<Guid>("FooId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BarId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FooId", "BarId");

                    b.HasIndex("BarId");

                    b.ToTable("FooBar");
                });

            modelBuilder.Entity("CrunchyPeanutButter.Core.Models.Bars.Ack", b =>
                {
                    b.HasOne("CrunchyPeanutButter.Core.Models.Bars.Bar", "Bar")
                        .WithOne("Ack")
                        .HasForeignKey("CrunchyPeanutButter.Core.Models.Bars.Ack", "BarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CrunchyPeanutButter.Core.Models.Foos.Baz", b =>
                {
                    b.HasOne("CrunchyPeanutButter.Core.Models.Foos.Foo", "Foo")
                        .WithMany("Bazs")
                        .HasForeignKey("FooId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CrunchyPeanutButter.Core.Models.Foos.FooBar", b =>
                {
                    b.HasOne("CrunchyPeanutButter.Core.Models.Bars.Bar", "Bar")
                        .WithMany()
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrunchyPeanutButter.Core.Models.Foos.Foo", "Foo")
                        .WithMany("Bars")
                        .HasForeignKey("FooId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
