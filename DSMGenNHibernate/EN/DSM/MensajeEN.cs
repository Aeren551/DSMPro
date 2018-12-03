
using System;
// Definición clase MensajeEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class MensajeEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo mensaje
 */
private string mensaje;



/**
 *	Atributo leido
 */
private bool leido;



/**
 *	Atributo usuario
 */
private DSMGenNHibernate.EN.DSM.UsuarioEN usuario;



/**
 *	Atributo usuario_0
 */
private DSMGenNHibernate.EN.DSM.UsuarioEN usuario_0;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Mensaje {
        get { return mensaje; } set { mensaje = value;  }
}



public virtual bool Leido {
        get { return leido; } set { leido = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.UsuarioEN Usuario_0 {
        get { return usuario_0; } set { usuario_0 = value;  }
}





public MensajeEN()
{
}



public MensajeEN(int id, string mensaje, bool leido, DSMGenNHibernate.EN.DSM.UsuarioEN usuario, DSMGenNHibernate.EN.DSM.UsuarioEN usuario_0
                 )
{
        this.init (Id, mensaje, leido, usuario, usuario_0);
}


public MensajeEN(MensajeEN mensaje)
{
        this.init (Id, mensaje.Mensaje, mensaje.Leido, mensaje.Usuario, mensaje.Usuario_0);
}

private void init (int id
                   , string mensaje, bool leido, DSMGenNHibernate.EN.DSM.UsuarioEN usuario, DSMGenNHibernate.EN.DSM.UsuarioEN usuario_0)
{
        this.Id = id;


        this.Mensaje = mensaje;

        this.Leido = leido;

        this.Usuario = usuario;

        this.Usuario_0 = usuario_0;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MensajeEN t = obj as MensajeEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
