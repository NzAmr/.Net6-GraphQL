using Microsoft.EntityFrameworkCore;
using CommanderGQL.Models;

namespace CommanderGQL.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(){

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options){

        }
        
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Platform>()
            .HasMany(p=>p.Commands)
            .WithOne(p=>p.Platform!)
            .HasForeignKey(p=>p.PlatformId);

            modelBuilder
            .Entity<Command>()
            .HasOne(p=>p.Platform)
            .WithMany(p=>p.Commands)
            .HasForeignKey(p=>p.PlatformId);
        }
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //      #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=CommandDB;User Id=sa;Password=pa55w0rd!;TrustServerCertificate=True");
            }
        }
    }
}