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
        int EntryId = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnNew_Click(null, null);
            if( Convert.ToInt32(MyModule.FindId) > 0)
            {
                Filldata(Convert.ToInt32(MyModule.FindId));
            }
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
                if (e.ColumnIndex == 4)
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
            if(e.KeyChar==(char)(Keys.Enter) || e.KeyChar== (char)(Keys.Tab))
            {
                int ColumnIndex = gridsaledetail.CurrentCell.ColumnIndex;
                if (ColumnIndex == 5)
                {
                    Addrow();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int Addnew = 0;
            if (EntryId < 1)
            {
                Addnew = 1;
            }
            string sqlstring = "SaleSave";
            DAL.AddParameter("@AddNew", Addnew);
            DAL.AddParameter("@Saleid", EntryId);
            if(dtpsaledate.Text.Length > 0)
            {
                //DAL.AddParameter("@SaleDate", Convert.ToDateTime(dtpsaledate.Value).ToString("yyyy/MM/dd"));
                DAL.AddParameter("@SaleDate", DBNull.Value);
            }
            else
            {
                DAL.AddParameter("@SaleDate", DBNull.Value);
            }
            

            DAL.AddParameter("@Partyid", cmbPartyMaster.SelectedValue);
            DAL.AddParameter("@SaleNo",5 );
            DAL.AddParameter("@Remark", "TEST");
            DAL.AddParameter("@TotalAmount", txttotalAmount.Text);
            DAL.AddParameter("@Saledetail", mydataset.Tables[1]);
            EntryId = Convert.ToInt16(DAL.ExecuteScalar(sqlstring, DAL.ParameterList));
            if(EntryId > 0)
            {
                MessageBox.Show("Data Saved Successfully");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }


        }

        private void btnView_Click(object sender, EventArgs e)
        {
          //  DataSet ViewDataset = new DataSet();
          //  ViewDataset = DAL.ExecuteDataSet("ViewData 0");
            FormView Fv = new FormView();
            Fv.Show();

            
          
        }
        public void Filldata(int findid)
        {
            mydataset = new DataSet();
            mydataset = DAL.ExecuteDataSet("Viewdata " + findid.ToString());
            var viewdata = mydataset.Tables[0];

            //dtpsaledate.Text = string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(viewdata.Rows[0]["Saledate"]));
            cmbPartyMaster.SelectedValue = viewdata.Rows[0]["partyid"].ToString();
            txttotalAmount.Text = viewdata.Rows[0]["Amount"].ToString();
            gridsaledetail.DataSource = mydataset.Tables[1];
            EntryId = Convert.ToInt32(viewdata.Rows[0]["Saleid"].ToString());


        }
        private void gridsaledetail_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Delete)
            {
                foreach(DataGridViewRow row in gridsaledetail.SelectedRows)
                {
                    if(gridsaledetail.Rows.Count > 0)
                    {
                        DialogResult dr = MessageBox.Show("Are you sure you want to delete?","Remove Row", MessageBoxButtons.YesNo);
                        if(dr == DialogResult.Yes)
                        {
                            mydataset.Tables[1].Rows.RemoveAt(row.Index);
                            mydataset.Tables[1].AcceptChanges();
                            Recalculate();
                        }
                    }
                }
            }
        }
    }
}
