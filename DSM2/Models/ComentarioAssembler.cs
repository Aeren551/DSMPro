using DSMGenNHibernate.EN.DSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSM2.Models
{
    public class ComentarioAssembler
    {
        public ComentarioModel ConvierteObjInterfaz(ComentarioEN en)
        {
            ComentarioModel com = new ComentarioModel();
            com.id = en.Id;
            com.titulo = en.Titulo;
            com.texto = en.Texto;
            com.likes = en.Likes;

           //AQUI A LO MEJOR HAY Q ANYADIR ALGO


            return com;
        }



        public IList<ComentarioModel> ConvierteListEnModelo(IList<ComentarioEN> comens)
        {
            IList<ComentarioModel> com = new List<ComentarioModel>();
            foreach (ComentarioEN comEN in comens)
            {
                com.Add(ConvierteObjInterfaz(comEN));
            }

            return com;
        }
    }
}