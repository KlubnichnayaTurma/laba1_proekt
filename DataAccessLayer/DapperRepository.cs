using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using laba1;

namespace DataAccessLayer
{
    public class DapperRepository<T> : IRepository<T> where T : IDomainObject
    {
        private readonly string _connectionString;
        private readonly string _tableName;

        public DapperRepository(string connectionString)
        {
            _connectionString = connectionString;
            _tableName = typeof(T).Name;
        }


        public void Add(T obj)
        {
            var props = typeof(T).GetProperties()
                .Where(p => p.Name != "Id")
                .ToList();
            string columns = string.Join(", ", props.Select(p => p.Name));
            string values = string.Join(", ", props.Select(p => "@" + p.Name));

            string sql = $"INSERT INTO {_tableName} ({columns}) OUTPUT INSERTED.Id VALUES ({values})";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int newId = db.ExecuteScalar<int>(sql, obj);
                obj.Id = newId;

            }
        }

        public IEnumerable<T> ReadAll()
        {
            string sql = $"SELECT * FROM {_tableName}";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<T>(sql).ToList();


            }
        }


        public T ReadById(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE Id = @Id";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.QueryFirstOrDefault<T>(sql, new { Id = id });
            }
        }

        public void Update(T obj)
        {
            var props = typeof(T).GetProperties()
                .Where(p => p.Name != "Id")
                .ToList();

            string setClause = string.Join(", ", props.Select(p => $"{p.Name} = @{p.Name}"));
            string sql = $"UPDATE {_tableName} SET {setClause} WHERE Id = @Id";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, obj);
            }
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {_tableName} WHERE Id = @Id";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                db.Execute(sql, new { Id = id });
            }
        }
    }
}