using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Clientes
    {
        private CD_Clientes objCapadato = new CD_Clientes();

        public List<Clientes> listar()
        {
            return objCapadato.Listar();
        }
        public int sp_registro_cliente_web(Clientes obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.nombres) || string.IsNullOrWhiteSpace(obj.nombres))
                Mensaje = "El nombre de cliente no puede estar vacio";
            if (string.IsNullOrEmpty(obj.Distrito) || string.IsNullOrWhiteSpace(obj.Distrito))
                Mensaje = "El distrito de cliente no puede estar vacio";
            if (string.IsNullOrEmpty(obj.correo) || string.IsNullOrWhiteSpace(obj.correo))
                Mensaje = "El correo de cliente no puede estar vacio";
            if (string.IsNullOrEmpty(obj.direccion) || string.IsNullOrWhiteSpace(obj.direccion))
                Mensaje = "La direccion de cliente no puede estar vacio";

            if (string.IsNullOrEmpty(Mensaje)) 
            {

               return objCapadato.sp_registro_cliente_web(obj,out Mensaje);
            }
            else
            {
                return 0;
            }
            
        }

        public bool sp_editar_cliente_web(Clientes obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.nombres) || string.IsNullOrWhiteSpace(obj.nombres))
                Mensaje = "El nombre de cliente no puede estar vacio";
            if (string.IsNullOrEmpty(obj.Distrito) || string.IsNullOrWhiteSpace(obj.Distrito))
                Mensaje = "El distrito de cliente no puede estar vacio";
            if (string.IsNullOrEmpty(obj.correo) || string.IsNullOrWhiteSpace(obj.correo))
                Mensaje = "El correo de cliente no puede estar vacio";
            if (string.IsNullOrEmpty(obj.direccion) || string.IsNullOrWhiteSpace(obj.direccion))
                Mensaje = "La direccion de cliente no puede estar vacio";

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapadato.sp_editar_cliente_web(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }
        public bool Eliminar_cliente_web(string codigo, out string Mensaje)
        {
            return objCapadato.Eliminar_cliente_web(codigo, out Mensaje);
        }
    }
}
