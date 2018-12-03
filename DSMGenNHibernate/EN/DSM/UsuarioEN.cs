
using System;
// Definición clase UsuarioEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class UsuarioEN
{
/**
 *	Atributo correo
 */
private string correo;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo contrasenya
 */
private String contrasenya;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo telefono
 */
private int telefono;



/**
 *	Atributo grupo
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> grupo;



/**
 *	Atributo mensaje
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje;



/**
 *	Atributo mensaje_1
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje_1;






public virtual string Correo {
        get { return correo; } set { correo = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual String Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual int Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> Grupo {
        get { return grupo; } set { grupo = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> Mensaje {
        get { return mensaje; } set { mensaje = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> Mensaje_1 {
        get { return mensaje_1; } set { mensaje_1 = value;  }
}





public UsuarioEN()
{
        grupo = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.GrupoEN>();
        mensaje = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.MensajeEN>();
        mensaje_1 = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.MensajeEN>();
}



public UsuarioEN(string correo, string nombre, String contrasenya, string foto, string direccion, int telefono, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> grupo, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje_1
                 )
{
        this.init (Correo, nombre, contrasenya, foto, direccion, telefono, grupo, mensaje, mensaje_1);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Correo, usuario.Nombre, usuario.Contrasenya, usuario.Foto, usuario.Direccion, usuario.Telefono, usuario.Grupo, usuario.Mensaje, usuario.Mensaje_1);
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
        UsuarioEN t = obj as UsuarioEN;
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
