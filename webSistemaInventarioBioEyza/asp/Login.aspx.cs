using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSistemaInventarioBioEyza.Html
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string contraseña = txtContraseña.Text;
            lblMensaje.Text = "Usuario o contraseña invalida";

            string connectionString = "Server=localhost;Database=SistemaInventario;Uid=root;Pwd=admin54321;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand checkUserCommand = new MySqlCommand("SELECT id FROM usuarios WHERE nombre = @p_usuario AND contrasena=@p_pass_login", connection))
                {
                    checkUserCommand.Parameters.AddWithValue("@p_usuario", nombre);
                    checkUserCommand.Parameters.AddWithValue("@p_pass_login", contraseña);

                    object userId = checkUserCommand.ExecuteScalar();

                    if (userId == null)
                    {
                        
                        return;
                    }

                    // Almacenar el ID del usuario en una variable de sesión
                    Session["UserID"] = userId.ToString();
                
                }

                using (MySqlCommand command = new MySqlCommand("Login", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("p_usuario", nombre);
                    command.Parameters.AddWithValue("p_pass_login", contraseña);


                    command.ExecuteNonQuery();
                }


                Response.Redirect("index.aspx");
            }
        }
    }
}