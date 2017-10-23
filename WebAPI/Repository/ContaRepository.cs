using System.Collections.Generic;
using System.Linq;
using WebAPI.Entities;

namespace WebAPI.Repository
{
    public class ContaRepository : BaseRepository<Conta>
    {
        public List<Conta> ToList(string cpf)
        {
            var contas = _context.Set<Conta>().Join(_context.Cliente,
                     conta => conta.ClientId,
                     cliente => cliente.Id,
                     (conta, cliente) => new { Conta = conta, Cliente = cliente })
                 .Where(contaECliente => contaECliente.Cliente.Cpf.Equals(cpf))
                 .Select(x => x.Conta).ToList();

            return contas;
        }
    }
}
