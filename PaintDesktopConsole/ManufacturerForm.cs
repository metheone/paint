using Paint.Model.Models;
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
    public partial class ManufacturerForm : Form
    {
        private Main _mainForm = null;
        private readonly IPaintService _paintService;

        public ManufacturerForm()
        {
            InitializeComponent();
        }
        public ManufacturerForm(Form mainForm, IPaintService paintService)
        {
            _mainForm = mainForm as Main;
            _paintService = paintService;
            InitializeComponent();
        }

        private void ManufacturerForm_Load(object sender, EventArgs e)
        {
            // Gets all the manufactuerer list items.
            //TODO: WE can use pictureBox and use forloop and for each manufactuers instatiate one picturebox.
            List<Manufacturer> list = _paintService.GetAllManufacturers().ToList();
        }

         private void button1_Click(object sender, EventArgs e)
        {
            //SElected Manufacturer
            this._mainForm.CurrentPartLog.ManufacturerId = 100;
            this.Close();
            this._mainForm.UpdatedMainForm();
            this._mainForm.Focus();
        }
    }
}
