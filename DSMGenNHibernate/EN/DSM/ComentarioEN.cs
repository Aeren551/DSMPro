
using System;
// Definición clase ComentarioEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class ComentarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo evento
 */
private DSMGenNHibernate.EN.DSM.EventoEN evento;



/**
 *	Atributo asistente
 */
private DSMGenNHibernate.EN.DSM.AsistenteEN asistente;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo texto
 */
private string texto;



/**
 *	Atributo likes
 */
private int likes;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.EventoEN Evento {
        get { return evento; } set { evento = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.AsistenteEN Asistente {
        get { return asistente; } set { asistente = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}



public virtual int Likes {
        get { return likes; } set { likes = value;  }
}





public ComentarioEN()
{
}



public ComentarioEN(int id, DSMGenNHibernate.EN.DSM.EventoEN evento, DSMGenNHibernate.EN.DSM.AsistenteEN asistente, string titulo, string texto, int likes
                    )
{
        this.init (Id, evento, asistente, titulo, texto, likes);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (Id, comentario.Evento, comentario.Asistente, comentario.Titulo, comentario.Texto, comentario.Likes);
}

private void init (int id
                   , DSMGenNHibernate.EN.DSM.EventoEN evento, DSMGenNHibernate.EN.DSM.AsistenteEN asistente, string titulo, string texto, int likes)
{
        this.Id = id;


        this.Evento = evento;

        this.Asistente = asistente;

        this.Titulo = titulo;

        this.Texto = texto;

        this.Likes = likes;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioEN t = obj as ComentarioEN;
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
