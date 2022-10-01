using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroNuevo.UIWebMVC.Controllers
{
    public class Empleado_controller
    {
        // GET: Empleado 
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult BuscarEmpleadoPorId(int Id)
        {
            byte id = Convert.ToByte(Id);
            return JsonResult(EmpleadoBL.BuscarPorId(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Guardar(Empleado empleado)
        {
            string mensaje = "";
            if (empleado.Nombre != "" && empleado != null)
            {
                if (EmpleadoBL.Guardar(empleado) > 0)
                {
                    mensaje = "Registro Guardado";
                }
                else
                {
                    mensaje = "No se Guardo el Registro";
                }
            }
            else
            {
                mensaje = "No dejar campos vacios";
            }
            return Json(new { Mensaje = mensaje, JsonRequestBehavior.AllowGet });
        }
        //Json: JSON (Notación de objetos de JavaScript) 
        //JsonResult: Un resultado de acción que formatea el objeto dado como JSON.
        public ActionResult Modificar(byte id)
        {
            return View();
        }

        [HttpPost]
        public JsonResult Modificar(Empleado empleado)
        {
            string mensaje = "";
            if (empleado.Nombre != "" && empleado != null)
            {
                if (EmpleadoBL.Modificar(empleado) > 0)
                {
                    mensaje = "Registro Actualizado";
                }
                else
                {
                    mensaje = "No se Actualizó el Registro";
                }
            }
            else
            {
                mensaje = "No dejar campos vacios";
            }
            return Json(new { Mensaje = mensaje, JsonRequestBehavior.AllowGet });
        }


        public ActionResult Eliminar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Eliminar(Empleado empleado)
        {
            string mensaje = "";
            if (empleado.Nombre != "" && empleado != null)
            {
                if (EmpleadoBL.Eliminar(empleado) > 0)
                {
                    mensaje = "Registro Eliminado";
                }
                else
                {
                    mensaje = "No se Eliminó el Registro";
                }
            }
            else
            {
                mensaje = "No dejar campos vacios";
            }
            return Json(new { Mensaje = mensaje, JsonRequestBehavior.AllowGet });
        }
    }
}
   
    
