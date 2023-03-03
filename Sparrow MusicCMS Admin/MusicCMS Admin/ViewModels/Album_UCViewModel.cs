using MusicCMS_Admin.Command;
using MusicCMS_Admin.Helpers;
using MusicCMS_Admin.Models.Data;
using MusicCMS_Admin.Models;
using MusicCMS_Admin.Views.Helper_Views.Notification_Views;
using MusicCMS_Admin.Views.UserControls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace MusicCMS_Admin.ViewModels
{

    public class Album_UCViewModel : BaseViewModel
    {
        public Album_UC _Album_UC { get; set; }

        File _file { get; set; }


        public File file { get { return _file; } set { _file = value; OnPropertyChanged(); } }


        Playerwork _playerwork { get; set; }


        public Playerwork playerwork { get { return _playerwork; } set { _playerwork = value; OnPropertyChanged(); } }


        LogIn _logIn { get; set; }



        public ToastNotificationWindow toastNotificationWindow { get; set; }

        public ToastNotificationWindow ToastNotificationWindow
        {
            get { return toastNotificationWindow; }
            set { toastNotificationWindow = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ToastNotificationWindow> toastNotificationWindowList;

        public ObservableCollection<ToastNotificationWindow> ToastNotificationWindowList
        {
            get { return toastNotificationWindowList; }
            set { toastNotificationWindowList = value; OnPropertyChanged(); }
        }


        private int _ToastNotificationWindowIndex;
        public int ToastNotificationWindowIndex
        {


            get { return _ToastNotificationWindowIndex; }
            set { _ToastNotificationWindowIndex = value; OnPropertyChanged(); }

        }

        private Music currentMusic;

        public Music CurrentMusic
        {
            get { return currentMusic; }
            set { currentMusic = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Music> musics;

        public ObservableCollection<Music> Musics
        {
            get { return musics; }
            set { musics = value; OnPropertyChanged(); }
        }




        private Album album;

        public Album Album
        {
            get { return album; }
            set { album = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Album> albumCollection;

        public ObservableCollection<Album> AlbumCollection
        {
            get { return albumCollection; }
            set { albumCollection = value; OnPropertyChanged(); }
        }



        private Radio radio;

        public Radio Radio
        {
            get { return radio; }
            set { radio = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Radio> radioCollection;

        public ObservableCollection<Radio> RadioCollection
        {
            get { return radioCollection; }
            set { radioCollection = value; OnPropertyChanged(); }
        }


        private UserAccount userAccount;

        public UserAccount UserAccount
        {
            get { return userAccount; }
            set { userAccount = value; OnPropertyChanged(); }
        }

        private ObservableCollection<UserAccount> userAccounts;

        public ObservableCollection<UserAccount> UserAccounts
        {
            get { return userAccounts; }
            set { userAccounts = value; OnPropertyChanged(); }
        }



        HttpClientHandler clientHandler { get; set; }


        DispatcherTimer timerGetList = new DispatcherTimer();


        private MediaPlayer mediaPlayer = new MediaPlayer();


        public RelayCommand MusicListboxMouseDoubleClick { get; set; }

        public RelayCommand AlbumListboxMouseDoubleClick { get; set; }


        public RelayCommand AlbumSearchCommand { get; set; }



        public RelayCommand CreateAlbumCommand { get; set; }


        public RelayCommand LoadedCommand { get; set; }


        public RelayCommand DeleteAlbumCommand { get; set; }

        public RelayCommand AddMusicPlaylisCommand { get; set; }


        public RelayCommand ExitAppCommand { get; set; }


        public int playpausecount = 0;

        int nextpreviouscount = 0;





        int userAccountId_forPlaylist_ { get; set; }


        string idFile_ { get; set; }

        string filePath_ { get; set; }

        string fileName_ { get; set; }

        string fileImage_ { get; set; }

        public string IdFile_
        {
            get { return idFile_; }
            set { idFile_ = value; OnPropertyChanged(); }
        }

        public string FilePath_
        {
            get { return filePath_; }
            set { filePath_ = value; OnPropertyChanged(); }
        }

        public string FileName_
        {
            get { return fileName_; }
            set { fileName_ = value; OnPropertyChanged(); }
        }

        public string FileImage_
        {
            get { return fileImage_; }
            set { fileImage_ = value; OnPropertyChanged(); }
        }

        int idAlbum_ { get; set; }

        string albumName_ { get; set; }

        string imageAlbum_ { get; set; }



        public int IdAlbum_
        {
            get { return idAlbum_; }
            set { idAlbum_ = value; OnPropertyChanged(); }
        }

        public string AlbumName_
        {
            get { return albumName_; }
            set { albumName_ = value; OnPropertyChanged(); }
        }

        public string ImageAlbum_
        {
            get { return imageAlbum_; }
            set { imageAlbum_ = value; OnPropertyChanged(); }
        }


        int changeRegistrationCount = 0;

        Border border = new Border();




        bool logincheck_ { get; set; }

        public bool logincheck
        {
            get { return logincheck_; }
            set { logincheck_ = value; OnPropertyChanged(); }
        }






        static ManualResetEvent mre = new ManualResetEvent(false);





        private double _sizecount;
        public double sizecount
        {

            get { return _sizecount; }
            set { _sizecount = value; OnPropertyChanged(); }

        }

        public CancellationTokenSource cts = new CancellationTokenSource();

        Player_UCViewModel _Player_UCViewModel { get; set; }

        Player_UC player_UC { get; set; }

        public Album_UCViewModel()
        {

            timerGetList.Tick += TimerGetList_Tick; ;

            timerGetList.Interval = TimeSpan.FromSeconds(1);


            ToastNotificationWindowList = new ObservableCollection<ToastNotificationWindow>();

            dynamic ListSelectedItem;

            sizecount = 5;
            ToastNotificationWindowIndex = 0;



            using (clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            }


            LoadedCommand = new RelayCommand((e) =>
            {

                _Album_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {
                    _logIn = new LogIn();

                    timerGetList.Start();


                    //Task.Run(() =>
                    //{

                    //    if (System.IO.File.Exists("../../../Asserts/Files/playlist.json"))
                    //    {
                    //        System.IO.File.Delete("../../../Asserts/Files/playlist.json");


                    //    }

                    //});

                    //                    System.Net.ServicePointManager.SecurityProtocol =
                    //SecurityProtocolType.Tls12 |
                    //SecurityProtocolType.Tls11 |
                    //SecurityProtocolType.Tls;


                    if (string.IsNullOrEmpty(_Album_UC.AlbumNameTextbox.Text))
                    {
                        _Album_UC.AlbumNameTextbox.Text = "Album name";
                        _Album_UC.AlbumNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
                    }







                    _Album_UC.AlbumNameTextbox.MouseEnter += AlbumNameTextbox_MouseEnter;
                    _Album_UC.AlbumNameTextbox.MouseLeave += AlbumNameTextbox_MouseLeave;



                }));

            });


            AlbumSearchCommand = new RelayCommand((e) =>
            {

                _Album_UC.Dispatcher.InvokeAsync(new Action(() =>
                {


                    if (AlbumCollection != null)
                    {


                        _Album_UC.AlbumListbox.ItemsSource = null;

                        if (string.IsNullOrEmpty(_Album_UC.SearchTextboxForAlbumListbox.Text) == false)
                        {
                            _Album_UC.AlbumListbox.ItemsSource = null;
                            _Album_UC.AlbumListbox.Items.Clear();
                            foreach (var item in AlbumCollection)
                            {
                                //var str = char.ToUpper(_Music_UC.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _Music_UC.SearchTextboxForMusicListbox.Text.ToLower().Substring(1);

                                var str = char.ToUpper(_Album_UC.SearchTextboxForAlbumListbox.Text.ElementAt(0)) + _Album_UC.SearchTextboxForAlbumListbox.Text.Substring(1);

                                Debug.WriteLine(str);

                                if (item.AlbumName.Contains(str))
                                {

                                    _Album_UC.AlbumListbox.Items.Add(item);
                                }
                                _Album_UC.AlbumListbox.ItemsSource = null;
                            }
                        }

                        else
                        {
                            _Album_UC.AlbumListbox.Items.Clear();

                            foreach (var item in AlbumCollection)
                            {

                                _Album_UC.AlbumListbox.Items.Add(item);


                            }
                        }

                    }


                }));

            });



            CreateAlbumCommand = new RelayCommand((e) =>
            {

                _Album_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {
                    if (logincheck == true)
                    {

                        _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");


                        Album = new Album()
                        {
                            AlbumName = _Album_UC.AlbumNameTextbox.Text,
                            ImageAlbum = "./../../../Asserts/Images/Images/album_qdepai.png"

                        };

                        if (Album != null)
                        {
                            await PostAlbum(_logIn.Username, _logIn.UserPassword, Album);




                        }
                    }
                }));

            });




            DeleteAlbumCommand = new RelayCommand((e) =>
            {

                _Album_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {

                    try
                    {



                        Task.Run(async () =>
                        {

                            _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");

                        });

                        if (_logIn != null)
                        {

                            ListSelectedItem = _Album_UC.AlbumListbox.SelectedItem as dynamic;

                            if (ListSelectedItem != null)
                            {
                                IdAlbum_ = ListSelectedItem.IdAlbum;
                                AlbumName_ = ListSelectedItem.AlbumName.ToString();
                                ImageAlbum_ = ListSelectedItem.ImageAlbum.ToString();

                                Album = new Album()
                                {
                                    IdAlbum = IdAlbum_,
                                    AlbumName = AlbumName_,
                                    ImageAlbum = "https://res.cloudinary.com/sociala/image/upload/v1674239244/MusicCMS/User/album_b6qtbl.png"

                                };

                                //Playlist = new Playlist();
                                //Playlist.IdPlaylist = IdPlaylist_;

                                //MessageBox.Show(IdPlaylist_.ToString());


                                //  MessageBox.Show(IdPlaylist_.ToString());

                                //for (int i = 0; i < _Playlist_UC.PlaylistListbox.SelectedItems.Count; i++)
                                //{
                                //    foreach (Playlist p in PlaylistCollection)
                                //    {


                                //MessageBox.Show(p.PlaylistName.ToString());

                                //    }
                                //    //_Playlist_UC.PlaylistListbox.Items.Remove(_Playlist_UC.PlaylistListbox.SelectedItems[i]);
                                //}

                                if (Album != null)
                                {

                                    await DeleteAlbum(_logIn.Username, _logIn.UserPassword, Album);
                                }


                            }

                        }
                    }
                    catch (Exception)
                    {

                    }
                }));

            });





        }

        async Task DeleteAlbum(string username, string password, Album Album)
        {

            if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    ServicePointManager.Expect100Continue = true;
                    clientHandler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                    clientHandler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
                    //clientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        await ConnectionAPI.DeleteAlbum(httpClient, username, password, "https://localhost:7270/api/Authenticate/login", Album);


                        //Task.Run(() =>
                        //{


                        //    FileWriteRead<Playlist>.WriteToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);

                        //});


                        ToastNotificationWindow = new ToastNotificationWindow($"{Album.AlbumName} has been deleted.", $"../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
                        ToastNotificationWindow.Show();

                        if (ToastNotificationWindow.Top <= 0)
                        {
                            sizecount = 5;
                        }

                        else
                        {
                            //sizecount = sizecount + 80;
                        }

                    }



                }

            };
        }

        async Task PostAlbum(string username, string password, Album Album)
        {
            if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        await ConnectionAPI.PostAlbum(httpClient, username, password, "https://localhost:7270/api/Authenticate/login", Album);

                        //Task.Run(() =>
                        //{


                        //    FileWriteRead<Playlist>.WriteToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);

                        //});


                        ToastNotificationWindow = new ToastNotificationWindow("A Album named" + " " + Album.AlbumName + " " + "has been created.", Album.ImageAlbum, (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);

                        ToastNotificationWindowList.Add(ToastNotificationWindow);

                        ToastNotificationWindowList.ElementAt(ToastNotificationWindowIndex).Show();


                        if (ToastNotificationWindowList.ElementAt(ToastNotificationWindowIndex).Top <= 0)
                        {
                            sizecount = 5;

                        }

                        else
                        {
                            sizecount = sizecount + 80;
                        }

                        if (ToastNotificationWindowIndex > 0)
                        {



                            if (ToastNotificationWindowList.ElementAt(ToastNotificationWindowIndex - 1).Close_ == true)
                            {

                                sizecount = 5;

                            }
                        }


                        ToastNotificationWindowIndex++;

                    }



                }

            };
        }

        private void AlbumNameTextbox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_Album_UC.AlbumNameTextbox.Text))
            {
                _Album_UC.AlbumNameTextbox.Text = "Album name";
                _Album_UC.AlbumNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
            }
        }

        private void AlbumNameTextbox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_Album_UC.AlbumNameTextbox.Text == "Album name")
            {
                _Album_UC.AlbumNameTextbox.Text = "";
                _Album_UC.AlbumNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }

        private void TimerGetList_Tick(object? sender, EventArgs e)
        {
            _Album_UC.Dispatcher.BeginInvoke(new Action(async () =>
            {

                string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                logincheck = JsonConvert.DeserializeObject<bool>(data2);

                if (logincheck == true)
                {

                    try
                    {


                        _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");



                        await GetAlbum(_logIn.Username, _logIn.UserPassword);


                        if (string.IsNullOrEmpty(_Album_UC.SearchTextboxForAlbumListbox.Text))
                        {
                            _Album_UC.SearchTextboxForAlbumListbox.Text = "  ";
                            _Album_UC.SearchTextboxForAlbumListbox.Text = string.Empty;
                        }



                        //if (_Music_UC.MusicListbox.ItemsSource!=null)
                        //{

                        //_Music_UC.MusicListbox.ItemsSource = Musics;
                        //}





                    }
                    catch (Exception)
                    {

                    }



                    //var fi = _Music_UC.GetType().GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
                    //if (fi != null)
                    //{
                    //    object obj = fi.GetValue(_Music_UC);
                    //    PropertyInfo pi = _Music_UC.MusicListbox.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                    //    EventHandlerList list = (EventHandlerList)pi.GetValue(_Music_UC, null);
                    //    list.RemoveHandler(obj, list[obj]);
                    //}


                    [DllImport("kernel32.dll")]
                    static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

                    SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);

                }
                else
                {
                    _Album_UC.AlbumListbox.ItemsSource = null;
                    _Album_UC.AlbumListbox.Items.Clear();



                }


            }));
        }





        async Task GetAlbum(string username, string password)
        {
            if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        var response = await ConnectionAPI.GetAlbum(httpClient, username, password, "https://localhost:7270/api/Authenticate/login");


                        var Albums = JsonConvert.DeserializeObject<ObservableCollection<Album>>(response);

                        AlbumCollection = new ObservableCollection<Album>(Albums);
                    }

                    //FileWriteRead<Playlist>.ReadToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);
                }

            };
        }
    }
}
