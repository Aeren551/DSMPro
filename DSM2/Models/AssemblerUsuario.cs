using DSMGenNHibernate.EN.DSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DSM2.Models
{
    public class AssemblerUsuario
    {


        public Usuario ConvertENToModelUI(UsuarioEN en)
        {
            Usuario Usuario = new Usuario();



            Usuario.correo = en.Correo;

            Usuario.nombre = en.Nombre;
            Usuario.contrasenya = en.Contrasenya;
            Usuario.foto = en.Foto;
            Usuario.direccion = en.Direccion;
            Usuario.telefono = en.Telefono;

            return Usuario;


        }
        public IList<Usuario> ConvertListENToModel(IList<UsuarioEN> ens)
        {
            IList<Usuario> arts = new List<Usuario>();
            foreach (UsuarioEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}