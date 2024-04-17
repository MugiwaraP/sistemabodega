using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web.Security;
using System.Configuration;

namespace webSistemaInventarioBioEyza.Html
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            autenticacionID();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            guardarCajas();
           
        }
        



        protected void guardarCajas()
        {
            string userId = Session["UserID"] as string;

            if (string.IsNullOrEmpty(txtNombreCaja.Text) || string.IsNullOrEmpty(txtCantidadCajas.Text) || string.IsNullOrEmpty(txtCantidadUnidad.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Algún campo está vacío');", true);
            }
            else
            {
                int  unidadesCaja;
                double  stockCajas;
                if (!int.TryParse(txtCantidadUnidad.Text, out unidadesCaja) || !double.TryParse(txtCantidadCajas.Text, out stockCajas))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Campo de CAJAS O UNIDAD solo permite números enteros');", true);
                }
                else
                {
                    try
                    {
                        string connectionString = "Server=localhost;Database=SistemaInventario;Uid=root;Pwd=admin54321;";
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();

                            // Verificar el tipo de inventario seleccionado
                            string tipoInventarioSeleccionado = tipoInventario.SelectedValue;

                            if (tipoInventarioSeleccionado == "Bioeyza" || tipoInventarioSeleccionado == "Lote")
                            {
                                MySqlCommand command = new MySqlCommand("registrar_caja", connection);
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@p_nombreCaja", txtNombreCaja.Text);
                                command.Parameters.AddWithValue("@p_cantidadCajas", stockCajas);
                                command.Parameters.AddWithValue("@p_cantidadPorUnidad", unidadesCaja);
                                command.Parameters.AddWithValue("@p_id_usuario", userId); 
                                command.Parameters.AddWithValue("@p_tipoInventario", tipoInventarioSeleccionado);
                                command.ExecuteNonQuery();

                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "setTimeout(function(){ alert('Caja agregada correctamente'); window.location.href = 'registroCaja.aspx'; }, 30);", true);
                                txtNombreCaja.Text = "";
                                txtCantidadCajas.Text = "";
                                txtCantidadUnidad.Text = "";
                            }
                            else
                            {
                                // Manejar el caso donde no se ha seleccionado un tipo de inventario
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Seleccione un tipo de inventario antes de guardar.');", true);
                            }

                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error al guardar los datos');", true);
                    }
                }
            }
        }

        protected void btnMostrarInventario_Click(object sender, EventArgs e)
        {
            
        }
        protected void CerrarSesion()
        {
            // Elimina todas las variables de sesión
            Session.Clear();

            // Redirige al usuario a la página de inicio de sesión o a cualquier otra página que desees
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "setTimeout(function(){ alert('Ha cerrado sesión, vuelva a loguarse'); window.location.href = 'Login.aspx'; }, 30);", true);
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
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "setTimeout(function(){ alert('Ha cerrado sesión, vuelva a loguarse'); window.location.href = 'Login.aspx'; }, 30);", true);
                    Response.Redirect("login.aspx");
                   
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