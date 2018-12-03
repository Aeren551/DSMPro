
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface IAsistenteCAD
{
AsistenteEN ReadOIDDefault (string correo
                            );

void ModifyDefault (AsistenteEN asistente);

System.Collections.Generic.IList<AsistenteEN> ReadAllDefault (int first, int size);



void Modify (AsistenteEN asistente);


void Destroy (string correo
              );


AsistenteEN ReadOID (string correo
                     );


System.Collections.Generic.IList<AsistenteEN> ReadAll (int first, int size);



string CrearUsuario (AsistenteEN asistente);
}
}
