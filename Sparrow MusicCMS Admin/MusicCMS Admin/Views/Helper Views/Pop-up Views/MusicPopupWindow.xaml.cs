using MusicCMS_Admin.ViewModels;
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

namespace MusicCMS_Admin.Views.Helper_Views.Pop_up_Views
{
    /// <summary>
    /// Interaction logic for MusicPopupWindow.xaml
    /// </summary>
    public partial class MusicPopupWindow : Window
    {
        public MusicPopupWindow()
        {
            InitializeComponent();

            this.DataContext = new MusicPopupViewModel() { _MusicPopupWindow = this };
        }
    }
}
