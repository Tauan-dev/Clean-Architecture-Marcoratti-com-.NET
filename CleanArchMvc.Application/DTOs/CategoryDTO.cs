using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        // define as propriedades das etidades que ficarão expostas 
        public int Id { get; set; }
        // através do data annotations é possível fazer a validação na camada de aplicação para 
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        public required string Name { get; set; }
    }
}