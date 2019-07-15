using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationCalculadora.CustomValidators
{
    public class EsParAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool esPar = false;
            int dato = Convert.ToInt32(value);
            esPar = (dato % 2 == 0) ? true : false;            
            return esPar;
        }

        public override string FormatErrorMessage(string name)
        {
            string msg = "";

            if (this.ErrorMessage == null)            
                msg = "Este es el mensaje de default para {0}, debe ser par.";                            
            else            
                msg = this.ErrorMessage;
            
            msg = string.Format(msg, name);
            return msg;
        }
    }
}