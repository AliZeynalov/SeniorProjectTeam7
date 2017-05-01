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

namespace Team7Senior
{

    public class MyMotionItem
    {
        public int Id { get; set; }

        public string MotionName { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }
    }
    
    /// <summary>
    /// Interaction logic for PastMotion.xaml
    /// </summary>
    public partial class PastMotion : Window
    {
        public PastMotion()
        {
            InitializeComponent();

            refreshPatientList();
            refreshMotionList();
        }

        public void refreshPatientList()
        {
            this.patientList.Items.Clear();

            OleDbConnection con;
            OleDbCommand cmd;
            OleDbDataReader dr;

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

        public void refreshMotionList() {
            this.motionList.Items.Clear();

            OleDbConnection con;
            OleDbCommand cmd;
            OleDbDataReader dr;

            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT motion.id, motion.motion_name, motion.description, category.cat_name FROM motion, category where motion.category_id = category.id ";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string a = dr["id"].ToString();
                int id = Int32.Parse(a);

                String name = dr["motion_name"].ToString();
                String desc = dr["description"].ToString();
                String cat_name = dr["cat_name"].ToString();
                    
                this.motionList.Items.Add(new MyMotionItem { Id = id, MotionName = name, Description = desc, CategoryName = cat_name });
                
                this.motionList.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Id", System.ComponentModel.ListSortDirection.Ascending));
            }


            con.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection con;
            OleDbCommand cmd;
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;

            MyItem patient = (MyItem)patientList.SelectedItem;
            MyMotionItem motion = (MyMotionItem)motionList.SelectedItem;
            Console.WriteLine(patient.Id);
            Console.WriteLine(motion.Id);

            
            cmd.CommandText = "insert into user_motion(user_id,motion_id) Values(" + patient.Id + "," + motion.Id + ")";
            cmd.ExecuteNonQuery();

            MessageBox.Show("Motion Added Successfully...");

            con.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Team7Senior.DoctorWindow dw = new Team7Senior.DoctorWindow();
            dw.Show();
            this.Close();
        }
    }
}
