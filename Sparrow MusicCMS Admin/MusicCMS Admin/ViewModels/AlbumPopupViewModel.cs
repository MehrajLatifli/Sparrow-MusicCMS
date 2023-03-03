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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using MusicCMS_Admin.Views.Helper_Views.Pop_up_Views;

namespace MusicCMS_Admin.ViewModels
{



    public class AlbumPopupViewModel : BaseViewModel
    {
        public AlbumPopupWindow _AlbumPopupWindow { get; set; }




        File _file { get; set; }


        public File file { get { return _file; } set { _file = value; OnPropertyChanged(); } }


        Playerwork _playerwork { get; set; }


        public Playerwork playerwork { get { return _playerwork; } set { _playerwork = value; OnPropertyChanged(); } }


        LogIn _logIn { get; set; }

        PlaylistMusic _playlistMusic { get; set; }

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



        private ArtistAlbum artistAlbum ;

        public ArtistAlbum ArtistAlbum
        {
            get { return artistAlbum; }
            set { artistAlbum = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ArtistAlbum> artistAlbumCollection;

        public ObservableCollection<ArtistAlbum> ArtistAlbumCollection
        {
            get { return artistAlbumCollection; }
            set { artistAlbumCollection = value; OnPropertyChanged(); }
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



        HttpClientHandler clientHandler { get; set; }


        DispatcherTimer timerGetList = new DispatcherTimer();


        private MediaPlayer mediaPlayer = new MediaPlayer();


        public RelayCommand AddArtistAlbumCommand { get; set; }

        public RelayCommand AlbumListboxMouseDoubleClick { get; set; }


        public RelayCommand PlaylistSearchCommand { get; set; }

        public RelayCommand AlbumSearchCommand { get; set; }

        public RelayCommand AddMusictoPlaylisCommand { get; set; }

        public RelayCommand CreatePlaylisCommand { get; set; }


        public RelayCommand LoadedCommand { get; set; }


        public RelayCommand ExitAppCommand { get; set; }

        public RelayCommand PlaylistMusicWindow_MouseDownCommand { get; set; }

        public int playpausecount = 0;

        int nextpreviouscount = 0;



        string playlistName_ { get; set; }

        string playlistDescription_ { get; set; }

        string playlistDatetime_ { get; set; }

        string imagePlaylist_ { get; set; }

        int idPlaylist_ { get; set; }

        int userAccountId_forPlaylist_ { get; set; }

        public int IdPlaylist_
        {
            get { return idPlaylist_; }
            set { idPlaylist_ = value; OnPropertyChanged(); }
        }



        public string PlaylistName_
        {
            get { return playlistName_; }
            set { playlistName_ = value; OnPropertyChanged(); }
        }

        public string PlaylistDescription_
        {
            get { return playlistDescription_; }
            set { playlistDescription_ = value; OnPropertyChanged(); }
        }

        public string PlaylistDatetime_
        {
            get { return playlistDatetime_; }
            set { playlistDatetime_ = value; OnPropertyChanged(); }
        }

        public string ImagePlaylist_
        {
            get { return imagePlaylist_; }
            set { imagePlaylist_ = value; OnPropertyChanged(); }
        }

        public int UserAccountId_forPlaylist_
        {
            get { return userAccountId_forPlaylist_; }
            set { userAccountId_forPlaylist_ = value; OnPropertyChanged(); }
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



        int idArtistAlbum_ { get; set; }

        string artistId_forArtistAlbum_ { get; set; }

        string albumId_forArtistAlbum_ { get; set; }


        int idAlbum_ { get; set; }

        string albumName_ { get; set; }

        string imageAlbum_ { get; set; }


        public int IdArtistAlbum_
        {
            get { return idArtistAlbum_; }
            set { idArtistAlbum_ = value; OnPropertyChanged(); }
        }

        public string ArtistId_forArtistAlbum_
        {
            get { return artistId_forArtistAlbum_; }
            set { artistId_forArtistAlbum_ = value; OnPropertyChanged(); }
        }

        public string AlbumId_forArtistAlbum_
        {
            get { return albumId_forArtistAlbum_; }
            set { albumId_forArtistAlbum_ = value; OnPropertyChanged(); }
        }


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

        public AlbumPopupViewModel()
        {
            timerGetList.Tick += TimerGetList_Tick;

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
                Task.Run(() =>
                {
                    _AlbumPopupWindow.Dispatcher.BeginInvoke(new Action(async () =>
                    {
                        _logIn = new LogIn();

                        Album = new Album();

                        Artist = new Artist();

                        ArtistAlbum = new ArtistAlbum();

                        timerGetList.Start();
                    }));

                });
            });

            ExitAppCommand = new RelayCommand((e) =>
            {

                Task.Run(() =>
                {
                    _AlbumPopupWindow.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        _AlbumPopupWindow.Close();




                    }));
                });
            });

            PlaylistMusicWindow_MouseDownCommand = new RelayCommand(async (e) =>
            {
                //MouseButtonEventArgs ev = (MouseButtonEventArgs)e;

                //if (ev.ChangedButton == MouseButton.Left)
                //{
                //    if (_PlaylistMusicWindow != null)
                //    {
                //        _PlaylistMusicWindow.DragMove();

                //    }
                //}
            });




