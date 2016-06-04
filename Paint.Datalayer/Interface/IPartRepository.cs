using Paint.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Data.Interface
{
   public interface IPartRepository
    {
        IEnumerable<Part> GetAll();
        IEnumerable<Part> GetAllByManufacturerId(int manufacturerId);
    }
}
