
using System;
// Definición clase AsistenteEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class AsistenteEN                                                                    : DSMGenNHibernate.EN.DSM.UsuarioEN


{
/**
 *	Atributo evento
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.EventoEN> evento;



/**
 *	Atributo premio
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> premio;



/**
 *	Atributo comentario_0
 */
private DSMGenNHibernate.EN.DSM.ComentarioEN comentario_0;






public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.EventoEN> Evento {
        get { return evento; } set { evento = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> Premio {
        get { return premio; } set { premio = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.ComentarioEN Comentario_0 {
        get { return comentario_0; } set { comentario_0 = value;  }
}





public AsistenteEN() : base ()
{
        evento = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.EventoEN>();
        premio = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.PremioEN>();
}



public AsistenteEN(string correo, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.EventoEN> evento, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> premio, DSMGenNHibernate.EN.DSM.ComentarioEN comentario_0
                   , string nombre, String contrasenya, string foto, string direccion, int telefono, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> grupo, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje_1
                   )
{
        this.init (Correo, evento, premio, comentario_0, nombre, contrasenya, foto, direccion, telefono, grupo, mensaje, mensaje_1);
}


public AsistenteEN(AsistenteEN asistente)
{
        this.init (Correo, asistente.Evento, asistente.Premio, asistente.Comentario_0, asistente.Nombre, asistente.Contrasenya, asistente.Foto, asistente.Direccion, asistente.Telefono, asistente.Grupo, asistente.Mensaje, asistente.Mensaje_1);
}

private void init (string correo
                   , System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.EventoEN> evento, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.PremioEN> premio, DSMGenNHibernate.EN.DSM.ComentarioEN comentario_0, string nombre, String contrasenya, string foto, string direccion, int telefono, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.GrupoEN> grupo, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje_1)
{
        this.Correo = correo;


        this.Evento = evento;

        this.Premio = premio;

        this.Comentario_0 = comentario_0;

        this.Nombre = nombre;

        this.Contrasenya = contrasenya;

        this.Foto = foto;

        this.Direccion = direccion;

        this.Telefono = telefono;

        this.Grupo = grupo;

        this.Mensaje = mensaje;

        this.Mensaje_1 = mensaje_1;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AsistenteEN t = obj as AsistenteEN;
        if (t == null)
                return false;
        if (Correo.Equals (t.Correo))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Correo.GetHashCode ();
        return hash;
}
}
}
