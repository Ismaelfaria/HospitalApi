﻿// <auto-generated />
using HospitalApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalApi.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20240124083930_df")]
    partial class df
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HospitalApi.Entity.Condition", b =>
                {
                    b.Property<int>("IdCondition")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCondition"));

                    b.Property<string>("ColorOfUrgency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("IdCondition");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("HospitalApi.Entity.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexuality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalApi.Entity.Condition", b =>
                {
                    b.HasOne("HospitalApi.Entity.Patient", null)
                        .WithOne("Condition")
                        .HasForeignKey("HospitalApi.Entity.Condition", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalApi.Entity.Patient", b =>
                {
                    b.Navigation("Condition")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
