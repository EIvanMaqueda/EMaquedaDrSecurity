using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAll() { 
        
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EMaquedaDrSecurityEntities context=new DL.EMaquedaDrSecurityEntities())
                {
                    var query = context.UsuarioGetAll().ToList();
                    if (query!=null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre= obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno= obj.ApellidoMaterno;
                            //usuario.FechaNacimineto = obj.FechaNacimiento.ToString("dd/MM/yyyy");
                            usuario.FechaNacimineto = obj.FechaNacimiento.ToString();
                            usuario.EstadoCivil=obj.EstadoCivil;
                            usuario.Sexo = char.Parse(obj.Sexo);
                            usuario.Curp = obj.CURP;


                            usuario.Direccion=new ML.Direccion();
                            usuario.Direccion.IdDireccion = obj.IdDireccion.Value;
                            usuario.Direccion.Estado = obj.Estado;
                            usuario.Direccion.Municipio = obj.Municipio;
                            usuario.Direccion.Colonia= obj.Colonia;
                            usuario.Direccion.Calle=obj.Calle;
                            usuario.Direccion.Numero= obj.Numero;   

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Message=ex.Message;
                result.Correct=false;
            }
            return result;
        }
        public static ML.Result Add(ML.Usuario usuario) { 
        
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EMaquedaDrSecurityEntities context=new DL.EMaquedaDrSecurityEntities())
                {
                    int query = context.UsuarioAdd(usuario.Nombre,usuario.ApellidoPaterno,usuario.ApellidoMaterno,usuario.FechaNacimineto,usuario.Sexo.ToString()
                        ,usuario.EstadoCivil,usuario.Curp,usuario.Direccion.Estado,usuario.Direccion.Municipio,usuario.Direccion.Colonia,
                        usuario.Direccion.Calle,usuario.Direccion.Numero);
                    if (query>0)
                    { 
                        result.Correct = true;
                        result.Message = "Usuario Agregado Correctamente";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Message=ex.Message;
                result.Correct=false;
            }
            return result;
        }

        public static ML.Result GetById(int id)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.EMaquedaDrSecurityEntities context = new DL.EMaquedaDrSecurityEntities())
                {
                    var query = context.UsuarioGetById(id).AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                       
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = query.IdUsuario;
                            usuario.Nombre = query.Nombre;
                            usuario.ApellidoPaterno = query.ApellidoPaterno;
                            usuario.ApellidoMaterno = query.ApellidoMaterno;
                            //usuario.FechaNacimineto = query.FechaNacimiento.ToString("dd/MM/yyyy");
                            usuario.FechaNacimineto = query.FechaNacimiento.ToString();
                            usuario.EstadoCivil = query.EstadoCivil;
                            usuario.Sexo = char.Parse(query.Sexo);
                            usuario.Curp = query.CURP;


                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = query.IdDireccion.Value;
                            usuario.Direccion.Estado = query.Estado;
                            usuario.Direccion.Municipio = query.Municipio;
                            usuario.Direccion.Colonia = query.Colonia;
                            usuario.Direccion.Calle = query.Calle;
                            usuario.Direccion.Numero = query.Numero;

                            result.Object= usuario;
                        
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.EMaquedaDrSecurityEntities context = new DL.EMaquedaDrSecurityEntities())
                {
                    int query = context.UsuarioUpdate(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimineto, usuario.Sexo.ToString()
                        , usuario.EstadoCivil, usuario.Curp, usuario.Direccion.Estado, usuario.Direccion.Municipio, usuario.Direccion.Colonia,
                        usuario.Direccion.Calle, usuario.Direccion.Numero,usuario.IdUsuario,usuario.Direccion.IdDireccion);
                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Usuario Actualizado Correctamente";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Delete(int idUsuario,int idDireccion)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.EMaquedaDrSecurityEntities context = new DL.EMaquedaDrSecurityEntities())
                {
                    int query = context.UsuarioDelete(idDireccion,idUsuario);
                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Usuario Eliminado Correctamente";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
                result.Correct = false;
            }
            return result;
        }

    }
}
