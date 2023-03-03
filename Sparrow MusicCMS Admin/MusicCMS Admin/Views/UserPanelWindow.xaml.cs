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

namespace MusicCMS_Admin.Views
{
    /// <summary>
    /// Interaction logic for UserPanelWindow.xaml
    /// </summary>
    public partial class UserPanelWindow : Window
    {
        public UserPanelWindow()
        {
            InitializeComponent();

            this.DataContext = new UserPanelViewModel() { _UserPanelWindow = this };
        }
    }
}
