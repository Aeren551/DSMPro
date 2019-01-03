using SportsEventsGenNHibernate.EN.SportsEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsEvents_FrontEnd.Models
{
    public class UsuarioAssembler
    {
        public UsuarioModelo ConvertENToModelUI(UsuarioEN usrEN)
        {
            UsuarioModelo usr = new UsuarioModelo();
            usr.id = usrEN.Nick;
            usr.email = usrEN.Correo;
            usr.password = usrEN.Password;
            usr.bloqueado = usrEN.Bloqueado;
            usr.tipo = usrEN.Tipo;
            usr.nombre = usrEN.Nombre;
            usr.apellidos = usrEN.Apellidos;
            usr.telefono = usrEN.Telefono;
            usr.localidad = usrEN.Localidad;
            usr.provincia = usrEN.Provincia;
            //  usr.bloqueado = usrEN.;

            return usr;
        }


        public IList<UsuarioModelo> ConvertListENToModelUI(IList<UsuarioEN> usrsEN)
        {
            IList<UsuarioModelo> usrs = new List<UsuarioModelo>();
            foreach (UsuarioEN usrEN in usrsEN)
            {
                usrs.Add(ConvertENToModelUI(usrEN));
            }

            return usrs;
        }
    }
}