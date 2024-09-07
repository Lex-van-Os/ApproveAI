﻿// <auto-generated />
using System;
using ApproveAiModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApproveAiModels.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApprovalWorkflowGroup", b =>
                {
                    b.Property<long>("ApprovalWorkflowId")
                        .HasColumnType("bigint");

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.HasKey("ApprovalWorkflowId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("ApprovalWorkflowGroup");
                });

            modelBuilder.Entity("ApprovalWorkflowRole", b =>
                {
                    b.Property<long>("ApprovalWorkflowId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("ApprovalWorkflowId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("ApprovalWorkflowRole");
                });

            modelBuilder.Entity("ApproveAiModels.Models.ApprovalRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("ApprovalDeadline")
                        .HasColumnType("datetime2");

                    b.Property<long>("ApprovalWorkflowId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("RegisteredAnswerId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApprovalWorkflowId");

                    b.ToTable("ApprovalRequests");
                });

            modelBuilder.Entity("ApproveAiModels.Models.ApprovalStep", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ApprovalRequestId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ApprovedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("RejectedById")
                        .HasColumnType("bigint");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StepIndex")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApprovalRequestId");

                    b.HasIndex("ApprovedById");

                    b.HasIndex("RejectedById");

                    b.ToTable("ApprovalSteps");
                });

            modelBuilder.Entity("ApproveAiModels.Models.ApprovalWorkflow", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("ApprovalTimeLimit")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ApprovalWorkflows");
                });

            modelBuilder.Entity("ApproveAiModels.Models.Group", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ApproveAiModels.Models.RegisteredAnswer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ApprovalRequestId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("Approved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("RegisteredById")
                        .HasColumnType("bigint");

                    b.Property<bool?>("Rejected")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApprovalRequestId")
                        .IsUnique();

                    b.HasIndex("RegisteredById");

                    b.ToTable("RegisteredAnswers");
                });

            modelBuilder.Entity("ApproveAiModels.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ApproveAiModels.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("HasAdministratorAccess")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserGroup", b =>
                {
                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGroup");
                });

            modelBuilder.Entity("ApprovalWorkflowGroup", b =>
                {
                    b.HasOne("ApproveAiModels.Models.ApprovalWorkflow", null)
                        .WithMany()
                        .HasForeignKey("ApprovalWorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApproveAiModels.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApprovalWorkflowRole", b =>
                {
                    b.HasOne("ApproveAiModels.Models.ApprovalWorkflow", null)
                        .WithMany()
                        .HasForeignKey("ApprovalWorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApproveAiModels.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApproveAiModels.Models.ApprovalRequest", b =>
                {
                    b.HasOne("ApproveAiModels.Models.ApprovalWorkflow", "ApprovalWorkflow")
                        .WithMany("ApprovalRequests")
                        .HasForeignKey("ApprovalWorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApprovalWorkflow");
                });

            modelBuilder.Entity("ApproveAiModels.Models.ApprovalStep", b =>
                {
                    b.HasOne("ApproveAiModels.Models.ApprovalRequest", "ApprovalRequest")
                        .WithMany("ApprovalSteps")
                        .HasForeignKey("ApprovalRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApproveAiModels.Models.User", "ApprovedBy")
                        .WithMany()
                        .HasForeignKey("ApprovedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ApproveAiModels.Models.User", "RejectedBy")
                        .WithMany()
                        .HasForeignKey("RejectedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApprovalRequest");

                    b.Navigation("ApprovedBy");

                    b.Navigation("RejectedBy");
                });

            modelBuilder.Entity("ApproveAiModels.Models.RegisteredAnswer", b =>
                {
                    b.HasOne("ApproveAiModels.Models.ApprovalRequest", "ApprovalRequest")
                        .WithOne("RegisteredAnswer")
                        .HasForeignKey("ApproveAiModels.Models.RegisteredAnswer", "ApprovalRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApproveAiModels.Models.User", "RegisteredBy")
                        .WithMany("RegisteredAnswers")
                        .HasForeignKey("RegisteredById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApprovalRequest");

                    b.Navigation("RegisteredBy");
                });

            modelBuilder.Entity("ApproveAiModels.Models.User", b =>
                {
                    b.HasOne("ApproveAiModels.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("UserGroup", b =>
                {
                    b.HasOne("ApproveAiModels.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApproveAiModels.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApproveAiModels.Models.ApprovalRequest", b =>
                {
                    b.Navigation("ApprovalSteps");

                    b.Navigation("RegisteredAnswer")
                        .IsRequired();
                });

            modelBuilder.Entity("ApproveAiModels.Models.ApprovalWorkflow", b =>
                {
                    b.Navigation("ApprovalRequests");
                });

            modelBuilder.Entity("ApproveAiModels.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ApproveAiModels.Models.User", b =>
                {
                    b.Navigation("RegisteredAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}
