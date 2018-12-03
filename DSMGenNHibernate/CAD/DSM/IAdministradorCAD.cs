
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (string correo
                                );

void ModifyDefault (AdministradorEN administrador);

System.Collections.Generic.IList<AdministradorEN> ReadAllDefault (int first, int size);



AdministradorEN ReadOID (string correo
                         );


System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size);


string CrearUsuario (AdministradorEN administrador);

void Modify (AdministradorEN administrador);


void Destroy (string correo
              );
}
}
