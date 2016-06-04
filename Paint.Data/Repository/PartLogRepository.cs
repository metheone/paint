using Paint.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paint.Model.Models;
using Paint.Model.common;
using System.Data.SqlClient;
using System.Data;
using Paint.Data.ADO.NET;
using System.Xml.Serialization;

namespace Paint.Data.Repository
{
    public class PartLogRepository : DataAccess, IPartLogRepository
    {
        private readonly string _connectionString;
        public PartLogRepository(ISettings settings)
        {
            _connectionString = settings.GetDatabaseConnectionStringSettings().ConnectionString;
        }

        public IEnumerable<PartLog> GetByBarcode(long barcodeId)
        {
            List<PartLog> list = new List<PartLog>();
            string procName = "paint.part_log_select_by_barcode_number";
            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(new SqlParameter() { ParameterName = "@barcode_number", Direction = ParameterDirection.Input, Value = barcodeId, DbType = DbType.UInt64 });

            using (IDataReader reader = ExecuteReader(procName, collection.ToArray(), _connectionString))
            {
                if (reader.Read())
                {
                    LoadPartLog(reader, list);
                }
            }
            return list;
        }

        private PartLog LoadPartLog(IDataReader reader, List<PartLog> list)
        {
            throw new NotImplementedException();
        }

        public void Save(ref PartLog model)
        {
            string procName = "paint.part_log_save";
            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(new SqlParameter() { ParameterName = "@data", Direction = ParameterDirection.Input, Value = ToXML(model), DbType = DbType.Xml });

            model.PartLogId = (long)ExecuteScalar(procName, collection.ToArray(), _connectionString);
        }

        private object ToXML(object model)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(model.GetType());
            serializer.Serialize(stringwriter, model);
            return stringwriter.ToString();
        }
    }

}
