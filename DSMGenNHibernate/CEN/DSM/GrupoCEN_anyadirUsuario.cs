
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


/*PROTECTED REGION ID(usingDSMGenNHibernate.CEN.DSM_Grupo_anyadirUsuario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGenNHibernate.CEN.DSM
{
public partial class GrupoCEN
{
public void AnyadirUsuario (int p_Grupo_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        /*PROTECTED REGION ID(DSMGenNHibernate.CEN.DSM_Grupo_anyadirUsuario_customized) START*/


        //Call to GrupoCAD

        _IGrupoCAD.AnyadirUsuario (p_Grupo_OID, p_usuario_OIDs);

        /*PROTECTED REGION END*/
}
}
}
