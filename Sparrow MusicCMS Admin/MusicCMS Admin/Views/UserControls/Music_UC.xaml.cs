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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicCMS_Admin.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Music_UC.xaml
    /// </summary>
    public partial class Music_UC : UserControl
    {
        public Music_UC()
        {
            InitializeComponent();

            this.DataContext = new Music_UCViewModel() { _Music_UC = this };
        }
    }
}
