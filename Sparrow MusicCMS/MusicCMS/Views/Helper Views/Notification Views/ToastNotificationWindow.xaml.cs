using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Threading;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;

namespace MusicCMS.Views.Helper_Views.Notification_Views
{
    /// <summary>
    /// Interaction logic for ToastNotificationWindow.xaml
    /// </summary>
    public partial class ToastNotificationWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnpropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    
        String _text { get; set; }
        String _imagepath { get; set; }
        Color _Backgroundcolor { get; set; }
        Color _BorderBrush { get; set; }
        double _count { get; set; }


        private bool _close;
        public bool Close_
        {


            get { return _close; }
            set { _close = value; OnpropertyChanged(); }

        }

        public ToastNotificationWindow(String text, string imagepath, Color Backgroundcolor , Color BorderBrush, double count)
        {
            InitializeComponent();

            _text = text;
            _imagepath = imagepath;
            _BorderBrush=BorderBrush;
            _Backgroundcolor = Backgroundcolor;
            _count = count;
            Close_ = false;


        }

        DispatcherTimer timer = new DispatcherTimer();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {



            this.border1.Background = new SolidColorBrush(_Backgroundcolor);
            this.border1.BorderBrush = new SolidColorBrush(_BorderBrush);
            this.image.ImageSource = new BitmapImage(new Uri(_imagepath, UriKind.RelativeOrAbsolute));
                this.label.Content = _text;

     

            if (Close_ != true)
            {
                WindowStartupLocation windowStartupLocation = WindowStartupLocation.Manual;

                var workingArea = System.Windows.SystemParameters.WorkArea;
                var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
                var corner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));

                this.Left = corner.X - this.ActualWidth - 10;
                this.Top = corner.Y - this.ActualHeight - _count;



            }


            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {

            Task task = Task.Run(() =>
            {

                Close_ = true;

                Dispatcher.BeginInvoke(new Action(() =>
                {


                    if (Close_ == true)
                    {

                        var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;


                        Close();




                    }

                }));

            });


        }
    }
}
