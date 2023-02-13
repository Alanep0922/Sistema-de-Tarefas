
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SistemasDeTarefas.Data.Map;
using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        private IConfiguration configuration;
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options,IConfiguration configuration) : base(options) 
        {
            this.configuration = configuration;
        }   
        public DbSet<UsuarioModel> Usuarios { get; set; }  
        public DbSet<TarefaModel> Tarefas { get; set; }
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            optionsBuilder.UseMySql(configuration.GetConnectionString("DataBase"), serverVersion);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
