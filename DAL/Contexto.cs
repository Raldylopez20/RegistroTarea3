using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RegistroTarea3.Entidades;

namespace RegistroTarea3.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Prestamos> Prestamos { set; get; }
        public DbSet<Personas> Personas { set; get; }
        public DbSet<Moras> Moras{set; get;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Prestamos.db");
        }
    }
}