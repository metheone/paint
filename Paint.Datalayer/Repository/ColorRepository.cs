using Paint.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paint.Model.Models;

namespace Paint.Data.Repository
{
    public class ColorRepository : IColorRepository
    {
        public IEnumerable<Model.Models.Color> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
