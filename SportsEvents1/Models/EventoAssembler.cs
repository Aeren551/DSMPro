using SportsEventsGenNHibernate.CEN.SportsEvents;
using SportsEventsGenNHibernate.EN.SportsEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsEvents_FrontEnd.Models
{
    public class EventoAssembler
    {
        public EventoModelo ConvertENToModelUI(EventoEN en)
        {
            EventoModelo art = new EventoModelo();
            UsuarioCEN cen = new UsuarioCEN();
            art.id = en.Id;
            art.Descripcion = en.Descripcion;
            art.Nombre = en.Nombre;
            art.numPart = en.NumeroParticipantes;
            art.numPartMax = en.MaxParticipantes;
            art.tipo = en.Tipo;
            art.Categoria = en.Categoria.Nombre;
            art.Fecha = en.Fecha;
            art.Longitud = en.Longitud;
            art.Latitud = en.Latitud;
            art.Localizacion = en.Localizacion;

            art.Crea = en.Crea.Nick;
            if (en.Galeria != null)
            {
                art.idgaleria = en.Galeria.Id;
            }
            return art;
        }
        public IList<EventoModelo> ConvertListENToModel(IList<EventoEN> ens)
        {
            IList<EventoModelo> arts = new List<EventoModelo>();
            foreach (EventoEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}

