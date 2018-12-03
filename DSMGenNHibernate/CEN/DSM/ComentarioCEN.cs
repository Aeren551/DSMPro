

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGenNHibernate.Exceptions;

using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.CAD.DSM;


namespace DSMGenNHibernate.CEN.DSM
{
/*
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioCAD _IComentarioCAD;

public ComentarioCEN()
{
        this._IComentarioCAD = new ComentarioCAD ();
}

public ComentarioCEN(IComentarioCAD _IComentarioCAD)
{
        this._IComentarioCAD = _IComentarioCAD;
}

public IComentarioCAD get_IComentarioCAD ()
{
        return this._IComentarioCAD;
}

public void EditarComentario (int p_Comentario_OID, string p_titulo, string p_texto, int p_likes)
{
        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Id = p_Comentario_OID;
        comentarioEN.Titulo = p_titulo;
        comentarioEN.Texto = p_texto;
        comentarioEN.Likes = p_likes;
        //Call to ComentarioCAD

        _IComentarioCAD.EditarComentario (comentarioEN);
}

public void BorrarComentario (int id
                              )
{
        _IComentarioCAD.BorrarComentario (id);
}

public ComentarioEN ReadOID (int id
                             )
{
        ComentarioEN comentarioEN = null;

        comentarioEN = _IComentarioCAD.ReadOID (id);
        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> list = null;

        list = _IComentarioCAD.ReadAll (first, size);
        return list;
}
public void VincEvento (int p_Comentario_OID, int p_evento_OID)
{
        //Call to ComentarioCAD

        _IComentarioCAD.VincEvento (p_Comentario_OID, p_evento_OID);
}
public void VincAsistente (int p_Comentario_OID, string p_asistente_OID)
{
        //Call to ComentarioCAD

        _IComentarioCAD.VincAsistente (p_Comentario_OID, p_asistente_OID);
}
}
}
