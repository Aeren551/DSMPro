
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface IEntradaCAD
{
EntradaEN ReadOIDDefault (int id
                          );

void ModifyDefault (EntradaEN entrada);

System.Collections.Generic.IList<EntradaEN> ReadAllDefault (int first, int size);



int New_ (EntradaEN entrada);

void Modify (EntradaEN entrada);


void Destroy (int id
              );


EntradaEN ReadOID (int id
                   );


System.Collections.Generic.IList<EntradaEN> ReadAll (int first, int size);
}
}