            AlbumListboxMouseDoubleClick = new RelayCommand((e) =>
            {


                Task.Run(() =>
                {

                    _AlbumPopupWindow.Dispatcher.BeginInvoke(new Action(async () =>
                    {


                        try
                        {

                            if (logincheck == true)
                            {

                                IdFile_ = string.Empty;
                                FileName_ = string.Empty;



                                _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");



                                Artist = await Artist.DeSerialize("../../../Asserts/Files/artist.json");




                                ListSelectedItem = _AlbumPopupWindow.AlbumListbox.SelectedItem as dynamic;



                                IdAlbum_ = ListSelectedItem.IdAlbum;
                                AlbumName_ = ListSelectedItem.AlbumName.ToString();
                                ImageAlbum_ = ListSelectedItem.ImageAlbum.ToString();


                                ArtistAlbum = new ArtistAlbum()
                                {

                                    ArtistId_forArtistAlbum = Artist.IdArtist,
                                    AlbumId_forArtistAlbum = Convert.ToInt32(IdAlbum_)

                                };




                                if (ArtistAlbum != null)
                                {


                                    await PostArtistAlbum(_logIn.Username, _logIn.UserPassword, ArtistAlbum);

                                 


                                }

                            }

                        }
                        catch (Exception)
                        {

                        }


                    }));

                });



            });


            AlbumSearchCommand = new RelayCommand((e) =>
            {
                _AlbumPopupWindow.Dispatcher.InvokeAsync(new Action(() =>
                {

                    if (AlbumCollection != null)
                        {


                            _AlbumPopupWindow.AlbumListbox.ItemsSource = null;

                            if (string.IsNullOrEmpty(_AlbumPopupWindow.SearchTextboxForAlbumbox.Text) == false)
                            {
                                _AlbumPopupWindow.AlbumListbox.ItemsSource = null;
                                _AlbumPopupWindow.AlbumListbox.Items.Clear();

                                foreach (var item in AlbumCollection)
                                {
                                    //var str = char.ToUpper(_Music_UC.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _Music_UC.SearchTextboxForMusicListbox.Text.ToLower().Substring(1);

                                    var str = char.ToUpper(_AlbumPopupWindow.SearchTextboxForAlbumbox.Text.ElementAt(0)) + _AlbumPopupWindow.SearchTextboxForAlbumbox.Text.Substring(1);

                                    Debug.WriteLine(str);

                                    if (item.AlbumName.Contains(str))
                                    {

                                        _AlbumPopupWindow.AlbumListbox.Items.Add(item);
                                    }
                                    _AlbumPopupWindow.AlbumListbox.ItemsSource = null;
                                }
                            }

                            else
                            {
                                _AlbumPopupWindow.AlbumListbox.Items.Clear();

                                foreach (var item in AlbumCollection)
                                {

                                    _AlbumPopupWindow.AlbumListbox.Items.Add(item);


                                }
                            }

                        }
                    

                }));
            });

        }

        private void TimerGetList_Tick(object? sender, EventArgs e)
        {
            _AlbumPopupWindow.Dispatcher.BeginInvoke(new Action(async () =>
            {

                string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                logincheck = JsonConvert.DeserializeObject<bool>(data2);

                if (logincheck == true)
                {

                    try
                    {


                        _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");



                        await GetAlbum(_logIn.Username, _logIn.UserPassword);

                        await GetArtist(_logIn.Username, _logIn.UserPassword);



                        if (string.IsNullOrEmpty(_AlbumPopupWindow.SearchTextboxForAlbumbox.Text))
                        {
                            _AlbumPopupWindow.SearchTextboxForAlbumbox.Text = "  ";
                            _AlbumPopupWindow.SearchTextboxForAlbumbox.Text = string.Empty;
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


                    _AlbumPopupWindow.AlbumListbox.ItemsSource = null;
                    _AlbumPopupWindow.AlbumListbox.Items.Clear();


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

        async Task GetArtist(string username, string password)
        {
            if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        var response = await ConnectionAPI.GetArtist(httpClient, username, password, "https://localhost:7270/api/Authenticate/login");


                        var artists = JsonConvert.DeserializeObject<ObservableCollection<Artist>>(response);

                        ArtistCollection = new ObservableCollection<Artist>(artists);
                    }

                    //FileWriteRead<Playlist>.ReadToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);
                }

            };
        }

        async Task PostArtistAlbum(string username, string password, ArtistAlbum artistAlbum)
        {
            if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        await ConnectionAPI.PostArtistAlbum(httpClient, username, password, "https://localhost:7270/api/Authenticate/login", artistAlbum);

                        //Task.Run(() =>
                        //{


                        //    FileWriteRead<Playlist>.WriteToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);

                        //});


                        ToastNotificationWindow = new ToastNotificationWindow(AlbumName_ + " " + "has been added.", ImageAlbum_, (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);

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

    }

}
