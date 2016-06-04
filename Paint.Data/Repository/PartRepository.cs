using Paint.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paint.Model.Models;
using Paint.Model.common;
using Paint.Data.ADO.NET;
using Paint.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace Paint.Data.Repository
{
    public class PartRepository : DataAccess, IPartRepository
    {
        private readonly string _connectionString;
        public PartRepository(ISettings settings)
        {
            _connectionString = settings.GetDatabaseConnectionStringSettings().ConnectionString;
        }

        public IEnumerable<Part> GetAll()
        {
            List<Part> list = new List<Part>();
            string procName = "paint.part_select_all";
            using (IDataReader reader = ExecuteReader(procName, null, _connectionString))
            {
                if (reader.Read())
                {
                    list.Add(LoadPart(reader));
                }
            }
            return list;
        }

        private Part LoadPart(IDataReader reader)
        {
            Part model = new Part();
            model.PartId = reader.GetInt32("part_id");
            model.ManufacturerId = reader.GetInt32("manufacturer_id");
            model.Name = reader.GetString("name");
            model.Description = reader.GetString("description");
            model.ImageName = reader.GetString("image_name");
            model.DateEntry = reader.GetDateTime("date_entry");
            model.DateUpdated = reader.GetDateTime("date_updated");

            return model; ;
        }

        public IEnumerable<Part> GetAllByManufacturerId(int manufacturerId)
        {
            List<Part> list = new List<Part>();
            string procName = "paint.part_select_by_manufacturer_id";
            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(new SqlParameter() { ParameterName = "@manufacturer_id", Direction = ParameterDirection.Input, Value = manufacturerId, DbType = DbType.Int32 });

            using (IDataReader reader = ExecuteReader(procName, collection.ToArray(), _connectionString))
            {
                if (reader.Read())
                {
                    list.Add(LoadPart(reader));
                }
            }
            return list;
        }
    }
}
