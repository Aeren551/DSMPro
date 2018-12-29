using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSMGenNHibernate.CAD.DSM;
using DSMGenNHibernate.CEN.DSM;
using DSMGenNHibernate.EN.DSM;
using DSM2.Models;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.IO;
using NHibernate;

namespace DSM2.Models
{
    public class GrupoAssembler
    {
        public Grupo ConvertENToModelUI(GrupoEN en)
        {
            Grupo art = new Grupo();
            art.ID = en.Id;
            IList<UsuarioEN> usul = new List<UsuarioEN>();
            foreach(string usuar in art.ListaUsu)
            {
                UsuarioEN artEN = new UsuarioCAD().ReadOIDDefault(usuar);
                usul.Add(artEN);
            }
            art.cantidad = en.Cantidad;

            return art;


        }
        public IList<Grupo> ConvertListENToModel(IList<GrupoEN> ens)
        {
            IList<Grupo> arts = new List<Grupo>();
            foreach (GrupoEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }

    }
}