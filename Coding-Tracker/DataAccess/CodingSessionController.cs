using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Coding_Tracker.DataAccess
{
    internal class CodingSessionController
    {
        private DatabaseManager _dbManager = new();
        public void AddCodingSession(CodingSession session)
        {
            string query = @"INSERT INTO CodingSessions (Language, Day, StartTime, EndTime, Duration, Notes) 
                                                VALUES (@Language, @FormattedDay, @FormattedStartTime, @FormattedEndTime, @Duration, @Notes)";
            using (var connection = _dbManager.GetConnection())
            {
                connection.Execute(query, session);
            }
        }

        public IEnumerable<CodingSession> GetCodingSessions()
        {
            string query = "SELECT * FROM CodingSessions";
            using (var connection = _dbManager.GetConnection())
            {
                var sessions = connection.Query<CodingSession>(query);
                return sessions;
            }
        }
    }
}
