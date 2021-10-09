using Microsoft.EntityFrameworkCore;
using NSE.Catalogo.API.Models;
using NSE.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoDbContext _context;

        public ProdutoRepository(CatalogoDbContext context)
        {
            _context = context;
        }

        private IUnitOfWork UnitOfWork => _context;
        
        public async Task<IEnumerable<Produto>> ObterTodos(int pageSize, int pageIndex, string query = null)
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
