﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Restaurant.DataAccess;

#nullable disable

namespace Restaurant.DataAccess.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    [Migration("20220721101444_mustberole")]
    partial class mustberole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Restaurant.Data.Models.Role", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Guid");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("912334a5-f27c-4620-be49-fb992fc89099"),
                            Name = "Admin"
                        },
                        new
                        {
                            Guid = new Guid("baaf5e12-646e-4d2b-aca8-12ac5894eb52"),
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Restaurant.Data.Models.User", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserRoleGuid")
                        .HasColumnType("uuid");

                    b.HasKey("Guid");

                    b.HasIndex("UserRoleGuid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Restaurant.Data.Models.User", b =>
                {
                    b.HasOne("Restaurant.Data.Models.Role", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}