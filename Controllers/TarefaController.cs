using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PedidosBackEnd.Repository;
using PedidosBackEnd.Models;
using Microsoft.AspNetCore.Authorization;

namespace PedidosBackEnd.Controllers
{
    [Authorize]
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] ITarefa repository){
            var id = new Guid(User.Identity.Name);
            var tarefas = repository.Read(id);
            return Ok(tarefas);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Tarefa model, [FromServices]ITarefa repository){
            if(!ModelState.IsValid)
                return BadRequest();

            model.UsuarioId = new Guid(User.Identity.Name);
            repository.Create(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Tarefa model, [FromServices]ITarefa repository){
            if(!ModelState.IsValid)
                return BadRequest();

            repository.Update(new Guid(id), model); 
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromServices]ITarefa repository){
            repository.Delete(new Guid(id)); 
            return Ok();
        }
    } 
}