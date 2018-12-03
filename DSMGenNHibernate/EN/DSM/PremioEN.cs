
using System;
// Definición clase PremioEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class PremioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo evento
 */
private DSMGenNHibernate.EN.DSM.EventoEN evento;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo asistente
 */
private DSMGenNHibernate.EN.DSM.AsistenteEN asistente;



/**
 *	Atributo grupo
 */
private DSMGenNHibernate.EN.DSM.GrupoEN grupo;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.EventoEN Evento {
        get { return evento; } set { evento = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.AsistenteEN Asistente {
        get { return asistente; } set { asistente = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.GrupoEN Grupo {
        get { return grupo; } set { grupo = value;  }
}





public PremioEN()
{
}



public PremioEN(int id, string descripcion, DSMGenNHibernate.EN.DSM.EventoEN evento, string nombre, DSMGenNHibernate.EN.DSM.AsistenteEN asistente, DSMGenNHibernate.EN.DSM.GrupoEN grupo
                )
{
        this.init (Id, descripcion, evento, nombre, asistente, grupo);
}


public PremioEN(PremioEN premio)
{
        this.init (Id, premio.Descripcion, premio.Evento, premio.Nombre, premio.Asistente, premio.Grupo);
}

private void init (int id
                   , string descripcion, DSMGenNHibernate.EN.DSM.EventoEN evento, string nombre, DSMGenNHibernate.EN.DSM.AsistenteEN asistente, DSMGenNHibernate.EN.DSM.GrupoEN grupo)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Evento = evento;

        this.Nombre = nombre;

        this.Asistente = asistente;

        this.Grupo = grupo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PremioEN t = obj as PremioEN;
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
