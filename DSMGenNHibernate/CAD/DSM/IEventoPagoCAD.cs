
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface IEventoPagoCAD
{
EventoPagoEN ReadOIDDefault (int id
                             );

void ModifyDefault (EventoPagoEN eventoPago);

System.Collections.Generic.IList<EventoPagoEN> ReadAllDefault (int first, int size);



EventoPagoEN ReadOID (int id
                      );


System.Collections.Generic.IList<EventoPagoEN> ReadAll (int first, int size);


int CrearEvento (EventoPagoEN eventoPago);

void Modify (EventoPagoEN eventoPago);


void Destroy (int id
              );
}
}
