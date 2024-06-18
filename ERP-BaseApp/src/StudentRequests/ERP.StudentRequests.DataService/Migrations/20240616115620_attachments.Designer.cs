﻿// <auto-generated />
using System;
using ERP.StudentRequests.DataService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ERP.StudentRequests.DataService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240616115620_attachments")]
    partial class attachments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("ERP.StudentRequests.Core.Entity.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("ERP.StudentRequests.Core.Entity.Lecturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("ERP.StudentRequests.Core.Entity.Reply", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LecturerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LecturerId");

                    b.HasIndex("RequestId");

                    b.HasIndex("StudentId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("ERP.StudentRequests.Core.Entity.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LecturerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LecturerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StudentBatch")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentDegree")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentRegNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LecturerId");

                    b.HasIndex("StudentId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("ERP.StudentRequests.Core.Entity.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ERP.StudentRequests.Core.Entity.Attachment", b =>
                {
                    b.HasOne("ERP.StudentRequests.Core.Entity.Request", "Request")
                        .WithMany("Attachments")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Attachments_Request");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("ERP.StudentRequests.Core.Entity.Reply", b =>
                {
                    b.HasOne("ERP.StudentRequests.Core.Entity.Lecturer", "Lecturer")
                        .WithMany("Replies")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Replies_Lecturer");

                    b.HasOne("ERP.StudentRequests.Core.Entity.Request", "Request")
                        .WithMany("Replies")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Replies_Request");

                    b.HasOne("ERP.StudentRequests.Core.Entity.Student", "Student")
                        .WithMany("Replies")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Replies_Student");

                    b.Navigation("Lecturer");

                    b.Navigation("Request");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ERP.StudentRequests.Core.Entity.Request", b =>
                {
                    b.HasOne("ERP.StudentRequests.Core.Entity.Lecturer", "Lecturer")
                        .WithMany("Requests")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Requests_Lecturer");

                    b.HasOne("ERP.StudentRequests.Core.Entity.Student", "Student")
                        .WithMany("Requests")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Requests_Student");

                    b.Navigation("Lecturer");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ERP.StudentRequests.Core.Entity.Lecturer", b =>
                {
                    b.Navigation("Replies");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("ERP.StudentRequests.Core.Entity.Request", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Replies");
                });

            modelBuilder.Entity("ERP.StudentRequests.Core.Entity.Student", b =>
                {
                    b.Navigation("Replies");

                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
