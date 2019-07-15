using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Tributos de validacion
using System.ComponentModel.DataAnnotations;
using WebApplicationCalculadora.CustomValidators;

namespace WebApplicationCalculadora.Models.Calculadora
{
    public class CalculadoraVM
    {
        [EsPar(ErrorMessage = "Cuidado, {0} debe ser par")]
        [Required(ErrorMessage = "Cuidado, {0} es obligatorio")]
        [Range(0, 100, ErrorMessage = "Cuidado, el rango de {0} debe estar entre {1},{2}")]
        public int OperadorA { set; get; }

        [Required]
        [EsPar]
        public int OperadorB { set; get; }

        public int? Resultado { set; get; }
    }
}