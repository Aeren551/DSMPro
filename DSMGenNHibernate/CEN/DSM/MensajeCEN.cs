

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
 *      Definition of the class MensajeCEN
 *
 */
public partial class MensajeCEN
{
private IMensajeCAD _IMensajeCAD;

public MensajeCEN()
{
        this._IMensajeCAD = new MensajeCAD ();
}

public MensajeCEN(IMensajeCAD _IMensajeCAD)
{
        this._IMensajeCAD = _IMensajeCAD;
}

public IMensajeCAD get_IMensajeCAD ()
{
        return this._IMensajeCAD;
}

public int CrearMensaje (string p_mensaje, bool p_leido, string p_usuario, string p_usuario_0)
{
        MensajeEN mensajeEN = null;
        int oid;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Mensaje = p_mensaje;

        mensajeEN.Leido = p_leido;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                mensajeEN.Usuario = new DSMGenNHibernate.EN.DSM.UsuarioEN ();
                mensajeEN.Usuario.Correo = p_usuario;
        }


        if (p_usuario_0 != null) {
                // El argumento p_usuario_0 -> Property usuario_0 es oid = false
                // Lista de oids id
                mensajeEN.Usuario_0 = new DSMGenNHibernate.EN.DSM.UsuarioEN ();
                mensajeEN.Usuario_0.Correo = p_usuario_0;
        }

        //Call to MensajeCAD

        oid = _IMensajeCAD.CrearMensaje (mensajeEN);
        return oid;
}

public void Modify (int p_Mensaje_OID, string p_mensaje, bool p_leido)
{
        MensajeEN mensajeEN = null;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Id = p_Mensaje_OID;
        mensajeEN.Mensaje = p_mensaje;
        mensajeEN.Leido = p_leido;
        //Call to MensajeCAD

        _IMensajeCAD.Modify (mensajeEN);
}

public void Destroy (int id
                     )
{
        _IMensajeCAD.Destroy (id);
}

public MensajeEN ReadOID (int id
                          )
{
        MensajeEN mensajeEN = null;

        mensajeEN = _IMensajeCAD.ReadOID (id);
        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> list = null;

        list = _IMensajeCAD.ReadAll (first, size);
        return list;
}
}
}
