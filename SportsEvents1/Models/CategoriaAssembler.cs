using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SportsEventsGenNHibernate.EN.SportsEvents;
using SportsEvents_FrontEnd.Models;


namespace SportsEvents_FrontEnd.Models
{
    public class CategoriaAssembler 
    {
        //
        // GET: /CategoriaAssembler/

        public CategoriaModelo ConvertENToModelUI(CategoriaEN en)
        {
            CategoriaModelo cat = new CategoriaModelo();

            cat.nombre = en.Nombre;

            return cat; 
        }



        public IList<CategoriaModelo>ConvertListENToModel(IList<CategoriaEN> catens)
        {
            IList<CategoriaModelo> catmod = new List<CategoriaModelo>();
            foreach(CategoriaEN caten in catens)
            {
                catmod.Add(ConvertENToModelUI(caten)); 
            }

            return catmod;
        }

    }
}
