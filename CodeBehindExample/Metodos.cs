using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeBehindExample
{
    public class Metodos
    {
        public static string servidorbdd = @"ELITEBOOK\SQLEXPRESS";
        public string constr = "Data Source=" + servidorbdd + ";Initial Catalog=INVENTORYMNGDB;User ID=Dev;Password=Dev1414";

        public bool GetDataByQuery_sql(string sql, Boolean s_iud, ref DataSet ds)
        {
            //OleDbConnection cn1 = new OleDbConnection(cn);

            SqlConnection cn1 = new SqlConnection(this.constr);
            //OleDbConnection cn1 = new OleDbConnection(this.constr);
            SqlDataAdapter daVb = new SqlDataAdapter();
            //OleDbDataAdapter daVb = new OleDbDataAdapter();
            SqlCommand cmdVb = new SqlCommand();
            //OleDbCommand cmdVb = new OleDbCommand();
            DataSet dsVb = new DataSet();

            int result;
            cmdVb.Connection = cn1;
            daVb.SelectCommand = cmdVb;
            cmdVb.CommandText = sql;

            try
            {
                if (!s_iud)
                {
                    //Realiza un select
                    daVb.Fill(ds);
                }
                else
                {
                    //ejecuta una sentencia insert, update o delete
                    cn1.Open();
                    result = cmdVb.ExecuteNonQuery();
                    cn1.Close();
                    cn1 = null;
                    System.GC.Collect();
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataSet RunDataSet(string StoredProcedure, List<SqlParameter> ListSqlParam, string Conexion)
        {
            DataSet DtSt = new DataSet();
            SqlConnection sqlCnx = null;
            SqlCommand SqlCmnd = null;
            SqlDataAdapter SqlAdapter = null;

            try
            {
                sqlCnx = new SqlConnection(Conexion);
                SqlCmnd = new SqlCommand(StoredProcedure, sqlCnx);
                SqlCmnd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter Parametro in ListSqlParam)
                {
                    SqlCmnd.Parameters.Add(Parametro);
                }

                SqlAdapter = new SqlDataAdapter(SqlCmnd);
                SqlAdapter.Fill(DtSt);
                sqlCnx.Dispose();
                SqlCmnd.Dispose();
                SqlAdapter.Dispose();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            return DtSt;
        }
        public void cargarListView(ListView ddlObj, DataSet ds, string campoValue, string CampoTexto)
        {
            ddlObj.DataSource = ds.Tables[0];
            ddlObj.DataBind();
        }
        public void cargarDropDownList(DropDownList ddlObj, DataSet ds, string campoValue, string CampoTexto)
        {
            ddlObj.Items.Clear();
            ddlObj.Items.Add(new ListItem() { Value = "-1", Text = "Seleccione" });
            ddlObj.DataSource = ds.Tables[0];
            ddlObj.DataValueField = campoValue;
            ddlObj.DataTextField = CampoTexto;
            ddlObj.DataBind();
        }

        public DataSet GetCompany(int companyID)
        {
            try
            {
                DataSet dst = new DataSet();
                List<SqlParameter> ListadeParametros = new List<SqlParameter>();
                ListadeParametros.Add(new SqlParameter("@companyID", companyID));
                dst = this.RunDataSet("spGetCompanyInformation", ListadeParametros, constr);
                return dst;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);

            }
        }

        public DataSet UpdateCompany(int @companyID, int countryID, string companyName, string companyAddress, string companyContact,
            string companyEmail, string companyPhone, string companyFax, string companyAvatar, int companyCreatedBy)
        {
            try
            {
                DataSet dst = new DataSet();
                List<SqlParameter> ListadeParametros = new List<SqlParameter>();
                ListadeParametros.Add(new SqlParameter("@companyID", companyID));
                ListadeParametros.Add(new SqlParameter("@countryID", countryID));
                ListadeParametros.Add(new SqlParameter("@companyName", companyName));
                ListadeParametros.Add(new SqlParameter("@companyAddress", companyAddress));
                ListadeParametros.Add(new SqlParameter("@companyContact", companyContact));
                ListadeParametros.Add(new SqlParameter("@companyEmail", companyEmail));
                ListadeParametros.Add(new SqlParameter("@companyPhone", companyPhone));
                ListadeParametros.Add(new SqlParameter("@companyFax", companyFax));
                ListadeParametros.Add(new SqlParameter("@companyAvatar", companyAvatar));
                ListadeParametros.Add(new SqlParameter("@companyCreatedBy", companyCreatedBy));
                dst = this.RunDataSet("spCompanyUpdate", ListadeParametros, constr);
                return dst;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);

            }
        }
    }
}