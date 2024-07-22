using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
	public partial class EmployeeDbContext : DbContext
	{
		public EmployeeDbContext()
		{
		}

		public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Employee> Employee { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
				optionsBuilder.UseSqlServer("Data Source=HASAN\\SQLEXPRESS;Initial Catalog=EmployeeDatabase;Integrated Security=True;TrustServerCertificate=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>(entity =>
			{
				entity.Property(e => e.Address).IsUnicode(false);

				entity.Property(e => e.FirstName).IsUnicode(false);

				entity.Property(e => e.LastName).IsUnicode(false);

				entity.Property(e => e.PhoneNumber).IsUnicode(false);
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
