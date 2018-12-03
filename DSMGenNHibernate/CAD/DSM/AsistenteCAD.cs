
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
 * Clase Asistente:
 *
 */

namespace DSMGenNHibernate.CAD.DSM
{
public partial class AsistenteCAD : BasicCAD, IAsistenteCAD
{
public AsistenteCAD() : base ()
{
}

public AsistenteCAD(ISession sessionAux) : base (sessionAux)
{
}



public AsistenteEN ReadOIDDefault (string correo
                                   )
{
        AsistenteEN asistenteEN = null;

        try
        {
                SessionInitializeTransaction ();
                asistenteEN = (AsistenteEN)session.Get (typeof(AsistenteEN), correo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in AsistenteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return asistenteEN;
}

public System.Collections.Generic.IList<AsistenteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AsistenteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AsistenteEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AsistenteEN>();
                        else
                                result = session.CreateCriteria (typeof(AsistenteEN)).List<AsistenteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in AsistenteCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AsistenteEN asistente)
{
        try
        {
                SessionInitializeTransaction ();
                AsistenteEN asistenteEN = (AsistenteEN)session.Load (typeof(AsistenteEN), asistente.Correo);



                session.Update (asistenteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in AsistenteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modify (AsistenteEN asistente)
{
        try
        {
                SessionInitializeTransaction ();
                AsistenteEN asistenteEN = (AsistenteEN)session.Load (typeof(AsistenteEN), asistente.Correo);

                asistenteEN.Nombre = asistente.Nombre;


                asistenteEN.Contrasenya = asistente.Contrasenya;


                asistenteEN.Foto = asistente.Foto;


                asistenteEN.Direccion = asistente.Direccion;


                asistenteEN.Telefono = asistente.Telefono;

                session.Update (asistenteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in AsistenteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string correo
                     )
{
        try
        {
                SessionInitializeTransaction ();
                AsistenteEN asistenteEN = (AsistenteEN)session.Load (typeof(AsistenteEN), correo);
                session.Delete (asistenteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in AsistenteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: AsistenteEN
public AsistenteEN ReadOID (string correo
                            )
{
        AsistenteEN asistenteEN = null;

        try
        {
                SessionInitializeTransaction ();
                asistenteEN = (AsistenteEN)session.Get (typeof(AsistenteEN), correo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in AsistenteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return asistenteEN;
}

public System.Collections.Generic.IList<AsistenteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AsistenteEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AsistenteEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AsistenteEN>();
                else
                        result = session.CreateCriteria (typeof(AsistenteEN)).List<AsistenteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in AsistenteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public string CrearUsuario (AsistenteEN asistente)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (asistente);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in AsistenteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return asistente.Correo;
}
}
}
