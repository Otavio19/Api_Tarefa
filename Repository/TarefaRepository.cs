using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidosBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace PedidosBackEnd.Repository
{
    public interface ITarefa
    {
        List<Tarefa> Read(Guid id);

        void Create(Tarefa tarefa);

        void Delete(Guid id);

        void Update(Guid id, Tarefa tarefa);
    }

    public class TarefaRepository : ITarefa
    {
        private readonly DataContext _context;

        public TarefaRepository(DataContext context){
            _context = context;
        }
        public void Create(Tarefa tarefa)
        {
            tarefa.Id = Guid.NewGuid();
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }

       public void Delete(Guid id)
        {
            var tarefa =  _context.Tarefas.Find(id);
            _context.Entry(tarefa).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Tarefa> Read(Guid id)
        {
            // A clausula "Where" é para pegar o parametro do metodo e assim vai
            // retornar apenas as tarefas que forem igual ao ID passado no paramentro.
            return _context.Tarefas.Where(tarefa => tarefa.UsuarioId == id).ToList();
        }

        public void Update(Guid id, Tarefa tarefa)
        {
            var _tarefa = _context.Tarefas.Find(id);

            _tarefa.Nome = tarefa.Nome;
            _tarefa.Concluida = tarefa.Concluida;

            _context.Entry(_tarefa).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}