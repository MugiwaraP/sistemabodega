using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webSistemaInventarioBioEyza.Clases;
using System.Configuration;

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
            lblMensaje.Text = "Usuario o contraseña inválida";

            string connectionStringHosting = ConnectionHelper.GetHostingConnectionString();

            using (MySqlConnection connection = new MySqlConnection(connectionStringHosting))
            {
                connection.Open();

                using (MySqlCommand checkUserCommand = new MySqlCommand("SELECT id FROM usuarios WHERE nombre = @p_usuario AND contrasena=@p_pass_login", connection))
                {
                    checkUserCommand.Parameters.AddWithValue("@p_usuario", nombre);
                    checkUserCommand.Parameters.AddWithValue("@p_pass_login", contraseña);

                    object userId = checkUserCommand.ExecuteScalar();

                    if (userId == null)
                    {
                        // Usuario no encontrado, manejar el caso según sea necesario
                        return;
                    }

                    // Almacenar el ID del usuario en una variable de sesión
                    Session["UserID"] = userId.ToString();
                }

                // Llamar al procedimiento almacenado "Login"
                using (MySqlCommand command = new MySqlCommand("Login", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("p_usuario", nombre);
                    command.Parameters.AddWithValue("p_pass_login", contraseña);

                    command.ExecuteNonQuery();
                }

                // Redireccionar al usuario a la página de inicio después de iniciar sesión
                Response.Redirect("index.aspx");
            }
        }

    }
}
