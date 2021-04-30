using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Connections.Database
{
    public class Command
    {
        internal string Query { get; set; }
        internal bool IsStoredProcedure { get; set; }
        internal IDictionary<string, object> Parameters { get; set; }

        public Command(string query, bool isStoredProcedure = true)
        {
            IsStoredProcedure = isStoredProcedure;
            Parameters = new Dictionary<string, object>();
            Query = query;
        }

        public void AddParameter(string parameterName, object value)
        {
            Parameters.Add(parameterName, value ?? DBNull.Value);
        }
    }
}
