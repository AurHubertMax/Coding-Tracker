using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Coding_Tracker.DataAccess
{
    internal class DatabaseManager
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["CodingTrackerDB"].ConnectionString;

        public SqliteConnection GetConnection() => new(_connectionString);
        public void CreateDatabase()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var table_command = connection.CreateCommand();
                string query = @"CREATE TABLE IF NOT EXISTS CodingSessions (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Language TEXT NOT NULL,
                    Day TEXT NOT NULL,
                    StartTime TEXT NOT NULL,
                    EndTime TEXT NOT NULL,
                    Duration TEXT NOT NULL,
                    Notes TEXT)";

                connection.Execute(query);

                connection.Close();
            }

        }


    }
}
