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
        /// <summary>
        /// Lista todos os elementos da tabela produto.
        /// </summary>
        /// <returns>Lista de elementos da tabela produto.</returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um produto da tabela de acordo com seu Id.
        /// </summary>
        /// <param name="id">Id do produto que se quer encontrar.</param>
        /// <returns>Produto cujo Id é correspondente ao fornecido pelo usuário.</returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Produtos.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um produto de acordo com um termo/nome.
        /// </summary>
        /// <param name="nome">Termo/nome fornecido.</param>
        /// <returns>Lista de produtos que contém o termo fornecido como argumento.</returns>
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Where(p => p.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Gravação
        /// <summary>
        /// Cadastra um produto no banco de dados.
        /// </summary>
        /// <param name="p">Produto adicionado.</param>
        public void Adicionar(Produto p)
        {
            try
            {
                _ctx.Produtos.Add(p);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        /// <summary>
        /// Edita os atributos/colunas de um produto.
        /// </summary>
        /// <param name="p">Produto a ser editado.</param>
        public void Editar(Produto p)
        {
            try
            {
                Produto pTemp = BuscarPorId(p.Id);
                if (pTemp == null)
                {
                    throw new Exception("Produto não encontrado.");
                }
                pTemp.Nome = p.Nome;
                pTemp.Preco = p.Preco;

                _ctx.Produtos.Update(pTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um produto com base em seu Id.
        /// </summary>
        /// <param name="id">Id do produto a ser deletado.</param>
        public void Remover(Guid id)
        {
            try
            {
                Produto pTemp = BuscarPorId(id);
                if (pTemp == null)
                {
                    throw new Exception("Produto não encontrado.");
                }

                _ctx.Produtos.Remove(pTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
