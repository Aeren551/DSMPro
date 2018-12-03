

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
 *      Definition of the class EntradaCEN
 *
 */
public partial class EntradaCEN
{
private IEntradaCAD _IEntradaCAD;

public EntradaCEN()
{
        this._IEntradaCAD = new EntradaCAD ();
}

public EntradaCEN(IEntradaCAD _IEntradaCAD)
{
        this._IEntradaCAD = _IEntradaCAD;
}

public IEntradaCAD get_IEntradaCAD ()
{
        return this._IEntradaCAD;
}

public int New_ (double p_precio, bool p_vendida, int p_eventoPago)
{
        EntradaEN entradaEN = null;
        int oid;

        //Initialized EntradaEN
        entradaEN = new EntradaEN ();
        entradaEN.Precio = p_precio;

        entradaEN.Vendida = p_vendida;


        if (p_eventoPago != -1) {
                // El argumento p_eventoPago -> Property eventoPago es oid = false
                // Lista de oids id
                entradaEN.EventoPago = new DSMGenNHibernate.EN.DSM.EventoPagoEN ();
                entradaEN.EventoPago.Id = p_eventoPago;
        }

        //Call to EntradaCAD

        oid = _IEntradaCAD.New_ (entradaEN);
        return oid;
}

public void Modify (int p_Entrada_OID, double p_precio, bool p_vendida)
{
        EntradaEN entradaEN = null;

        //Initialized EntradaEN
        entradaEN = new EntradaEN ();
        entradaEN.Id = p_Entrada_OID;
        entradaEN.Precio = p_precio;
        entradaEN.Vendida = p_vendida;
        //Call to EntradaCAD

        _IEntradaCAD.Modify (entradaEN);
}

public void Destroy (int id
                     )
{
        _IEntradaCAD.Destroy (id);
}

public EntradaEN ReadOID (int id
                          )
{
        EntradaEN entradaEN = null;

        entradaEN = _IEntradaCAD.ReadOID (id);
        return entradaEN;
}

public System.Collections.Generic.IList<EntradaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EntradaEN> list = null;

        list = _IEntradaCAD.ReadAll (first, size);
        return list;
}
}
}
