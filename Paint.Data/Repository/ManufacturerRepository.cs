using Paint.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paint.Model.Models;
using Paint.Model.common;
using Paint.Data.ADO.NET;
using System.Data;
using Paint.Data.Common;

namespace Paint.Data.Repository
{
    public class ManufacturerRepository : DataAccess, IManufacturerRepository
    {
        private readonly string _connectionString;

        public ManufacturerRepository(ISettings settings)
        {
            _connectionString = settings.GetDatabaseConnectionStringSettings().ConnectionString;
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            List<Manufacturer> list = new List<Manufacturer>();
            string procName = "paint.manufacturer_select_all";
            using (IDataReader reader = ExecuteReader(procName, null, _connectionString))
            {
                if (reader.Read())
                {
                    list.Add(LoadManufacturer(reader));
                }
            }
            return list;
        }

        private Manufacturer LoadManufacturer(IDataReader reader)
        {
            Manufacturer model = new Manufacturer();
            model.ManufacturerId = reader.GetInt32("manufacturer_id");
            model.Name = reader.GetString("name");
            model.Description = reader.GetString("description");
            model.ImageName = reader.GetString("image_name");
            model.DateEntry = reader.GetDateTime("date_entry");
            model.DateUpdated = reader.GetDateTime("date_updated");

            return model;
        }
    }
}
