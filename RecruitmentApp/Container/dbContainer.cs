using Microsoft.EntityFrameworkCore;
using RecruitmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RecruitmentApp.Container
{
    public class dbContainer:DbContext
    {
        public dbContainer(DbContextOptions<dbContainer> op) : base(op)
        { 

        }
        public DbSet<Lk_Company> Companies { get; set; }
        public DbSet<Lk_Company_Department> CompanyDepartments { get; set; }
        public DbSet<Op_Jobs> Jobs { get; set; }
        public DbSet<Sys_EmployeeStatus> EmployeeStatuses { get; set; }
        public DbSet<Sys_EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Op_Employee> Employees { get; set; }
        public DbSet<Op_EmployeeLoginData> EmployeeLoginDatas { get; set; }
        public DbSet<Op_Candidates> Candidates { get; set; }
        public DbSet<Sys_Phase> Phases { get; set; }
        public DbSet<Sys_ApplicationStatus> ApplicationStatuses { get; set; }
        public DbSet<Op_Application> Applications { get; set; }
        public DbSet<Op_ApplicationReviewer> ApplicationReviewers { get; set; }
        public DbSet<Op_ApplicationPhaseComment> ApplicationPhaseComments{ get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Op_ApplicationReviewer>()
                .HasKey(rev => new { rev.ApplicationId, rev.ReviewerId, rev.PhaseId });

            
            modelBuilder.Entity<Lk_Company_Department>()
                .HasKey(cd => new { cd.CompanyId, cd.DepartmentName });

            modelBuilder.Entity<Op_ApplicationPhaseComment>()
               .HasKey(app => new { app.ApplicationId, app.PhaseId});

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
