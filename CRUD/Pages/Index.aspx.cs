
using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace CRUD.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        readonly MySqlConnection con = new MySqlConnection(
            ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        void CargarTabla()
        {
            try
            {
                con.Open();

                using (MySqlCommand cmd = new MySqlCommand("sp_load", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        gvusuarios.DataSource = dt;
                        gvusuarios.DataBind();
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        private int ObtenerId(object sender)
        {
            Button boton = (Button)sender;

            GridViewRow fila = (GridViewRow)boton.NamingContainer;

            return Convert.ToInt32(
                gvusuarios.DataKeys[fila.RowIndex].Value);
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CRUD.aspx?op=C");
        }

        protected void BtnRead_Click(object sender, EventArgs e)
        {
            int id = ObtenerId(sender);

            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=R");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int id = ObtenerId(sender);

            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = ObtenerId(sender);

            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=D");
        }
    }
}
