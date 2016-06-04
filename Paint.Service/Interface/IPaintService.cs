using Paint.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Service.Interface
{
    public interface IPaintService
    {
        #region Color
        IEnumerable<Color> GetAllColors();
        #endregion

        #region Solvent
        IEnumerable<Solvent> GetAllSolvents();
        #endregion

        #region Defect
        IEnumerable<Defect> GetAllDefects();
        #endregion

        #region Manufacturer
        IEnumerable<Manufacturer> GetAllManufacturers();
        #endregion

        #region MixRoom
        void SaveMixRoom(ref MixRoom model);
        #endregion

        #region PartLog
        void SavePartLog(ref PartLog model);
        IEnumerable<PartLog> GetByBarcode(long barcodeId);
        #endregion

        #region Part
        IEnumerable<Part> GetAllParts();
        IEnumerable<Part> GetPartsByManufacturerId(int manufacturerId);
        #endregion
    }
}
