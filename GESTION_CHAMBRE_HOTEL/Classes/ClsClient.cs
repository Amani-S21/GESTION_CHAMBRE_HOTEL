using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CHAMBRE_HOTEL.Classes
{
    class ClsClient
    {
        int Id;
        string Nom;
        string Adresse;
        string Contact;
        int RefCategorisation;

        public int Id1
        {
            get
            {
                return Id;
            }

            set
            {
                Id = value;
            }
        }

        public string Nom1
        {
            get
            {
                return Nom;
            }

            set
            {
                Nom = value;
            }
        }

        public string Adresse1
        {
            get
            {
                return Adresse;
            }

            set
            {
                Adresse = value;
            }
        }

        public string Contact1
        {
            get
            {
                return Contact;
            }

            set
            {
                Contact = value;
            }
        }

        public int RefCategorisation1
        {
            get
            {
                return RefCategorisation;
            }

            set
            {
                RefCategorisation = value;
            }
        }
    }
}
