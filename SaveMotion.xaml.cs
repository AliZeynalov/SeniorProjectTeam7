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
using System.Data.OleDb;
using System.Data;



namespace Team7Senior { 
    /// <summary>
    /// Interaction logic for FeaturesPage.xaml
    /// </summary>
public partial class SaveMotion : Window
    {
        private KinectSensor _sensor;
        private MultiSourceFrameReader _reader;
        private RecordingMode _mode;

        private string resources = (@"C:\Users\Ayşenur\Desktop\483\resources\");

        private Body _currentBody;
        private BodyWrapper _previousBody;

        ArrayList savedPose = new ArrayList();

        public SaveMotion()
        {
            InitializeComponent();

            _mode = RecordingMode.Stopped;

            _sensor = KinectSensor.GetDefault();

            if (_sensor != null)
            {
                _sensor.Open();

                _reader = _sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color | FrameSourceTypes.Depth | FrameSourceTypes.Infrared | FrameSourceTypes.Body);
                _reader.MultiSourceFrameArrived += Reader_MultiSourceFrameArrived;
            }

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
                            savedPose.Add(pose_json);
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
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            if (_mode == RecordingMode.Started && _currentBody != null)
            {
                _mode = RecordingMode.Stopped;
              
            }
            Team7Senior.DefineMotion dm = new Team7Senior.DefineMotion(savedPose);
            dm.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Team7Senior.DoctorWindow dw = new Team7Senior.DoctorWindow();
            dw.Show();
            this.Close();
        }
    }

    enum RecordingMode
    {
        Started,
        Stopped,
        Saving
    }
}