
using System;
// Definición clase EventoEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class EventoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo lugar
 */
private string lugar;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo tipo
 */
private DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum tipo;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo genero
 */
private DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum genero;



/**
 *	Atributo asistente
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.AsistenteEN> asistente;



/**
 *	Atributo grupo
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> grupo;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.ComentarioEN> comentario;



/**
 *	Atributo premio
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> premio;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Lugar {
        get { return lugar; } set { lugar = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum Genero {
        get { return genero; } set { genero = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.AsistenteEN> Asistente {
        get { return asistente; } set { asistente = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> Grupo {
        get { return grupo; } set { grupo = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> Premio {
        get { return premio; } set { premio = value;  }
}





public EventoEN()
{
        asistente = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.AsistenteEN>();
        grupo = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.GrupoEN>();
        comentario = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.ComentarioEN>();
        premio = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.PremioEN>();
}



public EventoEN(int id, string lugar, Nullable<DateTime> fecha, DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum tipo, string descripcion, string nombre, DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum genero, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.AsistenteEN> asistente, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> grupo, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.ComentarioEN> comentario, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> premio
                )
{
        this.init (Id, lugar, fecha, tipo, descripcion, nombre, genero, asistente, grupo, comentario, premio);
}


public EventoEN(EventoEN evento)
{
        this.init (Id, evento.Lugar, evento.Fecha, evento.Tipo, evento.Descripcion, evento.Nombre, evento.Genero, evento.Asistente, evento.Grupo, evento.Comentario, evento.Premio);
}

private void init (int id
                   , string lugar, Nullable<DateTime> fecha, DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum tipo, string descripcion, string nombre, DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum genero, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.AsistenteEN> asistente, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> grupo, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.ComentarioEN> comentario, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> premio)
{
        this.Id = id;


        this.Lugar = lugar;

        this.Fecha = fecha;

        this.Tipo = tipo;

        this.Descripcion = descripcion;

        this.Nombre = nombre;

        this.Genero = genero;

        this.Asistente = asistente;

        this.Grupo = grupo;

        this.Comentario = comentario;

        this.Premio = premio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EventoEN t = obj as EventoEN;
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
