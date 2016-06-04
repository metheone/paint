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
    public class ColorRepository : DataAccess, IColorRepository
    {
        private readonly string _connectionString;

        public ColorRepository(ISettings settings)
        {
            _connectionString = settings.GetDatabaseConnectionStringSettings().ConnectionString;
        }
        public IEnumerable<Color> GetAll()
        {
            List<Color> list = new List<Color>();
            string procName = "paint.color_select_all";
            using (IDataReader reader = ExecuteReader(procName, null, _connectionString))
            {
                if (reader.Read())
                {
                    list.Add(LoadColor(reader));
                }
            }
            return list;
        }

        private Color LoadColor(IDataReader reader)
        {
            Color model = new Color();
            model.ColorId = reader.GetInt32("color_id");
            model.Name = reader.GetString("name");
            model.Description = reader.GetString("description");
            model.ImageName = reader.GetString("image_name");
            model.DateEntry = reader.GetDateTime("date_entry");
            model.DateUpdated = reader.GetDateTime("date_updated");

            return model;
        }
    }
}
