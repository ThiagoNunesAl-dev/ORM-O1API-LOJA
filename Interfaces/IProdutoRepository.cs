using ORM_API_Loja.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORM_API_Loja.Interfaces
{
    interface IProdutoRepository
    {
        List<Produto> Listar();
        Produto BuscarPorId(Guid id);
        List<Produto> BuscarPorNome(string nome);
        void Adicionar(Produto p);
        void Editar(Produto p);
        void Remover(Guid id);
    }
}
