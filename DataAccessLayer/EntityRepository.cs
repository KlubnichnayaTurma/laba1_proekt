using laba1;
using Microsoft.EntityFrameworkCore;
using model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        // DbSet для каждой сущности
        public DbSet<Sushnost> Sushnosti { get; set; }

        // Конструктор принимает строку подключения
        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sushnost>().ToTable("Sushnost");
            modelBuilder.Entity<Sushnost>().HasKey(s => s.Id);
            modelBuilder.Entity<Sushnost>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
        }
    }


    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private readonly AppDbContext _context;

        public EntityRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<T> ReadAll()
        {
            return _context.Set<T>().ToList();
        }

        public T ReadById(int id)
        {

            return _context.Set<T>().Find(id);
        }

        public void Update(T obj)
        {

            var existing = _context.Set<T>().Find(obj.Id);

            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(obj);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var obj = _context.Set<T>().Find(id);

            if (obj != null)
            {
                _context.Set<T>().Remove(obj);
                _context.SaveChanges();
            }
        }
    }
}