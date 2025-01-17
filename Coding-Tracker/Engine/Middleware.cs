using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using static CodingSession;

namespace Coding_Tracker.Engine
{
    internal class Middleware
    {
        public static Table GetTable(List<CodingSession> sessions)
        {
            var table = new Table();
            var props = Enum.GetValues(typeof(CodingSessionProps)).Cast<CodingSessionProps>();

            // Add columns based on enum values
            foreach (var prop in props)
            {
                table.AddColumn(prop.ToString()).Centered();
            }

            // Add rows based on property values
            foreach (var session in sessions)
            {
                var row = new List<string>();
                foreach (var prop in props)
                {
                    string value = GetPropertyValue(session, prop);
                    row.Add(value);
                }
                table.AddRow(row.ToArray());
            }

            return table;
        }

        private static string GetPropertyValue(CodingSession session, CodingSessionProps prop)
        {
            var propName = prop.ToString();
            var propertyInfo = typeof(CodingSession).GetProperty(propName);

            if (propertyInfo != null)
            {
                return propertyInfo.GetValue(session)?.ToString() ?? string.Empty;
            }

            return string.Empty;
        }
    }
}
