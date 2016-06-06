using Paint.Model.Models;
using Paint.Service;
using Paint.Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintDesktopConsole
{
    public partial class Main : Form
    {
        private readonly IPaintService _paintService;
        private List<Manufacturer> ManufacturerList = new List<Manufacturer>();
        public Main(IPaintService paintService)
        {
            _paintService = paintService;
            InitializeComponent();
            ManufacturerList = _paintService.GetAllManufacturers().ToList();
            CurrentPartLog = new PartLog();
        }
        public PartLog CurrentPartLog { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            ManufacturerForm frm = new ManufacturerForm(this,_paintService);
            frm.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
        public void UpdatedMainForm()
        {
            Manufacturer m = ManufacturerList.FirstOrDefault(x => x.ManufacturerId == CurrentPartLog.ManufacturerId);

            if (m != null) ManufacturerLabel.Text = m.Name;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
