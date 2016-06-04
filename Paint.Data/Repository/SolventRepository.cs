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
    public class SolventRepository : DataAccess, ISolventRepository
    {
        private readonly string _connectionString;

        public SolventRepository(ISettings settings)
        {
            _connectionString = settings.GetDatabaseConnectionStringSettings().ConnectionString;
        }

        public IEnumerable<Solvent> GetAll()
        {
            List<Solvent> list = new List<Solvent>();
            string procName = "paint.solvent_select_all";
            using (IDataReader reader = ExecuteReader(procName, null, _connectionString))
            {
                if (reader.Read())
                {
                    list.Add(LoadSolvent(reader));
                }
            }
            return list;
        }

        private Solvent LoadSolvent(IDataReader reader)
        {
            Solvent model = new Solvent();
            model.SolventId = reader.GetInt32("solvent_id");
            model.Name = reader.GetString("name");
            model.Description = reader.GetString("description");
            model.ImageName = reader.GetString("image_name");
            model.DateEntry = reader.GetDateTime("date_entry");
            model.DateUpdated = reader.GetDateTime("date_updated");

            return model;
        }
    }
}
