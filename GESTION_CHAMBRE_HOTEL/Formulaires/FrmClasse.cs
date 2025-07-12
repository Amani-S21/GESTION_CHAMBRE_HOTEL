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
    public partial class FrmClasse : Form
    {
        public FrmClasse()
        {
            InitializeComponent();
        }

        ClsClasse clas = new ClsClasse();

        void InsertUpdateDelete(int a)
        {
            clas.Designation1 = txtDesignation.Text;
            clas.Prix1 = double.Parse(txtPrix.Text);

            if (a == 1)
            {
                clas.Id1 = -1;
                ClsGlossiarie.GetInstance().InsertUpdateClasse(clas);
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("tClasse");
            }
            else if (a == 2)
            {
                clas.Id1 = int.Parse(txtId.Text);
                ClsGlossiarie.GetInstance().InsertUpdateClasse(clas);
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("tClasse");
            }
            else if (a == 3)
            {
                ClsGlossiarie.GetInstance().DeleteData("tClasse", "Id", int.Parse(txtId.Text));
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("tClasse");
            }
        }

        private void FrmClasse_Load(object sender, EventArgs e)
        {
            dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("tClasse");
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtDesignation.Text = "";
            txtPrix.Text = "";
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
