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
using System.Collections;
//using MySql.Data;
//using MySql.Data.MySqlClient;


namespace Team7Senior { 
    /// <summary>
    /// Interaction logic for FeaturesPage.xaml
    /// </summary>
public partial class SaveMotion : Window
    {
        private KinectSensor _sensor;
        private MultiSourceFrameReader _reader;
        private RecordingMode _mode;

        private string resources = (@"C:\Users\Asus\Desktop\483\resources\");
        private int counter = 0;

       // private MySqlConnection connection;
        private Body _currentBody;
        private BodyWrapper _previousBody;

        ArrayList savedPose = new ArrayList();

        public SaveMotion()
        {
            InitializeComponent();
           // connectDB();

            _mode = RecordingMode.Stopped;

            _sensor = KinectSensor.GetDefault();

            if (_sensor != null)
            {
                _sensor.Open();

                _reader = _sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color | FrameSourceTypes.Depth | FrameSourceTypes.Infrared | FrameSourceTypes.Body);
                _reader.MultiSourceFrameArrived += Reader_MultiSourceFrameArrived;
            }

        }

       /* public void connectDB()
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

        public void writeToFile(ArrayList poses)
        {
            Console.WriteLine("SAVING FILE");
            int numberOfFrames = poses.Count;
            string description = "TEST 2";
            string name = "";
            string category_id = "1";
            string path = resources; // +"\\" + name + "\\";

            bool exists = System.IO.Directory.Exists(path);
            if (!exists)
                System.IO.Directory.CreateDirectory(path);

            for (int i = 0; i < poses.Count; i++)
            {
                System.IO.File.WriteAllText(path + i + ".json", poses[i].ToString());
                //  counter++;
            }

           /* string cmdText = "insert into motion(path, motion_name, frame_no, description, category_id) values(@path, @motion_name, @frame_no, @description, @category_id)";
            MySqlCommand cmd = new MySqlCommand(cmdText, connection);
            cmd.Parameters.Add("@path", resources);
            cmd.Parameters.Add("@motion_name", name);
            cmd.Parameters.Add("@frame_no", numberOfFrames);
            cmd.Parameters.Add("@description", description);
            cmd.Parameters.Add("@category_id", category_id);
            cmd.ExecuteNonQuery();*/

        }

        void Reader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            var reference = e.FrameReference.AcquireFrame();

            // Color
            using (var frame = reference.ColorFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    viewer.Image = frame.ToBitmap();
                }
            }

            // Body
            using (var frame = reference.BodyFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    _currentBody = frame.Bodies().Closest();

                    if (_currentBody != null)
                    {
                        var recording_brush = Brushes.Green;
                        var stopped_brush = Brushes.Red;

                        var current_brush = _mode == RecordingMode.Started ? recording_brush : stopped_brush;
                        double radius = 15;

                        viewer.Clear();
                        viewer.DrawBody(_currentBody, radius, current_brush, radius, current_brush);

                        if (_mode == RecordingMode.Started)
                        {
                            BodyWrapper pose = new BodyWrapper();
                            pose.Set(_currentBody, viewer.CoordinateMapper, Visualization.Color);
                            string pose_json = JsonConvert.SerializeObject(pose);
                            //writeToFile(pose_json);
                            savedPose.Add(pose_json);
                        }
                        else if (_mode == RecordingMode.Saving)
                        {
                            if (savedPose.Count > 0)
                            {

                                // writeToFile(savedPose);
                            }
                            _mode = RecordingMode.Stopped;
                        }
                    }
                    else
                    {
                        viewer.Clear();
                    }
                }
            }
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
           /* if (connection != null)
            {
                connection.Close();
            }*/
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            Team7Senior.DoctorWindow dw = new Team7Senior.DoctorWindow();
            dw.Show();
           
           
            //if (NavigationService.CanGoBack)
            // {
            //  NavigationService.GoBack();
            // }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (_mode == RecordingMode.Stopped && _currentBody != null)
            {
                _mode = RecordingMode.Started;
                counter = 0;
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            if (_mode == RecordingMode.Started && _currentBody != null)
            {

                _mode = RecordingMode.Saving;
                writeToFile(savedPose);
            }
        }
    }

    enum RecordingMode
    {
        Started,
        Stopped,
        Saving
    }
}