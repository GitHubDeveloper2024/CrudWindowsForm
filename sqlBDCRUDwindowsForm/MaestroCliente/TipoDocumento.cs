using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaestroCliente
{
    public class TipoDocumento
    {

        public int IDtipo_documento { get; set; }
        public string Descripcion { get; set; }

      
    }

    public class TipoDocumentoManager
    {
        // Aquí creas la lista de objetos TipoDocumento
        List<TipoDocumento> tiposDocumento = new List<TipoDocumento>
{
    new TipoDocumento { Descripcion = "dni", IDtipo_documento = 5 },
    new TipoDocumento { Descripcion = "pasaporte", IDtipo_documento = 4 },
    new TipoDocumento { Descripcion = "ruc", IDtipo_documento = 3 }
};

        public TipoDocumentoManager()
        {
            
        }


        


    }
    




}
