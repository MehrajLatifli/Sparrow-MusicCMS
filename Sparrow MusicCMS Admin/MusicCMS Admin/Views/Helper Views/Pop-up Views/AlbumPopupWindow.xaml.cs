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
    /// Interaction logic for AlbumPopupWindow.xaml
    /// </summary>
    public partial class AlbumPopupWindow : Window
    {
        public AlbumPopupWindow()
        {
            InitializeComponent();

            this.DataContext = new AlbumPopupViewModel() { _AlbumPopupWindow = this };
        }
    }
}
