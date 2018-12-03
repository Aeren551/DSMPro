

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
 *      Definition of the class EventoCEN
 *
 */
public partial class EventoCEN
{
private IEventoCAD _IEventoCAD;

public EventoCEN()
{
        this._IEventoCAD = new EventoCAD ();
}

public EventoCEN(IEventoCAD _IEventoCAD)
{
        this._IEventoCAD = _IEventoCAD;
}

public IEventoCAD get_IEventoCAD ()
{
        return this._IEventoCAD;
}

public void ModificarEvento (int p_Evento_OID, string p_lugar, Nullable<DateTime> p_fecha, DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum p_tipo, string p_descripcion, string p_nombre, DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum p_genero)
{
        EventoEN eventoEN = null;

        //Initialized EventoEN
        eventoEN = new EventoEN ();
        eventoEN.Id = p_Evento_OID;
        eventoEN.Lugar = p_lugar;
        eventoEN.Fecha = p_fecha;
        eventoEN.Tipo = p_tipo;
        eventoEN.Descripcion = p_descripcion;
        eventoEN.Nombre = p_nombre;
        eventoEN.Genero = p_genero;
        //Call to EventoCAD

        _IEventoCAD.ModificarEvento (eventoEN);
}

public void BorrarEvento (int id
                          )
{
        _IEventoCAD.BorrarEvento (id);
}

public EventoEN ReadOID (int id
                         )
{
        EventoEN eventoEN = null;

        eventoEN = _IEventoCAD.ReadOID (id);
        return eventoEN;
}

public System.Collections.Generic.IList<EventoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EventoEN> list = null;

        list = _IEventoCAD.ReadAll (first, size);
        return list;
}
}
}
