using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Conta")]
    public class ContaController : Controller
    {
        private readonly ContaRepository _contaRepository;
        private readonly BaseRepository<Cliente> _baseRepository;
        public ContaController()
        {
            _contaRepository = new ContaRepository();
            _baseRepository = new BaseRepository<Cliente>();
        }

        [HttpGet("{cpfCliente}")]
        public List<Conta> Get(string cpfCliente) => _contaRepository.ToList(cpfCliente);

        // POST api/values
        [HttpPost("{cpfCliente}")]
        public void Post(string cpfCliente, [FromBody]Conta conta)
        {
            var idCliente = _baseRepository.FirstOrDefault(x => x.Cpf.Equals(cpfCliente)).Id;
            var contaObj = new Conta(Guid.NewGuid(), idCliente, conta);
            _contaRepository.Add(contaObj);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Conta conta)
        {
            conta = new Conta(id, conta);
            _contaRepository.Update(conta);
        }
    }
}
