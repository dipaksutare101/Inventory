using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Inventory
{

    public class DataAccessLayer
    {
        public List<SqlParameter> ParameterList = new List<SqlParameter>();
        public void BuildConnString()
        {
            try
            {
                string path = System.IO.Path.Combine(Application.StartupPath, "ConnectionConfig.ini");
                string TermsConditionConfigPath = System.IO.Path.Combine(Application.StartupPath, "TermsConditionConfig.ini");
                // CS.Clear()
                // "ConnConfig.dat"
                // "ConnectionConfig.ini"

                SqlConnection DBConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);

                //  SaleBillPrefix = ConfigurationManager.AppSettings("SaleBillPrefix");

                //string IsQuotationNewSetting = ConfigurationManager.AppSettings("IsQuotationNew");
                //IsQuotationNew = Convert.ToBoolean(IsQuotationNewSetting);

                MyModule.ConnString = DBConnection.ConnectionString.ToString();

                MyModule.ServerName = DBConnection.DataSource.ToString();
                MyModule.DataBase = DBConnection.Database.ToString();
                MyModule.DbUser = "sa";
                MyModule.dbPass = "smart@123";

                if (System.IO.File.Exists(path) == false)
                    System.IO.File.Create(path);
                else
                {
                }


                //if (System.IO.File.Exists(TermsConditionConfigPath) == false)
                //    System.IO.File.Create(TermsConditionConfigPath);
                //else
                //    using (System.IO.StreamReader sr = new System.IO.StreamReader(TermsConditionConfigPath))
                //    {
                //        TermsConditions += sr.ReadLine();
                //        TermsConditions += Environment.NewLine + sr.ReadLine();
                //        TermsConditions += Environment.NewLine + sr.ReadLine();
                //        TermsConditions += Environment.NewLine + sr.ReadLine();
                //        TermsConditions += Environment.NewLine + sr.ReadLine();
                //        TermsConditions += Environment.NewLine + sr.ReadLine();
                //        TermsConditions += Environment.NewLine + sr.ReadLine();
                //        TermsConditions += Environment.NewLine + sr.ReadLine();
                //    }
            }


            // If ServerName.Equals(String.Empty) Or DataBase.Equals(String.Empty) Or DbUser.Equals(String.Empty) Or dbPass.Equals(String.Empty) Then
            // MessageBox.Show("Database Connection Not Established.", "Data Access Layer", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            // Else
            // 'ConnString = "Server=" & ServerName & ";Database=" & DataBase & ";User Id=" & DbUser & ";password=" & dbPass & ";"
            // 'ConnString = "Data Source=JAYESH-PC; Initial Catalog=ParekhDbNew; Integrated Security=True;"
            // ConnString = DBConnection.ConnectionString.ToString()

            // ServerName = DBConnection.DataSource.ToString()
            // DataBase = DBConnection.Database.ToString()
            // DbUser = DBConnection.Credential.UserId.ToString()
            // dbPass = DBConnection.Credential.Password.ToString()

            // End If

            catch (Exception ex)
            {
                LogError(ex, "Build Connection String");
            }
        }

        //public void ResetTextBox(Control Root)
        //{
        //    try
        //    {
        //        foreach (Control MyCtl in Root.Controls)
        //        {
        //            if (MyCtl is MyTextBox)
        //            {
        //                {
        //                    var withBlock = (MyTextBox)MyCtl;
        //                    withBlock.Text = string.Empty;
        //                    withBlock.Tag = string.Empty;
        //                }
        //            }

        //            if (MyCtl is MyDateTime)
        //            {
        //                {
        //                    var withBlock = (MyDateTime)MyCtl;
        //                    withBlock.Value = CurrentDate();
        //                    withBlock.Tag = string.Empty;
        //                }
        //            }

        //            if (MyCtl is CheckBox)
        //            {
        //                {
        //                    var withBlock = (CheckBox)MyCtl;
        //                    withBlock.Checked = false;
        //                    withBlock.Tag = string.Empty;
        //                }
        //            }

        //            if (MyCtl is Button)
        //            {
        //                {
        //                    var withBlock = (Button)MyCtl;
        //                    if (withBlock.Name.Equals("BtnDelete") == true)
        //                        withBlock.Text = "Delete";
        //                }
        //            }

        //            if (MyCtl is MyLabel)
        //            {
        //                {
        //                    var withBlock = (MyLabel)MyCtl;
        //                    withBlock.Tag = string.Empty;
        //                    if (withBlock.TextBox.Equals(true) & withBlock.InputType == MyTextInputType.None)
        //                        withBlock.Text = string.Empty;
        //                    else if (withBlock.TextBox.Equals(true) & withBlock.InputType == MyTextInputType.Currency)
        //                        withBlock.Text = "0.00";
        //                    else if (withBlock.TextBox.Equals(true) & withBlock.InputType == MyTextInputType.Number)
        //                        withBlock.Text = "0";
        //                }
        //            }

        //            if (MyCtl.HasChildren)
        //                ResetTextBox(MyCtl);
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message.ToString(), "Reset Text", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}

        public void LogError(Exception ex, string CmdText = null)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            if (CmdText != null)
            {
                message += Environment.NewLine;
                message += string.Format("Command Text: {0}", CmdText.ToString());
            }
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;

            string Path = Application.StartupPath + @"\ErrorLog.txt";
            if (System.IO.File.Exists(Path).Equals(false))
                System.IO.File.Create(Path).Close();

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(Path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        //public DateTime CurrentDate()
        //{
        //    return GetValue("Select GETDATE()");
        //}

        private object MyValue(string SqlString, List<SqlParameter> SqlPara = null)
        {
            // BuildConnString()
            object MyStatus = null;
            using (SqlConnection SqlConn = new SqlConnection(MyModule.ConnString))
            {
                using (SqlCommand SqlCmd = new SqlCommand())
                {
                    try
                    {
                        {
                            var withBlock = SqlCmd;
                            withBlock.Parameters.Clear();
                            withBlock.Connection = SqlConn;
                            if (SqlString.StartsWith("Select", StringComparison.CurrentCultureIgnoreCase).Equals(true))
                            {
                                withBlock.CommandType = CommandType.Text;
                                withBlock.CommandText = SqlString;
                            }
                            else if (SqlString.StartsWith("Insert", StringComparison.CurrentCultureIgnoreCase).Equals(true))
                            {
                                withBlock.CommandType = CommandType.Text;
                                withBlock.CommandText = SqlString;
                            }
                            else if (SqlString.StartsWith("Update", StringComparison.CurrentCultureIgnoreCase).Equals(true))
                            {
                                withBlock.CommandType = CommandType.Text;
                                withBlock.CommandText = SqlString;
                            }
                            else if (SqlString.StartsWith("Delete", StringComparison.CurrentCultureIgnoreCase).Equals(true))
                            {
                                withBlock.CommandType = CommandType.Text;
                                withBlock.CommandText = SqlString;
                            }
                            else if (SqlPara == null)
                            {
                                withBlock.CommandType = CommandType.Text;
                                withBlock.CommandText = "Exec dbo." + SqlString;
                            }
                            else if (SqlPara != null)
                            {
                                withBlock.CommandType = CommandType.StoredProcedure;
                                withBlock.CommandText = "dbo." + SqlString;
                                withBlock.Parameters.AddRange(SqlPara.ToArray());
                            }
                        }

                        SqlConn.Open();
                        SqlDataReader MyValueReader = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (MyValueReader.Read())
                        {
                            if ((MyValueReader[0]) == DBNull.Value)
                                MyStatus = null;
                            else
                                MyStatus = MyValueReader[0];
                        }
                        MyValueReader.Close(); MyValueReader = null;
                    }
                    catch (Exception ex)
                    {
                        LogError(ex, SqlString);
                        MessageBox.Show(("An exception Of type " + ex.GetType().ToString() + " was encountered While Filling Auto Complate Text." + Environment.NewLine + ex.Message.ToString()), "Get Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        ParameterList.Clear(); SqlConn.Close();
                    }
                }
            }
            return MyStatus;
        }

        public object GetValue(string SqlString)
        {
            return MyValue(SqlString, null);
        }

        public object GetValue(string SqlString, List<SqlParameter> ListofSqlParameter)
        {
            return MyValue(SqlString, ListofSqlParameter);
        }

        public void AddParameter(string ParameterName, object value)
        {
            try
            {
                ParameterList.Add(new SqlParameter(ParameterName, value));
            }
            catch (Exception Ex)
            {
                LogError(Ex, "Build Parameter");
                MessageBox.Show(Ex.Message.ToString(), "Base Form AddParameter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearParameter()
        {
            try
            {
                ParameterList.Clear();
            }
            catch (Exception Ex)
            {
                LogError(Ex, "Clear Parameter");
            }
        }

        private object MyScalar(string SqlString, List<SqlParameter> SqlPara = null)
        {
            object res = new object();

            // If BuildConnString.Equals(True) Then
            using (SqlConnection Sqlconn = new SqlConnection(MyModule.ConnString))
            {
                SqlTransaction Transaction = null;
                SqlCommand Sqlcmd = new SqlCommand();
                try
                {
                    {
                        var withBlock = Sqlcmd;
                        withBlock.Connection = Sqlconn;
                        withBlock.Parameters.Clear();
                        if (SqlString.StartsWith("Select", StringComparison.CurrentCultureIgnoreCase))
                        {
                            withBlock.CommandType = CommandType.Text;
                            withBlock.CommandText = SqlString;
                        }
                        else if (SqlString.StartsWith("Insert", StringComparison.CurrentCultureIgnoreCase))
                        {
                            withBlock.CommandType = CommandType.Text;
                            withBlock.CommandText = SqlString;
                        }
                        else if (SqlString.StartsWith("Update", StringComparison.CurrentCultureIgnoreCase))
                        {
                            withBlock.CommandType = CommandType.Text;
                            withBlock.CommandText = SqlString;
                        }
                        else if (SqlString.StartsWith("Delete", StringComparison.CurrentCultureIgnoreCase))
                        {
                            withBlock.CommandType = CommandType.Text;
                            withBlock.CommandText = SqlString;
                        }
                        else if (SqlPara == null)
                        {
                            withBlock.CommandType = CommandType.Text;
                            withBlock.CommandText = "Exec dbo." + SqlString;
                        }
                        else if (SqlPara != null)
                        {
                            withBlock.CommandType = CommandType.StoredProcedure;
                            withBlock.Parameters.AddRange(SqlPara.ToArray());
                            withBlock.CommandText = "dbo." + SqlString;
                        }
                    }

                    Sqlconn.Open();
                    Transaction = Sqlconn.BeginTransaction();
                    Sqlcmd.Transaction = Transaction;
                    res = Sqlcmd.ExecuteScalar();
                    Transaction.Commit();
                }
                catch (Exception ex)
                {
                    try
                    {
                        LogError(ex, SqlString);
                        res = null;
                        Transaction.Rollback();
                    }
                    catch (SqlException ex1)
                    {
                        LogError(ex1, SqlString);
                        if (Transaction.Connection != null)
                            MessageBox.Show("An exception Of type " + ex1.GetType().ToString() + " was encountered While attempting To roll back the transaction." + Environment.NewLine + ex1.Message.ToString(), "Execute Scalar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    MessageBox.Show("An exception Of type " + ex.GetType().ToString() + "was encountered While inserting the data." + Environment.NewLine + ex.Message.ToString(), "Execute Scalar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Sqlconn.Close(); Sqlcmd.Dispose(); Transaction.Dispose(); ClearParameter();
                }
            }
            // Else
            // MessageBox.Show(ErrMsg.ToString(), "Execure Scalar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            // End If

            return res;
        }

        public object ExecuteScalar(string SqlString)
        {
            return MyScalar(SqlString);
        }

        public object ExecuteScalar(string SqlString, List<SqlParameter> ListofParameter)
        {
            return MyScalar(SqlString, ListofParameter);
        }

        private void MyNonQuery(string SqlString, List<SqlParameter> SqlPara = null)
        {

            // If BuildConnString.Equals(True) Then
            using (SqlConnection SQLConn = new SqlConnection(MyModule.ConnString))
            {
                SqlCommand SqlCmd = SQLConn.CreateCommand();
                SqlTransaction Transaction = null;
                try
                {
                    SQLConn.Open();
                    // Start a local transaction
                    Transaction = SQLConn.BeginTransaction("SampleTransaction");
                    // Must assign both transaction object and connection
                    // to Command object for a pending local transaction
                    SqlCmd.Connection = SQLConn;
                    SqlCmd.Transaction = Transaction;

                    {
                        var withBlock = SqlCmd;
                        withBlock.Parameters.Clear();
                        if (SqlString.StartsWith("Select", StringComparison.CurrentCultureIgnoreCase))
                        {
                            withBlock.CommandType = CommandType.Text;
                            withBlock.CommandText = SqlString;
                        }
                        else if (SqlString.StartsWith("Insert", StringComparison.CurrentCultureIgnoreCase))
                        {
                            withBlock.CommandType = CommandType.Text;
                            withBlock.CommandText = SqlString;
                        }
                        else if (SqlString.StartsWith("Update", StringComparison.CurrentCultureIgnoreCase))
                        {
                            withBlock.CommandType = CommandType.Text;
                            withBlock.CommandText = SqlString;
                        }
                        else if (SqlString.StartsWith("Delete", StringComparison.CurrentCultureIgnoreCase))
                        {
                            withBlock.CommandType = CommandType.Text;
                            withBlock.CommandText = SqlString;
                        }
                        else if (SqlPara == null)
                        {
                            withBlock.CommandType = CommandType.Text;
                            withBlock.CommandText = "Exec dbo." + SqlString;
                        }
                        else if (SqlPara != null)
                        {
                            withBlock.CommandType = CommandType.StoredProcedure;
                            withBlock.CommandText = "dbo." + SqlString;
                            withBlock.Parameters.AddRange(SqlPara.ToArray());
                        }
                    }

                    SqlCmd.ExecuteNonQuery();
                    Transaction.Commit();
                }
                catch (Exception Ex)
                {
                    try
                    {
                        LogError(Ex, SqlString);
                        Transaction.Rollback();
                    }
                    catch (SqlException Exr)
                    {
                        LogError(Exr, SqlString);
                        if (Transaction.Connection != null)
                            MessageBox.Show("An exception Of type " + Exr.GetType().ToString() + " was encountered While attempting To roll back the transaction." + Environment.NewLine + Exr.Message.ToString(), "Execute Non Query", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    MessageBox.Show("An exception Of type " + Ex.GetType().ToString() + "was encountered While inserting the data." + Environment.NewLine + Ex.Message.ToString(), "Execute Non Query", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    throw Ex;
                }
                finally
                {
                    SQLConn.Close(); SqlCmd.Dispose(); Transaction.Dispose(); ClearParameter();
                }
            }
        }

        public void ExecuteNonQuery(string SqlString)
        {
            try
            {
                MyNonQuery(SqlString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteNonQuery(string SqlString, List<SqlParameter> ListOfParameter)
        {
            try
            {
                MyNonQuery(SqlString, ListOfParameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable NewDataTable(string SqlString, List<SqlParameter> Sqlpara = null)
        {
            DataTable DT = new DataTable();

            // If BuildConnString.Equals(True) Then
            using (SqlConnection SqlConn = new SqlConnection(MyModule.ConnString))
            {
                try
                {
                    if (SqlString.StartsWith("Select", StringComparison.CurrentCultureIgnoreCase))
                        SqlString = SqlString;
                    else if (SqlString.StartsWith("Insert", StringComparison.CurrentCultureIgnoreCase))
                        SqlString = SqlString;
                    else if (SqlString.StartsWith("Update", StringComparison.CurrentCultureIgnoreCase))
                        SqlString = SqlString;
                    else if (SqlString.StartsWith("Delete", StringComparison.CurrentCultureIgnoreCase))
                        SqlString = SqlString;
                    else if (Sqlpara == null)
                        SqlString = "Exec dbo." + SqlString;
                    else if (Sqlpara != null)
                        SqlString = "dbo." + SqlString;

                    using (SqlDataAdapter SqlDA = new SqlDataAdapter(SqlString, SqlConn))
                    {
                        SqlDA.SelectCommand.Parameters.Clear();

                        if (Sqlpara == null)
                            SqlDA.SelectCommand.CommandType = CommandType.Text;
                        else
                        {
                            SqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                            Sqlpara.ForEach(p => SqlDA.SelectCommand.Parameters.Add(p));
                        }

                        SqlDA.Fill(DT);
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex, SqlString);
                    MessageBox.Show(("An exception Of type " + ex.GetType().ToString() + " was encountered While Getting DataTable." + Environment.NewLine + ex.Message.ToString()), "Data Table", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    SqlConn.Close(); ClearParameter();
                }
            }
            // Else
            // MessageBox.Show(ErrMsg.ToString, "Data Table", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            // End If
            return DT;
        }

        public DataTable ExecuteDatatable(string SqlString)
        {
            return NewDataTable(SqlString);
        }

        public DataTable ExecuteDatatable(string SqlString, List<SqlParameter> ListofParameter)
        {
            return NewDataTable(SqlString, ListofParameter);
        }


        private DataSet NewDataSet(string SqlString, List<SqlParameter> SqlPara = null)
        {
            DataSet Ds = new DataSet();
            // If BuildConnString.Equals(True) Then
            using (SqlConnection SqlConn = new SqlConnection(MyModule.ConnString))
            {
                try
                {
                    if (SqlString.StartsWith("Select", StringComparison.CurrentCultureIgnoreCase))
                        SqlString = SqlString;
                    else if (SqlString.StartsWith("Insert", StringComparison.CurrentCultureIgnoreCase))
                        SqlString = SqlString;
                    else if (SqlString.StartsWith("Update", StringComparison.CurrentCultureIgnoreCase))
                        SqlString = SqlString;
                    else if (SqlString.StartsWith("Delete", StringComparison.CurrentCultureIgnoreCase))
                        SqlString = SqlString;
                    else if (SqlPara == null)
                        SqlString = "Exec dbo." + SqlString;
                    else if (SqlPara != null)
                        SqlString = "dbo." + SqlString;

                    using (SqlDataAdapter SqlDA = new SqlDataAdapter(SqlString, SqlConn))
                    {
                        SqlDA.SelectCommand.Parameters.Clear();

                        if (SqlPara == null)
                            SqlDA.SelectCommand.CommandType = CommandType.Text;
                        else
                        {
                            SqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                            SqlPara.ForEach(p => SqlDA.SelectCommand.Parameters.Add(p));
                        }
                        SqlDA.Fill(Ds);
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex, SqlString);
                    MessageBox.Show(("An exception Of type " + ex.GetType().ToString() + " was encountered While Getting DataTable." + Environment.NewLine + ex.Message.ToString()), "Data Set", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    SqlConn.Close(); ClearParameter();
                }
            }
            // Else
            // MessageBox.Show(ErrMsg.ToString(), "Get DataSet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            // End If
            return Ds;
        }

        public DataSet ExecuteDataSet(string SqlString, List<SqlParameter> ListofParameter)
        {
            return NewDataSet(SqlString, ListofParameter);
        }

        public DataSet ExecuteDataSet(string SqlString)
        {
            return NewDataSet(SqlString);
        }

        private void MyComboDataSource(string Sqlstring, ComboBox MyCombobox, string MyDefaultValue = null, List<SqlParameter> SqlPara = null)
        {

            // If BuildConnString.Equals(True) Then
            DataTable DT = new DataTable();
            try
            {
                using (SqlConnection SqlConn = new SqlConnection(MyModule.ConnString))
                {
                    using (SqlCommand SqlCmd = new SqlCommand())
                    {
                        {
                            var withBlock = SqlCmd;
                            withBlock.Parameters.Clear();
                            withBlock.Connection = SqlConn;
                            if (Sqlstring.StartsWith("Select", StringComparison.CurrentCultureIgnoreCase).Equals(true))
                            {
                                withBlock.CommandType = CommandType.Text;
                                withBlock.CommandText = Sqlstring;
                            }
                            else if (Sqlstring.StartsWith("Insert", StringComparison.CurrentCultureIgnoreCase).Equals(true))
                            {
                                withBlock.CommandType = CommandType.Text;
                                withBlock.CommandText = Sqlstring;
                            }
                            else if (Sqlstring.StartsWith("Update", StringComparison.CurrentCultureIgnoreCase).Equals(true))
                            {
                                withBlock.CommandType = CommandType.Text;
                                withBlock.CommandText = Sqlstring;
                            }
                            else if (Sqlstring.StartsWith("Delete", StringComparison.CurrentCultureIgnoreCase).Equals(true))
                            {
                                withBlock.CommandType = CommandType.Text;
                                withBlock.CommandText = Sqlstring;
                            }
                            else if (SqlPara == null)
                            {
                                withBlock.CommandType = CommandType.Text;
                                withBlock.CommandText = "Exec dbo." + Sqlstring;
                            }
                            else if (SqlPara != null)
                            {
                                withBlock.CommandType = CommandType.StoredProcedure;
                                withBlock.CommandText = "dbo." + Sqlstring;
                                SqlPara.ForEach(p => withBlock.Parameters.Add(p));
                            }
                        }
                        using (SqlDataAdapter SqlDA = new SqlDataAdapter(SqlCmd))
                        {
                            SqlDA.Fill(DT);

                            if (DT.Rows.Count > 0 && MyDefaultValue != null)
                            {
                                DataRow Dr;
                                Dr = DT.NewRow();
                                Dr[0] = 0;
                                Dr[1] = MyDefaultValue.ToString();
                                DT.Rows.InsertAt(Dr, 0);
                                
                            }
                            MyCombobox.DataSource = DT;
                            MyCombobox.ValueMember = DT.Columns[0].ColumnName;
                            MyCombobox.DisplayMember = DT.Columns[1].ColumnName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, Sqlstring);
                MessageBox.Show(("An exception Of type " + ex.GetType().ToString() + " was encountered While Filling Combobx Data Source." + Environment.NewLine + ex.Message.ToString()), "Data Table", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                ClearParameter();
            }
        }

        public void FillComboDataSource(string Sqlstring, ComboBox MyCombobox)
        {
            MyComboDataSource(Sqlstring, MyCombobox);
        }

        public void FillComboDataSource(string Sqlstring, ComboBox MyCombobox, string DefaultValue)
        {
            MyComboDataSource(Sqlstring, MyCombobox, DefaultValue);
        }

        public void FillComboDataSource(string Sqlstring, ComboBox MyCombobox, List<SqlParameter> SqlPara)
        {
            MyComboDataSource(Sqlstring, MyCombobox, null/* TODO Change to default(_) if this is not a reference type */, SqlPara);
        }

        public void FillComboDataSource(string Sqlstring, ComboBox MyCombobox, string DefaultValue, List<SqlParameter> SqlPara)
        {
            MyComboDataSource(Sqlstring, MyCombobox, DefaultValue, SqlPara);
        }

        //public void SetDBLogonForReport(ReportDocument myReportDocument, bool isProcReport = false)
        //{
        //    ConnectionInfo myConnectionInfo = new ConnectionInfo();

        //    if (isProcReport == false)
        //    {
        //        myConnectionInfo.ServerName = ServerName;
        //        myConnectionInfo.DatabaseName = DataBase;
        //        if (Trim(DbUser) != "")
        //            myConnectionInfo.UserID = DbUser;
        //        if (Trim(dbPass) != "")
        //            myConnectionInfo.Password = dbPass;

        //        if (Trim(DbUser) == "" | Trim(dbPass) == "")
        //            myConnectionInfo.IntegratedSecurity = true;
        //        else
        //            myConnectionInfo.IntegratedSecurity = false;

        //        Tables myTables = myReportDocument.Database.Tables;
        //        foreach (Table myTable in myTables)
        //        {
        //            TableLogOnInfo myTableLogonInfo = new TableLogOnInfo();
        //            myTableLogonInfo.ConnectionInfo = myConnectionInfo;
        //            myTable.ApplyLogOnInfo(myTableLogonInfo);

        //            myTable.Location = DataBase + ".dbo." + myTable.Location.Substring(myTable.Location.LastIndexOf(".") + 1);

        //            if (myTable.TestConnectivity.ToString == "False")
        //                Interaction.MsgBox("Connection not Found");
        //        }
        //    }
        //    else
        //    {
        //        myConnectionInfo.ServerName = ServerName;
        //        myConnectionInfo.DatabaseName = DataBase;
        //        if (Trim(DbUser) != "")
        //            myConnectionInfo.UserID = DbUser;
        //        if (Trim(dbPass) != "")
        //            myConnectionInfo.Password = dbPass;

        //        if (Trim(DbUser) == "" | Trim(dbPass) == "")
        //            myConnectionInfo.IntegratedSecurity = true;
        //        else
        //            myConnectionInfo.IntegratedSecurity = false;

        //        Tables myTables = myReportDocument.Database.Tables;
        //        foreach (Table myTable in myTables)
        //        {
        //            TableLogOnInfo myTableLogonInfo = new TableLogOnInfo();
        //            myTableLogonInfo.ConnectionInfo = myConnectionInfo;
        //            myTable.ApplyLogOnInfo(myTableLogonInfo);

        //            myTable.Location = DataBase + ".dbo." + myTable.Location.Substring(myTable.Location.LastIndexOf(".") + 1);

        //            if (myTable.TestConnectivity.ToString == "False")
        //                Interaction.MsgBox("Connection not Found");
        //        }
        //    }
        //}
    }

}