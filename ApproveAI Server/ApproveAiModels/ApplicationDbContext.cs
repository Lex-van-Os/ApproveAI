using ApproveAiModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveAiModels
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<RegisteredAnswer> RegisteredAnswers { get; set; }
        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
        public DbSet<ApprovalStep> ApprovalSteps { get; set; }
        public DbSet<ApprovalWorkflow> ApprovalWorkflows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User -> Role (Many-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            // User -> Group (Many-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Groups)
                .WithMany(g => g.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserGroup",
                    j => j.HasOne<Group>().WithMany().HasForeignKey("GroupId"),
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId"));

            // User -> RegisteredAnswer (One-to-Many)
            modelBuilder.Entity<RegisteredAnswer>()
                .HasOne(ra => ra.RegisteredBy)
                .WithMany(u => u.RegisteredAnswers)
                .HasForeignKey(ra => ra.RegisteredById)
                .OnDelete(DeleteBehavior.Restrict);

            // RegisteredAnswer -> ApprovalRequest (Many-to-One)
            modelBuilder.Entity<RegisteredAnswer>()
                .HasOne(ra => ra.ApprovalRequest)
                .WithOne(ar => ar.RegisteredAnswer)
                .HasForeignKey<RegisteredAnswer>(ra => ra.ApprovalRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            // Group -> ApprovalWorkflow (Many-to-Many)
            modelBuilder.Entity<ApprovalWorkflow>()
                .HasMany(aw => aw.ApprovalGroups)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "ApprovalWorkflowGroup",
                    j => j.HasOne<Group>().WithMany().HasForeignKey("GroupId"),
                    j => j.HasOne<ApprovalWorkflow>().WithMany().HasForeignKey("ApprovalWorkflowId"));

            // Role -> ApprovalWorkflow (Many-to-Many)
            modelBuilder.Entity<ApprovalWorkflow>()
                .HasMany(aw => aw.PrivilegedRoles)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "ApprovalWorkflowRole",
                    j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    j => j.HasOne<ApprovalWorkflow>().WithMany().HasForeignKey("ApprovalWorkflowId"));

            // ApprovalRequest -> ApprovalWorkflow (Many-to-One)
            modelBuilder.Entity<ApprovalRequest>()
                .HasOne(ar => ar.ApprovalWorkflow)
                .WithMany(aw => aw.ApprovalRequests)
                .HasForeignKey(ar => ar.ApprovalWorkflowId)
                .OnDelete(DeleteBehavior.Cascade);

            // ApprovalRequest -> ApprovalStep (One-to-Many)
            modelBuilder.Entity<ApprovalRequest>()
                .HasMany(ar => ar.ApprovalSteps)
                .WithOne(s => s.ApprovalRequest)
                .HasForeignKey(s => s.ApprovalRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            // ApprovalStep -> User (Many-to-One)
            modelBuilder.Entity<ApprovalStep>()
                .HasOne(s => s.ApprovedBy)
                .WithMany()
                .HasForeignKey(s => s.ApprovedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApprovalStep>()
                .HasOne(s => s.RejectedBy)
                .WithMany()
                .HasForeignKey(s => s.RejectedById)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
