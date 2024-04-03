using DocumentFormat.OpenXml.Office.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaestroCliente
{
    public partial class Form2 : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=WinFormsContacts;Integrated Security=True;";
        private int clientId;
        private Form1 parentForm;

        public event EventHandler DatosActualizados;

        public Form2(int clientId, Form1 parentForm = null)
        {
            InitializeComponent();
            this.clientId = clientId;
            this.parentForm = parentForm;
            CargarCliente();
            CargarComboBoxTipoDocumento(); // Cargar los tipos de documento en el ComboBox
        }


        private void CargarComboBoxTipoDocumento()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string obtenerTiposDocumentosProcedure = "ObtenerTiposDocumento";
                    using (SqlCommand cmd = new SqlCommand(obtenerTiposDocumentosProcedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }

                // Asignar el DataTable al DataSource del ComboBox
                comboBoxTipoDocumento.DataSource = dt;
                // Especificar la columna que se mostrará en el ComboBox
                comboBoxTipoDocumento.DisplayMember = "descrip";
                // Especificar la columna que se utilizará como valor seleccionado
                comboBoxTipoDocumento.ValueMember = "idTipDoc";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el ComboBox: " + ex.Message);
            }
        }












        private void CargarCliente()
        {
            if (clientId != 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string storedProcedure = "Pa_SeleccionarClientes";
                        SqlCommand command = new SqlCommand(storedProcedure, connection);
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            txtCodigo.Text = reader["codigo"].ToString();
                            txtRazonSocial.Text = reader["razon_social"].ToString();
                            comboBoxTipoDocumento.Text = reader["IDtipo_documento"].ToString();
                            txtNumeroDocumento.Text = reader["numero_documento"].ToString();

                            // Obtener el valor del tipo de documento del lector
                            string tipoDocumento = reader["IDtipo_documento"].ToString();

                            // Verificar si el valor del tipo de documento está presente en el ComboBox
                            if (comboBoxTipoDocumento.Items.Contains(tipoDocumento))
                            {
                                // Si está presente, seleccionar ese valor en el ComboBox
                                comboBoxTipoDocumento.SelectedItem = tipoDocumento;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el cliente en la base de datos.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el cliente: " + ex.Message);
                }
            }
        }











        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (clientId == 0)
            {
                InsertarCliente();
            }
            else
            {
                ActualizarCliente();
            }

            this.Close();
        }

        private void LimpiarCampos()
        {
            txtRazonSocial.Text = "";
            txtCodigo.Text = "";
            comboBoxTipoDocumento.Text = "";
            txtNumeroDocumento.Text = "";
        }

        private void InsertarCliente()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string storedProcedure = "Pa_InsertarCliente";
                    SqlCommand command = new SqlCommand(storedProcedure, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Obtener el ID del tipo de documento basado en el nombre seleccionado en el ComboBox
                    SqlCommand getIdTipoDocumentoCmd = new SqlCommand("Pa_ObtenerIDTipoDocumentoPorNombre", connection);
                    getIdTipoDocumentoCmd.CommandType = CommandType.StoredProcedure;
                    getIdTipoDocumentoCmd.Parameters.AddWithValue("@NombreTipoDocumento", comboBoxTipoDocumento.Text);
                    int idTipoDocumento = Convert.ToInt32(getIdTipoDocumentoCmd.ExecuteScalar());

                    command.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                    command.Parameters.AddWithValue("@razon_social", txtRazonSocial.Text);
                    command.Parameters.AddWithValue("@IDtipoDocumento", idTipoDocumento);
                    command.Parameters.AddWithValue("@numero_documento", Convert.ToInt32(txtNumeroDocumento.Text));

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente insertado exitosamente.");
                        parentForm.MostrarClientes();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el cliente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el cliente: " + ex.Message);
            }
        }

        private void ActualizarCliente()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string storedProcedure = "Pa_ActualizarCliente";
                    SqlCommand command = new SqlCommand(storedProcedure, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@nuevo_id", clientId);
                    command.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                    command.Parameters.AddWithValue("@razon_social", txtRazonSocial.Text);

                    // Obtener el ID del tipo de documento basado en la descripción seleccionada en el ComboBox
                    SqlCommand getIdTipoDocumentoCmd = new SqlCommand("Pa_ObtenerIDTipoDocumentoPorDescripcion", connection);
                    getIdTipoDocumentoCmd.CommandType = CommandType.StoredProcedure;
                    getIdTipoDocumentoCmd.Parameters.AddWithValue("@DescripcionTipoDocumento", comboBoxTipoDocumento.Text);
                    int idTipoDocumento = Convert.ToInt32(getIdTipoDocumentoCmd.ExecuteScalar());

                    command.Parameters.AddWithValue("@IDtipo_documento", idTipoDocumento);

                    // Validar y convertir el valor de txtNumeroDocumento.Text a un entero
                    if (int.TryParse(txtNumeroDocumento.Text, out int numeroDocumento))
                    {
                        command.Parameters.AddWithValue("@numero_documento", numeroDocumento);
                    }
                    else
                    {
                        MessageBox.Show("El número de documento no es válido.");
                        return; // Salir del método si la conversión falla
                    }

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente actualizado exitosamente.");
                        parentForm.MostrarClientes();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el cliente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message);
            }






        }

        public void LimpiarComboBox()
        {
            comboBoxTipoDocumento.SelectedIndex = -1; // Establece el índice seleccionado en -1 para deseleccionar cualquier elemento
        }






        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            // Aquí puedes agregar el código que deseas ejecutar cuando el texto en txtCodigo cambie
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            // Aquí puedes agregar el código que deseas ejecutar cuando el texto en txtRazonSocial cambie
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void btnEliminarRegistro_Click(object sender, EventArgs e)
        {
            // Aquí colocarías la lógica para eliminar un registro
            // Verificar si se ha seleccionado un cliente
            if (clientId != 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string storedProcedure = "Pa_EliminarCliente";
                        SqlCommand command = new SqlCommand(storedProcedure, connection);
                        command.CommandType = CommandType.StoredProcedure;

                        // Pasar el ID del cliente como parámetro al procedimiento almacenado
                        command.Parameters.AddWithValue("@ID", clientId);

                        // Ejecutar el comando
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente eliminado exitosamente.");
                            // Actualizar la lista de clientes en el formulario padre
                            parentForm.MostrarClientes();
                            // Cerrar el formulario actual
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el cliente.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún cliente.");
            }
        }








    }
}