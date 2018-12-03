
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
 * Clase Grupo:
 *
 */

namespace DSMGenNHibernate.CAD.DSM
{
public partial class GrupoCAD : BasicCAD, IGrupoCAD
{
public GrupoCAD() : base ()
{
}

public GrupoCAD(ISession sessionAux) : base (sessionAux)
{
}



public GrupoEN ReadOIDDefault (int id
                               )
{
        GrupoEN grupoEN = null;

        try
        {
                SessionInitializeTransaction ();
                grupoEN = (GrupoEN)session.Get (typeof(GrupoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return grupoEN;
}

public System.Collections.Generic.IList<GrupoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<GrupoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(GrupoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<GrupoEN>();
                        else
                                result = session.CreateCriteria (typeof(GrupoEN)).List<GrupoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (GrupoEN grupo)
{
        try
        {
                SessionInitializeTransaction ();
                GrupoEN grupoEN = (GrupoEN)session.Load (typeof(GrupoEN), grupo.Id);

                grupoEN.Nombre = grupo.Nombre;





                grupoEN.Cantidad = grupo.Cantidad;

                session.Update (grupoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearGrupo (GrupoEN grupo)
{
        try
        {
                SessionInitializeTransaction ();
                if (grupo.Usuario != null) {
                        for (int i = 0; i < grupo.Usuario.Count; i++) {
                                grupo.Usuario [i] = (DSMGenNHibernate.EN.DSM.UsuarioEN)session.Load (typeof(DSMGenNHibernate.EN.DSM.UsuarioEN), grupo.Usuario [i].Correo);
                                grupo.Usuario [i].Grupo.Add (grupo);
                        }
                }

                session.Save (grupo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return grupo.Id;
}

public void Modify (GrupoEN grupo)
{
        try
        {
                SessionInitializeTransaction ();
                GrupoEN grupoEN = (GrupoEN)session.Load (typeof(GrupoEN), grupo.Id);

                grupoEN.Nombre = grupo.Nombre;


                grupoEN.Cantidad = grupo.Cantidad;

                session.Update (grupoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
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
                GrupoEN grupoEN = (GrupoEN)session.Load (typeof(GrupoEN), id);
                session.Delete (grupoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirUsuario (int p_Grupo_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        DSMGenNHibernate.EN.DSM.GrupoEN grupoEN = null;
        try
        {
                SessionInitializeTransaction ();
                grupoEN = (GrupoEN)session.Load (typeof(GrupoEN), p_Grupo_OID);
                DSMGenNHibernate.EN.DSM.UsuarioEN usuarioENAux = null;
                if (grupoEN.Usuario == null) {
                        grupoEN.Usuario = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.UsuarioEN>();
                }

                foreach (string item in p_usuario_OIDs) {
                        usuarioENAux = new DSMGenNHibernate.EN.DSM.UsuarioEN ();
                        usuarioENAux = (DSMGenNHibernate.EN.DSM.UsuarioEN)session.Load (typeof(DSMGenNHibernate.EN.DSM.UsuarioEN), item);
                        usuarioENAux.Grupo.Add (grupoEN);

                        grupoEN.Usuario.Add (usuarioENAux);
                }


                session.Update (grupoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EliminarUsuario (int p_Grupo_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                DSMGenNHibernate.EN.DSM.GrupoEN grupoEN = null;
                grupoEN = (GrupoEN)session.Load (typeof(GrupoEN), p_Grupo_OID);

                DSMGenNHibernate.EN.DSM.UsuarioEN usuarioENAux = null;
                if (grupoEN.Usuario != null) {
                        foreach (string item in p_usuario_OIDs) {
                                usuarioENAux = (DSMGenNHibernate.EN.DSM.UsuarioEN)session.Load (typeof(DSMGenNHibernate.EN.DSM.UsuarioEN), item);
                                if (grupoEN.Usuario.Contains (usuarioENAux) == true) {
                                        grupoEN.Usuario.Remove (usuarioENAux);
                                        usuarioENAux.Grupo.Remove (grupoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuario_OIDs you are trying to unrelationer, doesn't exist in GrupoEN");
                        }
                }

                session.Update (grupoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: ReadOID
//Con e: GrupoEN
public GrupoEN ReadOID (int id
                        )
{
        GrupoEN grupoEN = null;

        try
        {
                SessionInitializeTransaction ();
                grupoEN = (GrupoEN)session.Get (typeof(GrupoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return grupoEN;
}

public System.Collections.Generic.IList<GrupoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<GrupoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(GrupoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<GrupoEN>();
                else
                        result = session.CreateCriteria (typeof(GrupoEN)).List<GrupoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
