
using System;
// Definición clase EntradaEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class EntradaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo vendida
 */
private bool vendida;



/**
 *	Atributo eventoPago
 */
private DSMGenNHibernate.EN.DSM.EventoPagoEN eventoPago;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual bool Vendida {
        get { return vendida; } set { vendida = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.EventoPagoEN EventoPago {
        get { return eventoPago; } set { eventoPago = value;  }
}





public EntradaEN()
{
}



public EntradaEN(int id, double precio, bool vendida, DSMGenNHibernate.EN.DSM.EventoPagoEN eventoPago
                 )
{
        this.init (Id, precio, vendida, eventoPago);
}


public EntradaEN(EntradaEN entrada)
{
        this.init (Id, entrada.Precio, entrada.Vendida, entrada.EventoPago);
}

private void init (int id
                   , double precio, bool vendida, DSMGenNHibernate.EN.DSM.EventoPagoEN eventoPago)
{
        this.Id = id;


        this.Precio = precio;

        this.Vendida = vendida;

        this.EventoPago = eventoPago;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EntradaEN t = obj as EntradaEN;
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
