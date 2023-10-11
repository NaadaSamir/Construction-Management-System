using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class CompanyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DBCompany;Integrated Security=True;Encrypt=False\r\n\r\n");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(E => E.SSN);
            modelBuilder.Entity<Department>().HasKey(E => E.Dnumber);
            modelBuilder.Entity<Project>().HasKey(P => P.Pnumber);
            modelBuilder.Entity<DEPT_LOCATION>().HasKey(d => new { d.Dnumber, d.DLocation });
            modelBuilder.Entity<WorksOn>().HasKey(w => new { w.ESSN, w.Pno });
            modelBuilder.Entity<Dependent>().HasKey(p => new { p.Essn, p.Dependent_Name });
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.department)
                .HasForeignKey(e => e.DNO);
    
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DEPT_LOCATION> DEPT_LOCATIONs { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<WorksOn> WorksOns { get; set; }
        public virtual DbSet<Dependent> Dependents { get; set; }
    }
}