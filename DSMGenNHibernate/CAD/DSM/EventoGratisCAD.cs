
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
 * Clase EventoGratis:
 *
 */

namespace DSMGenNHibernate.CAD.DSM
{
public partial class EventoGratisCAD : BasicCAD, IEventoGratisCAD
{
public EventoGratisCAD() : base ()
{
}

public EventoGratisCAD(ISession sessionAux) : base (sessionAux)
{
}



public EventoGratisEN ReadOIDDefault (int id
                                      )
{
        EventoGratisEN eventoGratisEN = null;

        try
        {
                SessionInitializeTransaction ();
                eventoGratisEN = (EventoGratisEN)session.Get (typeof(EventoGratisEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoGratisCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return eventoGratisEN;
}

public System.Collections.Generic.IList<EventoGratisEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<EventoGratisEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(EventoGratisEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<EventoGratisEN>();
                        else
                                result = session.CreateCriteria (typeof(EventoGratisEN)).List<EventoGratisEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoGratisCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (EventoGratisEN eventoGratis)
{
        try
        {
                SessionInitializeTransaction ();
                EventoGratisEN eventoGratisEN = (EventoGratisEN)session.Load (typeof(EventoGratisEN), eventoGratis.Id);

                eventoGratisEN.Aforo = eventoGratis.Aforo;

                session.Update (eventoGratisEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoGratisCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


//Sin e: ReadOID
//Con e: EventoGratisEN
public EventoGratisEN ReadOID (int id
                               )
{
        EventoGratisEN eventoGratisEN = null;

        try
        {
                SessionInitializeTransaction ();
                eventoGratisEN = (EventoGratisEN)session.Get (typeof(EventoGratisEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoGratisCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return eventoGratisEN;
}

public System.Collections.Generic.IList<EventoGratisEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EventoGratisEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EventoGratisEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EventoGratisEN>();
                else
                        result = session.CreateCriteria (typeof(EventoGratisEN)).List<EventoGratisEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoGratisCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int CrearEvento (EventoGratisEN eventoGratis)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (eventoGratis);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoGratisCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return eventoGratis.Id;
}

public void Modify (EventoGratisEN eventoGratis)
{
        try
        {
                SessionInitializeTransaction ();
                EventoGratisEN eventoGratisEN = (EventoGratisEN)session.Load (typeof(EventoGratisEN), eventoGratis.Id);

                eventoGratisEN.Lugar = eventoGratis.Lugar;


                eventoGratisEN.Fecha = eventoGratis.Fecha;


                eventoGratisEN.Tipo = eventoGratis.Tipo;


                eventoGratisEN.Descripcion = eventoGratis.Descripcion;


                eventoGratisEN.Nombre = eventoGratis.Nombre;


                eventoGratisEN.Genero = eventoGratis.Genero;


                eventoGratisEN.Aforo = eventoGratis.Aforo;

                session.Update (eventoGratisEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoGratisCAD.", ex);
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
                EventoGratisEN eventoGratisEN = (EventoGratisEN)session.Load (typeof(EventoGratisEN), id);
                session.Delete (eventoGratisEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EventoGratisCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
