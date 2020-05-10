using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratoAdmin.Dtos
{
    public class ContratoCreateDto
    {
        public DateTime FechaInicio { get; set; }


        public DateTime FechaFin { get; set; }

        public string Servicio { get; set; }

  
        public int DependenciaId { get; set; }

        public int ProveedorId { get; set; }
    }
}
