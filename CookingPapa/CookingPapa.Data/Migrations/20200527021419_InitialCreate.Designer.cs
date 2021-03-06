﻿// <auto-generated />
using System;
using CookingPapa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CookingPapa.Data.Migrations
{
    [DbContext(typeof(CookingpapaContext))]
    [Migration("20200527021419_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CookingPapa.Domain.Models.Cookbook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("CookBook");
                });

            modelBuilder.Entity("CookingPapa.Domain.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RecipeCookTime")
                        .HasColumnType("int");

                    b.Property<string>("RecipeInstruction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecipeOriginId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeOriginId");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("CookingPapa.Domain.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RecipeIngredientName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("CookingPapa.Domain.Models.RecipeIngredientGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeIngredientAmount")
                        .HasColumnType("int");

                    b.Property<int?>("RecipeIngredientId")
                        .HasColumnType("int");

                    b.Property<int?>("RecipeMeasurementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("RecipeIngredientId");

                    b.HasIndex("RecipeMeasurementId");

                    b.ToTable("RecipeIngredientGroups");
                });

            modelBuilder.Entity("CookingPapa.Domain.Models.RecipeMeasurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RecipeMeasurementName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecipeMeasurements");
                });

            modelBuilder.Entity("CookingPapa.Domain.Models.RecipeOrigin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RecipeOriginName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecipeOrigins");
                });

            modelBuilder.Entity("CookingPapa.Domain.Models.RecipeReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("RecipeReviewComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeReviewRating")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("RecipeReviews");
                });

            modelBuilder.Entity("CookingPapa.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CookingPapa.Domain.Models.Cookbook", b =>
                {
                    b.HasOne("CookingPapa.Domain.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");

                    b.HasOne("CookingPapa.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CookingPapa.Domain.Models.Recipe", b =>
                {
                    b.HasOne("CookingPapa.Domain.Models.RecipeOrigin", "RecipeOrigin")
                        .WithMany()
                        .HasForeignKey("RecipeOriginId");

                    b.HasOne("CookingPapa.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CookingPapa.Domain.Models.RecipeIngredientGroups", b =>
                {
                    b.HasOne("CookingPapa.Domain.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");

                    b.HasOne("CookingPapa.Domain.Models.RecipeIngredient", "RecipeIngredient")
                        .WithMany()
                        .HasForeignKey("RecipeIngredientId");

                    b.HasOne("CookingPapa.Domain.Models.RecipeMeasurement", "RecipeMeasurement")
                        .WithMany()
                        .HasForeignKey("RecipeMeasurementId");
                });

            modelBuilder.Entity("CookingPapa.Domain.Models.RecipeReview", b =>
                {
                    b.HasOne("CookingPapa.Domain.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");

                    b.HasOne("CookingPapa.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
