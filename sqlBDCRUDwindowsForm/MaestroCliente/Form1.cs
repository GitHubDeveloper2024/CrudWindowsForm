
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using static System.Resources.ResXFileRef;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System.IO;
using SpreadsheetLight;

namespace MaestroCliente
{
    public partial class Form1 : Form
    {

        // Define el control comboBoxTipoDocumento a nivel de clase
        private ComboBox comboBoxTipoDocumento = new ComboBox();

        private string connectionString = @"Data Source=DESKTOP-GLVK46U;Initial Catalog=WinFormsContacts;Integrated Security=True;";



        private SqlConnection connection;





        public Form1()
        {


            InitializeComponent();





            connection = new SqlConnection(connectionString);


            dataGridView1.ReadOnly = false;









            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;


            CargarComboBoxTipoDocumento();




        }





        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {












            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value)
            {




                int clientId;


                if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["IdColumn"].Value.ToString(), out clientId))
                {




                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {




                            connection.Open();


                            string storedProcedure = "Pa_SeleccionarClientePorID";






                            SqlCommand command = new SqlCommand(storedProcedure, connection);
                            command.CommandType = CommandType.StoredProcedure;


                            command.Parameters.AddWithValue("@ID", clientId);







                            SqlDataReader reader = command.ExecuteReader();







                            if (reader.Read())
                            {



                                Form2 form2 = new Form2(clientId, parentForm: this);





                                form2.txtCodigo.Text = reader["codigo"].ToString();






                                form2.txtRazonSocial.Text = reader["razon_social"].ToString();




                                //form2.comboBoxTipoDocumento.Text = reader["IDtipo_documento"].ToString().Trim();
                                form2.comboBoxTipoDocumento.SelectedValue = reader["IDtipo_documento"].ToString().Trim();

                                form2.txtNumeroDocumento.Text = reader["numero_documento"].ToString().Trim();






                                form2.DatosActualizados += Form2_DatosActualizados;




                                form2.ShowDialog();





                            }
                            else
                            {
                                MessageBox.Show("No se encontró el cliente en la base de datos.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los detalles del cliente: " + ex.Message);
                    }
                }

                else
                {
                    MessageBox.Show("No se pudo obtener el ID del cliente seleccionado.");
                }












            }



        }


        private void Form2_DatosActualizados(object sender, EventArgs e)
        {




            // Refrescar la lista de clientes mostrada en el DataGridView

            MostrarClientes();





        }











        private void Form1_Load(object sender, EventArgs e)
        {








            MostrarClientes();







        }














        internal void MostrarClientes()
        {


            try
            {
                connection.Open();

                // Cargar el ComboBox de tipos de documento
                CargarComboBoxTipoDocumento();

                SqlCommand cmd = new SqlCommand("Pa_SeleccionarClientes", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }





        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarRegistro_Click(object sender, EventArgs e)
        {






            // Crear una instancia del Form2 y mostrarlo


            int clientId = 0;
            Form2 form2 = new Form2(clientId, parentForm: this);
            form2.LimpiarComboBox(); // Llama al método para limpiar el ComboBox
            form2.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {




            ExportarDataGridViewToExcel(dataGridView1);



        }







        private void ExportarDataGridViewToExcel(DataGridView dataGridView)
        {
            //Inicialización de un nuevo documento de Excel:

            //Aquí se crea un nuevo documento de Excel utilizando la clase SLDocument proporcionada por la biblioteca SpreadsheetLight.

            SLDocument sl = new SLDocument();


            //Creación de un estilo para las celdas:

            //Se crea un estilo para las celdas del documento. En este caso, se establece el tamaño de la fuente en 12 y se hace que el
            //texto sea negrita.

            SLStyle style = new SLStyle();
            style.Font.FontSize = 12;
            style.Font.Bold = true;





            int iC = 1;

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                sl.SetCellValue(1, iC, column.HeaderText.ToString());
                sl.SetCellStyle(1, iC, style);
                iC++;

            }

            //En resumen, este bucle recorre cada columna en el DataGridView, obtiene el encabezado de la columna y lo escribe en la
            //primera fila del documento Excel, aplicando un estilo específico. Luego, avanza a la siguiente columna para repetir el proceso
            //hasta que todas las columnas hayan sido procesadas.









            //Recorriendo las filas del DataGridView

            int iR = 2;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // sl.SetCellValue(iR, 1, row.Cells[0].Value.ToString());




                object cellValue = row.Cells[0].Value;
                if (cellValue != null)
                {
                    sl.SetCellValue(iR, 1, cellValue.ToString());
                }
                else
                {
                    sl.SetCellValue(iR, 1, string.Empty); // O cualquier otro valor predeterminado que desees en caso de que el valor de la celda sea null
                }



                // sl.SetCellValue(iR, 2, row.Cells[1].Value.ToString());



                cellValue = row.Cells[1].Value;

                if (cellValue != null)
                {
                    sl.SetCellValue(iR, 2, cellValue.ToString());
                }
                else
                {
                    sl.SetCellValue(iR, 2, string.Empty); // O cualquier otro valor predeterminado que desees en caso de que el valor de la celda sea null
                }



                cellValue = row.Cells[2].Value;


                if (cellValue != null)
                {
                    sl.SetCellValue(iR, 3, cellValue.ToString());
                }
                else
                {
                    sl.SetCellValue(iR, 3, string.Empty); // O cualquier otro valor predeterminado que desees en caso de que el valor de la celda sea null
                }





                cellValue = row.Cells[3].Value;


                if (cellValue != null)
                {
                    sl.SetCellValue(iR, 4, cellValue.ToString());
                }
                else
                {
                    sl.SetCellValue(iR, 4, string.Empty); // O cualquier otro valor predeterminado que desees en caso de que el valor de la celda sea null
                }



                cellValue = row.Cells[4].Value;


                if (cellValue != null)
                {
                    sl.SetCellValue(iR, 5, cellValue.ToString());
                }
                else
                {
                    sl.SetCellValue(iR, 5, string.Empty); // O cualquier otro valor predeterminado que desees en caso de que el valor de la celda sea null
                }






                iR++;


            }

            sl.SaveAs(@"D:\VisualStudio\MaestroCliente\archivoExcel.xlsx");

        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Verifica si se ha hecho clic en la columna de Tipo de documento
        //    if (e.ColumnIndex == dataGridView1.Columns["Tipo de Documento"].Index && e.RowIndex >= 0)
        //    {
        //        // Crea un objeto DataGridViewComboBoxCell para acceder al ComboBox
        //        DataGridViewComboBoxCell comboBoxCell = dataGridView1.Rows[e.RowIndex].Cells["Tipo de Documento"] as DataGridViewComboBoxCell;

        //        // Verifica si la celda es editable
        //        if (comboBoxCell != null && comboBoxCell.ReadOnly == false)
        //        {
        //            // Abre el ComboBox en la celda seleccionada
        //            dataGridView1.BeginEdit(true);
        //        }
        //    }
        //}

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewComboBoxCell comboBoxCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                if (comboBoxCell != null)
                {
                    // Obtener el valor seleccionado del ComboBox dentro de la celda
                    string selectedValue = comboBoxCell.Value?.ToString();

                    // Una vez que tengas el valor seleccionado, puedes obtener el ID del cliente desde otra celda
                    int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IdColumn"].Value);

                    // Llama a la función para guardar el tipo de documento en la base de datos
                    GuardarTipoDocumentoEnBaseDeDatos(id, selectedValue);
                }
            }
        }


        private void GuardarTipoDocumentoEnBaseDeDatos(int id, string tipoDocumento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Define el nombre del procedimiento almacenado para guardar el tipo de documento
                    string storedProcedureName = "GuardarTipoDocumento";

                    // Crea el comando para ejecutar el procedimiento almacenado
                    SqlCommand cmd = new SqlCommand(storedProcedureName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros al comando
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);

                    // Ejecuta el comando
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el tipo de documento en la base de datos: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
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
                cmbTipoDocumentoColumn.DataSource = dt;
                // Especificar la columna que se mostrará en el ComboBox
                cmbTipoDocumentoColumn.DisplayMember = "descrip";
                // Especificar la columna que se utilizará como valor seleccionado
                cmbTipoDocumentoColumn.ValueMember = "idTipDoc";
                //cmbTipoDocumentoColumn.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el ComboBox: " + ex.Message);
            }
        }




        // Método para guardar los datos seleccionados en el DataGridView
        private void GuardarDatos(int id)
        {
            // Utilizar el parámetro id en lugar de la variable id
            if (id > 0)
            {
                // Obtener la celda específica en la fila actual que contiene el ComboBox
                DataGridViewComboBoxCell comboBoxCell = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["cmbTipoDocumentoColumn"] as DataGridViewComboBoxCell;

                if (comboBoxCell != null)
                {
                    // Obtener el valor seleccionado del ComboBox en la celda
                    string tipoDocumentoSeleccionado = comboBoxCell.Value?.ToString();
                    // Luego puedes utilizar esta información para guardarla en tu base de datos
                    GuardarTipoDocumentoEnBaseDeDatos(id, tipoDocumentoSeleccionado);
                }
            }
        }





        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Error al guardar los datos: " + e.Exception.Message);
            }
        }
        // Variable de clase para almacenar el ID del registro seleccionado
        private int selectedRecordId;

        // Evento que se dispara cuando se selecciona una celda en el DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // Verificar si la celda tiene un valor nulo antes de intentar convertirlo
                if (row.Cells["IdColumn"].Value != DBNull.Value)
                {
                    // Obtener el ID del registro seleccionado y almacenarlo en la variable de clase
                    selectedRecordId = Convert.ToInt32(row.Cells["IdColumn"].Value);
                }
                else
                {
                    // Manejar el caso en que la celda tiene un valor DBNull
                    // Por ejemplo, podrías asignar un valor predeterminado a selectedRecordId o mostrar un mensaje de error
                    MessageBox.Show("El valor de la celda es nulo.");
                }
            }
        }





        // Evento que se dispara cuando se hace clic en el botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID del registro seleccionado
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdColumn"].Value);
                // Llamar al método GuardarDatos() pasando el ID como parámetro
                GuardarDatos(id);
            }
        }









    }





}


