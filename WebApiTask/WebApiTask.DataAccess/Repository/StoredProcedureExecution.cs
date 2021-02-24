// <copyright file="StoredProcedureExecution.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// StoredProcedureExecution.
    /// </summary>
    public class StoredProcedureExecution : IStoredProcedure
    {
        private readonly ApplicationDbContext applicationDbContext;

        private static string connectionString;

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoredProcedureExecution"/> class.
        /// </summary>
        /// <param name="dbContext">dbContext</param>
        /// <param name="configuration">configuration</param>
        public StoredProcedureExecution(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            applicationDbContext = dbContext;
            connectionString = this.Configuration.GetConnectionString("DefaultConnection");
        }

        public void Execute(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public T OneRecord<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                var value = sqlCon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                return (T)Convert.ChangeType(value.FirstOrDefault(), typeof(T));
            }
        }

        public T Single<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }

        public void Dispose()
        {
            applicationDbContext.DisposeAsync();
        }
    }
}
