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
        private List<Manufacturer> _list;

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
            _list = _paintService.GetAllManufacturers().ToList();
            button1.Text = _list.FirstOrDefault().Name;
        }


         private void button1_Click(object sender, EventArgs e)
        {
            //SElected Manufacturer
            this._mainForm.CurrentPartLog.ManufacturerId = _list.FirstOrDefault().ManufacturerId;// This is just testing. The ID should come from what user selected
            this.Close();
            this._mainForm.UpdatedMainForm();
            this._mainForm.Focus();
        }
    }
}
