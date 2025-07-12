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

        public void InsertUpdateCategorisation(ClsCategorisation categ)
        {
            try
            {
                InitialiseConnect();
                connexion.Open();
                commande = new SqlCommand("exec SaveCategorisation @id, @designation ", connexion);
                commande.Parameters.AddWithValue("@id", categ.Id1);
                commande.Parameters.AddWithValue("@designation", categ.Designation1);
                commande.ExecuteNonQuery();
                connexion.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void InsertUpdateClasse(ClsClasse clas)
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

        public void InsertUpdateClient(ClsClient cli)
        {
            try
            {
                InitialiseConnect();
                connexion.Open();
                commande = new SqlCommand("exec SaveClient @id, @nom, @adresse, @contact, @refcategorie ", connexion);
                commande.Parameters.AddWithValue("@id", cli.Id1);
                commande.Parameters.AddWithValue("@nom", cli.Nom1);
                commande.Parameters.AddWithValue("@adresse", cli.Adresse1);
                commande.Parameters.AddWithValue("@contact", cli.Contact1);
                commande.Parameters.AddWithValue("@refcategorie", cli.RefCategorisation1);
                commande.ExecuteNonQuery();
                connexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void InsertUpdateChambre(ClsChambre cha)
        {
            try
            {
                InitialiseConnect();
                connexion.Open();
                commande = new SqlCommand("exec SaveChambre @id, @numero, @contact, @refclasse ", connexion);
                commande.Parameters.AddWithValue("@id", cha.Id1);
                commande.Parameters.AddWithValue("@numero", cha.Numero1);
                commande.Parameters.AddWithValue("@contact", cha.Contact1);
                commande.Parameters.AddWithValue("@refclasse", cha.RefClasse1);
                commande.ExecuteNonQuery();
                connexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void InsertUpdateReservation(ClsReservation res)
        {
            try
            {
                InitialiseConnect();
                connexion.Open();
                commande = new SqlCommand("exec SaveReservation @id, @refclient, @refchambre, @dateentre, @datesort ", connexion);
                commande.Parameters.AddWithValue("@id", res.Id1);
                commande.Parameters.AddWithValue("@refclient", res.RefClient1);
                commande.Parameters.AddWithValue("@refchambre", res.RefChambre1);
                commande.Parameters.AddWithValue("@dateentre", res.DateEntree1);
                commande.Parameters.AddWithValue("@datesort", res.DateSortie1);
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
