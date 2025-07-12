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
    public partial class FrmClient : Form
    {
        public FrmClient()
        {
            InitializeComponent();
        }

        ClsClient cli = new ClsClient();

        void InsertUpdateDelete(int a)
        {
            cli.Nom1 = txtNom.Text;
            cli.Adresse1 = txtAdres.Text;
            cli.Contact1 = txtContact.Text;
            cli.RefCategorisation1 = int.Parse(ClsGlossiarie.GetInstance().getcode_Combo("tCategorisation", "Id", "designation", cmbCategor.Text));
            if (a == 1)
            {
                cli.Id1 = -1;
                ClsGlossiarie.GetInstance().InsertUpdateClient(cli);
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("AfficherCategorisation");
            }
            else if (a == 2)
            {
                cli.Id1 = int.Parse(txtId.Text);
                ClsGlossiarie.GetInstance().InsertUpdateClient(cli);
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("AfficherCategorisation");
            }
            else if (a == 3)
            {
                ClsGlossiarie.GetInstance().DeleteData("tClient", "Id", int.Parse(txtId.Text));
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("AfficherCategorisation");
            }
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNom.Text = "";
            txtAdres.Text = "";
            txtContact.Text = "";
            cmbCategor.Text = "";
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            ClsGlossiarie.GetInstance().loadCombo("tCategorisation", "designation", cmbCategor);
            dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("AfficherCategorisation");
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
