using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTO
{
    public class CheckTodoDTO
    {
        [Required]
        public Guid Id { get; set; }
    }
}
