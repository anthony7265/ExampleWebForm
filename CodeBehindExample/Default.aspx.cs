using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CodeBehindExample
{
    public partial class _Default : Page
    {
        Metodos objMetodos = new Metodos();
        public string cuerpo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cargargrid();
        }

        protected void cargargrid()
        {
            gvCompany.DataSource = objMetodos.GetCompany(1);
            gvCompany.DataBind();
        }

        protected void gvCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            string selectedUser = gvCompany.SelectedValue.ToString();

            DataSet dsCompany = objMetodos.GetCompany(Convert.ToInt32(selectedUser));

            Session["CompanyID"] = dsCompany.Tables[0].Rows[0]["companyID"].ToString();
            txtCompanyName.Text = dsCompany.Tables[0].Rows[0]["companyName"].ToString();
            txtContact.Text = dsCompany.Tables[0].Rows[0]["companyContact"].ToString();
            txtemail.Text = dsCompany.Tables[0].Rows[0]["companyEmail"].ToString();
            txtphone.Text = dsCompany.Tables[0].Rows[0]["companyPhone"].ToString();
            txtFax.Text = dsCompany.Tables[0].Rows[0]["companyFax"].ToString();
            txtAddress.Text = dsCompany.Tables[0].Rows[0]["companyAddress"].ToString();

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "$('#ModalNewCompany').modal({keyboard: false})", true);
        }

        protected void gvCompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvCompany, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click for select Company";
            }
        }

        protected void gvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (e.NewPageIndex != -1)
                {
                    gvCompany.PageIndex = e.NewPageIndex;
                    gvCompany.DataSource = objMetodos.GetCompany(1);
                    gvCompany.DataBind();
                    gvCompany.DataKeyNames = new string[] { "ID" };
                }
            }
            catch
            {
            }
        }

        protected void btnNewCompany_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "$('#ModalNewCompany').modal({keyboard: true})", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //ddlPerfil.SelectedValue == "-1"
            if (txtCompanyName.Text == "" || txtContact.Text == "" || txtemail.Text == "" || txtphone.Text == "" || txtFax.Text == "" || txtAddress.Text == "")
            {
                return;
            }
            
            string idCompany = Session["CompanyID"].ToString();
            string CompanyName = txtCompanyName.Text;
            string Contact = txtContact.Text;
            string email = txtemail.Text;
            string phone = txtphone.Text;
            string fax = txtFax.Text;
            string address = txtAddress.Text;

            DataSet dsUpdateUsuario = new DataSet();
            dsUpdateUsuario = objMetodos.UpdateCompany(Convert.ToInt32(idCompany), 1, CompanyName, address, Contact, email, phone, fax, null, 1);
            int respuesta = Convert.ToInt32(dsUpdateUsuario.Tables[0].Rows[0][0]);

            if (respuesta > 0)
            {
                cuerpo = "Registro actualizado Correctamente.";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Notificacion", "$('#ModalNewUser').modal('hide');notificacionURLImagen('" + cuerpo + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('Ocurrio un Problema!!');", true);
            }
            
            cargargrid();
        }
        
    }
}