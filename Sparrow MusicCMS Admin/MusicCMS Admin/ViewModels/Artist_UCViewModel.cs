using MusicCMS_Admin.Command;
using MusicCMS_Admin.Models.Data;
using MusicCMS_Admin.Models;
using MusicCMS_Admin.Views.Helper_Views.Notification_Views;
using MusicCMS_Admin.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MusicCMS_Admin.Helpers;
using System.Windows.Documents;
using System.Net;
using System.Security.Authentication;
using MusicCMS_Admin.Views.Helper_Views.Pop_up_Views;

namespace MusicCMS_Admin.ViewModels
{
    public class Artist_UCViewModel : BaseViewModel
    {
        public Artist_UC _Artist_UC { get; set; }

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


        public RelayCommand MusicListboxMouseDoubleClick { get; set; }

        public RelayCommand ArtistListboxMouseDoubleClick { get; set; }


        public RelayCommand ArtistSearchCommand { get; set; }



        public RelayCommand CreateArtistCommand { get; set; }


        public RelayCommand LoadedCommand { get; set; }


        public RelayCommand DeleteArtistCommand { get; set; }

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

        public Artist_UCViewModel()
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

                _Artist_UC.Dispatcher.InvokeAsync(new Action(async () =>
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


                    if (string.IsNullOrEmpty(_Artist_UC.ArtistNameTextbox.Text))
                    {
                        _Artist_UC.ArtistNameTextbox.Text = "Artist name";
                        _Artist_UC.ArtistNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
                    }







                    _Artist_UC.ArtistNameTextbox.MouseEnter += ArtistNameTextbox_MouseEnter;
                    _Artist_UC.ArtistNameTextbox.MouseLeave += ArtistNameTextbox_MouseLeave;



                }));

            });


            ArtistSearchCommand = new RelayCommand((e) =>
            {

                _Artist_UC.Dispatcher.InvokeAsync(new Action( () =>
                {


                        if (ArtistCollection != null)
                        {


                            _Artist_UC.ArtistListbox.ItemsSource = null;

                            if (string.IsNullOrEmpty(_Artist_UC.SearchTextboxForArtistListbox.Text) == false)
                            {
                                _Artist_UC.ArtistListbox.ItemsSource = null;
                                _Artist_UC.ArtistListbox.Items.Clear();
                                foreach (var item in ArtistCollection)
                                {
                                    //var str = char.ToUpper(_Music_UC.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _Music_UC.SearchTextboxForMusicListbox.Text.ToLower().Substring(1);

                                    var str = char.ToUpper(_Artist_UC.SearchTextboxForArtistListbox.Text.ElementAt(0)) + _Artist_UC.SearchTextboxForArtistListbox.Text.Substring(1);

                                    Debug.WriteLine(str);

                                    if (item.ArtistName.Contains(str))
                                    {

                                        _Artist_UC.ArtistListbox.Items.Add(item);
                                    }
                                    _Artist_UC.ArtistListbox.ItemsSource = null;
                                }
                            }

                            else
                            {
                                _Artist_UC.ArtistListbox.Items.Clear();

                                foreach (var item in ArtistCollection)
                                {

                                    _Artist_UC.ArtistListbox.Items.Add(item);


                                }
                            }

                        }
                    


                }));

            });



            CreateArtistCommand = new RelayCommand((e) =>
            {

                _Artist_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {
                    if (logincheck == true)
                    {

                        _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");


                        Artist = new Artist()
                        {
                            ArtistName = _Artist_UC.ArtistNameTextbox.Text,
                            ImageArtist = "./../../../Asserts/Images/Images/artist_rd9jux.png"

                        };

                        if (Artist != null)
                        {
                            await PostArtist(_logIn.Username, _logIn.UserPassword, Artist);




                        }
                    }
                }));

            });




            DeleteArtistCommand = new RelayCommand((e) =>
            {

                _Artist_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {

                    try
                    {



                        Task.Run(async () =>
                        {

                            _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");

                        });

                        if (_logIn != null)
                        {

                            ListSelectedItem = _Artist_UC.ArtistListbox.SelectedItem as dynamic;

                            if (ListSelectedItem != null)
                            {
                                IdArtist_ = ListSelectedItem.IdArtist;
                                ArtistName_ = ListSelectedItem.ArtistName.ToString();
                                ImageArtist_ = ListSelectedItem.ImageArtist.ToString();

                                Artist = new Artist()
                                {
                                    IdArtist = IdArtist_,
                                    ArtistName = ArtistName_,
                                    ImageArtist = "https://res.cloudinary.com/sociala/image/upload/v1675949427/MusicCMS/User/artist_rd9jux.png"

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

                                if (Artist != null)
                                {

                                    await DeleteArtist(_logIn.Username, _logIn.UserPassword, Artist);
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

        async Task DeleteArtist(string username, string password, Artist artist)
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


                        await ConnectionAPI.DeleteArtist(httpClient, username, password, "https://localhost:7270/api/Authenticate/login", artist);


                        //Task.Run(() =>
                        //{


                        //    FileWriteRead<Playlist>.WriteToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);

                        //});


                        ToastNotificationWindow = new ToastNotificationWindow($"{artist.ArtistName} has been deleted.", $"../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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

        async Task PostArtist(string username, string password, Artist artist)
        {
            if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        await ConnectionAPI.PostArtist(httpClient, username, password, "https://localhost:7270/api/Authenticate/login", artist);

                        //Task.Run(() =>
                        //{


                        //    FileWriteRead<Playlist>.WriteToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);

                        //});


                        ToastNotificationWindow = new ToastNotificationWindow("A artist named" + " " + artist.ArtistName + " " + "has been created.", artist.ImageArtist, (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);

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

        private void ArtistNameTextbox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_Artist_UC.ArtistNameTextbox.Text))
            {
                _Artist_UC.ArtistNameTextbox.Text = "Artist name";
                _Artist_UC.ArtistNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
            }
        }

        private void ArtistNameTextbox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_Artist_UC.ArtistNameTextbox.Text == "Artist name")
            {
                _Artist_UC.ArtistNameTextbox.Text = "";
                _Artist_UC.ArtistNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }

        private void TimerGetList_Tick(object? sender, EventArgs e)
        {
            _Artist_UC.Dispatcher.BeginInvoke(new Action(async () =>
            {

                string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                logincheck = JsonConvert.DeserializeObject<bool>(data2);

                if (logincheck == true)
                {

                    try
                    {


                        _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");



                        await GetArtist(_logIn.Username, _logIn.UserPassword);

                        if (string.IsNullOrEmpty(_Artist_UC.SearchTextboxForArtistListbox.Text))
                        {
                            _Artist_UC.SearchTextboxForArtistListbox.Text = "  ";
                            _Artist_UC.SearchTextboxForArtistListbox.Text = string.Empty;
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
                    _Artist_UC.ArtistListbox.ItemsSource = null;
                    _Artist_UC.ArtistListbox.Items.Clear();



                }


            }));
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
    }


}
