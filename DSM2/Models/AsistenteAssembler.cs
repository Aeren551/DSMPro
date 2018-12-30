using DSMGenNHibernate.EN.DSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DSM2.Models
{
    public class AsistenteAssembler
    {


        public Asistente ConvertENToModelUI(AsistenteEN en)
        {
            Asistente asis = new Asistente();
            asis.correo = en.Correo;
            asis.nombre = en.Nombre;
            asis.contrasenya = en.Contrasenya;
            asis.foto = en.Foto;
            asis.direccion = en.Direccion;
            asis.telefono = en.Telefono;

            return asis;


        }
        public IList<Asistente> ConvertListENToModel(IList<AsistenteEN> ens)
        {
            IList<Asistente> arts = new List<Asistente>();
            foreach (AsistenteEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}