﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task_Unis;

#nullable disable

namespace Task_Unis.Migrations
{
    [DbContext(typeof(UniversityContext))]
    partial class UniversityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Task_Unis.Models.University", b =>
                {
                    b.Property<int>("UniversityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UniversityCountry")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UniversityUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UniversityId");

                    b.ToTable("Universities", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
