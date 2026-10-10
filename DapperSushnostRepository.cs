using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace laba1.DAL
{
    public class DapperSushnostRepository : IRepository<Sushnost>
    {
        private readonly string _connectionString;

        public DapperSushnostRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(Sushnost obj)
        {
            // БД сама генерирует Id, поэтому мы его не вставляем.
            // OUTPUT INSERTED.Id вернёт сгенерированный Id обратно.
            string sql = @"INSERT INTO Sushnost (Name, Transcendence, Age) 
                           OUTPUT INSERTED.Id 
                           VALUES (@Name, @Transcendence, @Age)";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int newId = db.ExecuteScalar<int>(sql, obj);
                obj.Id = newId; // записываем Id обратно в объект
            }
        }

        public IEnumerable<Sushnost> ReadAll()
        {
            string sql = "SELECT * FROM Sushnost";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Sushnost>(sql).ToList();
            }
        }

        public Sushnost ReadById(int id)
        {
            string sql = "SELECT * FROM Sushnost WHERE Id = @Id";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.QueryFirstOrDefault<Sushnost>(sql, new { Id = id });
            }
        }

        public void Update(Sushnost obj)
        {
            string sql = @"UPDATE Sushnost 
                           SET Name = @Name, Transcendence = @Transcendence, Age = @Age 
                           WHERE Id = @Id";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, obj);
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Sushnost WHERE Id = @Id";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { Id = id });
            }
        }
    }
}