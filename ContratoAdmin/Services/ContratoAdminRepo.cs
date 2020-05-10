using ContratoAdmin.Contexts;
using ContratoAdmin.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratoAdmin.Services
{
    public class ContratoAdminRepo : IContratoAdminRepository
    {
        private readonly ContratoAdminContext _context;

        public ContratoAdminRepo(ContratoAdminContext context)
        {
            _context = context;
        }


        public IEnumerable<Contrato> GetContratos()
        {
            return _context.Contratos
                            .Include(c => c.Proveedor)
                            .Include(c => c.Dependencia)
                            .ToList();
        }

        public IEnumerable<Contrato> GetContratosProveedores(int proveedorId)
        {
            if (proveedorId <= 0)
                throw new ArgumentException(nameof(proveedorId));

            return _context.Contratos.Where(c => c.ProveedorId == proveedorId);
        }

 
        public Contrato GetContratoById(int contratoId)
        {
            if (contratoId <= 0)
                throw new ArgumentException(nameof(contratoId));

            return _context.Contratos.FirstOrDefault(c => c.Id == contratoId);
        }

        public Proveedor GetProveedorById(int proveedorId)
        {
            if (proveedorId <= 0)
                throw new ArgumentException(nameof(proveedorId));

            return _context.Proveedores.FirstOrDefault(c => c.Id == proveedorId);
        }


        public IEnumerable<Contrato> GetContratosDependencia(int dependenciaId)
        {
            if (dependenciaId <= 0)
                throw new ArgumentException(nameof(dependenciaId));

            return _context.Contratos.Where(c => c.DependenciaId == dependenciaId);
        }

       
        public IEnumerable<Proveedor> GetProveedores()
        {
            return _context.Proveedores.ToList();
        }


       public void AddContrato(Contrato contrato)
       {
            if (contrato == null)
                throw new ArgumentNullException(nameof(contrato));

            _context.Contratos.Add(contrato);
       }


        public bool ProveedorExist(int proveedorId)
        {
            if (proveedorId <= 0)
                throw new ArgumentException(nameof(proveedorId));

            return _context.Proveedores.Any(p => p.Id == proveedorId);
        }

        public bool ContratoExist(int contratoId)
        {
            if (contratoId <= 0)
                throw new ArgumentException(nameof(contratoId));

            return _context.Contratos.Any(p => p.Id == contratoId);
        }

        public bool DependenciaExist(int dependenciaId)
        {
            if (dependenciaId <= 0)
                throw new ArgumentException(nameof(dependenciaId));

            return _context.Dependencias.Any(p => p.Id == dependenciaId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
