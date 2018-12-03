

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
 *      Definition of the class EventoPagoCEN
 *
 */
public partial class EventoPagoCEN
{
private IEventoPagoCAD _IEventoPagoCAD;

public EventoPagoCEN()
{
        this._IEventoPagoCAD = new EventoPagoCAD ();
}

public EventoPagoCEN(IEventoPagoCAD _IEventoPagoCAD)
{
        this._IEventoPagoCAD = _IEventoPagoCAD;
}

public IEventoPagoCAD get_IEventoPagoCAD ()
{
        return this._IEventoPagoCAD;
}

public EventoPagoEN ReadOID (int id
                             )
{
        EventoPagoEN eventoPagoEN = null;

        eventoPagoEN = _IEventoPagoCAD.ReadOID (id);
        return eventoPagoEN;
}

public System.Collections.Generic.IList<EventoPagoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EventoPagoEN> list = null;

        list = _IEventoPagoCAD.ReadAll (first, size);
        return list;
}
public void Modify (int p_EventoPago_OID, string p_lugar, Nullable<DateTime> p_fecha, DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum p_tipo, string p_descripcion, string p_nombre, DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum p_genero, int p_entradas, double p_precio)
{
        EventoPagoEN eventoPagoEN = null;

        //Initialized EventoPagoEN
        eventoPagoEN = new EventoPagoEN ();
        eventoPagoEN.Id = p_EventoPago_OID;
        eventoPagoEN.Lugar = p_lugar;
        eventoPagoEN.Fecha = p_fecha;
        eventoPagoEN.Tipo = p_tipo;
        eventoPagoEN.Descripcion = p_descripcion;
        eventoPagoEN.Nombre = p_nombre;
        eventoPagoEN.Genero = p_genero;
        eventoPagoEN.Entradas = p_entradas;
        eventoPagoEN.Precio = p_precio;
        //Call to EventoPagoCAD

        _IEventoPagoCAD.Modify (eventoPagoEN);
}

public void Destroy (int id
                     )
{
        _IEventoPagoCAD.Destroy (id);
}
}
}
