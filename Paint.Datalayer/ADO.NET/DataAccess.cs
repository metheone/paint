using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.data
using System.Data;
using System.Data.Common;

namespace Paint.Data.ADO.NET
{
        public class DataAccess
        {
            public static IDataReader ExecuteReader(string ProcName, SqlParameter[] Parameters, string ConnectionString, int? Timeout = null, SqlTransaction Transaction = null)
            {
                return ExecuteReader(ProcName, Parameters, new SqlConnection(ConnectionString), Timeout, Transaction);
            }

            public static IDataReader ExecuteReader(string ProcName, SqlParameter[] Parameters, SqlConnection Connection, int? Timeout = null, SqlTransaction Transaction = null)
            {
                using (SqlCommand cmd = GetCommand(ProcName, Parameters, Connection, Timeout, Transaction))
                {
                    return cmd.ExecuteReader();
                }
            }


            public static object ExecuteScalar(string ProcName, SqlParameter[] Parameters, string ConnectionString, int? Timeout = null, SqlTransaction Transaction = null)
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    return ExecuteScalar(ProcName, Parameters, conn, Timeout, Transaction);
                }
            }

            public static object ExecuteScalar(string ProcName, SqlParameter[] Parameters, SqlConnection Connection, int? Timeout = null, SqlTransaction Transaction = null)
            {

                using (SqlCommand cmd = GetCommand(ProcName, Parameters, Connection, Timeout, Transaction))
                {
                    return cmd.ExecuteScalar();
                }
            }

            public static void ExecuteNonQuery(string query, SqlConnection Connection, int? Timeout = null, SqlTransaction Transaction = null)
            {
                using (SqlCommand cmd = GetCommand(query, Connection, Timeout, Transaction))
                {
                    cmd.ExecuteNonQuery();
                }
            }


            public static void ExecuteNonQuery(string ProcName, SqlParameter[] Parameters, string ConnectionString, int? Timeout = null, SqlTransaction Transaction = null)
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    ExecuteNonQuery(ProcName, Parameters, conn, Timeout, Transaction);
                }
            }

            public static void ExecuteNonQuery(string ProcName, SqlParameter[] Parameters, SqlConnection Connection, int? Timeout = null, SqlTransaction Transaction = null)
            {
                using (SqlCommand cmd = GetCommand(ProcName, Parameters, Connection, Timeout, Transaction))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            private static SqlCommand GetCommand(string ProcName, SqlParameter[] Parameters, SqlConnection Connection, int? Timeout, SqlTransaction Transaction = null)
            {
                SqlCommand cmd = new SqlCommand(ProcName, Connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = (Timeout.HasValue) ? Timeout.Value : 600; // Set timeout to ten minutes to support long-running operations

                if (Parameters != null)
                    cmd.Parameters.AddRange(Parameters);

                if (Transaction != null)
                    cmd.Transaction = Transaction;

                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                return cmd;
            }

            private static SqlCommand GetCommand(string query, SqlConnection Connection, int? Timeout, SqlTransaction Transaction = null)
            {
                SqlCommand cmd = new SqlCommand(query, Connection);

                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = (Timeout.HasValue) ? Timeout.Value : 600; // Set timeout to ten minutes to support long-running operations

                if (Transaction != null)
                    cmd.Transaction = Transaction;

                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                return cmd;
            }

            public static DataTable GetEmptyTable(string TableName, string ConnectionString)
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter("select top 0 * from " + TableName, ConnectionString))
                {
                    adapter.FillSchema(dt, SchemaType.Source);

                    return dt;
                }
            }
        }
}
