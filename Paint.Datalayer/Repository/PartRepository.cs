using Paint.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paint.Model.Models;

namespace Paint.Data.Repository
{
    public class PartRepository : IPartRepository
    {
        public IEnumerable<Part> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Part> GetAllByManufacturerId(int manufacturerId)
        {
            throw new NotImplementedException();
        }
    }
}
