
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface IComentarioCAD
{
ComentarioEN ReadOIDDefault (int id
                             );

void ModifyDefault (ComentarioEN comentario);

System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size);



int CrearComentario (ComentarioEN comentario);

void EditarComentario (ComentarioEN comentario);


void BorrarComentario (int id
                       );


ComentarioEN ReadOID (int id
                      );


System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size);


void VincEvento (int p_Comentario_OID, int p_evento_OID);


void VincAsistente (int p_Comentario_OID, string p_asistente_OID);
}
}
