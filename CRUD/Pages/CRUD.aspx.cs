
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace CRUD.Pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly MySqlConnection con = new MySqlConnection(
            ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        string sID = "-1";
        string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            sID = Request.QueryString["id"] ?? "-1";
            sOpc = Request.QueryString["op"] ?? "";

            if (sOpc == "R" || sOpc == "D")
            {
                BloquearCampos();
            }

            if (!Page.IsPostBack)
            {
                switch (sOpc)
                {
                    case "C":
                        lbltitulo.Text = "Ingresar nuevo usuario";
                        BtnCreate.Visible = true;
                        break;

                    case "R":
                        lbltitulo.Text = "Consultar usuario";
                        break;

                    case "U":
                        lbltitulo.Text = "Modificar usuario";
                        BtnUpdate.Visible = true;
                        break;

                    case "D":
                        lbltitulo.Text = "Eliminar usuario";
                        BtnDelete.Visible = true;
                        break;
                }

                if (sOpc == "R" || sOpc == "U" || sOpc == "D")
                {
                    CargarDatos();
                }
            }
        }

        void BloquearCampos()
        {
            tbnombre.ReadOnly = true;
            tbedad.ReadOnly = true;
            tbemail.ReadOnly = true;
            tbdate.ReadOnly = true;
        }

        void CargarDatos()
        {
            if (!int.TryParse(sID, out int id))
            {
                Response.Redirect("~/Pages/Index.aspx");
                return;
            }

            try
            {
                con.Open();

                using (MySqlDataAdapter da = new MySqlDataAdapter("sp_read", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add(
                        "_idUsuario",
                        MySqlDbType.Int32).Value = id;

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        Response.Redirect("~/Pages/Index.aspx");
                        return;
                    }

                    DataRow row = dt.Rows[0];

                    tbnombre.Text = row["Nombre"].ToString();
                    tbedad.Text = row["Edad"].ToString();
                    tbemail.Text = row["Correo"].ToString();

                    DateTime fecha = Convert.ToDateTime(
                        row["FechaNacimiento"]);

                    tbdate.Text = fecha.ToString("yyyy-MM-dd");
                }
            }
            finally
            {
                con.Close();
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbnombre.Text) ||
                string.IsNullOrWhiteSpace(tbemail.Text) ||
                !int.TryParse(tbedad.Text, out int edad) ||
                !DateTime.TryParseExact(
                    tbdate.Text,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime fecha))
            {
                lbltitulo.Text = "Verifique los datos ingresados";
                return;
            }

            try
            {
                con.Open();

                using (MySqlCommand cmd = new MySqlCommand("sp_create", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(
                        "_Nombre",
                        MySqlDbType.VarChar).Value = tbnombre.Text;

                    cmd.Parameters.Add(
                        "_Edad",
                        MySqlDbType.Int32).Value = edad;

                    cmd.Parameters.Add(
                        "_Correo",
                        MySqlDbType.VarChar).Value = tbemail.Text;

                    cmd.Parameters.Add(
                        "_Fecha",
                        MySqlDbType.Date).Value = fecha;

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                con.Close();
            }

            Response.Redirect("~/Pages/Index.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(sID, out int id) ||
                string.IsNullOrWhiteSpace(tbnombre.Text) ||
                string.IsNullOrWhiteSpace(tbemail.Text) ||
                !int.TryParse(tbedad.Text, out int edad) ||
                !DateTime.TryParseExact(
                    tbdate.Text,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime fecha))
            {
                lbltitulo.Text = "Verifique los datos ingresados";
                return;
            }

            try
            {
                con.Open();

                using (MySqlCommand cmd = new MySqlCommand("sp_update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(
                        "_idUsuario",
                        MySqlDbType.Int32).Value = id;

                    cmd.Parameters.Add(
                        "_Nombre",
                        MySqlDbType.VarChar).Value = tbnombre.Text;

                    cmd.Parameters.Add(
                        "_Edad",
                        MySqlDbType.Int32).Value = edad;

                    cmd.Parameters.Add(
                        "_Correo",
                        MySqlDbType.VarChar).Value = tbemail.Text;

                    cmd.Parameters.Add(
                        "_Fecha",
                        MySqlDbType.Date).Value = fecha;

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                con.Close();
            }

            Response.Redirect("~/Pages/Index.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(sID, out int id))
            {
                Response.Redirect("~/Pages/Index.aspx");
                return;
            }

            try
            {
                con.Open();

                using (MySqlCommand cmd = new MySqlCommand("sp_delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(
                        "_idUsuario",
                        MySqlDbType.Int32).Value = id;

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                con.Close();
            }

            Response.Redirect("~/Pages/Index.aspx");
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Index.aspx");
        }
    }
}

