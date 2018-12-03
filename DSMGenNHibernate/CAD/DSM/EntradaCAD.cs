
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
 * Clase Entrada:
 *
 */

namespace DSMGenNHibernate.CAD.DSM
{
public partial class EntradaCAD : BasicCAD, IEntradaCAD
{
public EntradaCAD() : base ()
{
}

public EntradaCAD(ISession sessionAux) : base (sessionAux)
{
}



public EntradaEN ReadOIDDefault (int id
                                 )
{
        EntradaEN entradaEN = null;

        try
        {
                SessionInitializeTransaction ();
                entradaEN = (EntradaEN)session.Get (typeof(EntradaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return entradaEN;
}

public System.Collections.Generic.IList<EntradaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<EntradaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(EntradaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<EntradaEN>();
                        else
                                result = session.CreateCriteria (typeof(EntradaEN)).List<EntradaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (EntradaEN entrada)
{
        try
        {
                SessionInitializeTransaction ();
                EntradaEN entradaEN = (EntradaEN)session.Load (typeof(EntradaEN), entrada.Id);

                entradaEN.Precio = entrada.Precio;


                entradaEN.Vendida = entrada.Vendida;


                session.Update (entradaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (EntradaEN entrada)
{
        try
        {
                SessionInitializeTransaction ();
                if (entrada.EventoPago != null) {
                        // Argumento OID y no colección.
                        entrada.EventoPago = (DSMGenNHibernate.EN.DSM.EventoPagoEN)session.Load (typeof(DSMGenNHibernate.EN.DSM.EventoPagoEN), entrada.EventoPago.Id);

                        entrada.EventoPago.Entrada
                        .Add (entrada);
                }

                session.Save (entrada);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return entrada.Id;
}

public void Modify (EntradaEN entrada)
{
        try
        {
                SessionInitializeTransaction ();
                EntradaEN entradaEN = (EntradaEN)session.Load (typeof(EntradaEN), entrada.Id);

                entradaEN.Precio = entrada.Precio;


                entradaEN.Vendida = entrada.Vendida;

                session.Update (entradaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
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
                EntradaEN entradaEN = (EntradaEN)session.Load (typeof(EntradaEN), id);
                session.Delete (entradaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: EntradaEN
public EntradaEN ReadOID (int id
                          )
{
        EntradaEN entradaEN = null;

        try
        {
                SessionInitializeTransaction ();
                entradaEN = (EntradaEN)session.Get (typeof(EntradaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return entradaEN;
}

public System.Collections.Generic.IList<EntradaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EntradaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EntradaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EntradaEN>();
                else
                        result = session.CreateCriteria (typeof(EntradaEN)).List<EntradaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
