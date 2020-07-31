using CadastroCliente.Dominio;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CadastroCliente.Infraestrutura
{
    public sealed class ClienteRepository
    {
        private readonly CadastroClienteDbContext _context;

        public ClienteRepository(CadastroClienteDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> ObterAsync(Guid id)
        {
            return await _context.Clientes.Where(EstaAtivo()).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Cliente>> ListarAsync(string filtro = null)
        {
            var query = _context.Clientes.Where(EstaAtivo());

            if (!string.IsNullOrEmpty(filtro))
                query = query.Where(t => t.Nome.ToUpper().Contains(filtro.ToUpper()) || t.Documento.Contains(filtro));

            return await query.ToListAsync();
        }

        public async Task DeletarAsync(Cliente cliente)
        {
            if (cliente is null)
                return;

            cliente.Inativar();
            await AtualizarAsync(cliente);
            await _context.SaveChangesAsync();
        }

        private static Expression<Func<Cliente, bool>> EstaAtivo()
        {
            return x => x.Status;
        }
    }
}