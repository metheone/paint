using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Model.Models
{
    public class PartLog
    {
        public PartLog()
        {
            Defects = new List<Defect>();

        }
        public long PartLogId { get; set; }
        public long BarcodeId { get; set; }
        public int ManufacturerId { get; set; }
        public int PartId { get; set; }
        public int ColorId { get; set; }
        public int SolventId { get; set; }
        public bool HasDefect { get; set; }
        public List<Defect> Defects { get; set; }
        public DateTime DateEntry { get; set; }
        public DateTime Dateupdated { get; set; }
        public string AddedBy { get; set; }
    }
}
