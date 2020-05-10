using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContratoAdmin.Dtos;
using ContratoAdmin.Entities;
using ContratoAdmin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContratoAdmin.Controllers
{
    [Route("api/Contratos")]
    [ApiController]
    public class ContratosController : ControllerBase
    {
        private readonly IContratoAdminRepository _repo;
        private readonly IMapper _mapper;

        public ContratosController(IContratoAdminRepository repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        // GET: api/Contratos
        [HttpGet()]
        public ActionResult <IEnumerable<ContratoReadDto>> GetContratos()
        {
            var contratos = _repo.GetContratos();

            if (contratos == null)
            {
                NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ContratoReadDto>>(contratos));
        }

        // GET: api/contratos/5
        [HttpGet("{contratoId:int}", Name = "GetContratosById")]
        public ActionResult<ContratoReadDto> GetContratosById(int contratoId)
        {
            var prov = _repo.GetContratoById(contratoId);

            if (prov == null)
                return NotFound();

            return Ok(_mapper.Map<ContratoReadDto>(prov));
        }

        // GET: api/contratos/proveedores/5
        [HttpGet("proveedores/{proveedorId:int}")]
        public ActionResult <IEnumerable<Contrato>> GetContratosProveedores(int proveedorId)
        {
            var contratos = _repo.GetContratosProveedores(proveedorId);

            if (contratos == null)
            {
                NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ContratoReadDto>>(contratos));
        }


        // POST: api/contratos
        [HttpPost]
        public ActionResult<ContratoReadDto> CreateContrato(ContratoCreateDto contratoNuevo)
        {
            var nuevoContrato = _mapper.Map<Contrato>(contratoNuevo);
            _repo.AddContrato(nuevoContrato);
            _repo.Save();

            var contratoToReturn = _mapper.Map<ContratoReadDto>(nuevoContrato);

            return CreatedAtRoute("GetContratosById", new { contratoId = contratoToReturn.Id }, contratoToReturn);

        }

        // PUT: api/Contratos/5
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
