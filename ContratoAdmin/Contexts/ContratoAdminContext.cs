using ContratoAdmin.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratoAdmin.Contexts
{
    public class ContratoAdminContext : DbContext
    {
        public ContratoAdminContext(DbContextOptions<ContratoAdminContext> opt) : base(opt)
        {
        }

        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Dependencia> Dependencias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
    }
}
