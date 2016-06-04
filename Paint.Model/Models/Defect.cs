using Paint.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Model.Models
{
    public class Defect
    {
        public Defect()
        {
            Zones = new List<Int32>();
        }
        public int DefectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public List<Int32> Zones { get; set; }
        public DateTime DateEntry { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
