using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AgenciaAutos.Negocio;
using System.Windows.Forms;

namespace AgenciaAutos.Presentacion
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadGrid();
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            NegocioAutos NegAutos = new NegocioAutos();
            
            if(NegAutos.AltaAuto(txtMarca.Text, decimal.Parse(txtPrecio.Text)) > 0)
            {
                LoadGrid();
                MessageBox.Show("Auto Insertado Correctamente");
            }
        }

        private void LoadGrid()
        {
            NegocioAutos NegAutos = new NegocioAutos();
            grvAutos.DataSource = NegAutos.ObtenerAutos();
            grvAutos.DataBind();
        }

        protected void grvAutos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)grvAutos.DataKeys[e.RowIndex].Values[0];

            if(id > 0)
            {
                NegocioAutos negAutos = new NegocioAutos();
                negAutos.EliminarAuto(id);

                LoadGrid();
            }
        }

        protected void grvAutos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvAutos.EditIndex = -1;
            LoadGrid();
        }

        protected void grvAutos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvAutos.EditIndex = e.NewEditIndex;
            LoadGrid();
        }

        protected void grvAutos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (int)grvAutos.DataKeys[e.RowIndex].Values[0];
            GridViewRow Fila = grvAutos.Rows[e.RowIndex];

            System.Web.UI.WebControls.TextBox EditMarca = (System.Web.UI.WebControls.TextBox)Fila.FindControl("txtEditMarca");
            string marca = EditMarca.Text;

            System.Web.UI.WebControls.TextBox EditPrecio = (System.Web.UI.WebControls.TextBox)Fila.FindControl("txtEditPrecio");
            decimal precio = decimal.Parse(EditPrecio.Text);

            (new NegocioAutos()).ActualizarAuto(id, marca, precio);

            grvAutos.EditIndex = -1;
            LoadGrid();
        }

        protected void grvAutos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAutos.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {

        }
    }
}