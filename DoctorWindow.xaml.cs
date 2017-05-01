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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace Team7Senior
{

     
   
    public class MyItem 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
       
    }
    
    public partial class DoctorWindow : Window
    {


       
        public DoctorWindow()
        {
           InitializeComponent();

           refreshList();
        }

        public void refreshList()
        {
            this.listView.Items.Clear();

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

                    this.listView.Items.Add(new MyItem { Id = id, Name = name, Email = mail });

                }
                //this.listView.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Id", System.ComponentModel.ListSortDirection.Ascending));

            }


            con.Close();
        }

        enum ExitCode : int
        {
            Success = 0,
            InvalidLogin = 1,
            InvalidFilename = 2,
            UnknownError = 10
        }

        public void clear_Text()
        {
            nametxt.Clear();
            mailtxt.Clear();
            unametxt.Clear();
            passwdtxt.Clear();
            cpasswdtxt.Clear();
        }
        private void id_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= id_GotFocus;
        }

        private void name_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= id_GotFocus;
        }

        private void mail_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= id_GotFocus;
        }


        
        private bool patientDetailsValidation(String username,String name)
        {

            Regex regexUname = new Regex(@"^[a-zA-Z][a-zA-Z0-9\._\-]{2,22}?[a-zA-Z0-9]{0,2}$");
            Match unameMatch = regexUname.Match(username);
            if (!unameMatch.Success)
            {
                MessageBox.Show(username + " is not valid username.");
                return false;
            }


            Regex regexName = new Regex(@"^[a-zA-Z][a-zA-Z\._\-]{2,22}?[a-zA-Z]{0,2}$");
            Match nameMatch = regexName.Match(name);
            if (!nameMatch.Success)
            {
                MessageBox.Show(name + " is not valid name.");
                return false;
            }

            return true;
        }
            
        


        private bool mailValidation(String mail)
        {
            OleDbConnection con;
            OleDbCommand cmd;
            OleDbDataReader dr;
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from users where mail='" + mail + "'";
            dr = cmd.ExecuteReader();
            
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(mail);
            if (!match.Success)
            {
                MessageBox.Show(mail + " is not valid email type.");
                return false;
            }
            if (dr.Read())
            {
                MessageBox.Show("There is already a user with typed email address");
                return false;
            }
            
            
            return true;
        }

        private void addbutton_Click(object sender, RoutedEventArgs e) 
        {
            OleDbConnection con;
            OleDbCommand cmd;
            

            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;

            bool mailVal = mailValidation(mailtxt.Text);
            bool patientVal = patientDetailsValidation(unametxt.Text, nametxt.Text);
            if (mailVal == false)
            {
                return;
            }
            else if(patientVal == false)
            {
                return;
            }

            if (nametxt.Text != "" && mailtxt.Text != "" && unametxt.Text != "" && passwdtxt.Password != "" && cpasswdtxt.Password != "")
            {
                if(passwdtxt.Password == cpasswdtxt.Password )
                {
                    cmd.CommandText = "insert into users(username,upassword,pname,mail) Values('" + unametxt.Text + "','" + passwdtxt.Password + "','" + nametxt.Text + "','" + mailtxt.Text + "')";
                    String variable = (string)cmd.ExecuteScalar();
                    MessageBox.Show("Patient Added Successfully...");
                    clear_Text();
                    refreshList();
                }
                else
                {
                    MessageBox.Show("You Must Confirm Your Password");
                }    
                        
            }
            else
            {
                MessageBox.Show("Please Be Sure That You Enter All Values!");
            }
            con.Close();
        }

        private void outbtn_Click(object sender, RoutedEventArgs e)
        {

            Team7Senior.Auth auth = new Team7Senior.Auth();
            auth.Show();
            this.Close();
        }


        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            Boolean x1, x2, x3, x4, x5, x6;
            OleDbConnection con;
            OleDbCommand cmd;

            


            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            


            var selectedItem = (dynamic)listView.SelectedItems[0];
            String selectedcmb = selectedItem.Name;

            cmd.CommandText = "update users set [shoulder] = ?, [knee] = ?, [neck] = ?, [arm] = ?, [stretch] = ?, [hip] = ? where pname=? ";
            cmd.Parameters.AddWithValue("?", selectedcmb);
            cmd.ExecuteNonQuery();


            


            MessageBox.Show("Patient Motions Modified Successfully...");


            con.Close();
        }

        private void delbutton_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection con;
            OleDbCommand cmd;


            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            var selectedItem = (dynamic)listView.SelectedItems[0];
            String selectedcmb = selectedItem.Name;
            cmd.CommandText = "delete from users where pname = '"+selectedcmb+"'";
            String variable = (string)cmd.ExecuteScalar();
            MessageBox.Show("Patient Deleted Successfully...");
            clear_Text();
            
            con.Close();
            refreshList();       
            
        }

        private void definebtn_Click(object sender, RoutedEventArgs e)
        {

            Team7Senior.SaveMotion sm = new Team7Senior.SaveMotion();
            sm.Show();
            this.Close();
           

            //this.Close();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            Console.WriteLine("Burda");


            String selectedcmb = "";

            try
            {
                var selectedItem = (dynamic)listView.SelectedItems[0];
                selectedcmb = selectedItem.Name;

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            
          
            OleDbConnection con;
            OleDbCommand cmd;
            OleDbDataReader dr;

            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM users where pname ='" + selectedcmb + "'";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                
                
                String name = dr["pname"].ToString();
                String mail = dr["mail"].ToString();
                nametb.Text = name;
                mailtb.Text = mail;
               
            }


            con.Close();
        }

        private void sendbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                 OleDbConnection con;
                 OleDbCommand cmd;
                 OleDbDataReader dr;

                 con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
                 cmd = new OleDbCommand();
                 con.Open();
                 cmd.Connection = con;
                 cmd.CommandText = "SELECT * FROM users";
                 dr = cmd.ExecuteReader();
                String adminmail = "";
                while (dr.Read())
                {
                    String username = dr["username"].ToString();
                    if (username == "admin")
                    {
                        adminmail = dr["mail"].ToString();
                    }

                }
                var subj = subjecttb.Text;
                var msg = msgtb.Text;
                var from = adminmail;
                var to = mailtb.Text;
                var pass = passtb.Password;

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = subj;

                StringBuilder sbBody = new StringBuilder();

                sbBody.AppendLine(msg);

                mail.Body = sbBody.ToString();

                
                SmtpServer.Credentials = new System.Net.NetworkCredential(from,pass);
                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;
                


                SmtpServer.Send(mail);
                
                MessageBox.Show("Mail Sended to "+to+"");

                msgtb.Clear();
                subjecttb.Clear();
                passtb.Clear();

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please Check Your Password");
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Team7Senior.PastMotion past = new Team7Senior.PastMotion();
            past.Show();
            this.Close();
        }

       
    }

        

      
}

