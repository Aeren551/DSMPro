using SportsEventsGenNHibernate.EN.SportsEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsEvents_FrontEnd.Models
{
    public class ComentarioAssembler
    {
        public ComentarioModelo ConvertENToModelUI(ComentarioEN en)
        {
            ComentarioModelo cat = new ComentarioModelo();
            cat.id = en.Id;
            cat.titulo = en.Titulo;
            cat.texto = en.Texto;
            cat.tipo = en.Tipocom;
            
            try
            {
                cat.idre = en.Foto.Id;
            }
            catch
            {
                cat.idre = en.Evento.Id;
            }
            


            return cat;
        }



        public IList<ComentarioModelo> ConvertListENToModel(IList<ComentarioEN> ens)
        {
            IList<ComentarioModelo> mod = new List<ComentarioModelo>();
            foreach (ComentarioEN comEN in ens)
            {
                mod.Add(ConvertENToModelUI(comEN));
            }

            return mod;
        }
    }
}