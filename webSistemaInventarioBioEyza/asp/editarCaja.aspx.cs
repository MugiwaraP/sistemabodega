using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webSistemaInventarioBioEyza.Clases;

namespace webSistemaInventarioBioEyza.asp
{
    public partial class editarCaja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticacionID();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string userId = Session["UserID"] as string;

            if (string.IsNullOrEmpty(txtNombreCaja.Text) || string.IsNullOrEmpty(txtCantidadCajas.Text) || string.IsNullOrEmpty(txtCantidadUnidad.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Algún campo está vacío');", true);
            }
            else
            {
                int unidadesCaja;
                double stockCajas;
                if (!int.TryParse(txtCantidadUnidad.Text, out unidadesCaja) || !double.TryParse(txtCantidadCajas.Text, out stockCajas))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Campo de CAJAS O UNIDAD solo permite números enteros');", true);
                }
                else
                {
                    try
                    {



                        string connectionStringHosting = ConnectionHelper.GetHostingConnectionString();
                        using (MySqlConnection connection = new MySqlConnection(connectionStringHosting))
                    {
                        // Abrir la conexión
                        connection.Open();

                            string nombreCaja = txtNombreCaja.Text;
                            string tipoInventarioSeleccionado = tipoInventario.SelectedValue;


                            // Crear un comando para ejecutar el procedimiento almacenado
                            using (MySqlCommand command = new MySqlCommand("editar_caja", connection))
                        {
                            // Establecer el tipo de comando como procedimiento almacenado
                            command.CommandType = CommandType.StoredProcedure;

                            // Pasar los parámetros necesarios al procedimiento almacenado
                            command.Parameters.AddWithValue("@p_nombreCaja", nombreCaja);
                            command.Parameters.AddWithValue("@p_tipoInventario", tipoInventarioSeleccionado);
                            command.Parameters.AddWithValue("@p_cantidadCajas", stockCajas);
                            command.Parameters.AddWithValue("@p_cantidadPorUnidad", unidadesCaja);
                            command.Parameters.AddWithValue("@p_id_usuario", userId);

                            // Ejecutar el comando
                            command.ExecuteNonQuery();
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "setTimeout(function(){ alert('Caja actualizada correctamente'); window.location.href = 'editarCaja.aspx'; }, 30);", true);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error al actualizar los datos');", true);
                    }
                }
            }
        }

        protected void CerrarSesion()
        {
            // Elimina todas las variables de sesión
            Session.Clear();

            // Redirige al usuario a la página de inicio de sesión o a cualquier otra página que desees
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Usted ha cerrado sesión, ingrese nuevamente');", true);
            Response.Redirect("login.aspx");
        }

        protected void btnCerrarSesión_Click(object sender, EventArgs e)
        {
            // Llama al método para cerrar sesión
            CerrarSesion();
        }

        public void autenticacionID()
        {
            if (!IsPostBack)
            {
                // Verifica si el usuario está autenticado
                if (Session["UserID"] == null)
                {
                    // Si el usuario no está autenticado, redirige a la página de inicio de sesión

                    Response.Redirect("login.aspx");
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "setTimeout(function(){ alert('Ha cerrado sesión, vuelva a loguarse'); window.location.href = 'Login.aspx'; }, 30);", true);
                }
                else
                {
                    // Si el usuario está autenticado, muestra el botón de cerrar sesión
                    btnCerrarSesion.Visible = true;
                }
            }

        }
    }
}