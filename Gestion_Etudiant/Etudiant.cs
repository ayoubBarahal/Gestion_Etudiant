using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant
{
    internal class Etudiant
    {

        private int code;
        private String name;
        private String prenom;
        private String filiere;

        public Etudiant()
        {

        }

        public Etudiant(int code, string name, string prenom, string filiere)
        {
            this.code = code;
            this.name = name;
            this.prenom = prenom;
            this.filiere = filiere;
        }

        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public string Filiere
        {
            get { return filiere; }
            set { filiere = value; }
        }


    }
}
