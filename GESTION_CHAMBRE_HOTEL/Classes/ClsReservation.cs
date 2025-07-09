using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CHAMBRE_HOTEL.Classes
{
    class ClsReservation
    {
        int Id;
        int RefClient;
        int RefChambre;
        DateTime DateEntree;
        DateTime DateSortie;

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

        public int RefClient1
        {
            get
            {
                return RefClient;
            }

            set
            {
                RefClient = value;
            }
        }

        public int RefChambre1
        {
            get
            {
                return RefChambre;
            }

            set
            {
                RefChambre = value;
            }
        }

        public DateTime DateEntree1
        {
            get
            {
                return DateEntree;
            }

            set
            {
                DateEntree = value;
            }
        }

        public DateTime DateSortie1
        {
            get
            {
                return DateSortie;
            }

            set
            {
                DateSortie = value;
            }
        }
    }
}
