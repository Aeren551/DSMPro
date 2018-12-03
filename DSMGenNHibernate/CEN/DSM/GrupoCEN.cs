

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGenNHibernate.Exceptions;

using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.CAD.DSM;


namespace DSMGenNHibernate.CEN.DSM
{
/*
 *      Definition of the class GrupoCEN
 *
 */
public partial class GrupoCEN
{
private IGrupoCAD _IGrupoCAD;

public GrupoCEN()
{
        this._IGrupoCAD = new GrupoCAD ();
}

public GrupoCEN(IGrupoCAD _IGrupoCAD)
{
        this._IGrupoCAD = _IGrupoCAD;
}

public IGrupoCAD get_IGrupoCAD ()
{
        return this._IGrupoCAD;
}

public int CrearGrupo (string p_nombre, System.Collections.Generic.IList<string> p_usuario, int p_cantidad)
{
        GrupoEN grupoEN = null;
        int oid;

        //Initialized GrupoEN
        grupoEN = new GrupoEN ();
        grupoEN.Nombre = p_nombre;


        grupoEN.Usuario = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.UsuarioEN>();
        if (p_usuario != null) {
                foreach (string item in p_usuario) {
                        DSMGenNHibernate.EN.DSM.UsuarioEN en = new DSMGenNHibernate.EN.DSM.UsuarioEN ();
                        en.Correo = item;
                        grupoEN.Usuario.Add (en);
                }
        }

        else{
                grupoEN.Usuario = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.UsuarioEN>();
        }

        grupoEN.Cantidad = p_cantidad;

        //Call to GrupoCAD

        oid = _IGrupoCAD.CrearGrupo (grupoEN);
        return oid;
}

public void Modify (int p_Grupo_OID, string p_nombre, int p_cantidad)
{
        GrupoEN grupoEN = null;

        //Initialized GrupoEN
        grupoEN = new GrupoEN ();
        grupoEN.Id = p_Grupo_OID;
        grupoEN.Nombre = p_nombre;
        grupoEN.Cantidad = p_cantidad;
        //Call to GrupoCAD

        _IGrupoCAD.Modify (grupoEN);
}

public void Destroy (int id
                     )
{
        _IGrupoCAD.Destroy (id);
}

public void EliminarUsuario (int p_Grupo_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        //Call to GrupoCAD

        _IGrupoCAD.EliminarUsuario (p_Grupo_OID, p_usuario_OIDs);
}
public GrupoEN ReadOID (int id
                        )
{
        GrupoEN grupoEN = null;

        grupoEN = _IGrupoCAD.ReadOID (id);
        return grupoEN;
}

public System.Collections.Generic.IList<GrupoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<GrupoEN> list = null;

        list = _IGrupoCAD.ReadAll (first, size);
        return list;
}
}
}
