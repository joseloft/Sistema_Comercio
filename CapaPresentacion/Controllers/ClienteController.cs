using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Clientes()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListarClientes()
        {
            List<Clientes> oLista = new List<Clientes>();
            oLista = new CN_Clientes().listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CrearEditarCliente(Clientes objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.id == 0)
            {
                resultado = new CN_Clientes().sp_registro_cliente_web(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Clientes().sp_editar_cliente_web(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}