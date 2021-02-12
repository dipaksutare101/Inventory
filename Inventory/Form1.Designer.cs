
namespace Inventory
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbPartyMaster = new System.Windows.Forms.ComboBox();
            this.dtpsaledate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSaleNo = new System.Windows.Forms.Label();
            this.gridsaledetail = new System.Windows.Forms.DataGridView();
            this.txttotalAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.Saledetailid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saleid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridsaledetail)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPartyMaster
            // 
            this.cmbPartyMaster.FormattingEnabled = true;
            this.cmbPartyMaster.Location = new System.Drawing.Point(12, 25);
            this.cmbPartyMaster.Name = "cmbPartyMaster";
            this.cmbPartyMaster.Size = new System.Drawing.Size(121, 21);
            this.cmbPartyMaster.TabIndex = 1;
            // 
            // dtpsaledate
            // 
            this.dtpsaledate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpsaledate.Location = new System.Drawing.Point(904, 26);
            this.dtpsaledate.Name = "dtpsaledate";
            this.dtpsaledate.Size = new System.Drawing.Size(102, 20);
            this.dtpsaledate.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(868, 28);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date";
            // 
            // lblSaleNo
            // 
            this.lblSaleNo.AutoSize = true;
            this.lblSaleNo.Location = new System.Drawing.Point(807, 25);
            this.lblSaleNo.Name = "lblSaleNo";
            this.lblSaleNo.Size = new System.Drawing.Size(0, 13);
            this.lblSaleNo.TabIndex = 4;
            // 
            // gridsaledetail
            // 
            this.gridsaledetail.AllowUserToAddRows = false;
            this.gridsaledetail.AllowUserToDeleteRows = false;
            this.gridsaledetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridsaledetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Saledetailid,
            this.Saleid,
            this.ItemName,
            this.Qty,
            this.Rate,
            this.Amount});
            this.gridsaledetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridsaledetail.Location = new System.Drawing.Point(173, 116);
            this.gridsaledetail.Name = "gridsaledetail";
            this.gridsaledetail.Size = new System.Drawing.Size(552, 150);
            this.gridsaledetail.TabIndex = 5;
            this.gridsaledetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            
            this.gridsaledetail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridsaledetail_KeyPress);
            // 
            // txttotalAmount
            // 
            this.txttotalAmount.Location = new System.Drawing.Point(788, 369);
            this.txttotalAmount.Name = "txttotalAmount";
            this.txttotalAmount.Size = new System.Drawing.Size(100, 20);
            this.txttotalAmount.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(712, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Total Amount";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(417, 372);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(218, 372);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(314, 372);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 10;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(521, 371);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // Saledetailid
            // 
            this.Saledetailid.DataPropertyName = "Saledetailid";
            this.Saledetailid.HeaderText = "Saledetailid";
            this.Saledetailid.Name = "Saledetailid";
            this.Saledetailid.Visible = false;
            // 
            // Saleid
            // 
            this.Saleid.DataPropertyName = "Saleid";
            this.Saleid.HeaderText = "Saleid";
            this.Saleid.Name = "Saleid";
            this.Saleid.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 200;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle10;
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            // 
            // Rate
            // 
            this.Rate.DataPropertyName = "Rate";
            dataGridViewCellStyle11.Format = "N2";
            this.Rate.DefaultCellStyle = dataGridViewCellStyle11;
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle12;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txttotalAmount);
            this.Controls.Add(this.gridsaledetail);
            this.Controls.Add(this.lblSaleNo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpsaledate);
            this.Controls.Add(this.cmbPartyMaster);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridsaledetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbPartyMaster;
        private System.Windows.Forms.DateTimePicker dtpsaledate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSaleNo;
        private System.Windows.Forms.DataGridView gridsaledetail;
        private System.Windows.Forms.TextBox txttotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saledetailid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saleid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}

