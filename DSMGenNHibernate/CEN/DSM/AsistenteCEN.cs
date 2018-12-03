

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
 *      Definition of the class AsistenteCEN
 *
 */
public partial class AsistenteCEN
{
private IAsistenteCAD _IAsistenteCAD;

public AsistenteCEN()
{
        this._IAsistenteCAD = new AsistenteCAD ();
}

public AsistenteCEN(IAsistenteCAD _IAsistenteCAD)
{
        this._IAsistenteCAD = _IAsistenteCAD;
}

public IAsistenteCAD get_IAsistenteCAD ()
{
        return this._IAsistenteCAD;
}

public void Modify (string p_Asistente_OID, string p_nombre, String p_contrasenya, string p_foto, string p_direccion, int p_telefono)
{
        AsistenteEN asistenteEN = null;

        //Initialized AsistenteEN
        asistenteEN = new AsistenteEN ();
        asistenteEN.Correo = p_Asistente_OID;
        asistenteEN.Nombre = p_nombre;
        asistenteEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        asistenteEN.Foto = p_foto;
        asistenteEN.Direccion = p_direccion;
        asistenteEN.Telefono = p_telefono;
        //Call to AsistenteCAD

        _IAsistenteCAD.Modify (asistenteEN);
}

public void Destroy (string correo
                     )
{
        _IAsistenteCAD.Destroy (correo);
}

public AsistenteEN ReadOID (string correo
                            )
{
        AsistenteEN asistenteEN = null;

        asistenteEN = _IAsistenteCAD.ReadOID (correo);
        return asistenteEN;
}

public System.Collections.Generic.IList<AsistenteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AsistenteEN> list = null;

        list = _IAsistenteCAD.ReadAll (first, size);
        return list;
}
public string CrearUsuario (string p_correo, string p_nombre, String p_contrasenya, string p_foto, string p_direccion, int p_telefono)
{
        AsistenteEN asistenteEN = null;
        string oid;

        //Initialized AsistenteEN
        asistenteEN = new AsistenteEN ();
        asistenteEN.Correo = p_correo;

        asistenteEN.Nombre = p_nombre;

        asistenteEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        asistenteEN.Foto = p_foto;

        asistenteEN.Direccion = p_direccion;

        asistenteEN.Telefono = p_telefono;

        //Call to AsistenteCAD

        oid = _IAsistenteCAD.CrearUsuario (asistenteEN);
        return oid;
}
}
}
