
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface IPremioCAD
{
PremioEN ReadOIDDefault (int id
                         );

void ModifyDefault (PremioEN premio);

System.Collections.Generic.IList<PremioEN> ReadAllDefault (int first, int size);



int CrearPremio (PremioEN premio);

void Modify (PremioEN premio);


void Destroy (int id
              );


PremioEN ReadOID (int id
                  );


System.Collections.Generic.IList<PremioEN> ReadAll (int first, int size);


void AnyadirPremio (int p_Premio_OID, string p_asistente_OID);
}
}
