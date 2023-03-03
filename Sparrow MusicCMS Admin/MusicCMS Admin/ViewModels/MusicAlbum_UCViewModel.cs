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
using System.Windows;
using MusicCMS_Admin.Views.Helper_Views.Pop_up_Views;

namespace MusicCMS_Admin.ViewModels
{
    public class MusicAlbum_UCViewModel : BaseViewModel
    {
        public MusicAlbum_UC _MusicAlbum_UC { get; set; }


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

            private Music music;

            public Music Music
            {
                get { return music; }
                set { music = value; OnPropertyChanged(); }
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


            private Artist artist;

            public Artist Artist
            {
                get { return artist; }
                set { artist = value; OnPropertyChanged(); }
            }

            private ObservableCollection<Artist> artistCollection;

            public ObservableCollection<Artist> ArtistCollection
            {
                get { return artistCollection; }
                set { artistCollection = value; OnPropertyChanged(); }
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




            private MusicAlbum musicAlbum;

            public MusicAlbum MusicAlbum
        {
                get { return musicAlbum; }
                set { musicAlbum = value; OnPropertyChanged(); }
            }

            private ObservableCollection<MusicAlbum> musicAlbumCollection;

            public ObservableCollection<MusicAlbum> MusicAlbumCollection
        {
                get { return musicAlbumCollection; }
                set { musicAlbumCollection = value; OnPropertyChanged(); }
            }



            HttpClientHandler clientHandler { get; set; }


            DispatcherTimer timerGetList = new DispatcherTimer();


            private MediaPlayer mediaPlayer = new MediaPlayer();


            public RelayCommand AlbumMouseDoubleClick { get; set; }

            public RelayCommand AlbumListboxMouseDoubleClick { get; set; }


            public RelayCommand MusicSearchCommand { get; set; }

            public RelayCommand AlbumSearchCommand { get; set; }


            public RelayCommand CreateAlbumCommand { get; set; }


            public RelayCommand LoadedCommand { get; set; }


            public RelayCommand DeleteMusicCommand { get; set; }

            public RelayCommand AddMusicCommand { get; set; }


            public RelayCommand ExitAppCommand { get; set; }


            public int playpausecount = 0;

            int nextpreviouscount = 0;





            int userAccountId_forPlaylist_ { get; set; }


        int idMusic_ { get; set; }

        string musicName_ { get; set; }

        bool isPopularMusic_ { get; set; }

        string imageMusic_ { get; set; }

        string musicFile_ { get; set; }

        public int IdMusic_
        {
            get { return idMusic_; }
            set { idMusic_ = value; OnPropertyChanged(); }
        }

        public string MusicName_
        {
            get { return musicName_; }
            set { musicName_ = value; OnPropertyChanged(); }
        }

        public bool IsPopularMusic_
        {
            get { return isPopularMusic_; }
            set { isPopularMusic_ = value; OnPropertyChanged(); }
        }

        public string ImageMusic_
        {
            get { return imageMusic_; }
            set { imageMusic_ = value; OnPropertyChanged(); }
        }
        public string MusicFile_
        {
            get { return musicFile_; }
            set { musicFile_ = value; OnPropertyChanged(); }
        }

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


            int idArtist_ { get; set; }

            string artistName_ { get; set; }

            string imageArtist_ { get; set; }



            public int IdArtist_
            {
                get { return idArtist_; }
                set { idArtist_ = value; OnPropertyChanged(); }
            }

            public string ArtistName_
            {
                get { return artistName_; }
                set { artistName_ = value; OnPropertyChanged(); }
            }

            public string ImageArtist_
            {
                get { return imageArtist_; }
                set { imageArtist_ = value; OnPropertyChanged(); }
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

            public MusicAlbum_UCViewModel()
            {

                timerGetList.Tick += TimerGetList_Tick; ;

                timerGetList.Interval = TimeSpan.FromSeconds(1);


                ToastNotificationWindowList = new ObservableCollection<ToastNotificationWindow>();

                dynamic ListSelectedItem;
                dynamic ListSelectedItem2;

                sizecount = 5;
                ToastNotificationWindowIndex = 0;



                using (clientHandler = new HttpClientHandler())
                {
                    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                }


                LoadedCommand = new RelayCommand((e) =>
                {

                    _MusicAlbum_UC.Dispatcher.BeginInvoke(new Action(async () =>
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






                    }));

                });


                AlbumMouseDoubleClick = new RelayCommand((e) =>
                {

           


                    Task.Run(() =>
                    {

                        _MusicAlbum_UC.Dispatcher.BeginInvoke(new Action(async () =>
                        {

                            ListSelectedItem = _MusicAlbum_UC.AlbumListbox.SelectedItem as dynamic;

                            if (ListSelectedItem != null)
                            {
                                IdAlbum_ = ListSelectedItem.IdAlbum;
                                AlbumName_ = ListSelectedItem.AlbumName.ToString();
                                ImageAlbum_ = ListSelectedItem.ImageAlbum.ToString();


                                if (MusicAlbumCollection != null)
                                {



                                    var lists = from ma in MusicAlbumCollection
                                                join a in AlbumCollection on ma.AlbumId_forMusicAlbum equals a.IdAlbum
                                                join m in Musics on ma.MusicId_forMusicAlbum equals m.IdMusic
                                                where ma.AlbumId_forMusicAlbum == IdAlbum_
                                                select new Music { IdMusic = m.IdMusic, MusicName = m.MusicName, ImageMusic = m.ImageMusic, MusicFile = m.MusicFile, IsPopularMusic = m.IsPopularMusic };



                                    var myObservableCollection = new ObservableCollection<Music>(lists);

                                    Musics = new ObservableCollection<Music>();

                                    Musics = (ObservableCollection<Music>)myObservableCollection;

                                    _MusicAlbum_UC.MusicListbox.ItemsSource = null;
                                    _MusicAlbum_UC.MusicListbox.Items.Clear();
                                    _MusicAlbum_UC.MusicListbox.ItemsSource = Musics;


                                }
                            }
                        }));

                    });
                });


                MusicSearchCommand = new RelayCommand((e) =>
                {
                    _MusicAlbum_UC.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (string.IsNullOrEmpty(_MusicAlbum_UC.SearchTextboxForMusicListbox.Text))
                        {
                            if (timerGetList.IsEnabled == false)
                            {

                                timerGetList.Start();

                            }
                        }
                        else
                        {

                            timerGetList.Stop();


                            if (Musics != null)
                            {


                                _MusicAlbum_UC.MusicListbox.ItemsSource = null;

                                if (string.IsNullOrEmpty(_MusicAlbum_UC.SearchTextboxForMusicListbox.Text) == false)
                                {

                                    _MusicAlbum_UC.MusicListbox.ItemsSource = null;
                                    _MusicAlbum_UC.MusicListbox.Items.Clear();

                                    foreach (var item in Musics)
                                    {
                                        //var str = char.ToUpper(_Music_UC.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _Music_UC.SearchTextboxForMusicListbox.Text.ToLower().Substring(1);

                                        var str = char.ToUpper(_MusicAlbum_UC.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _MusicAlbum_UC.SearchTextboxForMusicListbox.Text.Substring(1);

                                        Debug.WriteLine(str);

                                        if (item.MusicName.Contains(str))
                                        {

                                            _MusicAlbum_UC.MusicListbox.Items.Add(item);
                                        }
                                        _MusicAlbum_UC.MusicListbox.ItemsSource = null;
                                    }
                                }

                                else
                                {
                                    _MusicAlbum_UC.MusicListbox.Items.Clear();

                                    foreach (var item in Musics)
                                    {

                                        _MusicAlbum_UC.MusicListbox.Items.Add(item);


                                    }
                                }

                            }
                        }


                    }));

                });


            AlbumSearchCommand = new RelayCommand((e) =>
            {
                _MusicAlbum_UC.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (string.IsNullOrEmpty(_MusicAlbum_UC.SearchTextboxForAlbumListbox.Text))
                    {
                        if (timerGetList.IsEnabled == false)
                        {

                            timerGetList.Start();

                        }
                    }
                    else
                    {

                        timerGetList.Stop();


                        if (AlbumCollection != null)
                        {


                            _MusicAlbum_UC.AlbumListbox.ItemsSource = null;

                            if (string.IsNullOrEmpty(_MusicAlbum_UC.SearchTextboxForAlbumListbox.Text) == false)
                            {

                                _MusicAlbum_UC.AlbumListbox.ItemsSource = null;
                                _MusicAlbum_UC.AlbumListbox.Items.Clear();

                                foreach (var item in AlbumCollection)
                                {
                                    //var str = char.ToUpper(_Music_UC.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _Music_UC.SearchTextboxForMusicListbox.Text.ToLower().Substring(1);

                                    var str = char.ToUpper(_MusicAlbum_UC.SearchTextboxForAlbumListbox.Text.ElementAt(0)) + _MusicAlbum_UC.SearchTextboxForAlbumListbox.Text.Substring(1);

                                    Debug.WriteLine(str);

                                    if (item.AlbumName.Contains(str))
                                    {

                                        _MusicAlbum_UC.AlbumListbox.Items.Add(item);
                                    }
                                    _MusicAlbum_UC.AlbumListbox.ItemsSource = null;
                                }
                            }

                            else
                            {
                                _MusicAlbum_UC.AlbumListbox.Items.Clear();

                                foreach (var item in AlbumCollection)
                                {

                                    _MusicAlbum_UC.AlbumListbox.Items.Add(item);


                                }
                            }

                        }
                    }


                }));

            });



            AddMusicCommand = new RelayCommand((e) =>
            {


                    Task.Run(() =>
                    {


                            _MusicAlbum_UC.Dispatcher.InvokeAsync(new Action(() =>
                            {

                                ListSelectedItem = _MusicAlbum_UC.AlbumListbox.SelectedItem as dynamic;

                                if (ListSelectedItem != null)
                                {

                                    IdAlbum_ = ListSelectedItem.IdAlbum;
                                    AlbumName_ = ListSelectedItem.AlbumName.ToString();
                                    ImageAlbum_ = ListSelectedItem.ImageAlbum.ToString();


                                    Album = new Album()
                                    {
                                        IdAlbum = IdAlbum_,
                                        AlbumName = AlbumName_,
                                        ImageAlbum = ImageAlbum_

                                    };



                                    Task.Run(() =>
                                    {
                                        Album.Serialize(Album, "../../../Asserts/Files/album.json");

                                    });


                                    var musicPopupWindow = new MusicPopupWindow();

                                    musicPopupWindow.ShowDialog();

                                }


                            }));
                   

                    });
                });



                DeleteMusicCommand = new RelayCommand((e) =>
                {

                    _MusicAlbum_UC.Dispatcher.BeginInvoke(new Action(async () =>
                    {

                        try
                        {


                            Task.Run(async () =>
                            {

                                _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");

                            });

                            if (_logIn != null)
                            {

                                ListSelectedItem2 = _MusicAlbum_UC.MusicListbox.SelectedItem as dynamic;

                                if (ListSelectedItem2 != null)
                                {

                                    IdMusic_  = ListSelectedItem2.IdMusic;
                                    MusicFile_ = ListSelectedItem2.MusicFile.ToString();

                                    MusicName_ = ListSelectedItem2.MusicName.ToString();

                                    ImageMusic_ = ListSelectedItem2.ImageMusic.ToString();


                                    Music = new Music()
                                    {
                                        IdMusic = IdMusic_,
                                        MusicName = MusicName_,
                                        ImageMusic = ImageMusic_,
                                        MusicFile = MusicFile_,
                                        IsPopularMusic = IsPopularMusic_,

                                    };


                                    MusicAlbum = new MusicAlbum();

                                    MusicAlbum = MusicAlbumCollection.Where(i => i.MusicId_forMusicAlbum == IdMusic_).FirstOrDefault();


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

                                        await DeleteMusicAlbum(_logIn.Username, _logIn.UserPassword, MusicAlbum);
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

            async Task DeleteMusicAlbum(string username, string password, MusicAlbum musicAlbum)
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


                            await ConnectionAPI.DeleteMusicAlbum(httpClient, username, password, "https://localhost:7270/api/Authenticate/login", musicAlbum);


                            //Task.Run(() =>
                            //{


                            //    FileWriteRead<Playlist>.WriteToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);

                            //});


                            ToastNotificationWindow = new ToastNotificationWindow($"{Music.MusicName} has been deleted from {AlbumName_}.", $"../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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




        private void TimerGetList_Tick(object? sender, EventArgs e)
        {
            _MusicAlbum_UC.Dispatcher.BeginInvoke(new Action(async () =>
            {

                    string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                    logincheck = JsonConvert.DeserializeObject<bool>(data2);

                    if (logincheck == true)
                    {

                        try
                        {


                            _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");




                            await GetMusic(_logIn.Username, _logIn.UserPassword);

                            await GetAlbum(_logIn.Username, _logIn.UserPassword);


                            await GetMusicAlbum(_logIn.Username, _logIn.UserPassword);


                        if (string.IsNullOrEmpty(_MusicAlbum_UC.SearchTextboxForAlbumListbox.Text))
                        {
                            _MusicAlbum_UC.SearchTextboxForAlbumListbox.Text = "  ";
                            _MusicAlbum_UC.SearchTextboxForAlbumListbox.Text = string.Empty;


                        }

                        if (string.IsNullOrEmpty(_MusicAlbum_UC.SearchTextboxForMusicListbox.Text))
                        {
                            _MusicAlbum_UC.SearchTextboxForMusicListbox.Text = "  ";
                            _MusicAlbum_UC.SearchTextboxForMusicListbox.Text = string.Empty;
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
                        _MusicAlbum_UC.AlbumListbox.ItemsSource = null;
                        _MusicAlbum_UC.AlbumListbox.Items.Clear();

                        _MusicAlbum_UC.MusicListbox.ItemsSource = null;
                        _MusicAlbum_UC.MusicListbox.Items.Clear();

                    }


             }));
        }






            async Task GetMusicAlbum(string username, string password)
            {
                if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
                {
                    using (var clientHandler = new HttpClientHandler())
                    {
                        using (var httpClient = new HttpClient(clientHandler))
                        {


                            var response = await ConnectionAPI.GetMusicAlbum(httpClient, username, password, "https://localhost:7270/api/Authenticate/login");


                            var musicAlbums = JsonConvert.DeserializeObject<ObservableCollection<MusicAlbum>>(response);

                                MusicAlbumCollection = new ObservableCollection<MusicAlbum>(musicAlbums);
                        }

                        //FileWriteRead<Playlist>.ReadToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);
                    }

                };
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


                        var albums = JsonConvert.DeserializeObject<ObservableCollection<Album>>(response);

                        AlbumCollection = new ObservableCollection<Album>(albums);


                        _MusicAlbum_UC.AlbumListbox.ItemsSource = AlbumCollection;
                    }

                    //FileWriteRead<Playlist>.ReadToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);
                }

            };
        }


        async Task GetMusic(string username, string password)
            {
                if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
                {
                    using (var clientHandler = new HttpClientHandler())
                    {
                        using (var httpClient = new HttpClient(clientHandler))
                        {


                            var response = await ConnectionAPI.GetMusic(httpClient, username, password, "https://localhost:7270/api/Authenticate/login");


                            var musics = JsonConvert.DeserializeObject<ObservableCollection<Music>>(response);

                        Musics = new ObservableCollection<Music>(musics);


                        if (MusicAlbumCollection != null)
                        {



                            var lists = from ma in MusicAlbumCollection
                                        join a in AlbumCollection on ma.AlbumId_forMusicAlbum equals a.IdAlbum
                                        join m in Musics on ma.MusicId_forMusicAlbum equals m.IdMusic
                                        where ma.AlbumId_forMusicAlbum == IdAlbum_
                                        select new Music { IdMusic = m.IdMusic, MusicName = m.MusicName, ImageMusic = m.ImageMusic, MusicFile = m.MusicFile, IsPopularMusic = m.IsPopularMusic };



                            var myObservableCollection = new ObservableCollection<Music>(lists);

                            Musics = new ObservableCollection<Music>();

                            Musics = (ObservableCollection<Music>)myObservableCollection;

                            _MusicAlbum_UC.MusicListbox.ItemsSource = null;
                            _MusicAlbum_UC.MusicListbox.Items.Clear();
                            _MusicAlbum_UC.MusicListbox.ItemsSource = Musics;


                        }

                    }

                        //FileWriteRead<Playlist>.ReadToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);
                    }

                };
            }
        
    }
}
