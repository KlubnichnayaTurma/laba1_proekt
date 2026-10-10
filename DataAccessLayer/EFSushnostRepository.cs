using laba1;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{ 
    public class AppDbContext : DbContext
    {
        public DbSet<Sushnost> Sushnosti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UniversityDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sushnost>().ToTable("Sushnost");
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
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
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