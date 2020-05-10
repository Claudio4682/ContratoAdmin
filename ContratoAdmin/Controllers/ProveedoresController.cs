using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContratoAdmin.Entities;
using ContratoAdmin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContratoAdmin.Controllers
{
    [Route("api/Proveedores")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly IContratoAdminRepository _repo;
        public ProveedoresController(IContratoAdminRepository repo)
        {
            _repo = repo;
        }


        // GET: api/Proveedores
        [HttpGet]
        public ActionResult<IEnumerable<Proveedor>> GetProveedores()
        {
            var proveedores = _repo.GetProveedores();
            if (proveedores == null)
                NotFound();
            return Ok(proveedores);
        }

        // GET: api/Proveedores/5
        [HttpGet("{proveedorId:int}")]
        public ActionResult<Proveedor> GetProveedorById(int proveedorId)
        {
            var proveedor = _repo.GetProveedorById(proveedorId);
            if (proveedor == null)
                NotFound();
            return Ok(proveedor);
        }

        /*/ GET: api/Contratos/Proveedores
        [HttpGet("contratos/{id}")]
        public IEnumerable<Contrato> GetContratosProveedores(int proveedorId)
        {
            return _repo.GetContratosProveedores(proveedorId);
        }*/

        // POST: api/Proveedores
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Proveedores/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
