using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repository;
using WebAPI.Entities;


namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Cliente")]
    public class ClienteController : Controller
    {
        private readonly BaseRepository<Cliente> _clienteRepository;
        public ClienteController()
        {
            _clienteRepository = new BaseRepository<Cliente>();
        }
        [HttpGet]
        public IEnumerable<Cliente> Get() => _clienteRepository.ToList();

        [HttpGet("{cpf}")]
        public ObjectResult Get(string cpf)
        {
            var cliente = _clienteRepository.FirstOrDefault(x => x.Cpf.Equals(cpf));
            cliente.Contas = null;
            return Ok(cliente);
        }

        [HttpPost]
        public ObjectResult Post(string nome, string cpf, string endereco)
        {
            var cliente = new Cliente(nome, cpf, endereco);
            cliente = _clienteRepository.Add(cliente);
            return Ok(cliente);
        }
    }
}
