using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Clientes
    {

        public List<Clientes> Listar()
        {
            List<Clientes> lista = new List<Clientes>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select cod_cliente,nombres,apellidos,correo,direccion,distrito,telefono,celular,dni,ruc from Clientes where tipo = 'C'";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader() )
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Clientes()
                                {
                                    cod_cliente = dr["cod_cliente"].ToString(),
                                    nombres = dr["nombres"].ToString(),
                                    apellidos = dr["apellidos"].ToString(),
                                    correo = dr["correo"].ToString(),
                                    direccion = dr["direccion"].ToString(),
                                    Distrito = dr["distrito"].ToString(),
                                    telefono = dr["telefono"].ToString(),
                                    celular = dr["celular"].ToString(),
                                    dni = dr["dni"].ToString(),
                                    ruc = dr["ruc"].ToString()
                                }
                                );
                        }
                    }
                }
        }
            catch 
            {
                lista = new List<Clientes>();
                             
            }
            return lista;
        }

        public int sp_registro_cliente_web (Clientes obj,out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_registro_cliente_web", oconexion);
                    
                    cmd.Parameters.AddWithValue("Apellidos", obj.apellidos);
                    cmd.Parameters.AddWithValue("Nombres", obj.nombres);
                    cmd.Parameters.AddWithValue("distrito", obj.Distrito);
                    cmd.Parameters.AddWithValue("telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("correo", obj.correo);
                    cmd.Parameters.AddWithValue("direccion", obj.direccion);
                    cmd.Parameters.AddWithValue("celular", obj.celular);
                    cmd.Parameters.AddWithValue("DNI", obj.dni);
                    cmd.Parameters.AddWithValue("Ruc", obj.ruc);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();
                    //oconexion.Close();
                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
                
            }
            return idautogenerado;
        }


        public bool sp_editar_cliente_web(Clientes obj, out string Mensaje)
        {
            bool resutado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_editar_cliente_web", oconexion);

                    cmd.Parameters.AddWithValue("Apellidos", obj.apellidos);
                    cmd.Parameters.AddWithValue("Nombres", obj.nombres);
                    cmd.Parameters.AddWithValue("distrito", obj.Distrito);
                    cmd.Parameters.AddWithValue("telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("correo", obj.correo);
                    cmd.Parameters.AddWithValue("direccion", obj.direccion);
                    cmd.Parameters.AddWithValue("celular", obj.celular);
                    cmd.Parameters.AddWithValue("DNI", obj.dni);
                    cmd.Parameters.AddWithValue("Ruc", obj.ruc);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    resutado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();
                    //oconexion.Close();
                }
            }
            catch (Exception ex)
            {
                resutado = false;
                Mensaje = ex.Message;

            }
            return resutado;
        }

        public bool Eliminar_cliente_web(string codigo,out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top(1) from Clientes where cod_cliente = @cod_cliente", oconexion);
                    cmd.Parameters.AddWithValue("@cod_cliente", codigo);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch(Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }



    }
}
