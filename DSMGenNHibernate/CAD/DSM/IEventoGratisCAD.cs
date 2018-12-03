
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface IEventoGratisCAD
{
EventoGratisEN ReadOIDDefault (int id
                               );

void ModifyDefault (EventoGratisEN eventoGratis);

System.Collections.Generic.IList<EventoGratisEN> ReadAllDefault (int first, int size);



EventoGratisEN ReadOID (int id
                        );


System.Collections.Generic.IList<EventoGratisEN> ReadAll (int first, int size);


int CrearEvento (EventoGratisEN eventoGratis);

void Modify (EventoGratisEN eventoGratis);


void Destroy (int id
              );
}
}
