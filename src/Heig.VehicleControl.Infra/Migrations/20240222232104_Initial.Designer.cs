﻿// <auto-generated />
using System;
using Heig.VehicleControl.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Heig.VehicleControl.Infra.Migrations
{
    [DbContext(typeof(VehicleControlContext))]
    [Migration("20240222232104_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Heig.VehicleControl.Domain.Entities.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("AdditionalObservation")
                        .HasColumnType("varchar(4000)");

                    b.Property<Guid>("ChecklistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Ok")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChecklistId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Heig.VehicleControl.Domain.Entities.Checklist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OriginalChecklistTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OwnerUserId");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OriginalChecklistTemplateId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Checklists");
                });

            modelBuilder.Entity("Heig.VehicleControl.Domain.Entities.ChecklistTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Number");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ChecklistTemplates");
                });

            modelBuilder.Entity("Heig.VehicleControl.Domain.Entities.QuestionTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("ChecklistTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullDescription")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChecklistTemplateId");

                    b.ToTable("QuestionTemplates");
                });

            modelBuilder.Entity("Heig.VehicleControl.Domain.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("varchar(7)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Heig.VehicleControl.Domain.Entities.Answer", b =>
                {
                    b.HasOne("Heig.VehicleControl.Domain.Entities.Checklist", "Checklist")
                        .WithMany("Answers")
                        .HasForeignKey("ChecklistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Checklist");
                });

            modelBuilder.Entity("Heig.VehicleControl.Domain.Entities.Checklist", b =>
                {
                    b.HasOne("Heig.VehicleControl.Domain.Entities.ChecklistTemplate", "OriginalChecklistTemplate")
                        .WithMany("Checklists")
                        .HasForeignKey("OriginalChecklistTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Heig.VehicleControl.Domain.Entities.Vehicle", "Vehicle")
                        .WithMany("Checklists")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OriginalChecklistTemplate");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Heig.VehicleControl.Domain.Entities.QuestionTemplate", b =>
                {
                    b.HasOne("Heig.VehicleControl.Domain.Entities.ChecklistTemplate", "ChecklistTemplate")
                        .WithMany("Questions")
                        .HasForeignKey("ChecklistTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChecklistTemplate");
                });

            modelBuilder.Entity("Heig.VehicleControl.Domain.Entities.Checklist", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Heig.VehicleControl.Domain.Entities.ChecklistTemplate", b =>
                {
                    b.Navigation("Checklists");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Heig.VehicleControl.Domain.Entities.Vehicle", b =>
                {
                    b.Navigation("Checklists");
                });
#pragma warning restore 612, 618
        }
    }
}