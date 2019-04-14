using System;
using System.Data.SQLite;

namespace Mk0.Tools.SQLiteTools
{
    public static class SQLiteTools
    {
        /// <summary>
        /// Connects to SQLite, only if sql=null
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SQLiteConnection SQLiteConnect(this SQLiteConnection sql, string fileName)
        {
            if (sql == null)
            {
                try
                {
                    sql = new SQLiteConnection("Data Source=" + fileName + ";Version=3;")
                    {
                        ParseViaFramework = true
                    };
                    sql.Open();
                }
                catch (Exception ex)
                {
                    throw new SQLiteToolsException("Not connected to SQLite.", ex);
                }
            }
            return sql;
        }

        /// <summary>
        /// Disconnects from SQLite (optional VACUUM before diconnection)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="vacuumBeforeClose"></param>
        public static void SQLiteDisconnect(this SQLiteConnection sql, bool vacuumBeforeClose = false)
        {
            if (sql != null)
            {
                if (vacuumBeforeClose)
                {
                    try
                    {
                        SQLiteExecute(sql, "VACUUM;");
                    }
                    catch (Exception ex)
                    {
                        throw new SQLiteToolsException("Could not VACUUM before closing the SQLite Connection.", ex);
                    }
                }
                try
                {
                    sql.Close();
                    sql.Dispose();
                }
                catch (Exception ex)
                {
                    throw new SQLiteToolsException("Error while closing SQLite Connection.", ex);
                }
            }
            else
            {
                throw new SQLiteToolsException("SQLite Connection is NULL - so it could not be closed.");
            }
        }

        /// <summary>
        /// Executes Queries on SQLite (no selects!)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="query"></param>
        public static void SQLiteExecute(this SQLiteConnection sql, string query)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql)
                {
                    CommandText = query
                };
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (Exception ex)
            {
                throw new SQLiteToolsException("Could not execute the Query \"" + query + "\".", ex);
            }
        }
    }
}
