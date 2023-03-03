using MusicCMS.Command;
using MusicCMS.Helpers;
using MusicCMS.Models;
using MusicCMS.Views.Helper_Views.Notification_Views;
using MusicCMS.Views.Helper_Views.PlaylistMusic_Views;
using MusicCMS.Views.UserControls;
using Newtonsoft.Json;
using Sparrow_MusicCMS.Helpers;
using Sparrow_MusicCMS.ViewModels;
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
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Music = MusicCMS.Models.Data.Music;
using Playlist = MusicCMS.Models.Data.Playlist;
using Radio = MusicCMS.Models.Data.Radio;
using UserAccount = MusicCMS.Models.Data.UserAccount;
using MusicCMS.Views;
using System.Windows.Input;
using MusicCMS.Models.Data;
using MusicCMS_Entities.Concrete.DatabaseFirst;
using PlaylistMusic = MusicCMS.Models.Data.PlaylistMusic;

namespace MusicCMS.ViewModels
{
    public class PlaylistMusicViewModel : BaseViewModel
    {
        public PlaylistMusicWindow _PlaylistMusicWindow { get; set; }




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

        private Playlist playlist;

        public Playlist Playlist
        {
            get { return playlist; }
            set { playlist = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Playlist> playlistCollection;

        public ObservableCollection<Playlist> PlaylistCollection
        {
            get { return playlistCollection; }
            set { playlistCollection = value; OnPropertyChanged(); }
        }

        private PlaylistMusic playlistMusic;

        public PlaylistMusic PlaylistMusic
        {
            get { return playlistMusic; }
            set { playlistMusic = value; OnPropertyChanged(); }
        }

        private ObservableCollection<PlaylistMusic> playlistMusicCollection;

        public ObservableCollection<PlaylistMusic> PlaylistMusicCollection
        {
            get { return playlistMusicCollection; }
            set { playlistMusicCollection = value; OnPropertyChanged(); }
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


        public RelayCommand PlaylistSearchCommand { get; set; }

        public RelayCommand MusicSearchCommand { get; set; }

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

        public PlaylistMusicViewModel()
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
                    _PlaylistMusicWindow.Dispatcher.BeginInvoke(new Action(async () =>
                    {
                        _logIn = new LogIn();

                        Playlist = new Playlist();

                        PlaylistMusic = new PlaylistMusic();

                        timerGetList.Start();
                    }));
                });
            });

