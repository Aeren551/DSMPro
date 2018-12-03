

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
 *      Definition of the class EventoGratisCEN
 *
 */
public partial class EventoGratisCEN
{
private IEventoGratisCAD _IEventoGratisCAD;

public EventoGratisCEN()
{
        this._IEventoGratisCAD = new EventoGratisCAD ();
}

public EventoGratisCEN(IEventoGratisCAD _IEventoGratisCAD)
{
        this._IEventoGratisCAD = _IEventoGratisCAD;
}

public IEventoGratisCAD get_IEventoGratisCAD ()
{
        return this._IEventoGratisCAD;
}

public EventoGratisEN ReadOID (int id
                               )
{
        EventoGratisEN eventoGratisEN = null;

        eventoGratisEN = _IEventoGratisCAD.ReadOID (id);
        return eventoGratisEN;
}

public System.Collections.Generic.IList<EventoGratisEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EventoGratisEN> list = null;

        list = _IEventoGratisCAD.ReadAll (first, size);
        return list;
}
public int CrearEvento (string p_lugar, Nullable<DateTime> p_fecha, DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum p_tipo, string p_descripcion, string p_nombre, DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum p_genero, int p_aforo)
{
        EventoGratisEN eventoGratisEN = null;
        int oid;

        //Initialized EventoGratisEN
        eventoGratisEN = new EventoGratisEN ();
        eventoGratisEN.Lugar = p_lugar;

        eventoGratisEN.Fecha = p_fecha;

        eventoGratisEN.Tipo = p_tipo;

        eventoGratisEN.Descripcion = p_descripcion;

        eventoGratisEN.Nombre = p_nombre;

        eventoGratisEN.Genero = p_genero;

        eventoGratisEN.Aforo = p_aforo;

        //Call to EventoGratisCAD

        oid = _IEventoGratisCAD.CrearEvento (eventoGratisEN);
        return oid;
}

public void Modify (int p_EventoGratis_OID, string p_lugar, Nullable<DateTime> p_fecha, DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum p_tipo, string p_descripcion, string p_nombre, DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum p_genero, int p_aforo)
{
        EventoGratisEN eventoGratisEN = null;

        //Initialized EventoGratisEN
        eventoGratisEN = new EventoGratisEN ();
        eventoGratisEN.Id = p_EventoGratis_OID;
        eventoGratisEN.Lugar = p_lugar;
        eventoGratisEN.Fecha = p_fecha;
        eventoGratisEN.Tipo = p_tipo;
        eventoGratisEN.Descripcion = p_descripcion;
        eventoGratisEN.Nombre = p_nombre;
        eventoGratisEN.Genero = p_genero;
        eventoGratisEN.Aforo = p_aforo;
        //Call to EventoGratisCAD

        _IEventoGratisCAD.Modify (eventoGratisEN);
}

public void Destroy (int id
                     )
{
        _IEventoGratisCAD.Destroy (id);
}
}
}
