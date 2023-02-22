using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosBackEnd.Models
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        
        public Guid UsuarioId { get; set; }
        public string? Titulo { get; set; }
        public string? Nome { get; set; }
        public bool Concluida { get; set; }
    }
}