using ApproveAiModels.Enums;
using ApproveAiModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveAiModels
{
    public class DatabaseSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { Name = "Admin" },
                    new Role { Name = "User" }
                };

                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }

            if (!context.Groups.Any())
            {
                var groups = new List<Group>
                {
                    new Group { Name = "Development" },
                    new Group { Name = "CertifiedApprovers" }
                };

                context.Groups.AddRange(groups);
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                        {
                            Name = "John Doe",
                            Email = "john.doe@example.com",
                            RoleId = context.Roles.First(r => r.Name == "Admin").Id, // Link to Admin Role
                            Groups = new List<Group> { context.Groups.First(g => g.Name == "Development") } // Link to Development Group
                        },
                        new User
                        {
                            Name = "Jane Smith",
                            Email = "jane.smith@example.com",
                            RoleId = context.Roles.First(r => r.Name == "User").Id, // Link to User Role
                            Groups = new List<Group> { context.Groups.First(g => g.Name == "CertifiedApprovers") } // Link to Marketing Group
                        }
                    };

                context.Users.AddRange(users);
                await context.SaveChangesAsync();
            }

            if (!context.ApprovalWorkflows.Any())
            {
                var approvalWorkflows = new List<ApprovalWorkflow>
                {
                    new ApprovalWorkflow
                    {
                        Name = "New Feature Approval",
                        ApprovalGroups = new List<Group> { context.Groups.First(g => g.Name == "Development") },
                        PrivilegedRoles = new List<Role> { context.Roles.First(r => r.Name == "Admin") }
                    },
                    new ApprovalWorkflow
                    {
                        Name = "CertifiedApprovers Approval",
                        ApprovalGroups = new List<Group> { context.Groups.First(g => g.Name == "CertifiedApprovers") },
                        PrivilegedRoles = new List<Role> { context.Roles.First(r => r.Name == "User") }
                    }
                };

                context.ApprovalWorkflows.AddRange(approvalWorkflows);
                await context.SaveChangesAsync();
            }

            if (!context.RegisteredAnswers.Any())
            {
                var johnDoe = context.Users.FirstOrDefault(u => u.Name == "John Doe");
                var janeSmith = context.Users.FirstOrDefault(u => u.Name == "Jane Smith");

                var approvalRequest1 = context.ApprovalRequests.FirstOrDefault(ar => ar.Status == ApprovalStatus.Open && ar.ApprovalWorkflow.Name == "New Feature Approval");
                var approvalRequest2 = context.ApprovalRequests.FirstOrDefault(ar => ar.Status == ApprovalStatus.Open && ar.ApprovalWorkflow.Name == "CertifiedApprovers Approval");

                if (johnDoe == null || janeSmith == null || approvalRequest1 == null || approvalRequest2 == null)
                {
                    throw new Exception("Users or ApprovalRequests not found while seeding the application.");
                }

                var registeredAnswers = new List<RegisteredAnswer>
                {
                    new RegisteredAnswer
                    {
                        Answer = "Approve the new feature deployment",
                        Approved = null, // Not yet approved
                        Rejected = null, // Not yet rejected
                        ApprovalRequestId = approvalRequest1.Id,
                        RegisteredById = johnDoe.Id
                    },
                    new RegisteredAnswer
                    {
                        Answer = "Approve the request for certified approvers",
                        Approved = null, // Not yet approved
                        Rejected = null, // Not yet rejected
                        ApprovalRequestId = approvalRequest2.Id,
                        RegisteredById = janeSmith.Id
                    }
                };

                context.RegisteredAnswers.AddRange(registeredAnswers);
                await context.SaveChangesAsync();
            }

            if (!context.ApprovalRequests.Any())
            {
                var newFeatureApprovalWorkflow = context.ApprovalWorkflows.FirstOrDefault(aw => aw.Name == "New Feature Approval");
                var certifiedApproversApprovalWorkflow = context.ApprovalWorkflows.FirstOrDefault(aw => aw.Name == "CertifiedApprovers Approval");

                var johnDoe = context.Users.FirstOrDefault(u => u.Name == "John Doe");
                var janeSmith = context.Users.FirstOrDefault(u => u.Name == "Jane Smith");

                // Check if data exists before proceeding
                if (newFeatureApprovalWorkflow == null || certifiedApproversApprovalWorkflow == null)
                {
                    throw new Exception("Approval workflows not found while seeding the application.");
                }

                if (johnDoe == null || janeSmith == null)
                {
                    throw new Exception("Users not found while seeding the application.");
                }

                var approvalRequests = new List<ApprovalRequest>
                {
                    new ApprovalRequest
                    {
                        ApprovalWorkflowId = newFeatureApprovalWorkflow.Id,
                        ApprovalDeadline = DateTime.UtcNow.AddDays(7),
                        Status = ApprovalStatus.Open,
                        RegisteredAnswer = new RegisteredAnswer
                        {
                            Answer = "Approve the new feature deployment",
                            Approved = null, // Not approved yet
                            Rejected = null, // Not rejected yet
                            RegisteredById = johnDoe.Id // Registered by John Doe
                        }
                    },
                    new ApprovalRequest
                    {
                        ApprovalWorkflowId = certifiedApproversApprovalWorkflow.Id,
                        ApprovalDeadline = DateTime.UtcNow.AddDays(10),
                        Status = ApprovalStatus.Open,
                        RegisteredAnswer = new RegisteredAnswer
                        {
                            Answer = "Approve the new request for certified approvers",
                            Approved = null, // Not approved yet
                            Rejected = null, // Not rejected yet
                            RegisteredById = janeSmith.Id // Registered by Jane Smith
                        }
                    }
                };

                context.ApprovalRequests.AddRange(approvalRequests);
                await context.SaveChangesAsync();
            }

            if (!context.ApprovalSteps.Any())
            {
                var approvalSteps = new List<ApprovalStep>
                {
                    new ApprovalStep
                    {
                        StepIndex = 1,
                        ApprovedById = context.Users.First(u => u.Name == "John Doe").Id,
                        ApprovalRequestId = context.ApprovalRequests.First(ar => ar.RegisteredAnswer.Answer == "Approve the new feature deployment").Id
                    },
                    new ApprovalStep
                    {
                        StepIndex = 1,
                        ApprovedById = context.Users.First(u => u.Name == "Jane Smith").Id,
                        ApprovalRequestId = context.ApprovalRequests.First(ar => ar.RegisteredAnswer.Answer == "Approve the new request for certified approvers").Id
                    }
                };

                context.ApprovalSteps.AddRange(approvalSteps);
                await context.SaveChangesAsync();
            }
        }
    }
}
