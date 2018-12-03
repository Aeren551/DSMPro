
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface IGrupoCAD
{
GrupoEN ReadOIDDefault (int id
                        );

void ModifyDefault (GrupoEN grupo);

System.Collections.Generic.IList<GrupoEN> ReadAllDefault (int first, int size);



int CrearGrupo (GrupoEN grupo);

void Modify (GrupoEN grupo);


void Destroy (int id
              );


void AnyadirUsuario (int p_Grupo_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);

void EliminarUsuario (int p_Grupo_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);

GrupoEN ReadOID (int id
                 );


System.Collections.Generic.IList<GrupoEN> ReadAll (int first, int size);
}
}
