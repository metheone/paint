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

namespace Paint.Data.Repository
{
    public class MixRoomRepository : DataAccess, IMixRoomRepository
    {
        private readonly string _connectionString;
        public MixRoomRepository(ISettings settings)
        {
            _connectionString = settings.GetDatabaseConnectionStringSettings().ConnectionString;
        }

        public void Save(ref MixRoom model)
        {
            string procName = "paint.mix_room_save";
            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(new SqlParameter() { ParameterName = "@paint_name", Direction = ParameterDirection.Input, Value = model.PaintName, DbType = DbType.String });
            collection.Add(new SqlParameter() { ParameterName = "@paint_code", Direction = ParameterDirection.Input, Value = model.PaintCode, DbType = DbType.String });
            collection.Add(new SqlParameter() { ParameterName = "@paint_is_new_batch", Direction = ParameterDirection.Input, Value = model.PaintIsNewBatch, DbType = DbType.Boolean});
            collection.Add(new SqlParameter() { ParameterName = "@paint_batch_number", Direction = ParameterDirection.Input, Value = model.PaintBatchNumber, DbType = DbType.String });
            collection.Add(new SqlParameter() { ParameterName = "@paint_quantity_added", Direction = ParameterDirection.Input, Value = model.PaintQuantityAdded, DbType = DbType.Int32});
            collection.Add(new SqlParameter() { ParameterName = "@solvent_name", Direction = ParameterDirection.Input, Value = model.SolventName, DbType = DbType.String });
            collection.Add(new SqlParameter() { ParameterName = "@solvent_code", Direction = ParameterDirection.Input, Value = model.SolventCode, DbType = DbType.String });
            collection.Add(new SqlParameter() { ParameterName = "@solvent_is_new_batch", Direction = ParameterDirection.Input, Value = model.SolventIsNewBatch, DbType = DbType.Boolean});
            collection.Add(new SqlParameter() { ParameterName = "@solvent_batch_number", Direction = ParameterDirection.Input, Value = model.SolventBatchNumber, DbType = DbType.String });
            collection.Add(new SqlParameter() { ParameterName = "@solvent_quantity_added", Direction = ParameterDirection.Input, Value = model.SolventQuantityAdded, DbType = DbType.Int32});
            collection.Add(new SqlParameter() { ParameterName = "@viscosity", Direction = ParameterDirection.Input, Value = model.Viscosity, DbType = DbType.String });
            collection.Add(new SqlParameter() { ParameterName = "@catalyst", Direction = ParameterDirection.Input, Value = model.Catalyst, DbType = DbType.String });
            collection.Add(new SqlParameter() { ParameterName = "@additive", Direction = ParameterDirection.Input, Value = model.Additive, DbType = DbType.String });
            collection.Add(new SqlParameter() { ParameterName = "@added_by", Direction = ParameterDirection.Input, Value = model.AddedBy, DbType = DbType.String });

            model.MixRoomId = (int)ExecuteScalar(procName, collection.ToArray(), _connectionString);
        }
    }
}
