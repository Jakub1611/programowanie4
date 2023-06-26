using Microsoft.EntityFrameworkCore;

namespace LasotaProjekt.Model
{
    public class PlanContext : DbContext
    {
        public DbSet<Przedmiot> Przedmioty { get; set; }
        public DbSet<Grupa> Grupy { get; set; }
        public DbSet<PozycjePlanu> PozycjePlanu { get; set; }
        public DbSet<Student> Studenci { get; set; }

        public PlanContext(){}
        public PlanContext(DbContextOptions<PlanContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Baza w pamięci do testów:
            //optionsBuilder.UseInMemoryDatabase("Plan-Testy");

            optionsBuilder.UseSqlServer("Data Source=LAPTOP-552STJ0M\\DATACAMP_SQL;Initial Catalog=ProjektPlany;Integrated Security=True; TrustServerCertificate=True");
        }
    }
}
