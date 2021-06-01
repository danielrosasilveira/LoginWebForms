using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWebForms
{
    public partial class Listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarUsuarios();
        }

        private void CarregarUsuarios()
        {
            string query = @"select id, nome, nivel from usuario";
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                MySqlDataAdapter da = new MySqlDataAdapter(query, Conexao.Connection);
                da.Fill(dt);

                rptUsuarios.DataSource = dt;
                rptUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                lblMsg.Text = $"Erro: {ex.Message}";
            }
            finally
            {

            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adicionar.aspx");
        }
    }
}