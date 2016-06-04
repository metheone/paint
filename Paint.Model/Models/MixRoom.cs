using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Model.Models
{
    public class MixRoom
    {
        public long MixRoomId { get; set; }
        public string PaintName { get; set; }
        public string PaintCode { get; set; }
        public bool PaintIsNewBatch { get; set; }
        public string PaintBatchNumber { get; set; }
        public int PaintQuantityAdded { get; set; }
        public string SolventName { get; set; }
        public string SolventCode { get; set; }
        public bool SolventIsNewBatch { get; set; }
        public string SolventBatchNumber { get; set; }
        public int SolventQuantityAdded { get; set; }
        public string Viscosity { get; set; }
        public string Catalyst { get; set; }
        public string Additive { get; set; }
        public DateTime DateEntry { get; set; }
        public DateTime Dateupdated { get; set; }
        public string AddedBy { get; set; }

    }
}
