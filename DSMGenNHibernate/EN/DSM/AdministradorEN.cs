
using System;
// Definición clase AdministradorEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class AdministradorEN                                                                        : DSMGenNHibernate.EN.DSM.UsuarioEN


{
public AdministradorEN() : base ()
{
}



public AdministradorEN(string correo,
                       string nombre, String contrasenya, string foto, string direccion, int telefono, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> grupo, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje_1
                       )
{
        this.init (Correo, nombre, contrasenya, foto, direccion, telefono, grupo, mensaje, mensaje_1);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (Correo, administrador.Nombre, administrador.Contrasenya, administrador.Foto, administrador.Direccion, administrador.Telefono, administrador.Grupo, administrador.Mensaje, administrador.Mensaje_1);
}

private void init (string correo
                   , string nombre, String contrasenya, string foto, string direccion, int telefono, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> grupo, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje_1)
{
        this.Correo = correo;


        this.Nombre = nombre;

        this.Contrasenya = contrasenya;

        this.Foto = foto;

        this.Direccion = direccion;

        this.Telefono = telefono;

        this.Grupo = grupo;

        this.Mensaje = mensaje;

        this.Mensaje_1 = mensaje_1;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
        if (t == null)
                return false;
        if (Correo.Equals (t.Correo))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Correo.GetHashCode ();
        return hash;
}
}
}
