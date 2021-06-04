using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PT2
{
    public partial class ABONNÉS
    {
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        public void abonner(string nom, string prenom, string pays, string login, string password)
        {
            if (nom.Length == 0 || prenom.Length == 0)
            {
                throw new InformationsInvalidesException("les champs nom et prénom ne doivent pas être vides");
            }
            int LoginCount = (from aa in musiqueSQL.ABONNÉS where aa.LOGIN_ABONNÉ == login select aa).Count();
            if (LoginCount != 0)
            {
                throw new InformationsInvalidesException("login déjà existant. Veuillez entrer un login différent.");
            }
            int paysInt = (from p in musiqueSQL.PAYS where p.NOM_PAYS == pays select p.CODE_PAYS).First();

            ABONNÉS a = new ABONNÉS
            {
                CODE_PAYS = paysInt,
                LOGIN_ABONNÉ = login,
                NOM_ABONNÉ = nom,
                PRÉNOM_ABONNÉ = prenom,
                PASSWORD_ABONNÉ = password
            };
            musiqueSQL.ABONNÉS.Add(a);
            musiqueSQL.SaveChanges();
        }
    }
}