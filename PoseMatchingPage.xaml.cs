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
using System.Data.OleDb;
using System.Data;

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

        ArrayList savedPose = new ArrayList();
        int counter = 0;

        private Body _currentBody;
        private BodyWrapper bw;

        private BodyWrapper first_pose, last_pose, current_pose;
        int repetition = 0;

        int frame_rate = 10;
        int current_rate_counter = 0;

        bool flag = true;
        double radius = 15;
        Brush example_brush = Brushes.Blue;

        Patient.MotionItem motion;
        Patient.UserInfo userInfo;

        public PoseMatchingPage(Patient.MotionItem mi, Patient.UserInfo ui)
        {
            InitializeComponent();

            motion = mi;
            Console.WriteLine(motion.Repetition);
            userInfo = ui;

            readFromFile();
            first_pose = (BodyWrapper)savedPose[0];
            last_pose = (BodyWrapper)savedPose[savedPose.Count - 1];
            current_pose = first_pose;


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

        private void change() {
            //if (current_rate_counter % 10 != 0) { return; }
            Console.WriteLine(repetition);
            if (current_pose == first_pose)
            {
                current_pose = last_pose;
            }
            else
            {
                repetition++;
                current_pose = first_pose;
            }

            if (repetition == motion.Repetition) {
                MessageBox.Show("Congratulations!");
                dispose_window();
                // Mail burda attirilacak yapilan hareketin ismi motion.MotionName vs vs
            }

        }

        private void readFromFile()
        {
            string[] fileEntries = Directory.GetFiles(motion.Path);
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

                    //current_rate_counter = (current_rate_counter + 1) % 10;
                    // counter++;
                    //if (counter >= savedPose.Count)
                    //{
                    //    counter = 0;
                    //    Console.WriteLine("bir devre bitti");
                    //}

                    //refreshBody();

                    if (_currentBody != null)
                    {
                        viewer1.Clear();
                        viewer2.Clear();

                        var match = _matching.Matches(current_pose, _currentBody);
                        var verify_brush = match ? Brushes.Green : Brushes.Red;

                        if (match) {
                            change();
                        }

                        viewer1.DrawBody(_currentBody, radius, example_brush, radius, example_brush);
                        viewer2.DrawBody(current_pose, radius, verify_brush, radius, verify_brush);
                    }
                    else
                    {
                        viewer1.Clear();
                        viewer2.Clear();

                        viewer2.DrawBody(current_pose, radius, Brushes.Red, radius, Brushes.Red);
                    }
                }
                else
                {
                    Console.WriteLine("FRAME NULLLL!");
                }
            }
        }

       
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dispose_window();
        }

        private void dispose_window() {
            Team7Senior.Patient patient = new Team7Senior.Patient(userInfo.Username);
            patient.Show();
            this.Close();
        }

       
    }
}
