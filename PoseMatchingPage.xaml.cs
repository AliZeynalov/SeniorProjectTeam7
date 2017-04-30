using LightBuzz.Vitruvius;
using Microsoft.Kinect;
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
using Newtonsoft.Json;
using System.IO;
using System.Collections;
//using MySql.Data;
//using MySql.Data.MySqlClient;

namespace Team7Senior
{
    /// <summary>
    /// Interaction logic for PoseMatchingPage.xaml
    /// </summary>
    public partial class PoseMatchingPage : Window
    {
        private KinectSensor _sensor;
        private MultiSourceFrameReader _reader;
        private PoseMatching _matching;

      //  private MySqlConnection connection;

        int frameNumber = 0;
        int roundNumber = 5;
        ArrayList savedPose = new ArrayList();
        int counter = 0;
        private string resources = (@"C:\Users\Ayşenur\Desktop\483\resources\");

        private Body _currentBody;
        private BodyWrapper bw;

        int pose_choice;
        bool flag = true;
        double radius = 15;
        Brush example_brush = Brushes.Blue;

        public PoseMatchingPage()
        {
            InitializeComponent();
           // connectDB();

            pose_choice = 3;
            readFromFile();
            Console.WriteLine("# of poses found : " + savedPose.Count);
            _sensor = KinectSensor.GetDefault();

            if (_sensor != null)
            {
                _sensor.Open();

                _reader = _sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color | FrameSourceTypes.Depth | FrameSourceTypes.Infrared | FrameSourceTypes.Body);
                _reader.MultiSourceFrameArrived += Reader_MultiSourceFrameArrived;

                _matching = new PoseMatching
                {
                    CheckHead= false,
                    CheckLegLeft = false,
                    CheckLegRight = false,
                    CheckArmLeft = true,
                    CheckArmRight = true,
                    CheckSpine = false
                };
            }

        }

      /*  public void connectDB()
        {
            try
            {
                string connectionString = "user=root;database=physiotherapist;server=localhost;password=aysenur191;";
                connection = new MySqlConnection(connectionString);
                connection.Open();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("DB Connection Error");
            }

        }*/

        private void readFromFile()
        {
            //MySqlCommand cmd = new MySqlCommand("SELECT BusinessEntityID AS ID, FirstName, MiddleName, LastName FROM Person.Person WHERE id = '" + pose_choice + "'", connection);
            //MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            // Pose Matching klasorune gidilecek.

            string[] fileEntries = Directory.GetFiles(resources);
            // Console.WriteLine("Total size : " + fileEntries.Length);
            foreach (string fileName in fileEntries)
                processFile(fileName);

        }

        private void refreshBody()
        {
            bw = (BodyWrapper)savedPose[counter];
            bw.SetMap2D(viewer2.CoordinateMapper, Visualization.Color);
        }

        private void processFile(string file)
        {
            String json_file = File.ReadAllText(file);
            BodyWrapper bw2 = JsonConvert.DeserializeObject<BodyWrapper>(json_file);
            savedPose.Add(bw2);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_reader != null)
            {
                _reader.Dispose();
            }

            if (_sensor != null)
            {
                _sensor.Close();
            }
        }

        //private void Back_Click(object sender, RoutedEventArgs e)
        //{
        //    if (NavigationService.CanGoBack)
        //    {
        //        NavigationService.GoBack();
        //    }
        //}

        void Reader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            var reference = e.FrameReference.AcquireFrame();

            // Color
            using (var frame = reference.ColorFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    if (flag) { viewer1.Image = frame.ToBitmap(); flag = false; }
                    else
                    {
                        viewer1.Image.ClearValue(Image.SourceProperty);
                        viewer2.Image = frame.ToBitmap();
                    }
                }
                else
                {
                    Console.WriteLine("FRAME NULLLL!");
                }
            }

            // Body
            using (var frame = reference.BodyFrameReference.AcquireFrame())
            {

                if (frame != null)
                {
                    _currentBody = frame.Bodies().Closest();


                    // counter++;
                    if (counter >= savedPose.Count)
                    {
                        counter = 0;
                        Console.WriteLine("bir devre bitti");
                    }

                    refreshBody();

                    if (_currentBody != null)
                    {

                        viewer1.Clear();
                        viewer2.Clear();
                        //var match = _matching.Matches(bw, _currentBody);
                        //var verify_brush = match ? Brushes.Green : Brushes.Red;

                        // if (match)
                        //{
                        //Console.WriteLine("counter: " + counter);


                        //}

                        viewer1.DrawBody(_currentBody, radius, example_brush, radius, example_brush);
                        viewer2.DrawBody(bw, radius, example_brush, radius, example_brush);

                    }
                    else
                    {
                        viewer1.Clear();
                        viewer2.Clear();

                        viewer2.DrawBody(bw, radius, example_brush, radius, example_brush);

                    }
                }
                else
                {
                    Console.WriteLine("FRAME NULLLL!");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            counter++;
            Console.WriteLine("counter: " + counter + " " + bw.Joints[JointType.HandRight].Position.X + " " + bw.Joints[JointType.HandRight].Position.Y);

        }
    }
}
