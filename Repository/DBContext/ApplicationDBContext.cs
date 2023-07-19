using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repository.DBContext
{
    public class ApplicationDBContext: DbContext
    {
        private readonly ILogger<ApplicationDBContext> _logger;

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Activo_Empleado> activo_Empleados { get; set; }

        public DbSet<Activo> Activos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public ApplicationDBContext(DbContextOptions options, ILogger<ApplicationDBContext> logger): base(options) {
            _logger = logger;

        }

            public override int SaveChanges()
    {
        // Log SQL statements
        _logger.LogError(this.Database.GenerateCreateScript());

        return base.SaveChanges();
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>();
            modelBuilder.Entity<Empleado>();
            modelBuilder.Entity<Activo>();
            modelBuilder.Entity<Activo_Empleado>();
            modelBuilder.Entity<Usuario>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
