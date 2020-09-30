using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ORM_API_Loja.Domains;
using ORM_API_Loja.Interfaces;
using ORM_API_Loja.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ORM_API_Loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        // GET: api/<ProdutosController>
        [HttpGet]
        public List<Produto> Get()
        {
            return _produtoRepository.Listar();
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public Produto Get(Guid id)
        {
            return _produtoRepository.BuscarPorId(id);
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public List<Produto> Get(string nome)
        {
            return _produtoRepository.BuscarPorNome(nome);
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public void Post(Produto p)
        {
            _produtoRepository.Adicionar(p);
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Produto p)
        {
            p.Id = id;
            _produtoRepository.Editar(p);
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _produtoRepository.Remover(id);
        }
    }
}
