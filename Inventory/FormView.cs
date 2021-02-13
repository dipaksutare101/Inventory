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
    public partial class FormView : Form
    {
        DataAccessLayer DAL = new DataAccessLayer();
        public FormView()
        {
            InitializeComponent();
        }

        private void FormView_Load(object sender, EventArgs e)
        {
            DataSet ViewDataset = new DataSet();
            ViewDataset = DAL.ExecuteDataSet("ViewData 0");
            gridView.DataSource = ViewDataset.Tables[0];

        }

        private void gridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id  = gridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            MyModule.FindId = id;
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
            
        }
    }
}
