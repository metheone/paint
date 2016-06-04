using Paint.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paint.Model.Models;

namespace Paint.Data.Repository
{
    public class PartLogRepository : IPartLogRepository
    {
        public IEnumerable<PartLog> GetByBarcode(long barcodeId)
        {
            throw new NotImplementedException();
        }

        public void Save(ref PartLog model)
        {
            throw new NotImplementedException();
        }
    }
}
