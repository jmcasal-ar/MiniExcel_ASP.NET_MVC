using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationCalculadora.Models.Calculadora;


namespace WebApplicationCalculadora.Controllers
{
    public class CalculadoraController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            CalculadoraVM model = new CalculadoraVM();
            model.OperadorA = 10;
            model.OperadorB = 0;
            model.Resultado = null;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CalculadoraVM model, string command)
        {
            if(ModelState.IsValid)
            {
                /* Por bug MVC
                bool removeOk = this.ModelState.Remove("resultado");
                if (!removeOk) throw new Exception("Error en ModelState.Remove");
                */

                switch (command)
                {
                    case "+":
                        model.Resultado = model.OperadorA + model.OperadorB;
                        break;
                    case "-":
                        model.Resultado = model.OperadorA - model.OperadorB;
                        break;
                    case "*":
                        model.Resultado = model.OperadorA * model.OperadorB;
                        break;
                    case "/":
                        try
                        {
                            model.Resultado = model.OperadorA / model.OperadorB;
                        }
                        catch(DivideByZeroException)
                        {
                            ModelState.AddModelError("OperadorB", "No se puede dividir por cero.");
                        }
                        break;
                    default:
                        throw new
                            Exception
                                (
                                string.Format("El comando {0} no existe", command)
                                );

                }
            }
            
            return View(model);
        }
    }
}