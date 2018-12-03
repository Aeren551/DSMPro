

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
 *      Definition of the class PremioCEN
 *
 */
public partial class PremioCEN
{
private IPremioCAD _IPremioCAD;

public PremioCEN()
{
        this._IPremioCAD = new PremioCAD ();
}

public PremioCEN(IPremioCAD _IPremioCAD)
{
        this._IPremioCAD = _IPremioCAD;
}

public IPremioCAD get_IPremioCAD ()
{
        return this._IPremioCAD;
}

public int CrearPremio (string p_descripcion, int p_evento, string p_nombre, string p_asistente, int p_grupo)
{
        PremioEN premioEN = null;
        int oid;

        //Initialized PremioEN
        premioEN = new PremioEN ();
        premioEN.Descripcion = p_descripcion;


        if (p_evento != -1) {
                // El argumento p_evento -> Property evento es oid = false
                // Lista de oids id
                premioEN.Evento = new DSMGenNHibernate.EN.DSM.EventoEN ();
                premioEN.Evento.Id = p_evento;
        }

        premioEN.Nombre = p_nombre;


        if (p_asistente != null) {
                // El argumento p_asistente -> Property asistente es oid = false
                // Lista de oids id
                premioEN.Asistente = new DSMGenNHibernate.EN.DSM.AsistenteEN ();
                premioEN.Asistente.Correo = p_asistente;
        }


        if (p_grupo != -1) {
                // El argumento p_grupo -> Property grupo es oid = false
                // Lista de oids id
                premioEN.Grupo = new DSMGenNHibernate.EN.DSM.GrupoEN ();
                premioEN.Grupo.Id = p_grupo;
        }

        //Call to PremioCAD

        oid = _IPremioCAD.CrearPremio (premioEN);
        return oid;
}

public void Modify (int p_Premio_OID, string p_descripcion, string p_nombre)
{
        PremioEN premioEN = null;

        //Initialized PremioEN
        premioEN = new PremioEN ();
        premioEN.Id = p_Premio_OID;
        premioEN.Descripcion = p_descripcion;
        premioEN.Nombre = p_nombre;
        //Call to PremioCAD

        _IPremioCAD.Modify (premioEN);
}

public void Destroy (int id
                     )
{
        _IPremioCAD.Destroy (id);
}

public PremioEN ReadOID (int id
                         )
{
        PremioEN premioEN = null;

        premioEN = _IPremioCAD.ReadOID (id);
        return premioEN;
}

public System.Collections.Generic.IList<PremioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PremioEN> list = null;

        list = _IPremioCAD.ReadAll (first, size);
        return list;
}
public void AnyadirPremio (int p_Premio_OID, string p_asistente_OID)
{
        //Call to PremioCAD

        _IPremioCAD.AnyadirPremio (p_Premio_OID, p_asistente_OID);
}
}
}
