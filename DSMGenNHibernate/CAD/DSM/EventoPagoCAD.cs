
using System;
using System.Text;
using DSMGenNHibernate.CEN.DSM;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.Exceptions;


/*
 * Clase EventoPago:
 *
 */

namespace DSMGenNHibernate.CAD.DSM
{
public partial class EventoPagoCAD : BasicCAD, IEventoPagoCAD
{
public EventoPagoCAD() : base ()
{
}

public EventoPagoCAD(ISession sessionAux) : base (sessionAux)
{
}



public EventoPagoEN ReadOIDDefault (int id
                                    )
{
        EventoPagoEN eventoPagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                eventoPagoEN = (EventoPagoEN)session.Get (typeof(EventoPagoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return eventoPagoEN;
}

public System.Collections.Generic.IList<EventoPagoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<EventoPagoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(EventoPagoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<EventoPagoEN>();
                        else
                                result = session.CreateCriteria (typeof(EventoPagoEN)).List<EventoPagoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoPagoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (EventoPagoEN eventoPago)
{
        try
        {
                SessionInitializeTransaction ();
                EventoPagoEN eventoPagoEN = (EventoPagoEN)session.Load (typeof(EventoPagoEN), eventoPago.Id);

                eventoPagoEN.Entradas = eventoPago.Entradas;


                eventoPagoEN.Precio = eventoPago.Precio;


                session.Update (eventoPagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


//Sin e: ReadOID
//Con e: EventoPagoEN
public EventoPagoEN ReadOID (int id
                             )
{
        EventoPagoEN eventoPagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                eventoPagoEN = (EventoPagoEN)session.Get (typeof(EventoPagoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return eventoPagoEN;
}

public System.Collections.Generic.IList<EventoPagoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EventoPagoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EventoPagoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EventoPagoEN>();
                else
                        result = session.CreateCriteria (typeof(EventoPagoEN)).List<EventoPagoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int CrearEvento (EventoPagoEN eventoPago)
{
        try
        {
                SessionInitializeTransaction ();
                if (eventoPago.Entrada != null) {
                        foreach (DSMGenNHibernate.EN.DSM.EntradaEN item in eventoPago.Entrada) {
                                item.EventoPago = eventoPago;
                                session.Save (item);
                        }
                }

                session.Save (eventoPago);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return eventoPago.Id;
}

public void Modify (EventoPagoEN eventoPago)
{
        try
        {
                SessionInitializeTransaction ();
                EventoPagoEN eventoPagoEN = (EventoPagoEN)session.Load (typeof(EventoPagoEN), eventoPago.Id);

                eventoPagoEN.Lugar = eventoPago.Lugar;


                eventoPagoEN.Fecha = eventoPago.Fecha;


                eventoPagoEN.Tipo = eventoPago.Tipo;


                eventoPagoEN.Descripcion = eventoPago.Descripcion;


                eventoPagoEN.Nombre = eventoPago.Nombre;


                eventoPagoEN.Genero = eventoPago.Genero;


                eventoPagoEN.Entradas = eventoPago.Entradas;


                eventoPagoEN.Precio = eventoPago.Precio;

                session.Update (eventoPagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                EventoPagoEN eventoPagoEN = (EventoPagoEN)session.Load (typeof(EventoPagoEN), id);
                session.Delete (eventoPagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
