using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GESTION_CHAMBRE_HOTEL.Classes;

namespace GESTION_CHAMBRE_HOTEL.Formulaires
{
    public partial class FrmReservation : Form
    {
        public FrmReservation()
        {
            InitializeComponent();
        }

        ClsReservation res = new ClsReservation();

        void InsertUpdateDelete(int a)
        {
            res.RefClient1 = int.Parse(ClsGlossiarie.GetInstance().getcode_Combo("tClient", "Id", "Nom", cmbClient.Text));
            res.RefChambre1 = int.Parse(ClsGlossiarie.GetInstance().getcode_Combo("tChambre", "Id", "Numero", cmbChambre.Text));
            res.DateEntree1 = DateTime.Parse(txtdateentree.Text);
            res.DateSortie1 = DateTime.Parse(txtdatesortie.Text);
            if (a == 1)
            {
                res.Id1 = -1;
                ClsGlossiarie.GetInstance().InsertUpdateReservation(res);
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("AfficheClientChambre");
            }
            else if (a == 2)
            {
                res.Id1 = int.Parse(txtId.Text);
                ClsGlossiarie.GetInstance().InsertUpdateReservation(res);
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("AfficheClientChambre");
            }
            else if (a == 3)
            {
                ClsGlossiarie.GetInstance().DeleteData("tReservation", "Id", int.Parse(txtId.Text));
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("AfficheClientChambre");
            }
        }

        private void FrmChambre_Load(object sender, EventArgs e)
        {
            ClsGlossiarie.GetInstance().loadCombo("tClient", "nom", cmbClient);
            ClsGlossiarie.GetInstance().loadCombo("tChambre", "numero", cmbChambre);
            dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("AfficheClientChambre");
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            cmbClient.Text = "";
            cmbChambre.Text = "";
            txtdateentree.Text = "";
            txtdatesortie.Text = "";
        }

        private void btnEnreg_Click(object sender, EventArgs e)
        {
            InsertUpdateDelete(1);
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            InsertUpdateDelete(2);
        }

        private void btnSuppr_Click(object sender, EventArgs e)
        {
            InsertUpdateDelete(3);
        }
    }
}
