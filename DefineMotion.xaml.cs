using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;

namespace Team7Senior
{

    /// <summary>
    /// Interaction logic for DefineMotion.xaml
    /// </summary>
    public partial class DefineMotion : Window
    {
        private ArrayList savedPose;
        private string resources = (@"C:\Users\Ayşenur\Desktop\483\resources");

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        

        public DefineMotion(ArrayList savedPose)
        {
            InitializeComponent();

            this.savedPose = savedPose;

            fillCategories();
            refreshList();
        }

       

       
        //public void connectDB()
        //{
        //    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
        //    cmd = new OleDbCommand();
        //    try
        //    {
        //        con.Open();
        //        // Insert code to process data.
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Failed to connect to data source");
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
           
        //}

        public void refreshList()
        {
            this.patientList.Items.Clear();

           
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
            cmd = new OleDbCommand();
            con.Open();
            
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM users ";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string a = dr["id"].ToString();
                int id = Int32.Parse(a);

                String name = dr["pname"].ToString();
                String mail = dr["mail"].ToString();
                String username = dr["username"].ToString();


                if (username != "admin")
                {

                    this.patientList.Items.Add(new MyItem { Id = id, Name = name, Email = mail });

                }
                this.patientList.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Id", System.ComponentModel.ListSortDirection.Ascending));

            }
            con.Close();
        }

        public int getCategoryId(string name)
        {

            OleDbConnection con;
            OleDbCommand cmd;
            OleDbDataReader dr;

            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
            cmd = new OleDbCommand();
            con.Open();
           
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM category where cat_name ='" + name + "'";
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string a = dr["id"].ToString();
                int id = Int32.Parse(a);
                return id;
            }
            else
            {
                return -1;
            }
          
        }

        public void writeToFile(string name, string cat_name, string description)
        {
            Console.WriteLine("SAVING FILE");
            int numberOfFrames = savedPose.Count;
            int category_id = getCategoryId(cat_name);
            string path = resources + "\\" + name + "\\";
            int parsedValue;
            int repet;
            if (!int.TryParse(repetition.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                return;
            }
            else {
                repet = Int32.Parse(repetition.Text);
            }
      
            bool exists = System.IO.Directory.Exists(path);
            if (!exists)
                System.IO.Directory.CreateDirectory(path);

            for (int i = 0; i < savedPose.Count; i++)
            {
                System.IO.File.WriteAllText(path + i + ".json", savedPose[i].ToString());
            }

            var selectedItem = (dynamic)patientList.SelectedItems[0];
            String selectedcmb = selectedItem.Name;
            int chosenId = selectedItem.Id;


            OleDbConnection con;
            OleDbCommand cmd;
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
            cmd = new OleDbCommand();
            con.Open();
           
            cmd.Connection = con;
            

            cmd.CommandText = "insert into motion(motion_name,path,frame_no,description,category_id, repetition) Values('" + name + "','" + path + "'," + numberOfFrames + ",'" + description + "'," + category_id + ", " + repet + ")";
            
            cmd.ExecuteNonQuery();

            cmd.CommandText = "SELECT TOP 1 id FROM motion ORDER BY id DESC";
            //OleDbDataReader dr;

            cmd.CommandText = "Select @@Identity";
            int mot_id = (int)cmd.ExecuteScalar();

            if (mot_id != -1)
            {
                cmd.CommandText = "insert into user_motion(user_id,motion_id) Values(" + chosenId + "," + mot_id + ")";
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Motion Added Successfully...");
            refreshList();

            con.Close();
        }

        public void fillCategories()
        {
            this.category_combo.Items.Clear();

            OleDbConnection con;
            OleDbCommand cmd;
            OleDbDataReader dr;

            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
            cmd = new OleDbCommand();
            con.Open();
          
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM category ";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                String name = dr["cat_name"].ToString();

                ComboBoxItem item = new ComboBoxItem();
                item.Content = name;
                this.category_combo.Items.Add(item);
            }
            this.category_combo.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Id", System.ComponentModel.ListSortDirection.Ascending));


            con.Close();
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            Team7Senior.DoctorWindow dw = new Team7Senior.DoctorWindow();
            dw.Show();
            this.Close();
        }

        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selected_item = (ComboBoxItem)category_combo.SelectedItem;
            string cat_name = (string)selected_item.Content;
            string mot_name = motion_name.Text;
            string desc = description.Text;
           

            writeToFile(mot_name, cat_name, desc);
        }
    }
}
