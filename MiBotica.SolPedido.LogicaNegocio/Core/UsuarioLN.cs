using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Base;
using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.LogicaNegocio.Core
{
    public class UsuarioLN : BaseLN
    {
        public Usuario BuscarUsuarioPorId(int id)
        {
            try
            {
                return new UsuarioDA().BuscarUsuarioPorId(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public void InsertarUsuario(Usuario usuario)
        {
            try
            {
                new UsuarioDA().InsertarUsuario(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarUsuario(Usuario usuario, bool cambiarClave)
        {
            try
            {
                new UsuarioDA().ModificarUsuario(usuario, cambiarClave);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            try
            {
                new UsuarioDA().EliminarUsuario(idUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Usuario> ListaUsuarios()
        {
            try
            {
                return new UsuarioDA().ListaUsuarios();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarUsuario(Usuario Usuario)
        {
            try
            {
                return new UsuarioDA().BuscarUsuario(Usuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
