using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSMGenNHibernate.EN.DSM;
using DSM2.Models;

namespace DSM2.Models
{
    public class EventoAssembler
    {
        public Evento ConvertENToModelUI(EventoEN en)
        {
            Evento art = new Evento();
            art.id = en.Id;
            art.Lugar = en.Lugar;
            art.Fecha = en.Fecha;
            art.Tipo = en.Tipo;
            art.Descripcion = en.Descripcion;
            art.Nombre = en.Nombre;
            //ENUM?
           art.Genero = en.Genero;

            //art.IdCategoria = en.Categoria.Id;
            //art.NombreCategoria = en.Categoria.Nombre;
            //OJO
            
            //art.Correo = en.Usuario_creador.Correo;
            return art;


        }
        public IList<Evento> ConvertListENToModel(IList<EventoEN> ens)
        {
            IList<Evento> arts = new List<Evento>();
            foreach (EventoEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }

    }
}