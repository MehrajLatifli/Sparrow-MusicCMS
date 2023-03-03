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
using System.Windows.Forms;
using System.Windows;

namespace MusicCMS_Admin.ViewModels
{


    public class Music_UCViewModel : BaseViewModel
    {
        public Music_UC _Music_UC { get; set; }

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

        public RelayCommand RadioListboxMouseDoubleClick { get; set; }

        public RelayCommand MusicSearchCommand { get; set; }

        public RelayCommand CreateMusicCommand { get; set; }


        public RelayCommand LoadedCommand { get; set; }


        public RelayCommand DeleteMusicCommand { get; set; }

        public RelayCommand AddMusicPlaylisCommand { get; set; }


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

        public Music_UCViewModel()
        {

            timerGetList.Tick += TimerGetList_Tick; ;

            timerGetList.Interval = TimeSpan.FromSeconds(2);


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

                _Music_UC.Dispatcher.InvokeAsync(new Action(async () =>
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


                    if (string.IsNullOrEmpty(_Music_UC.MusicNameTextbox.Text))
                    {
                        _Music_UC.MusicNameTextbox.Text = "Music name";
                        _Music_UC.MusicNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
                    }

                    if (string.IsNullOrEmpty(_Music_UC.MusicNameTextbox.Text))
                    {
                        _Music_UC.MusicFileTextbox.Text = "Music file";
                        _Music_UC.MusicFileTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
                    }





                    _Music_UC.MusicNameTextbox.MouseEnter += MusicNameTextbox_MouseEnter; 
                    _Music_UC.MusicNameTextbox.MouseLeave += MusicNameTextbox_MouseLeave;

                    _Music_UC.MusicFileTextbox.MouseEnter += MusicFileTextbox_MouseEnter;
                    _Music_UC.MusicFileTextbox.MouseLeave += MusicFileTextbox_MouseLeave;

                }));

            });


            MusicListboxMouseDoubleClick = new RelayCommand((e) =>
            {
                _Music_UC.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (_Music_UC.MusicListbox.SelectedItem != null)
                    {

                        ListSelectedItem = _Music_UC.MusicListbox.SelectedItem as dynamic;

                        IdMusic_ = ListSelectedItem.IdMusic;
                        MusicFile_ = ListSelectedItem.MusicFile.ToString();

                        MusicName_ = ListSelectedItem.MusicName.ToString();

                        ImageMusic_ = ListSelectedItem.ImageMusic.ToString();

                        file = new File()
                        {
                            FileName = MusicName_,
                            FilePath = MusicFile_,
                            FileImage = ImageMusic_,
                            IdFile = IdMusic_.ToString()

                        };

                        playerwork = new Playerwork()
                        {

                            IdMusic = IdMusic_.ToString(),
                            playerstatus = true,

                        };

                        playerwork.Serialize(playerwork, "../../../Asserts/Files/player.json");


                        file.Serialize(file, "../../../Asserts/Files/file.json");



                        ToastNotificationWindow = new ToastNotificationWindow(MusicName_, ImageMusic_, (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);

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



           



            MusicSearchCommand = new RelayCommand((e) =>
            {

                _Music_UC.Dispatcher.InvokeAsync(new Action(() =>
                {



                    if (Musics != null)
                    {


                        _Music_UC.MusicListbox.ItemsSource = null;

                        if (string.IsNullOrEmpty(_Music_UC.SearchTextboxForMusicListbox.Text) == false)
                        {
                            _Music_UC.MusicListbox.ItemsSource = null;
                            _Music_UC.MusicListbox.Items.Clear();
                            foreach (var item in Musics)
                            {
                                //var str = char.ToUpper(_Music_UC.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _Music_UC.SearchTextboxForMusicListbox.Text.ToLower().Substring(1);

                                var str = char.ToUpper(_Music_UC.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _Music_UC.SearchTextboxForMusicListbox.Text.Substring(1);

                                Debug.WriteLine(str);

                                if (item.MusicName.Contains(str))
                                {

                                    _Music_UC.MusicListbox.Items.Add(item);
                                }
                                _Music_UC.MusicListbox.ItemsSource = null;
                            }
                        }

                        else
                        {
                            _Music_UC.MusicListbox.Items.Clear();

                            foreach (var item in Musics)
                            {

                                _Music_UC.MusicListbox.Items.Add(item);


                            }
                        }

                    }



                }));

            });





            CreateMusicCommand = new RelayCommand((e) =>
            {

                _Music_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {
                    if (logincheck == true)
                    {

                        _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");


                        Music = new Music()
                        {
                            MusicName=_Music_UC.MusicNameTextbox.Text,
                            IsPopularMusic= true,
                            ImageMusic = "../../../Asserts/Images/Images/music_fsq5k7.png",
                            MusicFile= _Music_UC.MusicFileTextbox.Text

                        };

                        if (Music != null)
                        {
                            await PostMusic(_logIn.Username, _logIn.UserPassword, Music);




                        }
                    }
                }));

            });




            DeleteMusicCommand = new RelayCommand((e) =>
            {


                _Music_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {

                    try
                    {



                        Task.Run(async () =>
                        {

                            _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");

                        });

                        if (_logIn != null)
                        {

                            ListSelectedItem = _Music_UC.MusicListbox.SelectedItem as dynamic;

                         
                                IdMusic_ = ListSelectedItem.IdMusic;
                                MusicName_ = ListSelectedItem.MusicName;
                                ImageMusic_ = ListSelectedItem.ImageMusic;
                                MusicFile_ = ListSelectedItem.MusicFile;
                                IsPopularMusic_ = ListSelectedItem.IsPopularMusic;



                                Music = new Music()
                                {
                                    IdMusic=IdMusic_,
                                    MusicName=MusicName_,
                                    ImageMusic=ImageMusic_,
                                    MusicFile=MusicFile_,
                                    IsPopularMusic=IsPopularMusic_,

                                };


                            Task.Run(async () =>
                            {
                                file = new File();
                 
                                playerwork = new Playerwork();

                                playerwork.Serialize(playerwork, "../../../Asserts/Files/player.json");


                                file.Serialize(file, "../../../Asserts/Files/file.json");


                            });

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

                            if (Music != null)
                                {

                                    await DeleteMusic(_logIn.Username, _logIn.UserPassword, Music);
                                }


                            

                        }
                    }
                    catch (Exception)
                    {

                    }
                }));

            });





        }



        async Task DeleteMusic(string username, string password, Music music)
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


                        await ConnectionAPI.DeleteMusic(httpClient, username, password, "https://localhost:7270/api/Authenticate/login", music);


                        //Task.Run(() =>
                        //{


                        //    FileWriteRead<Playlist>.WriteToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);

                        //});


                        ToastNotificationWindow = new ToastNotificationWindow($"{music.MusicName} has been deleted.", $"../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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


        async Task PostMusic(string username, string password, Music  music)
        {
            if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        await ConnectionAPI.PostMusic(httpClient, username, password, "https://localhost:7270/api/Authenticate/login", music);

                        //Task.Run(() =>
                        //{


                        //    FileWriteRead<Playlist>.WriteToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);

                        //});


                        ToastNotificationWindow = new ToastNotificationWindow("A music named" + " " + music.MusicName + " " + "has been created.", music.ImageMusic, (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);

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



        private void MusicNameTextbox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_Music_UC.MusicNameTextbox.Text))
            {
                _Music_UC.MusicNameTextbox.Text = "Music name";
                _Music_UC.MusicNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
            }
        }

        private void MusicNameTextbox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_Music_UC.MusicNameTextbox.Text == "Music name")
            {
                _Music_UC.MusicNameTextbox.Text = "";
                _Music_UC.MusicNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }

        private void MusicFileTextbox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_Music_UC.MusicFileTextbox.Text))
            {
                _Music_UC.MusicFileTextbox.Text = "Music file";
                _Music_UC.MusicFileTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
            }
        }

        private void MusicFileTextbox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_Music_UC.MusicFileTextbox.Text == "Music file")
            {
                _Music_UC.MusicFileTextbox.Text = "";
                _Music_UC.MusicFileTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }



        private void TimerGetList_Tick(object? sender, EventArgs e)
        {
            _Music_UC.Dispatcher.BeginInvoke(new Action(async () =>
            {

                string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                logincheck = JsonConvert.DeserializeObject<bool>(data2);

                if (logincheck == true)
                {

                    try
                    {


                        _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");



                        await GetMusic(_logIn.Username, _logIn.UserPassword);

                        if (string.IsNullOrEmpty(_Music_UC.SearchTextboxForMusicListbox.Text))
                        {
                            _Music_UC.SearchTextboxForMusicListbox.Text = "  ";
                            _Music_UC.SearchTextboxForMusicListbox.Text = string.Empty;
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
                    _Music_UC.MusicListbox.ItemsSource = null;
                    _Music_UC.MusicListbox.Items.Clear();



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

                    //FileWriteRead<Playlist>.ReadToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);
                }

            };
        }



    }


}
