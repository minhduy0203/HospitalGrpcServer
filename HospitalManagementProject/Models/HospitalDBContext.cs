using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace HospitalManagementProject.Models
{
	public class HospitalDBContext : IdentityDbContext<User>
	{
		public DbSet<User> Users { get; set; }
        public DbSet<StaffShift> StaffShifts { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedStaff> MedStaffs { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

		public HospitalDBContext(DbContextOptions<HospitalDBContext> options)
		   : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var conStr = "Server=localhost;Database=HospitalApp;Integrated Security=True;";
				optionsBuilder.UseSqlServer(conStr);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);	
			//dinh nghia PK cho bang ProductSupplier
			modelBuilder.Entity<StaffShift>()
				.HasKey(ss => new { ss.ShiftId, ss.MedStaffId });

			Seeding(modelBuilder);
		
		}

		private void Seeding(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<IdentityRole>()
				.HasData(
				new IdentityRole
				{
					Id = "1",
					Name = "ADMIN",
					NormalizedName = "ADMIN"
				},
				new IdentityRole
				{
					Id = "2",
					Name = "PATIENT",
					NormalizedName = "PATIENT"
				},
				new IdentityRole
				{
					Id = "3",
					Name = "DOCTOR",
					NormalizedName = "DOCTOR"
				}
				);

			modelBuilder.Entity<Service>()
				.HasData(new Service
				{
					Id = 1,
					Description = "X-Ray Pics",
					Name = "X-Ray",
					Price = 200,
				});

			modelBuilder.Entity<Shift>()
				.HasData(
				new Shift
				{
					Id = 1,
					Start = new TimeSpan(7,30,0),
					End = new TimeSpan(9, 0,0)
				},
				new Shift
				{
					Id = 2,
					Start = new TimeSpan(9, 30, 0),
					End = new TimeSpan(11, 0,0)
				}
				);

			modelBuilder.Entity<Patient>()
				.HasData(
				new Patient
				{
					Id = 1,

				}
				);


			modelBuilder.Entity<MedStaff>()
				.HasData(
				new MedStaff
				{
					Id = 1,
					Experience = "5 Years",
					Qualification ="Havard",

				}
				);

			modelBuilder.Entity<Appointment>()
				.HasData(new Appointment
				{
					Id= 1,
					MedStaffId = 1,
					Date = new DateTime(2024,07,20),
					Status = Status.PENDING,
					Conclusion = "Nice",
					
				});


		}
	}
}
