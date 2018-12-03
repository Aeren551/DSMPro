
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string correo
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



string CrearUsuario (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (string correo
              );


UsuarioEN ReadOID (string correo
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);
}
}
