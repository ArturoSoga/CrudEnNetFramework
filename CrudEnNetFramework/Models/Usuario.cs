using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudEnNetFramework.Models
{
    internal class Usuario
    {
        public int usu_id { get; set; }
        public string usu_nombre { get; set; }
        public string usu_usuario { get; set; }
        public string usu_correo { get; set; }
        public string usu_contrasena { get; set; }

        DataBaseSQLContext _sql = new DataBaseSQLContext();

        public void Crear(string nombre ,string usuario , string correo,string contrasena)
        {
            _sql.conn.Open();
            SqlCommand command = new SqlCommand("insert into Usuarios (usu_nombre,usu_usuario,usu_correo,usu_contrasena) values ('" + nombre+ "','" + usuario+ "','" + correo+ "','" + contrasena+"')", _sql.conn);
            command.ExecuteNonQuery();

            _sql.conn.Close();
        }
        public List<Usuario> Leer()
        {
                    List<Usuario> listaUsuarios = new List<Usuario>();

                    _sql.conn.Open();
                    SqlCommand command = new SqlCommand("select * from Usuarios", _sql.conn);
                    SqlDataReader reader = command.ExecuteReader();


                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listaUsuarios.Add(new Usuario() { usu_id = Convert.ToInt32(reader[0]) , 
                                                              usu_nombre = reader[1].ToString(), 
                                                              usu_usuario = reader[2].ToString() , 
                                                              usu_correo = reader[3].ToString(),
                                                              usu_contrasena = reader[4].ToString() 
                             });
                        
                        }
                        
                    }
                    reader.Close();
                    _sql.conn.Close();
            return listaUsuarios;
        }

        public void Actualizar(int id,string nombre , string usuario , string correo ,string contrasena)
        {
            _sql.conn.Open();
            SqlCommand command = new SqlCommand("update Usuarios set usu_nombre ='"+nombre+"',usu_usuario ='"+usuario+"' , usu_correo ='"+correo+"' ,usu_contrasena ='"+contrasena+"'  WHERE usu_id ='"+id+"' ", _sql.conn);
            command.ExecuteNonQuery();
            _sql.conn.Close();
        }

        public void Eliminar(int id)
        {
            _sql.conn.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Usuarios WHERE usu_id ='"+id+"' ", _sql.conn);
            command.ExecuteNonQuery();
            _sql.conn.Close();
        }

    }
}
