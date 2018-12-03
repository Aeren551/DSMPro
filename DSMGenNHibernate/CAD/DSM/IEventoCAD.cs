
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface IEventoCAD
{
EventoEN ReadOIDDefault (int id
                         );

void ModifyDefault (EventoEN evento);

System.Collections.Generic.IList<EventoEN> ReadAllDefault (int first, int size);



int CrearEvento (EventoEN evento);

void ModificarEvento (EventoEN evento);


void BorrarEvento (int id
                   );


EventoEN ReadOID (int id
                  );


System.Collections.Generic.IList<EventoEN> ReadAll (int first, int size);
}
}