            ExitAppCommand = new RelayCommand((e) =>
            {
                Task.Run(() =>
                {

                    _PlaylistMusicWindow.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        _PlaylistMusicWindow.Close();



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

            AddMusictoPlaylisCommand = new RelayCommand((e) =>
            {


                Task.Run( () =>
                {

                    _PlaylistMusicWindow.Dispatcher.BeginInvoke(new Action(async () =>
                    {


                        try
                        {

                            if (logincheck == true)
                            {

                                IdFile_ = string.Empty;
                                FileName_ = string.Empty;


                                _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");


                                await GetPlayList(_logIn.Username, _logIn.UserPassword, _logIn.IdUserAccount);

                                //_playlistMusic.se(_playlistMusic, "../../../Asserts/Files/_playlistMusic.json");

                                //await GetPlayList(_logIn.Username, _logIn.UserPassword, _logIn.IdUserAccount);




                                Playlist = await Playlist.DeSerialize("../../../Asserts/Files/playlist.json");


                                ListSelectedItem = _PlaylistMusicWindow.MusicListbox.SelectedItem as dynamic;



                                IdFile_ = ListSelectedItem.IdMusic.ToString();
                                FileName_ = ListSelectedItem.MusicName.ToString();

                                PlaylistMusic = new PlaylistMusic()
                                {
                                    PlaylistId_forPlaylistMusic = Playlist.IdPlaylist,
                                    MusicId_forPlaylistMusic = Convert.ToInt32(IdFile_)

                                };




                                if (PlaylistMusic != null)
                                {
                                    await PostPlaylistMusic(_logIn.Username, _logIn.UserPassword, PlaylistMusic);


                                }
                            }

                        }
                        catch (Exception)
                        {

                        }


                    }));

                });



            });

            MusicSearchCommand = new RelayCommand((e) =>
            {

                if (Musics != null)
                {


                    _PlaylistMusicWindow.MusicListbox.ItemsSource = null;

                    if (string.IsNullOrEmpty(_PlaylistMusicWindow.SearchTextboxForMusicListbox.Text) == false)
                    {
                        _PlaylistMusicWindow.MusicListbox.ItemsSource = null;
                        _PlaylistMusicWindow.MusicListbox.Items.Clear();

                        foreach (var item in Musics)
                        {
                            //var str = char.ToUpper(_Music_UC.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _Music_UC.SearchTextboxForMusicListbox.Text.ToLower().Substring(1);

                            var str = char.ToUpper(_PlaylistMusicWindow.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _PlaylistMusicWindow.SearchTextboxForMusicListbox.Text.Substring(1);

                            Debug.WriteLine(str);

                            if (item.MusicName.Contains(str))
                            {

                                _PlaylistMusicWindow.MusicListbox.Items.Add(item);
                            }
                            _PlaylistMusicWindow.MusicListbox.ItemsSource = null;
                        }
                    }

                    else
                    {
                        _PlaylistMusicWindow.MusicListbox.Items.Clear();

                        foreach (var item in Musics)
                        {

                            _PlaylistMusicWindow.MusicListbox.Items.Add(item);


                        }
                    }

                }

            });

        }

        private void TimerGetList_Tick(object? sender, EventArgs e)
        {
            _PlaylistMusicWindow.Dispatcher.BeginInvoke(new Action(async () =>
            {

                string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                logincheck = JsonConvert.DeserializeObject<bool>(data2);

                if (logincheck == true)
                {

                    try
                    {


                        _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");



                        await GetMusic(_logIn.Username, _logIn.UserPassword);

                        


                        _PlaylistMusicWindow.MusicListbox.ItemsSource = Musics;


                        //if (_Music_UC.MusicListbox.ItemsSource!=null)
                        //{

                        //_Music_UC.MusicListbox.ItemsSource = Musics;
                        //}

                        _PlaylistMusicWindow.MusicListbox.ItemsSource = Musics;





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


                    _PlaylistMusicWindow.MusicListbox.ItemsSource = null;
                    _PlaylistMusicWindow.MusicListbox.Items.Clear();


                }


            }));

           
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


                        Musics = JsonConvert.DeserializeObject<ObservableCollection<Music>>(response);


                    }
                    //FileWriteRead<Music>.ReadToFile("../../../Asserts/Files/_logIn.json", Musics);
                }

            };
        }

        async Task GetPlayList(string username, string password, int userid)
        {
            if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        var response = await ConnectionAPI.GetPlaylist(httpClient, username, password, "https://localhost:7270/api/Authenticate/login");


                        var playlist = JsonConvert.DeserializeObject<ObservableCollection<Playlist>>(response).Where(p => p.UserAccountId_forPlaylist == userid);

                        PlaylistCollection = new ObservableCollection<Playlist>(playlist);
                    }

                    //FileWriteRead<Playlist>.ReadToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);
                }

            };
        }

        async Task PostPlaylistMusic(string username, string password, PlaylistMusic playlistMusic)
        {
            if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        await ConnectionAPI.PostPlaylistMusic(httpClient, username, password, "https://localhost:7270/api/Authenticate/login", playlistMusic);

                        //Task.Run(() =>
                        //{


                        //    FileWriteRead<Playlist>.WriteToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);

                        //});


                        ToastNotificationWindow = new ToastNotificationWindow( FileName_ + " " + "has been added.", playlist.ImagePlaylist, (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);

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
