﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrunchyPeanutButter.Data.Migrations
{
    [DbContext(typeof(CrunchyPeanutButterDbContext))]
    internal class CrunchyPeanutButterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrunchyPeanutButter.Domain.Bars.Ack", b =>
            {
                b.Property<int>("BarId")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("BarId");

                b.ToTable("Ack");
            });

            modelBuilder.Entity("CrunchyPeanutButter.Domain.Bars.Bar", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Bars");
            });

            modelBuilder.Entity("CrunchyPeanutButter.Domain.Foos.Baz", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("FooId")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.HasIndex("FooId");

                b.ToTable("Baz");
            });

            modelBuilder.Entity("CrunchyPeanutButter.Domain.Foos.Foo", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Foos");
            });

            modelBuilder.Entity("CrunchyPeanutButter.Domain.Foos.FooBar", b =>
            {
                b.Property<int>("FooId")
                    .HasColumnType("int");

                b.Property<int>("BarId")
                    .HasColumnType("int");

                b.HasKey("FooId", "BarId");

                b.HasIndex("BarId");

                b.ToTable("FooBar");
            });

            modelBuilder.Entity("CrunchyPeanutButter.Domain.Foos.Qux", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("BazId")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.HasIndex("BazId");

                b.ToTable("Qux");
            });

            modelBuilder.Entity("CrunchyPeanutButter.Domain.Bars.Ack", b =>
            {
                b.HasOne("CrunchyPeanutButter.Domain.Bars.Bar", "Bar")
                    .WithOne("Ack")
                    .HasForeignKey("CrunchyPeanutButter.Domain.Bars.Ack", "BarId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("CrunchyPeanutButter.Domain.Bars.Bar", b =>
            {
                b.OwnsOne("CrunchyPeanutButter.Domain.Bars.Fum", "Fum", b1 =>
                {
                    b1.Property<int>("BarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b1.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b1.HasKey("BarId");

                    b1.ToTable("Bars");

                    b1.WithOwner()
                        .HasForeignKey("BarId");
                });
            });

            modelBuilder.Entity("CrunchyPeanutButter.Domain.Foos.Baz", b =>
            {
                b.HasOne("CrunchyPeanutButter.Domain.Foos.Foo", "Foo")
                    .WithMany("Bazes")
                    .HasForeignKey("FooId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("CrunchyPeanutButter.Domain.Foos.FooBar", b =>
            {
                b.HasOne("CrunchyPeanutButter.Domain.Bars.Bar", "Bar")
                    .WithMany()
                    .HasForeignKey("BarId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("CrunchyPeanutButter.Domain.Foos.Foo", "Foo")
                    .WithMany("Bars")
                    .HasForeignKey("FooId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("CrunchyPeanutButter.Domain.Foos.Qux", b =>
            {
                b.HasOne("CrunchyPeanutButter.Domain.Foos.Baz", "Baz")
                    .WithMany("Quxes")
                    .HasForeignKey("BazId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}