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
    public partial class FrmChambre : Form
    {
        public FrmChambre()
        {
            InitializeComponent();
        }

        ClsChambre cha = new ClsChambre();

        void InsertUpdateDelete(int a)
        {
            cha.Numero1 = int.Parse(txtNumero.Text);
            cha.Contact1 = txtContact.Text;
            cha.RefClasse1 = ClsGlossiarie.GetInstance().getcode_Combo("tClasse", "Id", "Designation", cmbClasse.Text);
            if (a == 1)
            {
                cha.Id1 = -1;
                ClsGlossiarie.GetInstance().InsertUpdateChambre(cha);
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("tChambre");
            }
            else if (a == 2)
            {
                cha.Id1 = int.Parse(txtId.Text);
                ClsGlossiarie.GetInstance().InsertUpdateChambre(cha);
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("tChambre");
            }
            else if (a == 3)
            {
                ClsGlossiarie.GetInstance().DeleteData("tChambre", "Id", int.Parse(txtId.Text));
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("tChambre");
            }
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNumero.Text = "";
            txtContact.Text = "";
            cmbClasse.Text = "";
        }

        private void FrmChambre_Load(object sender, EventArgs e)
        {
            ClsGlossiarie.GetInstance().loadCombo("tClasse", "designation", cmbClasse);
            dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("tChambre");
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
