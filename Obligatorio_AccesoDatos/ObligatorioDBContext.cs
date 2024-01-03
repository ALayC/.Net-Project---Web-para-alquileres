using Microsoft.EntityFrameworkCore;
using Obligatorio_LogicaNegocio.Entidades;
using System.Collections.Generic;
using System.Reflection;

namespace Obligatorio_AccesoDatos
{
    public class ObligatorioDBContext : DbContext
    {
        public DbSet<Cabana> Cabanas { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<TipoCabana> TipoCabanas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }


        //public ObligatorioDBContext(DbContextOptions<ObligatorioDBContext> optionsBuilder) : base(optionsBuilder)
        //{

        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //}



        //  Si necesito correr una nueva migracion para modificar la base de datos descomento lo que esta por debajo de esto y comento lo que esta por ecnima salgo  Cabana Mantenimien tipo y usuario

        public ObligatorioDBContext() { }

        public ObligatorioDBContext(DbContextOptions<ObligatorioDBContext> optionsBuilder) : base(optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=(localdb)\\mssqllocaldb;attachdbfilename=c:\\users\\alay\\source\\repos\\obligatoriop3\\basededatosobligatorioprogramacion.mdf;integrated security=true;connect timeout=30");
            }
        }
    }
}