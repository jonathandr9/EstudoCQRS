using Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.ProdutoRepository
{
    public class ProdutoRepository : IRepository<Produto>
    {
        private static Dictionary<int, Produto> produtos = new Dictionary<int, Produto>();
        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await Task.Run(() => produtos.Values.ToList());
        }
        public async Task<Produto> Get(int id)
        {
            return await Task.Run(() => produtos.GetValueOrDefault(id));
        }
        public async Task Add(Produto produto)
        {
            await Task.Run(() => produtos.Add(produto.Id, produto));
        }
        public async Task Edit(Produto produto)
        {
            await Task.Run(() =>
            {
                produtos.Remove(produto.Id);
                produtos.Add(produto.Id, produto);
            });
        }
        public async Task Delete(int id)
        {
            await Task.Run(() => produtos.Remove(id));
        }
    }
}
