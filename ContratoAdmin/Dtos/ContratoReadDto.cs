using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratoAdmin.Dtos
{
    public class ContratoReadDto
    {
        public int Id { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string Servicio { get; set; }

    }
}
