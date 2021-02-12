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
        DataAccessLayer DAL = new DataAccessLayer();
        DataSet mydataset = new DataSet();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnNew_Click(null, null);
        }



        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (gridsaledetail.Columns[e.ColumnIndex].Name == Qty.Name || gridsaledetail.Columns[e.ColumnIndex].Name == Rate.Name)
            {
                var gridcells = gridsaledetail.Rows[e.RowIndex];
                if(gridcells.Cells[Rate.Name].Value ==DBNull.Value)
                {
                    gridcells.Cells[Rate.Name].Value = 0.00;
                }
                if (gridcells.Cells[Qty.Name].Value == DBNull.Value)
                {
                    gridcells.Cells[Qty.Name].Value = 0;
                }
                gridcells.Cells[Amount.Name].Value = Convert.ToInt32(gridcells.Cells[Qty.Name].Value) * Convert.ToInt32(gridcells.Cells[Rate.Name].Value);

                Recalculate();
                if(e.ColumnIndex==4)
                {
                    Addrow();
                }

            }
            // mydataset.Tables[1].AcceptChanges();
          
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DAL.FillComboDataSource("select * from PartyMaster", cmbPartyMaster, string.Empty);
            mydataset = DAL.ExecuteDataSet("ViewData 0");
            gridsaledetail.DataSource = mydataset.Tables[1];
            ClearControls();
            Addrow();
        }
        public void Recalculate()
        {
            if (mydataset.Tables[1]!=null)
            {
                decimal totalamount=0;
                foreach(DataRow row  in mydataset.Tables[1].Rows)
                {
                    if (row["Amount"] != DBNull.Value)
                    {
                        totalamount = totalamount + Convert.ToDecimal(row["Amount"].ToString());
                    }
                }
                txttotalAmount.Text = totalamount.ToString("#0.00");
            }
        }
        public void ClearControls()
        {
            cmbPartyMaster.SelectedIndex = -1;
            txttotalAmount.Text = "";
            dtpsaledate.Text = "";
        }

        public void Addrow()
        {
            if (mydataset.Tables[1].Rows.Count > 0)
            {
                DataRow Dr = mydataset.Tables[1].NewRow();
                mydataset.Tables[1].Rows.InsertAt(Dr, gridsaledetail.CurrentRow.Index + 1);
                gridsaledetail.Focus();
                gridsaledetail.CurrentCell = gridsaledetail[2, gridsaledetail.CurrentRow.Index + 1];
            }
            else
            { 
                mydataset.Tables[1].Rows.Add();
            }
        }

        private void gridsaledetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar.Equals(Keys.Enter) || e.KeyChar.Equals(Keys.Tab))
            {
                int ColumnIndex = gridsaledetail.CurrentCell.ColumnIndex;
                if (ColumnIndex == 5)
                {
                    Addrow();
                }
            }
        }

       
    }
}
