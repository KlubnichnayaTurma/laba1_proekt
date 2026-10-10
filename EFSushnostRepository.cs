using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace laba1.DAL
{
    // Контекст EF
    public class AppDbContext : DbContext
    {
        public DbSet<Sushnost> Sushnosti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Вставьте свою строку подключения
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UniversityDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Говорим EF, что Id генерируется БД
            modelBuilder.Entity<Sushnost>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
        }
    }

    public class EFSushnostRepository : IRepository<Sushnost>
    {
        public void Create(Sushnost obj)
        {
            using (var context = new AppDbContext())
            {
                context.Sushnosti.Add(obj);
                context.SaveChanges(); // после этого obj.Id будет заполнен
            }
        }

        public IEnumerable<Sushnost> ReadAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Sushnosti.ToList();
            }
        }

        public Sushnost ReadById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Sushnosti.FirstOrDefault(s => s.Id == id);
            }
        }

        public void Update(Sushnost obj)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Sushnosti.Find(obj.Id);
                if (existing != null)
                {
                    existing.Name = obj.Name;
                    existing.Transcendence = obj.Transcendence;
                    existing.Age = obj.Age;
                    context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var s = context.Sushnosti.Find(id);
                if (s != null)
                {
                    context.Sushnosti.Remove(s);
                    context.SaveChanges();
                }
            }
        }
    }
}