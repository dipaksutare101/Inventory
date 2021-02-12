using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class Form1 : Form
    {
        DataAccessLayer DAL= new DataAccessLayer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DAL.BuildConnString();
            DAL.FillComboDataSource("select * from PartyMaster", cmbPartyMaster, string.Empty);
        }

        
    }
}
