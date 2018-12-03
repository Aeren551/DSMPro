
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.CAD.DSM;
using DSMGenNHibernate.CEN.DSM;



/*PROTECTED REGION ID(usingDSMGenNHibernate.CP.DSM_Comentario_crearComentario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGenNHibernate.CP.DSM
{
public partial class ComentarioCP : BasicCP
{
public DSMGenNHibernate.EN.DSM.ComentarioEN CrearComentario (int p_evento, string p_asistente, string p_titulo, string p_texto, int p_likes)
{
        /*PROTECTED REGION ID(DSMGenNHibernate.CP.DSM_Comentario_crearComentario) ENABLED START*/

        IComentarioCAD comentarioCAD = null;
        ComentarioCEN comentarioCEN = null;

        DSMGenNHibernate.EN.DSM.ComentarioEN result = null;


        try
        {
                SessionInitializeTransaction ();
                comentarioCAD = new ComentarioCAD (session);
                comentarioCEN = new ComentarioCEN (comentarioCAD);




                int oid;
                //Initialized ComentarioEN
                ComentarioEN comentarioEN;
                comentarioEN = new ComentarioEN ();

                if (p_evento != -1) {
                        comentarioEN.Evento = new DSMGenNHibernate.EN.DSM.EventoEN ();
                        comentarioEN.Evento.Id = p_evento;
                }


                if (p_asistente != null) {
                        comentarioEN.Asistente = new DSMGenNHibernate.EN.DSM.AsistenteEN ();
                        comentarioEN.Asistente.Correo = p_asistente;
                }

                comentarioEN.Titulo = p_titulo;

                comentarioEN.Texto = p_texto;

                comentarioEN.Likes = 0;

                //Call to ComentarioCAD

                oid = comentarioCAD.CrearComentario (comentarioEN);
                result = comentarioCAD.ReadOIDDefault (oid);

                //yo creo que esta cp seria solo vincular porque no hay ningun metodo entre medias que se tenga que disparar


                //vincular comentario al evento
                comentarioCEN.VincEvento (comentarioEN.Id, p_evento);
                //vincular comentario al asistente
                comentarioCEN.VincAsistente (p_evento, p_asistente);







                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
