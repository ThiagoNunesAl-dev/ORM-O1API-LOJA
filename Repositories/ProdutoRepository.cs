using ORM_API_Loja.Contexts;
using ORM_API_Loja.Domains;
using ORM_API_Loja.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORM_API_Loja.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        //É criada uma nova propriedade do tipo LojaContext, para que as mudanças possam ser atribuídas ao banco.
        private readonly LojaContext _ctx;

        public ProdutoRepository()
        {
            _ctx = new LojaContext();
        }

        #region Leitura
        public List<Produto> Listar()
        {
            throw new NotImplementedException();
        }

        public Produto BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Gravação
        public void Adicionar(Produto p)
        {
            _ctx.Produtos.Add(p);
            _ctx.SaveChanges();
        }

        public void Editar(Produto p)
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
