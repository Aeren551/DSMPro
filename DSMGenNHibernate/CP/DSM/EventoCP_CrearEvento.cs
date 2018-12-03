
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



/*PROTECTED REGION ID(usingDSMGenNHibernate.CP.DSM_Evento_crearEvento) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGenNHibernate.CP.DSM
{
public partial class EventoCP : BasicCP
{
public DSMGenNHibernate.EN.DSM.EventoEN CrearEvento (string p_lugar, Nullable<DateTime> p_fecha, DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum p_tipo, string p_descripcion, string p_nombre, DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum p_genero)
{
        /*PROTECTED REGION ID(DSMGenNHibernate.CP.DSM_Evento_crearEvento) ENABLED START*/

        //COMO SE LE PASA POR PARAMETRO EL PRECIO DE LAS ENTRADAS AL METODO SI EVENTO PAGO HEREDA?

        IEventoCAD eventoCAD = null;
        EventoCEN eventoCEN = null;


        DSMGenNHibernate.EN.DSM.EventoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                eventoCAD = new EventoCAD (session);
                eventoCEN = new EventoCEN (eventoCAD);
                //  eventoPagoCAD = new EventoPagoCAD(session);



                int oid;
                //Initialized EventoEN
                EventoEN eventoEN;
                eventoEN = new EventoEN ();
                eventoEN.Lugar = p_lugar;

                eventoEN.Fecha = p_fecha;

                eventoEN.Tipo = p_tipo;

                eventoEN.Descripcion = p_descripcion;

                eventoEN.Nombre = p_nombre;

                eventoEN.Genero = p_genero;

                //MIRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
                //inicializo tipos evento
                EventoPagoEN eventoPagoEN;
                eventoPagoEN = new EventoPagoEN ();
                eventoPagoEN.Entradas = 1;
                //eventoPagoEN.Precio = 1.0;

                EventoGratisEN eventoGratisEN;
                eventoGratisEN = new EventoGratisEN ();

                EntradaEN entradaEN;
                entradaEN = new EntradaEN ();
                entradaEN.Precio = 1.0;
                entradaEN.Vendida = false;

                //Call to EventoCAD

                oid = eventoCAD.CrearEvento (eventoEN);
                result = eventoCAD.ReadOIDDefault (oid);


                /* if (comentarioEN.Tipocom == TipoComentarioEnum.Evento)
                 * {
                 *  comentarioCEN.VincEv(comentarioEN.Id, idref);
                 * }*/

                if (eventoEN.Id == eventoPagoEN.Id) {
                }


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
