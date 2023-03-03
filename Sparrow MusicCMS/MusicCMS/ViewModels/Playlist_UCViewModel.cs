
using IdentityServer4.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.TransportationModel;
using Microsoft.EntityFrameworkCore.TestModels.UpdatesModel;
using MusicCMS.Command;
using MusicCMS.Helpers;
using MusicCMS.Models;
using MusicCMS.Models.Data;
using MusicCMS.Views.Helper_Views.Notification_Views;
using MusicCMS.Views.Helper_Views.PlaylistMusic_Views;
using MusicCMS.Views.UserControls;
using MusicCMS_Entities.Concrete.DatabaseFirst;
using Newtonsoft.Json;
using ProtoTest;
using Sparrow_MusicCMS.Helpers;
using Sparrow_MusicCMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Music = MusicCMS.Models.Data.Music;
using Playlist = MusicCMS.Models.Data.Playlist;
using PlaylistMusic = MusicCMS.Models.Data.PlaylistMusic;
using Radio = MusicCMS.Models.Data.Radio;
using UserAccount = MusicCMS.Models.Data.UserAccount;

namespace MusicCMS.ViewModels
{
    public class Playlist_UCViewModel :BaseViewModel
    {
        public Playlist_UC _Playlist_UC { get; set; }


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



        private Playlist  playlist;

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

        public RelayCommand PlaylistListboxMouseDoubleClick { get; set; }


        public RelayCommand PlaylistSearchCommand { get; set; }



        public RelayCommand CreatePlaylisCommand { get; set; }


        public RelayCommand LoadedCommand { get; set; }


        public RelayCommand DeletePlaylistCommand { get; set; }

        public RelayCommand AddMusicPlaylisCommand { get; set; }

        public RelayCommand MusicSearchCommand { get; set; }

        public RelayCommand ExitAppCommand { get; set; }


        public int playpausecount = 0;

        int nextpreviouscount = 0;

 

        string playlistName_ { get; set; }

        string playlistDescription_ { get; set; }

        string playlistDatetime_ { get; set; }

        string imagePlaylist_ { get; set; }

        int idPlaylist_ { get; set; }

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

        public Playlist_UCViewModel()
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

                _Playlist_UC.Dispatcher.BeginInvoke(new Action(async () =>
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


                    if (string.IsNullOrEmpty(_Playlist_UC.PlaylistNameTextbox.Text))
                    {
                        _Playlist_UC.PlaylistNameTextbox.Text = "Playlist name";
                        _Playlist_UC.PlaylistNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
                    }



                    if (string.IsNullOrWhiteSpace(GetRichTextBox(_Playlist_UC.PlaylistDescriptionRichTextBox)))
                    {
                        SetRichTextBox(_Playlist_UC.PlaylistDescriptionRichTextBox, "Playlist description");
                        _Playlist_UC.PlaylistDescriptionRichTextBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));

                    }




                    _Playlist_UC.PlaylistNameTextbox.MouseEnter += PlaylistNameTextbox_MouseEnter;
                    _Playlist_UC.PlaylistNameTextbox.MouseLeave += PlaylistNameTextbox_MouseLeave;

