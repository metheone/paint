using Paint.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Data.Interface
{
    public interface IManufacturerRepository
    {
        IEnumerable<Manufacturer> GetAll();

    }
}
