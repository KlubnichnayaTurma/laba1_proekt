using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using Dapper;
using laba1;

namespace DataAccessLayer
{
    /// <summary>
    /// Универсальный репозиторий через Dapper.
    /// Работает с любой сущностью T, у которой есть свойство Id.
    /// SQL-запросы строятся динамически на основе имён свойств класса T.
    /// </summary>
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
            PropertyInfo[] allProps = typeof(T).GetProperties();
            List<PropertyInfo> props = new List<PropertyInfo>();

            foreach (PropertyInfo p in allProps)
            {
                if (p.Name != "Id")
                {
                    props.Add(p);
                }
            }
            StringBuilder columns = new StringBuilder();
            StringBuilder values = new StringBuilder();

            for (int i = 0; i < props.Count; i++)
            {
                columns.Append(props[i].Name);
                values.Append("@" + props[i].Name);

                if (i < props.Count - 1)
                {
                    columns.Append(", ");
                    values.Append(", ");
                }
            }

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
                List<T> result = new List<T>();
                foreach (T item in db.Query<T>(sql))
                {
                    result.Add(item);
                }
                return result;
            }
        }

        public T ReadById(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE Id = @Id";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                foreach (T item in db.Query<T>(sql, new { Id = id }))
                {
                    return item; 
                }
                return default(T);
            }
        }

        public void Update(T obj)
        {
            PropertyInfo[] allProps = typeof(T).GetProperties();
            List<PropertyInfo> props = new List<PropertyInfo>();

            foreach (PropertyInfo p in allProps)
            {
                if (p.Name != "Id")
                {
                    props.Add(p);
                }
            }

            StringBuilder setClause = new StringBuilder();
            for (int i = 0; i < props.Count; i++)
            {
                setClause.Append(props[i].Name + " = @" + props[i].Name);
                if (i < props.Count - 1)
                {
                    setClause.Append(", ");
                }
            }

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