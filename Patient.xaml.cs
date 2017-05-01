using System;
using LightBuzz.Vitruvius;
using Microsoft.Kinect;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Net.Mail;
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

namespace Team7Senior
{
    /// <summary>
    /// Interaction logic for Patient.xaml
    /// </summary>
    public partial class Patient : Window
    {
        public class UserInfo {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Name { get; set; }
            public string Email { get; set; } 
        }

        public class MotionItem {
            public int Id { get; set; }
            public string Category { get; set; }
            public string MotionName { get; set; }
            public string Description { get; set; }
            public string Path { get; set; }
            public int FrameNo { get; set; }
            public int Repetition { get; set; }
        }

        private UserInfo userInfo;
       
        public Patient(String _mainusername)
        {
            userInfo = new UserInfo();
            InitializeComponent();
            String username = _mainusername;
            OleDbConnection con;
            OleDbCommand cmd;
            OleDbDataReader dr;

            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM users where username ='" + username + "'";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                userInfo.Name = dr["pname"].ToString();
                userInfo.Username = dr["username"].ToString();
                userInfo.Email = dr["mail"].ToString();
                userInfo.Id = Int32.Parse(dr["id"].ToString());

                nametb.Text = userInfo.Username;
                idtb.Text = userInfo.Id.ToString();
                mailtb.Text = userInfo.Email;
            }

            con.Close();

            fillUserMotions();
        }

        private void fillUserMotions() {
            OleDbConnection con;
            OleDbCommand cmd;
            OleDbDataReader dr;

            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            string sql = "SELECT c.cat_name, m.motion_name, m.description, m.id, m.path, m.frame_no, m.repetition FROM category c, user_motion um, motion m, users u where m.category_id = c.id and u.id = um.user_id and m.id = um.motion_id and u.username = '" + userInfo.Username + "'";
            cmd.CommandText = sql;
            dr = cmd.ExecuteReader();

            Console.WriteLine(sql);

            while (dr.Read())
            {
                Console.WriteLine(dr);
                MotionItem mi = new MotionItem();
                mi.Id = Int32.Parse(dr["id"].ToString());
                mi.MotionName = dr["motion_name"].ToString();
                mi.Category = dr["cat_name"].ToString();
                mi.Description = dr["description"].ToString();
                mi.Path = dr["path"].ToString();
                mi.FrameNo = Int32.Parse(dr["frame_no"].ToString());
                mi.Repetition = Int32.Parse(dr["repetition"].ToString());
                motionList.Items.Add(mi);
            }

            con.Close();
        }

        private void enablebtn_Click(object sender, RoutedEventArgs e)
        {
            if (mailtb.IsEnabled == true)
            {
                mailtb.IsEnabled = false;
                mailtb.IsReadOnly = true;
            }
            else
            {
                mailtb.IsEnabled = true;
                mailtb.IsReadOnly = false;
            }
        }

        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if (mailtb.IsEnabled == true)
            {
                
                OleDbConnection con;
                OleDbCommand cmd;
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=login.accdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;



                string nmail = mailtb.Text;
                string pname = nametb.Text;

                cmd.CommandText = "update users set [mail] = ? where pname=? ";
                cmd.Parameters.AddWithValue("?", nmail);
                cmd.Parameters.AddWithValue("?", pname);
                cmd.ExecuteNonQuery();

                MessageBox.Show("E-Mail Updated");

                con.Close();
            }
            else
            {
                MessageBox.Show("You must enable mail area to update your mail account!");
            }
            
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
                var from = mailtb.Text;
                var to = adminmail;
                var pass = passtb.Password;

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = subj;

                StringBuilder sbBody = new StringBuilder();

                sbBody.AppendLine(msg);

                mail.Body = sbBody.ToString();


                SmtpServer.Credentials = new System.Net.NetworkCredential(from, pass);
                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;



                SmtpServer.Send(mail);

                MessageBox.Show("Mail Sended to " + to + "");

                msgtb.Clear();
                subjecttb.Clear();
                passtb.Clear();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Check Your Password");
            }
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            Team7Senior.Auth auth = new Team7Senior.Auth();
            auth.Show();
            this.Close();
        }

      

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MotionItem mi = (MotionItem)motionList.SelectedItem;
            Team7Senior.PoseMatchingPage pm = new Team7Senior.PoseMatchingPage(mi, userInfo);
            pm.Show();
            this.Close();
        }

      
       
    }
}
