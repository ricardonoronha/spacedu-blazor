using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLoginSocial.Domain.Dtos
{
    public class CustomerInsertOrUpdateCommand
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cidade é obrigatória")]
        public string TownName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Estado é obrigatório")]
        public string State { get; set; } = string.Empty;

        [RegularExpression(@"^(https?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$", ErrorMessage = "A URL fornecida não é válida.")]
        public string ImageUrl { get; set; } = string.Empty;

        [MinLength(4, ErrorMessage = "Febraban deve ter 4 caracteres")]
        [MaxLength(4, ErrorMessage = "Febraban deve ter 4 caracteres")]
        public string Febraban { get; set; } = string.Empty;


    }
}
