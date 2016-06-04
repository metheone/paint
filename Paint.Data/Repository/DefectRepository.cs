using Paint.Data.Interface;
using Paint.Model.common;
using Paint.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paint.Data.ADO.NET;
using System.Data;
using Paint.Data.Common;

namespace Paint.Data.Repository
{
    public class DefectRepository : DataAccess, IDefectRepository
    {
        private readonly string _connectionString;

        public DefectRepository(ISettings settings)
        {
            _connectionString = settings.GetDatabaseConnectionStringSettings().ConnectionString;
        }
        public IEnumerable<Defect> GetAll()
        {
            List<Defect> list = new List<Defect>();
            string procName = "paint.defect_select_all";
            using (IDataReader reader = ExecuteReader(procName, null, _connectionString))
            {
                if (reader.Read())
                {
                    list.Add(LoadDefect(reader));
                }
            }
            return list;
        }

        private Defect LoadDefect(IDataReader reader)
        {
            Defect model = new Defect();
            model.DefectId = reader.GetInt32("defect_id");
            model.Name = reader.GetString("name");
            model.Description = reader.GetString("description");
            model.ImageName = reader.GetString("image_name");
            model.DateEntry = reader.GetDateTime("date_entry");
            model.DateUpdated = reader.GetDateTime("date_updated");

            return model;
        }
    }
}
