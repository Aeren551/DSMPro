
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
 * Clase Premio:
 *
 */

namespace DSMGenNHibernate.CAD.DSM
{
public partial class PremioCAD : BasicCAD, IPremioCAD
{
public PremioCAD() : base ()
{
}

public PremioCAD(ISession sessionAux) : base (sessionAux)
{
}



public PremioEN ReadOIDDefault (int id
                                )
{
        PremioEN premioEN = null;

        try
        {
                SessionInitializeTransaction ();
                premioEN = (PremioEN)session.Get (typeof(PremioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in PremioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return premioEN;
}

public System.Collections.Generic.IList<PremioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PremioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PremioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PremioEN>();
                        else
                                result = session.CreateCriteria (typeof(PremioEN)).List<PremioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in PremioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PremioEN premio)
{
        try
        {
                SessionInitializeTransaction ();
                PremioEN premioEN = (PremioEN)session.Load (typeof(PremioEN), premio.Id);

                premioEN.Descripcion = premio.Descripcion;



                premioEN.Nombre = premio.Nombre;



                session.Update (premioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in PremioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearPremio (PremioEN premio)
{
        try
        {
                SessionInitializeTransaction ();
                if (premio.Evento != null) {
                        // Argumento OID y no colección.
                        premio.Evento = (DSMGenNHibernate.EN.DSM.EventoEN)session.Load (typeof(DSMGenNHibernate.EN.DSM.EventoEN), premio.Evento.Id);

                        premio.Evento.Premio
                        .Add (premio);
                }
                if (premio.Asistente != null) {
                        // Argumento OID y no colección.
                        premio.Asistente = (DSMGenNHibernate.EN.DSM.AsistenteEN)session.Load (typeof(DSMGenNHibernate.EN.DSM.AsistenteEN), premio.Asistente.Correo);

                        premio.Asistente.Premio
                        .Add (premio);
                }
                if (premio.Grupo != null) {
                        // Argumento OID y no colección.
                        premio.Grupo = (DSMGenNHibernate.EN.DSM.GrupoEN)session.Load (typeof(DSMGenNHibernate.EN.DSM.GrupoEN), premio.Grupo.Id);

                        premio.Grupo.Premio
                        .Add (premio);
                }

                session.Save (premio);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in PremioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return premio.Id;
}

public void Modify (PremioEN premio)
{
        try
        {
                SessionInitializeTransaction ();
                PremioEN premioEN = (PremioEN)session.Load (typeof(PremioEN), premio.Id);

                premioEN.Descripcion = premio.Descripcion;


                premioEN.Nombre = premio.Nombre;

                session.Update (premioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in PremioCAD.", ex);
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
                PremioEN premioEN = (PremioEN)session.Load (typeof(PremioEN), id);
                session.Delete (premioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in PremioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PremioEN
public PremioEN ReadOID (int id
                         )
{
        PremioEN premioEN = null;

        try
        {
                SessionInitializeTransaction ();
                premioEN = (PremioEN)session.Get (typeof(PremioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in PremioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return premioEN;
}

public System.Collections.Generic.IList<PremioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PremioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PremioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PremioEN>();
                else
                        result = session.CreateCriteria (typeof(PremioEN)).List<PremioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in PremioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AnyadirPremio (int p_Premio_OID, string p_asistente_OID)
{
        DSMGenNHibernate.EN.DSM.PremioEN premioEN = null;
        try
        {
                SessionInitializeTransaction ();
                premioEN = (PremioEN)session.Load (typeof(PremioEN), p_Premio_OID);
                premioEN.Asistente = (DSMGenNHibernate.EN.DSM.AsistenteEN)session.Load (typeof(DSMGenNHibernate.EN.DSM.AsistenteEN), p_asistente_OID);

                premioEN.Asistente.Premio.Add (premioEN);



                session.Update (premioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in PremioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
