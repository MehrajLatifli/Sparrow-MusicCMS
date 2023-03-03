using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using MusicCMS.Command;
using MusicCMS.Helpers;
using MusicCMS.Models;
using MusicCMS.Views;
using MusicCMS.Views.UserControls;
using Newtonsoft.Json;
using Sparrow_MusicCMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MusicCMS.ViewModels
{
    public class UserPanelViewModel : BaseViewModel
    {


        public RelayCommand UserPanel_MouseDownCommand { get; set; }

        public RelayCommand ExitAppCommand { get; set; }

        public RelayCommand MinimizeAppCommand { get; set; }

        public RelayCommand MenuButtonCommand { get; set; }


        public UserPanelWindow _UserPanelWindow { get; set; }


        public ObservableCollection<ImagesforCover> _ImagesforCover_List { get; set; }
        public ObservableCollection<ImagesforCover> ImagesforCover_List { get { return _ImagesforCover_List; } set { _ImagesforCover_List = value; OnPropertyChanged(); } }

        private ImagesforCover _ImagesforCovers { get; set; }

        public ImagesforCover ImagesforCovers { get { return _ImagesforCovers; } set { _ImagesforCovers = value; OnPropertyChanged(); } }

        public Repo_CovertPhoto CovertPhotoRepository { get; set; }

        bool logincheck_ { get; set; }

        public bool logincheck
        {
            get { return logincheck_; }
            set { logincheck_ = value; OnPropertyChanged(); }
        }

        public Player_UC player_UC { get; set; }


        public UserPanelViewModel()
        {
            CovertPhotoRepository = new Repo_CovertPhoto();
            ImagesforCover_List = new ObservableCollection<ImagesforCover>(CovertPhotoRepository.GetAll());

            logincheck=false;

            var f = Newtonsoft.Json.Formatting.Indented;
            string data = JsonConvert.SerializeObject(logincheck, f);

            System.IO.File.WriteAllText("../../../Asserts/Files/logincheck.json", data);


            ImagesforCovers = new ImagesforCover
            {
                FilePath1 = "../../Asserts/Images/Images/Logo.gif",
                FilePath2 = "../../Asserts/Images/Images/Logo 2.gif",

            };

            [DllImport("kernel32.dll")]
            static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

            SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);


            UserPanel_MouseDownCommand = new RelayCommand((e) =>
            {
                MouseButtonEventArgs ev = (MouseButtonEventArgs)e;

                if (ev.ChangedButton == MouseButton.Left)
                {
                    if (_UserPanelWindow != null)
                    {
                        _UserPanelWindow.DragMove();

                    }
                }
            });

            ExitAppCommand = new RelayCommand((e) =>
            {

                _UserPanelWindow.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Environment.Exit(0);

            

                }));

            });


            MinimizeAppCommand = new RelayCommand((e) =>
            {

                _UserPanelWindow.Dispatcher.BeginInvoke(new Action(() =>
                {
                    _UserPanelWindow.WindowState = WindowState.Minimized;

                }));

            });


            MenuButtonCommand = new RelayCommand((e) =>
            {
                _UserPanelWindow.HomeButton.Click += HomeButton_Click;
                _UserPanelWindow.MusicButton.Click += MusicButton_Click;
                _UserPanelWindow.RadioButton.Click += RadioButton_Click;
                _UserPanelWindow.PlaylistButton.Click += PlaylistButton_Click;
                //_UserPanelWindow.ArtistButton.Click += ArtistButton_Click;
                //_UserPanelWindow.AlbumButton.Click += AlbumButton_Click;
                //_UserPanelWindow.NotificationButton.Click += NotificationButton_Click;
                //_UserPanelWindow.SettingButton.Click += SettingButton_Click;

            });


        }


        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button button)
            {

                button = e.Source as Button;

                SolidColorBrush ButtonBackground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonBackground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#02be68"));

                SolidColorBrush ButtonForeground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonForeground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"));



                button.Background = ButtonBackground2;
                button.Foreground = ButtonForeground;


                //_UserPanelWindow.settingicon.Visibility = Visibility.Visible;

                _UserPanelWindow.uControl_Home_UC.Visibility = Visibility.Collapsed;

                if (_UserPanelWindow.HomeButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.HomeButton.Background = ButtonBackground;
                    _UserPanelWindow.HomeButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.homeicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.MusicButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.MusicButton.Background = ButtonBackground;
                    _UserPanelWindow.MusicButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.musicicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.RadioButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.RadioButton.Background = ButtonBackground;
                    _UserPanelWindow.RadioButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.radioicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.PlaylistButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.PlaylistButton.Background = ButtonBackground;
                    _UserPanelWindow.PlaylistButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.playlisticon.Visibility = Visibility.Hidden;

                }

                //if (_UserPanelWindow.ArtistButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.ArtistButton.Background = ButtonBackground;
                //    _UserPanelWindow.ArtistButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.artisticon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.AlbumButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.AlbumButton.Background = ButtonBackground;
                //    _UserPanelWindow.AlbumButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.albumicon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.NotificationButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.NotificationButton.Background = ButtonBackground;
                //    _UserPanelWindow.NotificationButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.notificationicon.Visibility = Visibility.Hidden;

                //}



            }

        }

        private void NotificationButton_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button button)
            {

                button = e.Source as Button;


                SolidColorBrush ButtonBackground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonBackground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#02be68"));

                SolidColorBrush ButtonForeground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonForeground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"));



                button.Background = ButtonBackground2;
                button.Foreground = ButtonForeground;


                //_UserPanelWindow.notificationicon.Visibility = Visibility.Visible;

                _UserPanelWindow.uControl_Home_UC.Visibility = Visibility.Collapsed;

                if (_UserPanelWindow.HomeButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.HomeButton.Background = ButtonBackground;
                    _UserPanelWindow.HomeButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.homeicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.MusicButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.MusicButton.Background = ButtonBackground;
                    _UserPanelWindow.MusicButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.musicicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.RadioButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.RadioButton.Background = ButtonBackground;
                    _UserPanelWindow.RadioButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.radioicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.PlaylistButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.PlaylistButton.Background = ButtonBackground;
                    _UserPanelWindow.PlaylistButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.playlisticon.Visibility = Visibility.Hidden;

                }

                //if (_UserPanelWindow.ArtistButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.ArtistButton.Background = ButtonBackground;
                //    _UserPanelWindow.ArtistButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.artisticon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.AlbumButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.AlbumButton.Background = ButtonBackground;
                //    _UserPanelWindow.AlbumButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.albumicon.Visibility = Visibility.Hidden;

                //}


                //if (_UserPanelWindow.SettingButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.SettingButton.Background = ButtonBackground;
                //    _UserPanelWindow.SettingButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.settingicon.Visibility = Visibility.Hidden;

                //}

            }

        }

        private void AlbumButton_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button button)
            {

                button = e.Source as Button;


                SolidColorBrush ButtonBackground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonBackground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#02be68"));

                SolidColorBrush ButtonForeground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonForeground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"));



                button.Background = ButtonBackground2;
                button.Foreground = ButtonForeground;


                //_UserPanelWindow.albumicon.Visibility = Visibility.Visible;

                _UserPanelWindow.uControl_Home_UC.Visibility = Visibility.Collapsed;

                if (_UserPanelWindow.HomeButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.HomeButton.Background = ButtonBackground;
                    _UserPanelWindow.HomeButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.homeicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.MusicButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.MusicButton.Background = ButtonBackground;
                    _UserPanelWindow.MusicButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.musicicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.RadioButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.RadioButton.Background = ButtonBackground;
                    _UserPanelWindow.RadioButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.radioicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.PlaylistButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.PlaylistButton.Background = ButtonBackground;
                    _UserPanelWindow.PlaylistButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.playlisticon.Visibility = Visibility.Hidden;

                }

                //if (_UserPanelWindow.ArtistButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.ArtistButton.Background = ButtonBackground;
                //    _UserPanelWindow.ArtistButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.artisticon.Visibility = Visibility.Hidden;

                //}


                //if (_UserPanelWindow.NotificationButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.NotificationButton.Background = ButtonBackground;
                //    _UserPanelWindow.NotificationButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.notificationicon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.SettingButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.SettingButton.Background = ButtonBackground;
                //    _UserPanelWindow.SettingButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.settingicon.Visibility = Visibility.Hidden;

                //}

            }

        }

        private void ArtistButton_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button button)
            {

                button = e.Source as Button;


                SolidColorBrush ButtonBackground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonBackground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#02be68"));

                SolidColorBrush ButtonForeground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonForeground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"));



                button.Background = ButtonBackground2;
                button.Foreground = ButtonForeground;


                //_UserPanelWindow.artisticon.Visibility = Visibility.Visible;

                _UserPanelWindow.uControl_Home_UC.Visibility = Visibility.Collapsed;

                if (_UserPanelWindow.HomeButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.HomeButton.Background = ButtonBackground;
                    _UserPanelWindow.HomeButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.homeicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.MusicButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.MusicButton.Background = ButtonBackground;
                    _UserPanelWindow.MusicButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.musicicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.RadioButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.RadioButton.Background = ButtonBackground;
                    _UserPanelWindow.RadioButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.radioicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.PlaylistButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.PlaylistButton.Background = ButtonBackground;
                    _UserPanelWindow.PlaylistButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.playlisticon.Visibility = Visibility.Hidden;

                }



                //if (_UserPanelWindow.AlbumButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.AlbumButton.Background = ButtonBackground;
                //    _UserPanelWindow.AlbumButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.albumicon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.NotificationButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.NotificationButton.Background = ButtonBackground;
                //    _UserPanelWindow.NotificationButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.notificationicon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.SettingButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.SettingButton.Background = ButtonBackground;
                //    _UserPanelWindow.SettingButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.settingicon.Visibility = Visibility.Hidden;

                //}

            }

        }

        private void PlaylistButton_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button button)
            {

                button = e.Source as Button;


                SolidColorBrush ButtonBackground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonBackground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#02be68"));

                SolidColorBrush ButtonForeground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonForeground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"));



                button.Background = ButtonBackground2;
                button.Foreground = ButtonForeground;


                _UserPanelWindow.uControl_Home_UC.Visibility = Visibility.Collapsed;

                _UserPanelWindow.uControl_Music_UC.Visibility = Visibility.Collapsed;

                _UserPanelWindow.uControl_Radio_UC.Visibility = Visibility.Collapsed;

                _UserPanelWindow.uControl_Playlist_UC.Visibility = Visibility.Visible;

                _UserPanelWindow.playlisticon.Visibility = Visibility.Visible;

                if (_UserPanelWindow.HomeButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.HomeButton.Background = ButtonBackground;
                    _UserPanelWindow.HomeButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.homeicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.MusicButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.MusicButton.Background = ButtonBackground;
                    _UserPanelWindow.MusicButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.musicicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.RadioButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.RadioButton.Background = ButtonBackground;
                    _UserPanelWindow.RadioButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.radioicon.Visibility = Visibility.Hidden;

                }


                //if (_UserPanelWindow.ArtistButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.ArtistButton.Background = ButtonBackground;
                //    _UserPanelWindow.ArtistButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.artisticon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.AlbumButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.AlbumButton.Background = ButtonBackground;
                //    _UserPanelWindow.AlbumButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.albumicon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.NotificationButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.NotificationButton.Background = ButtonBackground;
                //    _UserPanelWindow.NotificationButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.notificationicon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.SettingButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.SettingButton.Background = ButtonBackground;
                //    _UserPanelWindow.SettingButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.settingicon.Visibility = Visibility.Hidden;

                //}

            }

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button button)
            {

                button = e.Source as Button;

                SolidColorBrush ButtonBackground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonBackground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#02be68"));

                SolidColorBrush ButtonForeground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonForeground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"));



                button.Background = ButtonBackground2;
                button.Foreground = ButtonForeground;







                _UserPanelWindow.uControl_Home_UC.Visibility = Visibility.Collapsed;

                _UserPanelWindow.uControl_Music_UC.Visibility = Visibility.Collapsed;

                _UserPanelWindow.uControl_Radio_UC.Visibility = Visibility.Visible;

                _UserPanelWindow.radioicon.Visibility = Visibility.Visible;

                _UserPanelWindow.uControl_Playlist_UC.Visibility = Visibility.Collapsed;

                //_UserPanelWindow.uControl_Home_UC.Visibility = Visibility.Collapsed;

                if (_UserPanelWindow.HomeButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.HomeButton.Background = ButtonBackground;
                    _UserPanelWindow.HomeButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.homeicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.MusicButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.MusicButton.Background = ButtonBackground;
                    _UserPanelWindow.MusicButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.musicicon.Visibility = Visibility.Hidden;

                }


                if (_UserPanelWindow.PlaylistButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.PlaylistButton.Background = ButtonBackground;
                    _UserPanelWindow.PlaylistButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.playlisticon.Visibility = Visibility.Hidden;

                }

                //if (_UserPanelWindow.ArtistButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.ArtistButton.Background = ButtonBackground;
                //    _UserPanelWindow.ArtistButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.artisticon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.AlbumButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.AlbumButton.Background = ButtonBackground;
                //    _UserPanelWindow.AlbumButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.albumicon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.NotificationButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.NotificationButton.Background = ButtonBackground;
                //    _UserPanelWindow.NotificationButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.notificationicon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.SettingButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.SettingButton.Background = ButtonBackground;
                //    _UserPanelWindow.SettingButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.settingicon.Visibility = Visibility.Hidden;

                //}

            }

        }

        private void MusicButton_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button button)
            {

                button = e.Source as Button;




                SolidColorBrush ButtonBackground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonBackground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#02be68"));

                SolidColorBrush ButtonForeground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonForeground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"));



                button.Background = ButtonBackground2;
                button.Foreground = ButtonForeground;


                _UserPanelWindow.musicicon.Visibility = Visibility.Visible;

                _UserPanelWindow.uControl_Home_UC.Visibility = Visibility.Collapsed;

                _UserPanelWindow.uControl_Radio_UC.Visibility = Visibility.Collapsed;

                _UserPanelWindow.uControl_Music_UC.Visibility = Visibility.Visible;

                _UserPanelWindow.uControl_Playlist_UC.Visibility = Visibility.Collapsed;

                if (_UserPanelWindow.HomeButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.HomeButton.Background = ButtonBackground;
                    _UserPanelWindow.HomeButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.homeicon.Visibility = Visibility.Hidden;

                }


                if (_UserPanelWindow.RadioButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.RadioButton.Background = ButtonBackground;
                    _UserPanelWindow.RadioButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.radioicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.PlaylistButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.PlaylistButton.Background = ButtonBackground;
                    _UserPanelWindow.PlaylistButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.playlisticon.Visibility = Visibility.Hidden;

                }

                //if (_UserPanelWindow.ArtistButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.ArtistButton.Background = ButtonBackground;
                //    _UserPanelWindow.ArtistButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.artisticon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.AlbumButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.AlbumButton.Background = ButtonBackground;
                //    _UserPanelWindow.AlbumButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.albumicon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.NotificationButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.NotificationButton.Background = ButtonBackground;
                //    _UserPanelWindow.NotificationButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.notificationicon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.SettingButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.SettingButton.Background = ButtonBackground;
                //    _UserPanelWindow.SettingButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.settingicon.Visibility = Visibility.Hidden;

                //}

            }

        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button button)
            {

                button = e.Source as Button;


                SolidColorBrush ButtonBackground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonBackground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#02be68"));

                SolidColorBrush ButtonForeground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

                SolidColorBrush ButtonForeground2 = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"));



                button.Background = ButtonBackground2;
                button.Foreground = ButtonForeground;


                _UserPanelWindow.homeicon.Visibility = Visibility.Visible;


                _UserPanelWindow.uControl_Home_UC.Visibility = Visibility.Visible;
                _UserPanelWindow.uControl_Music_UC.Visibility = Visibility.Collapsed;
                _UserPanelWindow.uControl_Radio_UC.Visibility = Visibility.Collapsed;

                _UserPanelWindow.uControl_Playlist_UC.Visibility = Visibility.Collapsed;

                //var yourStyle = (Style)Application.Current.Resources["menuButton"];
                //var yourStyle2 = (Style)Application.Current.Resources["menuButtonIcon"];

                //_UserPanelWindow.MusicButton.Style = yourStyle;
                //_UserPanelWindow.homeicon.Style = yourStyle2;


                if (_UserPanelWindow.MusicButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.MusicButton.Background = ButtonBackground;
                    _UserPanelWindow.MusicButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.musicicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.RadioButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.RadioButton.Background = ButtonBackground;
                    _UserPanelWindow.RadioButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.radioicon.Visibility = Visibility.Hidden;

                }

                if (_UserPanelWindow.PlaylistButton.Background != ButtonBackground2)
                {
                    _UserPanelWindow.PlaylistButton.Background = ButtonBackground;
                    _UserPanelWindow.PlaylistButton.Foreground = ButtonForeground2;

                    _UserPanelWindow.playlisticon.Visibility = Visibility.Hidden;

                }

                //if (_UserPanelWindow.ArtistButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.ArtistButton.Background = ButtonBackground;
                //    _UserPanelWindow.ArtistButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.artisticon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.AlbumButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.AlbumButton.Background = ButtonBackground;
                //    _UserPanelWindow.AlbumButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.albumicon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.NotificationButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.NotificationButton.Background = ButtonBackground;
                //    _UserPanelWindow.NotificationButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.notificationicon.Visibility = Visibility.Hidden;

                //}

                //if (_UserPanelWindow.SettingButton.Background != ButtonBackground2)
                //{
                //    _UserPanelWindow.SettingButton.Background = ButtonBackground;
                //    _UserPanelWindow.SettingButton.Foreground = ButtonForeground2;

                //    _UserPanelWindow.settingicon.Visibility = Visibility.Hidden;

                //}
            }

        }



    }
}
