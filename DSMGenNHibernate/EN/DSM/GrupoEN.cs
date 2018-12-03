
using System;
// Definición clase GrupoEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class GrupoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo evento
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.EventoEN> evento;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> usuario;



/**
 *	Atributo premio
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> premio;



/**
 *	Atributo cantidad
 */
private int cantidad;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.EventoEN> Evento {
        get { return evento; } set { evento = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> Premio {
        get { return premio; } set { premio = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}





public GrupoEN()
{
        evento = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.EventoEN>();
        usuario = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.UsuarioEN>();
        premio = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.PremioEN>();
}



public GrupoEN(int id, string nombre, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.EventoEN> evento, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> usuario, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> premio, int cantidad
               )
{
        this.init (Id, nombre, evento, usuario, premio, cantidad);
}


public GrupoEN(GrupoEN grupo)
{
        this.init (Id, grupo.Nombre, grupo.Evento, grupo.Usuario, grupo.Premio, grupo.Cantidad);
}

private void init (int id
                   , string nombre, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.EventoEN> evento, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> usuario, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> premio, int cantidad)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Evento = evento;

        this.Usuario = usuario;

        this.Premio = premio;

        this.Cantidad = cantidad;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GrupoEN t = obj as GrupoEN;
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
