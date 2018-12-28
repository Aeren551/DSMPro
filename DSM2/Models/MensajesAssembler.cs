using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSMGenNHibernate.EN.DSM;
using DSM2.Models;

namespace DSM2.Models
{
    public class MensajesAssembler
    {
        public Mensajes ConvertENToModelUI(MensajeEN en)
        {
            Mensajes art = new Mensajes();
            art.ID = en.Id;
            art.Mensaje = en.Mensaje;
            art.Leido = en.Leido;

            //art.IdCategoria = en.Categoria.Id;
            //art.NombreCategoria = en.Categoria.Nombre;
            //OJO
            
            //art.Correo = en.Usuario_creador.Correo;
            return art;


        }
        public IList<Mensajes> ConvertListENToModel(IList<MensajeEN> ens)
        {
            IList<Mensajes> arts = new List<Mensajes>();
            foreach (MensajeEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }

    }
}