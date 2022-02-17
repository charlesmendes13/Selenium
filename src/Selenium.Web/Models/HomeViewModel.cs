using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Selenium.Web.Models
{
    public class HomeViewModel
    {
        [Required(ErrorMessage = "Erro, O Nome não pode ser nulo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Erro, O Sobrenome não pode ser nulo")]
        public string Sobrenome { get; set; }

        public string Sexo { get; set; }

        [Required(ErrorMessage = "Erro, O RG não pode ser nulo")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Erro, O CPF não pode ser nulo")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Erro, O CEP não pode ser nulo")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Erro, O Endereco não pode ser nulo")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Erro, O Bairro não pode ser nulo")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Erro, O Cidade não pode ser nulo")]
        public string Cidade { get; set; }
        
        public string Estado { get; set; }
    }
}
