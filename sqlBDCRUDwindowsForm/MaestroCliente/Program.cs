using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaestroCliente
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Crea instancias de ambos formularios
            Form1 form1 = new Form1();
            //Form2 form2;

            // Muestra los formularios

            //Application.Run(new Form1());
            //Mostrar el Formulario Principal

            //Se llama al método Application.Run() para iniciar la aplicación y mostrar el formulario principal (form1)

            //Este método inicia el bucle de mensajes de la aplicación, lo que permite que la interfaz de usuario responda a eventos y
            //acciones del usuario.

            Application.Run(form1);

            // Después de cerrar Form1, crea y muestra el Form2
            //form2 = new Form2();
            //Application.Run(form2);


            //En resumen, este código establece la configuración inicial de la aplicación, muestra el formulario principal (Form1), y
            //configura la interfaz de usuario para que tenga un estilo visual moderno.

        }
    }
}
