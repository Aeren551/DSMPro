
using System;
// Definición clase EventoPagoEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class EventoPagoEN                                                                   : DSMGenNHibernate.EN.DSM.EventoEN


{
/**
 *	Atributo entradas
 */
private int entradas;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo entrada
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.EntradaEN> entrada;






public virtual int Entradas {
        get { return entradas; } set { entradas = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.EntradaEN> Entrada {
        get { return entrada; } set { entrada = value;  }
}





public EventoPagoEN() : base ()
{
        entrada = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.EntradaEN>();
}



public EventoPagoEN(int id, int entradas, double precio, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.EntradaEN> entrada
                    , string lugar, Nullable<DateTime> fecha, DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum tipo, string descripcion, string nombre, DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum genero, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.AsistenteEN> asistente, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> grupo, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.ComentarioEN> comentario, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> premio
                    )
{
        this.init (Id, entradas, precio, entrada, lugar, fecha, tipo, descripcion, nombre, genero, asistente, grupo, comentario, premio);
}


public EventoPagoEN(EventoPagoEN eventoPago)
{
        this.init (Id, eventoPago.Entradas, eventoPago.Precio, eventoPago.Entrada, eventoPago.Lugar, eventoPago.Fecha, eventoPago.Tipo, eventoPago.Descripcion, eventoPago.Nombre, eventoPago.Genero, eventoPago.Asistente, eventoPago.Grupo, eventoPago.Comentario, eventoPago.Premio);
}

private void init (int id
                   , int entradas, double precio, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.EntradaEN> entrada, string lugar, Nullable<DateTime> fecha, DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum tipo, string descripcion, string nombre, DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum genero, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.AsistenteEN> asistente, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> grupo, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.ComentarioEN> comentario, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> premio)
{
        this.Id = id;


        this.Entradas = entradas;

        this.Precio = precio;

        this.Entrada = entrada;

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
        EventoPagoEN t = obj as EventoPagoEN;
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
