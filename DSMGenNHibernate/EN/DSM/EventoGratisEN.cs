
using System;
// Definición clase EventoGratisEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class EventoGratisEN                                                                 : DSMGenNHibernate.EN.DSM.EventoEN


{
/**
 *	Atributo aforo
 */
private int aforo;






public virtual int Aforo {
        get { return aforo; } set { aforo = value;  }
}





public EventoGratisEN() : base ()
{
}



public EventoGratisEN(int id, int aforo
                      , string lugar, Nullable<DateTime> fecha, DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum tipo, string descripcion, string nombre, DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum genero, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.AsistenteEN> asistente, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> grupo, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.ComentarioEN> comentario, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> premio
                      )
{
        this.init (Id, aforo, lugar, fecha, tipo, descripcion, nombre, genero, asistente, grupo, comentario, premio);
}


public EventoGratisEN(EventoGratisEN eventoGratis)
{
        this.init (Id, eventoGratis.Aforo, eventoGratis.Lugar, eventoGratis.Fecha, eventoGratis.Tipo, eventoGratis.Descripcion, eventoGratis.Nombre, eventoGratis.Genero, eventoGratis.Asistente, eventoGratis.Grupo, eventoGratis.Comentario, eventoGratis.Premio);
}

private void init (int id
                   , int aforo, string lugar, Nullable<DateTime> fecha, DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum tipo, string descripcion, string nombre, DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum genero, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.AsistenteEN> asistente, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> grupo, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.ComentarioEN> comentario, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> premio)
{
        this.Id = id;


        this.Aforo = aforo;

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
        EventoGratisEN t = obj as EventoGratisEN;
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
