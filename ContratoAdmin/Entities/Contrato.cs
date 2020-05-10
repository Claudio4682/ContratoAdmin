using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContratoAdmin.Entities
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [Required]
        public string Servicio { get; set; }

        //clave foranea a Dependencia
        [ForeignKey("DependenciaId")]
        public Dependencia Dependencia { get; set; }
        public int DependenciaId { get; set; }

        //clave foranea a Proveedor
        [ForeignKey("ProveedorId")]
        public Proveedor Proveedor { get; set; }
        public int ProveedorId { get; set; }
    }
}
