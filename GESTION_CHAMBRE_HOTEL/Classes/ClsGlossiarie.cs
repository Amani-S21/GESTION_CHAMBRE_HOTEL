using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace GESTION_CHAMBRE_HOTEL.Classes
{
    class ClsGlossiarie
    {
        public static ClsGlossiarie instance = null;

        public static ClsGlossiarie GetInstance()
        {
            if (instance == null)
            {
                instance = new ClsGlossiarie();
            }
            return instance;
        }

        SqlConnection connexion = null;
        SqlCommand commande = null;
        SqlDataAdapter datadapter = null;
        SqlDataReader datreader = null;
        
        public void InitialiseConnect()
        {
            try
            {
                connexion = new SqlConnection(ClsConnexion.query);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Connexion Failed"+ex.Message);
            }
        }

        public void UpdateCategorisation(ClsCategorisation categ)
        {
            try
            {
                InitialiseConnect();
                connexion.Open();
                commande = new SqlCommand("exec SaveCategorisation @id, @categorie ", connexion);
                commande.Parameters.AddWithValue("@id", categ.Id1);
                commande.Parameters.AddWithValue("@categorie", categ.Designation1);
                commande.ExecuteNonQuery();
                connexion.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateClasse(ClsClasse clas)
        {
            try
            {
                InitialiseConnect();
                connexion.Open();
                commande = new SqlCommand("exec SaveClasse @id, @designation, @prix ", connexion);
                commande.Parameters.AddWithValue("@id", clas.Id1);
                commande.Parameters.AddWithValue("@designation", clas.Designation1);
                commande.Parameters.AddWithValue("@prix", clas.Prix1);
                commande.ExecuteNonQuery();
                connexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable loadData(string nomTable)
        {

            InitialiseConnect();
            if (!connexion.State.ToString().ToLower().Equals("open")) connexion.Open();
            DataTable table = new DataTable();
            datadapter = new SqlDataAdapter("select * from " + nomTable + "", connexion);
            datadapter.Fill(table);
            connexion.Close();

            return table;
        }

        public void DeleteData(string nomTable, string champId, int id)
        {
            try
            {
                InitialiseConnect();
                connexion.Open();
                commande = new SqlCommand("delete from  " + nomTable + " where " + champId + " = @id", connexion);
                commande.Parameters.AddWithValue("@id", id);
                commande.ExecuteNonQuery();
                connexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadCombo(string nomTable, string nomchamp, System.Windows.Forms.ComboBox comb1)
        {
            InitialiseConnect();
            if (!connexion.State.ToString().ToLower().Equals("open")) connexion.Open();
            DataTable table = new DataTable();
            datadapter = new SqlDataAdapter("SELECT " + nomchamp + " FROM " + nomTable + "", connexion);
            try
            {
                DataTable dt1 = new DataTable();
                datadapter.Fill(dt1);

                foreach (DataRow dr in dt1.Rows)
                {
                    comb1.Items.Add(dr[nomchamp]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }

            connexion.Close();
        }

        public string getcode_Combo(string nomTable, string nomChampId, string nomChamp, string valeur)
        {
            string IdData = "";
            try
            {
                InitialiseConnect();
                if (!connexion.State.ToString().ToLower().Equals("open")) connexion.Open();
                commande = new SqlCommand("select " + nomChampId + " from " + nomTable + " where " + nomChamp + "=@a", connexion);
                commande.Parameters.AddWithValue("@a", valeur);
                datreader = commande.ExecuteReader();
                while (datreader.Read())
                {
                    IdData = (datreader[nomChampId].ToString());
                }
                commande.Dispose();
                connexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return IdData;
        }
    }
}
