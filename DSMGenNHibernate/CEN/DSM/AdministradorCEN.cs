

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
 *      Definition of the class AdministradorCEN
 *
 */
public partial class AdministradorCEN
{
private IAdministradorCAD _IAdministradorCAD;

public AdministradorCEN()
{
        this._IAdministradorCAD = new AdministradorCAD ();
}

public AdministradorCEN(IAdministradorCAD _IAdministradorCAD)
{
        this._IAdministradorCAD = _IAdministradorCAD;
}

public IAdministradorCAD get_IAdministradorCAD ()
{
        return this._IAdministradorCAD;
}

public AdministradorEN ReadOID (string correo
                                )
{
        AdministradorEN administradorEN = null;

        administradorEN = _IAdministradorCAD.ReadOID (correo);
        return administradorEN;
}

public System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> list = null;

        list = _IAdministradorCAD.ReadAll (first, size);
        return list;
}
public string CrearUsuario (string p_correo, string p_nombre, String p_contrasenya, string p_foto, string p_direccion, int p_telefono)
{
        AdministradorEN administradorEN = null;
        string oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Correo = p_correo;

        administradorEN.Nombre = p_nombre;

        administradorEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        administradorEN.Foto = p_foto;

        administradorEN.Direccion = p_direccion;

        administradorEN.Telefono = p_telefono;

        //Call to AdministradorCAD

        oid = _IAdministradorCAD.CrearUsuario (administradorEN);
        return oid;
}

public void Modify (string p_Administrador_OID, string p_nombre, String p_contrasenya, string p_foto, string p_direccion, int p_telefono)
{
        AdministradorEN administradorEN = null;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Correo = p_Administrador_OID;
        administradorEN.Nombre = p_nombre;
        administradorEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        administradorEN.Foto = p_foto;
        administradorEN.Direccion = p_direccion;
        administradorEN.Telefono = p_telefono;
        //Call to AdministradorCAD

        _IAdministradorCAD.Modify (administradorEN);
}

public void Destroy (string correo
                     )
{
        _IAdministradorCAD.Destroy (correo);
}
}
}
