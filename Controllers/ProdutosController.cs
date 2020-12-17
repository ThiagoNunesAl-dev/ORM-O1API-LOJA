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
        public IActionResult Get()
        {
            try { 
                var produtos = _produtoRepository.Listar();
                
                if(produtos.Count == 0)
                {
                    return NoContent();
                }

                return Ok(produtos);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Produto produto = _produtoRepository.BuscarPorId(id);

                if(produto == null)
                {
                    return NotFound();
                }

                return Ok(produto);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string nome)
        {
            try
            {
                var produtos = _produtoRepository.BuscarPorNome(nome);

                if (produtos.Count == 0)
                    return NoContent();

                return Ok(produtos);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public IActionResult Post(Produto p)
        {
            try
            {
                _produtoRepository.Adicionar(p);

                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto p)
        {
            try
            {
                var produtoTemp = _produtoRepository.BuscarPorId(id);

                if(produtoTemp == null)
                {
                    return NotFound();
                }

                p.Id = id;
                _produtoRepository.Editar(p);

                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var produto = _produtoRepository.BuscarPorId(id);

                if (produto == null)
                    return NotFound();

                _produtoRepository.Remover(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
