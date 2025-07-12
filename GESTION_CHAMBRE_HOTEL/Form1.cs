using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GESTION_CHAMBRE_HOTEL.Formulaires;

namespace GESTION_CHAMBRE_HOTEL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategorisation cat = new FrmCategorisation();
            cat.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmClasse cla = new FrmClasse();
            cla.ShowDialog();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            FrmClient cli = new FrmClient();
            cli.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            FrmReservation res = new FrmReservation();
            res.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmChambre cha = new FrmChambre();
            cha.ShowDialog();
        }
    }
}
