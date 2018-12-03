
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGenNHibernate.Exceptions;
using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.CAD.DSM;


/*PROTECTED REGION ID(usingDSMGenNHibernate.CEN.DSM_Comentario_darLike) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGenNHibernate.CEN.DSM
{
public partial class ComentarioCEN
{
public void DarLike (int p_oid)
{
        /*PROTECTED REGION ID(DSMGenNHibernate.CEN.DSM_Comentario_darLike) ENABLED START*/

        // Write here your custom code...
        ComentarioCAD comentarioCAD = new ComentarioCAD ();
        ComentarioEN comentarioEN = new ComentarioEN ();

        comentarioEN = comentarioCAD.ReadOIDDefault (p_oid);
        comentarioEN.Likes = comentarioEN.Likes + 1;

        /*PROTECTED REGION END*/
}
}
}
