using ContratoAdmin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratoAdmin.Services
{
    public interface IContratoAdminRepository
    {
        IEnumerable<Contrato> GetContratos();
        Contrato GetContratoById(int contratoId);

        void AddContrato(Contrato contrato);


        Proveedor GetProveedorById(int proveedorId);
        IEnumerable<Contrato> GetContratosDependencia(int dependenciaId);
        IEnumerable<Contrato> GetContratosProveedores(int proveedorId);


        IEnumerable<Proveedor> GetProveedores();


        bool ContratoExist(int contratoId);
        bool DependenciaExist(int dependenciaId);
        bool ProveedorExist(int proveedorId);


        void Save();
    }
}
