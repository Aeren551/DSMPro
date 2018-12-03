
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.CAD.DSM;
using DSMGenNHibernate.CEN.DSM;



/*PROTECTED REGION ID(usingDSMGenNHibernate.CP.DSM_EventoPago_crearEvento) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGenNHibernate.CP.DSM
{
public partial class EventoPagoCP : BasicCP
{
public DSMGenNHibernate.EN.DSM.EventoPagoEN CrearEvento (string p_lugar, Nullable<DateTime> p_fecha, DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum p_tipo, string p_descripcion, string p_nombre, DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum p_genero, int p_entradas, double p_precio, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.EntradaEN> p_entrada)
{
        /*PROTECTED REGION ID(DSMGenNHibernate.CP.DSM_EventoPago_crearEvento) ENABLED START*/

        IEventoPagoCAD eventoPagoCAD = null;
        EventoPagoCEN eventoPagoCEN = null;

        DSMGenNHibernate.EN.DSM.EventoPagoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                eventoPagoCAD = new EventoPagoCAD (session);
                eventoPagoCEN = new  EventoPagoCEN (eventoPagoCAD);




                int oid;
                //Initialized EventoPagoEN


                //AQUI SE CAMBIA LA INICIALIZACION DE LAS VARIBLES POR EJ ENTRADAS = 0 SIEMPRE
                EventoPagoEN eventoPagoEN;
                eventoPagoEN = new EventoPagoEN ();
                eventoPagoEN.Lugar = p_lugar;

                eventoPagoEN.Fecha = p_fecha;

                eventoPagoEN.Tipo = p_tipo;

                eventoPagoEN.Descripcion = p_descripcion;

                eventoPagoEN.Nombre = p_nombre;

                eventoPagoEN.Genero = p_genero;

                eventoPagoEN.Entradas = 0;

                eventoPagoEN.Precio = p_precio;


                //WTF es esto ? lo borrariamos y se ha quedado aqui no ? xD
                //HOLAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                eventoPagoEN.Entrada = p_entrada;

                //Call to EventoPagoCAD

                oid = eventoPagoCAD.CrearEvento (eventoPagoEN);
                result = eventoPagoCAD.ReadOIDDefault (oid);


                //al crearse el evento asistentes  = 0




                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
