using EJK.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJK.Licitacao.Data.Repository
{
    internal class PregaoContext : DbContext
    {
        public PregaoContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Mensagem> Mensagem { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pregao> Pregao { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>().HasMany<Plataforma>();
            //modelBuilder.Entity<ClientePlataforma>().HasOne<Cliente>(x => x.Cliente);
            //modelBuilder.Entity<ClientePlataforma>().HasOne<Plataforma>(x => x.Plataforma);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);


        }
    }
}
