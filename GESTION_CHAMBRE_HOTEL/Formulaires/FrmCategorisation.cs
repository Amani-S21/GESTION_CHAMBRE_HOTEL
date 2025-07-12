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
    public partial class FrmCategorisation : Form
    {
        public FrmCategorisation()
        {
            InitializeComponent();
        }

        ClsCategorisation cat = new ClsCategorisation();

        void InsertUpdateDelete(int a)
        {
            cat.Designation1 = txtDesignation.Text;

            if (a == 1)
            {
                cat.Id1 = -1;
                ClsGlossiarie.GetInstance().InsertUpdateCategorisation(cat);
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("tCategorisation");
            }
            else if (a == 2)
            {
                cat.Id1 = int.Parse(txtId.Text);
                ClsGlossiarie.GetInstance().InsertUpdateCategorisation(cat);
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("tCategorisation");
            }
            else if (a == 3)
            {
                ClsGlossiarie.GetInstance().DeleteData("tCategorisation", "Id", int.Parse(txtId.Text));
                dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("tCategorisation");
            }
        }

        private void FrmCategorisation_Load(object sender, EventArgs e)
        {
            dgvListe.DataSource = ClsGlossiarie.GetInstance().loadData("tCategorisation");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtDesignation.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertUpdateDelete(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertUpdateDelete(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InsertUpdateDelete(3);
        }
    }
}
