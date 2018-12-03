

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
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public string CrearUsuario (string p_correo, string p_nombre, String p_contrasenya, string p_foto, string p_direccion, int p_telefono)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Correo = p_correo;

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        usuarioEN.Foto = p_foto;

        usuarioEN.Direccion = p_direccion;

        usuarioEN.Telefono = p_telefono;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.CrearUsuario (usuarioEN);
        return oid;
}

public void Modify (string p_Usuario_OID, string p_nombre, String p_contrasenya, string p_foto, string p_direccion, int p_telefono)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Correo = p_Usuario_OID;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        usuarioEN.Foto = p_foto;
        usuarioEN.Direccion = p_direccion;
        usuarioEN.Telefono = p_telefono;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (string correo
                     )
{
        _IUsuarioCAD.Destroy (correo);
}

public UsuarioEN ReadOID (string correo
                          )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.ReadOID (correo);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.ReadAll (first, size);
        return list;
}


        /*
private string Encode ()
{
        var payload = new Dictionary<string, object>(){
                {}
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (string correo)
{
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (correo);
        string token = Encode ();

        return token;
}
public string CheckToken (string token)
{
        string result = null;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                string id = (string)ObtenerCORREO (decodedToken);

                UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (id);

                if (en != null && ((string)en.Correo).Equals (ObtenerCORREO (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception e)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}

        private string ObtenerCORREO(string decodedToken)
        {
            throw new NotImplementedException();
        }*/
    }
}
