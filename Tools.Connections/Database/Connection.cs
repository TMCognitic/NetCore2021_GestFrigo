using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Tools.Connections.Database
{
    public class Connection : IConnection
    {
        private readonly string _connectionString;
        private readonly DbProviderFactory _factory;

        public Connection(DbProviderFactory factory, string connectionString)
        {
            _connectionString = connectionString;
            _factory = factory;

            using (DbConnection dbConnection = CreateConnection())
            {
                dbConnection.Open();
            }
        }

        public int ExecuteNonQuery(Command command)
        {
            using (DbConnection dbConnection = CreateConnection())
            {
                using (DbCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    dbConnection.Open();
                    return dbCommand.ExecuteNonQuery();
                }
            }
        }

        public object ExecuteScalar(Command command)
        {
            using (DbConnection dbConnection = CreateConnection())
            {
                using (DbCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    dbConnection.Open();
                    object o = dbCommand.ExecuteScalar();
                    return o;
                }
            }
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<IDataRecord, TResult> selector)
        {
            using (DbConnection dbConnection = CreateConnection())
            {
                using (DbCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    dbConnection.Open();
                    using (DbDataReader dbDataReader = dbCommand.ExecuteReader())
                    {
                        while (dbDataReader.Read())
                        {
                            yield return selector(dbDataReader);
                        }
                    }
                }
            }
        }

        public DataTable GetDataTable(Command command)
        {
            using (DbConnection dbConnection = CreateConnection())
            {
                using (DbCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    using (DbDataAdapter dbDataAdapter = _factory.CreateDataAdapter())
                    {
                        dbDataAdapter.SelectCommand = dbCommand;
                        DataTable dataTable = new DataTable();
                        dbDataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        private static DbCommand CreateCommand(Command command, DbConnection dbConnection)
        {
            DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = command.Query;
            if (command.IsStoredProcedure)
                dbCommand.CommandType = CommandType.StoredProcedure;

            foreach (KeyValuePair<string, object> kvp in command.Parameters)
            {
                DbParameter dbParameter = dbCommand.CreateParameter();
                dbParameter.ParameterName = kvp.Key;
                dbParameter.Value = kvp.Value;

                dbCommand.Parameters.Add(dbParameter);
            }

            return dbCommand;
        }

        private DbConnection CreateConnection()
        {
            DbConnection dbConnection = _factory.CreateConnection();
            dbConnection.ConnectionString = _connectionString;
            return dbConnection;
        }
    }
}