                    _Playlist_UC.PlaylistDescriptionRichTextBox.MouseEnter += PlaylistDescriptionRichTextBox_MouseEnter;
                    _Playlist_UC.PlaylistDescriptionRichTextBox.MouseLeave += PlaylistDescriptionRichTextBox_MouseLeave;



                }));

            });



            DeletePlaylistCommand = new RelayCommand( (e) =>
            {

                    _Playlist_UC.Dispatcher.BeginInvoke(new Action(async () =>
                    {
                        if (logincheck == true)
                        {


                            Task.Run(async () =>
                            {

                                _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");

                            });

                            if (_logIn != null)
                            {

                                ListSelectedItem = _Playlist_UC.PlaylistListbox.SelectedItem as dynamic;

                                if (ListSelectedItem != null)
                                {
                                    IdPlaylist_ = ListSelectedItem.IdPlaylist;
                                    PlaylistName_ = ListSelectedItem.PlaylistName.ToString();
                                    PlaylistDescription_ = ListSelectedItem.PlaylistDescription.ToString();
                                    PlaylistDatetime_ = ListSelectedItem.PlaylistDatetime.ToString();
                                    ImagePlaylist_ = ListSelectedItem.ImagePlaylist.ToString();
                                    UserAccountId_forPlaylist_ = ListSelectedItem.UserAccountId_forPlaylist;

                                    Playlist = new Playlist()
                                    {
                                        IdPlaylist = IdPlaylist_,
                                        PlaylistName = PlaylistName_,
                                        PlaylistDescription = PlaylistDescription_,
                                        PlaylistDatetime = PlaylistDatetime_,
                                        ImagePlaylist = ImagePlaylist_,
                                        UserAccountId_forPlaylist = UserAccountId_forPlaylist_
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

                                    if (Playlist != null)
                                    {

                                        await DeletePlaylist(_logIn.Username, _logIn.UserPassword, Playlist);
                                    }

                                }


                            }

                 

                        }

                    }));

            });


            AddMusicPlaylisCommand = new RelayCommand((e) =>
            {


                        Task.Run( () =>
                        {

                            _Playlist_UC.Dispatcher.BeginInvoke(new Action(async () =>
                            {

                                ListSelectedItem = _Playlist_UC.PlaylistListbox.SelectedItem as dynamic;

                                if (ListSelectedItem != null)
                                {
                                    IdPlaylist_ = ListSelectedItem.IdPlaylist;
                                    PlaylistName_ = ListSelectedItem.PlaylistName.ToString();
                                    PlaylistDescription_ = ListSelectedItem.PlaylistDescription.ToString();
                                    PlaylistDatetime_ = ListSelectedItem.PlaylistDatetime.ToString();
                                    ImagePlaylist_ = ListSelectedItem.ImagePlaylist.ToString();
                                    UserAccountId_forPlaylist_ = ListSelectedItem.UserAccountId_forPlaylist;


                                    Playlist = new Playlist()
                                    {
                                        IdPlaylist = IdPlaylist_,
                                        PlaylistName = PlaylistName_,
                                        PlaylistDescription = PlaylistDescription_,
                                        PlaylistDatetime = PlaylistDatetime_,
                                        ImagePlaylist = ImagePlaylist_,
                                        UserAccountId_forPlaylist = UserAccountId_forPlaylist_

                                    };
                                }

                            Task.Run(() =>
                            {
                                Playlist.Serialize(Playlist, "../../../Asserts/Files/playlist.json");
                            });

                                var PlaylistMusicWindow = new PlaylistMusicWindow();

                                PlaylistMusicWindow.ShowDialog();

                            }));

                        });
            });


            CreatePlaylisCommand = new RelayCommand((e) =>
            {

                _Playlist_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {
                    if (logincheck == true)
                    {

                        _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");


                        Playlist = new Playlist()
                        {
                            PlaylistName = _Playlist_UC.PlaylistNameTextbox.Text,
                            PlaylistDescription = RemoveSpecialCharacters(GetRichTextBox(_Playlist_UC.PlaylistDescriptionRichTextBox)),
                            PlaylistDatetime = DateTime.Now.ToString(),
                            ImagePlaylist = "https://res.cloudinary.com/sociala/image/upload/v1673725697/MusicCMS/User/playlist_ut8qkj.png",
                            UserAccountId_forPlaylist = _logIn.IdUserAccount

                        };

                        if (Playlist != null)
                        {
                            await PostPlaylist(_logIn.Username, _logIn.UserPassword, Playlist);




                        }
                    }
                }));

            });


            PlaylistListboxMouseDoubleClick = new RelayCommand((e) =>
            {

                _Playlist_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {

                    ListSelectedItem = _Playlist_UC.PlaylistListbox.SelectedItem as dynamic;

                    if (ListSelectedItem != null)
                    {


                        IdPlaylist_ = ListSelectedItem.IdPlaylist;
                        PlaylistName_ = ListSelectedItem.PlaylistName.ToString();
                        PlaylistDescription_ = ListSelectedItem.PlaylistDescription.ToString();
                        PlaylistDatetime_ = ListSelectedItem.PlaylistDatetime.ToString();
                        ImagePlaylist_ = ListSelectedItem.ImagePlaylist.ToString();
                        UserAccountId_forPlaylist_ = ListSelectedItem.UserAccountId_forPlaylist;

                    }
                }));



                string musicname = string.Empty;



                if (PlaylistMusicCollection != null)
                {



                    var takencourses = from sc in PlaylistMusicCollection
                                       join s in PlaylistCollection on sc.PlaylistId_forPlaylistMusic equals s.IdPlaylist
                                       join c in Musics on sc.MusicId_forPlaylistMusic equals c.IdMusic
                                       where s.IdPlaylist== IdPlaylist_
                                       select new Music { IdMusic=c.IdMusic, ImageMusic =c.ImageMusic, IsPopularMusic=c.IsPopularMusic, MusicFile=c.MusicFile, MusicName=c.MusicName };



                    var myObservableCollection = new ObservableCollection<Music>(takencourses);

                    Musics = new ObservableCollection<Music>();

                    Musics = (ObservableCollection<Music>)myObservableCollection;

                    _Playlist_UC.MusicListbox.ItemsSource = null;
                    _Playlist_UC.MusicListbox.Items.Clear();
                    _Playlist_UC.MusicListbox.ItemsSource = takencourses;


                }


            });


            MusicSearchCommand = new RelayCommand((e) =>
            {
                if (string.IsNullOrEmpty(_Playlist_UC.SearchTextboxForMusicListbox.Text))
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


                        _Playlist_UC.MusicListbox.ItemsSource = null;

                        if (string.IsNullOrEmpty(_Playlist_UC.SearchTextboxForMusicListbox.Text) == false)
                        {
                            _Playlist_UC.MusicListbox.ItemsSource = null;
                            _Playlist_UC.MusicListbox.Items.Clear();

                            foreach (var item in Musics)
                            {
                                //var str = char.ToUpper(_Music_UC.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _Music_UC.SearchTextboxForMusicListbox.Text.ToLower().Substring(1);

                                var str = char.ToUpper(_Playlist_UC.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _Playlist_UC.SearchTextboxForMusicListbox.Text.Substring(1);

                                Debug.WriteLine(str);

                                if (item.MusicName.Contains(str))
                                {

                                    _Playlist_UC.MusicListbox.Items.Add(item);
                                }
                                _Playlist_UC.MusicListbox.ItemsSource = null;
                            }
                        }

                        else
                        {
                            _Playlist_UC.MusicListbox.Items.Clear();

                            foreach (var item in Musics)
                            {

                                _Playlist_UC.MusicListbox.Items.Add(item);


                            }
                        }

                    }
                }

            });


            MusicListboxMouseDoubleClick = new RelayCommand((e) =>
            {
                _Playlist_UC.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (_Playlist_UC.MusicListbox.SelectedItem != null)
                    {

                        ListSelectedItem = _Playlist_UC.MusicListbox.SelectedItem as dynamic;

                        IdFile_ = ListSelectedItem.IdMusic.ToString();
                        FilePath_ = ListSelectedItem.MusicFile.ToString();

                        FileName_ = ListSelectedItem.MusicName.ToString();

                        FileImage_ = ListSelectedItem.ImageMusic.ToString();

                        file = new File()
                        {
                            FileName = FileName_,
                            FilePath = FilePath_,
                            FileImage = FileImage_,
                            IdFile = IdFile_

                        };

                        playerwork = new Playerwork()
                        {

                            IdMusic = IdFile_,
                            playerstatus = true,

                        };

                        playerwork.Serialize(playerwork, "../../../Asserts/Files/player.json");


                        file.Serialize(file, "../../../Asserts/Files/file.json");



                        ToastNotificationWindow = new ToastNotificationWindow(FileName_, FileImage_, (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);

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




                        //_ToastNotificationWindow = new ToastNotificationWindow(FileName, FileImage, (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
                        //_ToastNotificationWindow.Show();

                        //var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;

                        //if (_ToastNotificationWindow.Top<=0)
                        //{
                        //  sizecount = 5;
                        //}

                        //else
                        //{

                        //    //sizecount = sizecount + 80;
                        //}


                    }

                }));


            });

        }

        private async void PlaylistDescriptionRichTextBox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GetRichTextBox(_Playlist_UC.PlaylistDescriptionRichTextBox)))
            {
                SetRichTextBox(_Playlist_UC.PlaylistDescriptionRichTextBox, "Playlist description");
                _Playlist_UC.PlaylistDescriptionRichTextBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
            }
        }

        private async void PlaylistDescriptionRichTextBox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {


            string s = GetRichTextBox(_Playlist_UC.PlaylistDescriptionRichTextBox);



            if (s == "Playlist description\r\n")
            {
                _Playlist_UC.PlaylistDescriptionRichTextBox.Document.Blocks.Clear();
                _Playlist_UC.PlaylistDescriptionRichTextBox.Focus();

                _Playlist_UC.PlaylistDescriptionRichTextBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }


        }

        private async void PlaylistNameTextbox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_Playlist_UC.PlaylistNameTextbox.Text))
            {
                _Playlist_UC.PlaylistNameTextbox.Text = "Playlist name";
                _Playlist_UC.PlaylistNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
            }
        }

        private async void PlaylistNameTextbox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_Playlist_UC.PlaylistNameTextbox.Text == "Playlist name")
            {
                _Playlist_UC.PlaylistNameTextbox.Text = "";
                _Playlist_UC.PlaylistNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }

        private async void TimerGetList_Tick(object? sender, EventArgs e)
        {
            _Playlist_UC.Dispatcher.BeginInvoke(new Action(async () =>
            {

                string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                logincheck = JsonConvert.DeserializeObject<bool>(data2);

                if (logincheck == true)
                {

                    try
                    {


                        _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");



                        await GetMusic(_logIn.Username, _logIn.UserPassword);

                        await GetPlayList(_logIn.Username, _logIn.UserPassword, _logIn.IdUserAccount);

                        await GetPlaylistMusic(_logIn.Username, _logIn.UserPassword);

                        _Playlist_UC.MusicListbox.ItemsSource = Musics;


                        //if (_Music_UC.MusicListbox.ItemsSource!=null)
                        //{

                        //_Music_UC.MusicListbox.ItemsSource = Musics;
                        //}

                        _Playlist_UC.PlaylistListbox.ItemsSource = PlaylistCollection;





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
                    _Playlist_UC.PlaylistListbox.ItemsSource = null;
                    _Playlist_UC.PlaylistListbox.Items.Clear();

                    _Playlist_UC.MusicListbox.ItemsSource = null;
                    _Playlist_UC.MusicListbox.Items.Clear();


                }


            }));
        }



        async Task GetPlaylistMusic(string username, string password)
        {
            if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        var response = await ConnectionAPI.GetPlaylistMusic(httpClient, username, password, "https://localhost:7270/api/Authenticate/login");


                        var playlistmusic = JsonConvert.DeserializeObject<ObservableCollection<PlaylistMusic>>(response);

                        PlaylistMusicCollection = new ObservableCollection<PlaylistMusic>(playlistmusic);
                    }

                    //FileWriteRead<Playlist>.ReadToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);
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


                        var playlist = JsonConvert.DeserializeObject<ObservableCollection<Playlist>>(response).Where(p=>p.UserAccountId_forPlaylist==userid);

                        PlaylistCollection = new ObservableCollection<Playlist>(playlist);
                    }

                    //FileWriteRead<Playlist>.ReadToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);
                }

            };
        }

        async Task PostPlaylist(string username, string password , Playlist playlist )
        {
            if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        await ConnectionAPI.PostPlaylist(httpClient, username, password, "https://localhost:7270/api/Authenticate/login", playlist);

                        //Task.Run(() =>
                        //{


                        //    FileWriteRead<Playlist>.WriteToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);

                        //});


                        ToastNotificationWindow = new ToastNotificationWindow("A playlist named"+" "+playlist.PlaylistName+" "+ "has been created.", playlist.ImagePlaylist, (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);

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


        async Task DeletePlaylist(string username, string password, Playlist playlist)
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


                        await ConnectionAPI.DeletePlaylist(httpClient, username, password, "https://localhost:7270/api/Authenticate/login", playlist);


                        //Task.Run(() =>
                        //{


                        //    FileWriteRead<Playlist>.WriteToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);

                        //});


                        ToastNotificationWindow = new ToastNotificationWindow($"Playlist has been deleted.", $"../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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



                        if (PlaylistMusicCollection != null)
                        {



                            var takencourses = from sc in PlaylistMusicCollection
                                               join s in PlaylistCollection on sc.PlaylistId_forPlaylistMusic equals s.IdPlaylist
                                               join c in Musics on sc.MusicId_forPlaylistMusic equals c.IdMusic
                                               where s.IdPlaylist == IdPlaylist_
                                               select new Music { IdMusic = c.IdMusic, ImageMusic = c.ImageMusic, IsPopularMusic = c.IsPopularMusic, MusicFile = c.MusicFile, MusicName = c.MusicName };



                            var myObservableCollection = new ObservableCollection<Music>(takencourses);

                            Musics = new ObservableCollection<Music>();

                            Musics = (ObservableCollection<Music>)myObservableCollection;

                            _Playlist_UC.MusicListbox.ItemsSource = null;
                            _Playlist_UC.MusicListbox.Items.Clear();
                            _Playlist_UC.MusicListbox.ItemsSource = takencourses;


                        }



                    }
                    //FileWriteRead<Music>.ReadToFile("../../../Asserts/Files/musics.json", Musics);
                }

            };
        }



        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", " ", RegexOptions.Compiled);
        }

        private string GetRichTextBox( RichTextBox richTextBox)
        {
            return new TextRange(richTextBox.Document.ContentStart,
                richTextBox.Document.ContentEnd).Text;
        }

        private void SetRichTextBox(RichTextBox richTextBox, string text)
        {

            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(text)));


        }


        
    }


}
