using MusicCMS.ViewModels;
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

namespace MusicCMS.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Playlist_UC.xaml
    /// </summary>
    public partial class Playlist_UC : UserControl
    {
        public Playlist_UC()
        {
            InitializeComponent();

            this.DataContext = new Playlist_UCViewModel() { _Playlist_UC = this };
        }


    }
}
