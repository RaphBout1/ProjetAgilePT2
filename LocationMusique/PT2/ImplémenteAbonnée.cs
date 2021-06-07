using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2
{
    class ImplémenteAbonnée
    {
        public static void ImplementeAbonnée()
        {
            MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
            ABONNÉS a = new ABONNÉS();
            a.CODE_PAYS = 1;
            a.NOM_ABONNÉ = "De La Cour";
            a.PRÉNOM_ABONNÉ = "Robert";
            a.LOGIN_ABONNÉ = "Robert_DLC";
            a.PASSWORD_ABONNÉ = "1234";
            if (musiqueSQL.ABONNÉS.Contains(a))
            {
                musiqueSQL.ABONNÉS.Add(a);
            }
            musiqueSQL.SaveChanges();
            a = new ABONNÉS();
            a.CODE_PAYS = 1;
            a.NOM_ABONNÉ = "Histor";
            a.PRÉNOM_ABONNÉ = "Victor";
            a.LOGIN_ABONNÉ = "L'historien";
            a.PASSWORD_ABONNÉ = "Histoire";
            if (musiqueSQL.ABONNÉS.Contains(a))
            {
                musiqueSQL.ABONNÉS.Add(a);
            }
            musiqueSQL.SaveChanges();
        }
    }
}
