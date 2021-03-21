using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using TaskManagement.Logic.Interfaces;
using Task = TaskManagement.Core.Entities.Task;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration _configuration;

        public TaskRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        
        public async Task<Task> Get(int id)
        {
            var sql = "SELECT * FROM TASK1 WHERE Id = @Id;";
            
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Task>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Task>> GetAll()
        {
            var sql = "SELECT * FROM TASK1;";
            
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Task>(sql);
                return result;
            }
        }

        public async Task<int> Add(Task entity)
        {
            entity.DateCreated = DateTime.Now;
            var sql =
                "INSERT INTO TASK1 (Name, Description, Status, DueDate, DateCreated) VALUES(@Name, @Description, @Status, @DueDate, @DateCreated);";
            
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM TASK1 WHERE Id = @Id;";
            
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
                return affectedRows;
            }
        }

        public async Task<int> Update(Task entity)
        {
            entity.DateModified = DateTime.Now;
            var sql = "UPDATE TASK1 SET Name = @Name, Description = @Description, Status = @Status, DueDate = @DueDate, DateModified = @DateModified WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;

            }
        }
    }
}