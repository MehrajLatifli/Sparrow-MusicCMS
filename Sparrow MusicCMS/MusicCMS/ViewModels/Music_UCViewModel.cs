using MusicCMS.Command;
using MusicCMS.Helpers;
using MusicCMS.Models;
using MusicCMS.Models.Data;
using MusicCMS.Services.Player.State_Pattern;
using MusicCMS.Views.Helper_Views.Notification_Views;
using MusicCMS.Views.UserControls;
using MusicCMS_Entities.Concrete.DatabaseFirst;
using Newtonsoft.Json;
using Sparrow_MusicCMS.Helpers;
using Sparrow_MusicCMS.Models.Data;
using Sparrow_MusicCMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Album = Sparrow_MusicCMS.Models.Data.Album;
using Artist = Sparrow_MusicCMS.Models.Data.Artist;
using MusicAlbum = Sparrow_MusicCMS.Models.Data.MusicAlbum;

namespace MusicCMS.ViewModels
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

        private Models.Data.Music currentMusic;

        public Models.Data.Music CurrentMusic
        {
            get { return currentMusic; }
            set { currentMusic = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Models.Data.Music> musics;

        public ObservableCollection<Models.Data.Music> Musics
        {
            get { return musics; }
            set { musics = value; OnPropertyChanged(); }
        }



        private Sparrow_MusicCMS.Models.Data.Artist artist;

        public Sparrow_MusicCMS.Models.Data.Artist Artist
        {
            get { return artist; }
            set { artist = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Sparrow_MusicCMS.Models.Data.Artist> artists;

        public ObservableCollection<Sparrow_MusicCMS.Models.Data.Artist> Artists
        {
            get { return artists; }
            set { artists = value; OnPropertyChanged(); }
        }


        private Sparrow_MusicCMS.Models.Data.Album album;

        public Sparrow_MusicCMS.Models.Data.Album Album
        {
            get { return album; }
            set { album = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Sparrow_MusicCMS.Models.Data.Album> albums;

        public ObservableCollection<Sparrow_MusicCMS.Models.Data.Album> Albums
        {
            get { return albums; }
            set { albums = value; OnPropertyChanged(); }
        }


        private Sparrow_MusicCMS.Models.Data.ArtistAlbum artistAlbum;

        public Sparrow_MusicCMS.Models.Data.ArtistAlbum ArtistAlbum
        {
            get { return artistAlbum; }
            set { artistAlbum = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Sparrow_MusicCMS.Models.Data.ArtistAlbum> artistAlbums;

        public ObservableCollection<Sparrow_MusicCMS.Models.Data.ArtistAlbum> ArtistAlbums
        {
            get { return artistAlbums; }
            set { artistAlbums = value; OnPropertyChanged(); }
        }

        private Sparrow_MusicCMS.Models.Data.MusicAlbum musicAlbum;

        public Sparrow_MusicCMS.Models.Data.MusicAlbum MusicAlbum
        {
            get { return musicAlbum; }
            set { musicAlbum = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Sparrow_MusicCMS.Models.Data.MusicAlbum> musicAlbums;

        public ObservableCollection<Sparrow_MusicCMS.Models.Data.MusicAlbum> MusicAlbums
        {
            get { return musicAlbums; }
            set { musicAlbums = value; OnPropertyChanged(); }
        }

        private Models.Data.Radio radio;

        public Models.Data.Radio Radio
        {
            get { return radio; }
            set { radio = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Models.Data.Radio> radioCollection;

        public ObservableCollection<Models.Data.Radio> RadioCollection
        {
            get { return radioCollection; }
            set { radioCollection = value; OnPropertyChanged(); }
        }


        private Models.Data.UserAccount userAccount;

        public Models.Data.UserAccount UserAccount
        {
            get { return userAccount; }
            set { userAccount = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Models.Data.UserAccount> userAccounts;

        public ObservableCollection<Models.Data.UserAccount> UserAccounts
        {
            get { return userAccounts; }
            set { userAccounts = value; OnPropertyChanged(); }
        }



        //HttpClientHandler clientHandler = new HttpClientHandler();


        DispatcherTimer timerGetdata = new DispatcherTimer();



        private MediaPlayer mediaPlayer = new MediaPlayer();


        public RelayCommand MusicListboxMouseDoubleClick { get; set; }



        public RelayCommand MusicSearchCommand { get; set; }



        public RelayCommand ArtistSelectionChanged { get; set; }

        public RelayCommand AlbumSelectionChanged { get; set; }

        public RelayCommand LoadedCommand { get; set; }


        public int playpausecount = 0;

        int nextpreviouscount = 0;

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

        int artistId_ { get; set; }
        public int ArtistId_
        {
            get { return artistId_; }
            set { artistId_ = value; OnPropertyChanged(); }
        }

        string artistName_ { get; set; }
        public string ArtistName_
        {
            get { return artistName_; }
            set { artistName_ = value; OnPropertyChanged(); }
        }

        string imageArtist_ { get; set; }
        public string ImageArtist_
        {
            get { return imageArtist_; }
            set { imageArtist_ = value; OnPropertyChanged(); }
        }

        int albumId_ { get; set; }
        public int AlbumId_
        {
            get { return albumId_; }
            set { albumId_ = value; OnPropertyChanged(); }
        }

        string albumName_ { get; set; }
        public string AlbumName_
        {
            get { return albumName_; }
            set { albumName_ = value; OnPropertyChanged(); }
        }

        string imageAlbum_ { get; set; }
        public string ImageAlbum_
        {
            get { return imageAlbum_; }
            set { imageAlbum_ = value; OnPropertyChanged(); }
        }



        int changeRegistrationCount = 0;

        Border border = new Border();

        TextBox EmailtextBox = new TextBox();

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
            timerGetdata.Tick += Timer_Tick; ;
            timerGetdata.Interval = TimeSpan.FromSeconds(1);


            ToastNotificationWindowList = new ObservableCollection<ToastNotificationWindow>();

            dynamic ListSelectedItem;
            dynamic ListSelectedItem2;
            dynamic ListSelectedItem3;

            sizecount = 5;
            ToastNotificationWindowIndex = 0;





            //using (HttpClientHandler clientHandler = new HttpClientHandler())
            //{
            //    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            //}




            LoadedCommand = new RelayCommand((e) =>
            {

                _Music_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {
                    _logIn = new LogIn();

                    timerGetdata.Start();




                    _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");



                }));
            });



            ArtistSelectionChanged = new RelayCommand((e) =>
            {


                _Music_UC.Dispatcher.BeginInvoke(new Action(() =>
                {



                    if (_Music_UC.ArtistComboBox.SelectedItem != null)
                    {

                        ListSelectedItem2 = _Music_UC.ArtistComboBox.SelectedItem as dynamic;

                        if (ListSelectedItem2 != null)
                        {
                            ArtistId_ = ListSelectedItem2.IdArtist;
                            ArtistName_ = Convert.ToString(ListSelectedItem2.ArtistName);
                            ImageArtist_ = Convert.ToString(ListSelectedItem2.ImageArtist);


                            if (ArtistAlbums != null)
                            {


                                var lists = from aa in ArtistAlbums
                                            join a1 in Albums on aa.AlbumId_forArtistAlbum equals a1.IdAlbum
                                            join a2 in Artists on aa.ArtistId_forArtistAlbum equals a2.IdArtist
                                            where aa.ArtistId_forArtistAlbum == ArtistId_
                                            select new Sparrow_MusicCMS.Models.Data.Album { IdAlbum = a1.IdAlbum, AlbumName = a1.AlbumName, ImageAlbum = a1.ImageAlbum };



                                var myObservableCollection = new ObservableCollection<Sparrow_MusicCMS.Models.Data.Album>(lists);


                                Albums = new ObservableCollection<Sparrow_MusicCMS.Models.Data.Album>();

                                Albums = (ObservableCollection<Sparrow_MusicCMS.Models.Data.Album>)myObservableCollection;

                                _Music_UC.AlbumComboBox.ItemsSource = null;
                                _Music_UC.AlbumComboBox.Items.Clear();
                                _Music_UC.AlbumComboBox.ItemsSource = Albums;



                            }


                        }





                    }
                    


                }));

            });


            AlbumSelectionChanged = new RelayCommand((e) =>
            {

                _Music_UC.Dispatcher.BeginInvoke(new Action(() =>
                {



                    if (_Music_UC.AlbumComboBox.SelectedItem != null)
                    {



                        ListSelectedItem3 = _Music_UC.AlbumComboBox.SelectedItem as dynamic;

                        if (ListSelectedItem3 != null)
                        {
                            AlbumId_ = ListSelectedItem3.IdAlbum;
                            AlbumName_ = Convert.ToString(ListSelectedItem3.AlbumName);
                            imageAlbum_ = Convert.ToString(ListSelectedItem3.ImageAlbum);




                            if (MusicAlbums != null)
                            {
                                var lists = from ma in MusicAlbums
                                            join a in Albums on ma.AlbumId_forMusicAlbum equals a.IdAlbum
                                            join m in Musics on ma.MusicId_forMusicAlbum equals m.IdMusic
                                            where ma.AlbumId_forMusicAlbum == AlbumId_
                                            select new Models.Data.Music { IdMusic = m.IdMusic, MusicName = m.MusicName, ImageMusic = m.ImageMusic, MusicFile = m.MusicFile, IsPopularMusic = m.IsPopularMusic };



                                var myObservableCollection = new ObservableCollection<Models.Data.Music>(lists);


                                Musics = new ObservableCollection<Models.Data.Music>();

                                Musics = (ObservableCollection<Models.Data.Music>)myObservableCollection;

                                _Music_UC.MusicListbox.ItemsSource = null;
                                _Music_UC.MusicListbox.Items.Clear();
                                _Music_UC.MusicListbox.ItemsSource = Musics;




                            }


                        }

                    }
                    
                  
                    

                }));

            });


            MusicListboxMouseDoubleClick = new RelayCommand((e) =>
            {
                _Music_UC.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (_Music_UC.MusicListbox.SelectedItem != null)
                    {

                        ListSelectedItem = _Music_UC.MusicListbox.SelectedItem as dynamic;

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



            MusicSearchCommand = new RelayCommand((e) =>
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


            });







        }




        private void Timer_Tick(object? sender, EventArgs e)
        {
            _Music_UC.Dispatcher.BeginInvoke(new Action(async () =>
            {

                string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                logincheck = JsonConvert.DeserializeObject<bool>(data2);

                if (logincheck == true)
                {

                

                    _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");





                    //if (_Music_UC.MusicListbox.ItemsSource!=null)
                    //{

                    //_Music_UC.MusicListbox.ItemsSource = Musics;
                    //}


                    if (_Music_UC.MusicListbox.ItemsSource != null)
                    {
                        _Music_UC.MusicListbox.ItemsSource = Musics;

                    }
                        await GetArtist(_logIn.Username, _logIn.UserPassword);
                        await GetAlbum(_logIn.Username, _logIn.UserPassword);
                        await GetArtistAlbum(_logIn.Username, _logIn.UserPassword);
                        await GetMusic(_logIn.Username, _logIn.UserPassword);

                        await GetMusicAlbum(_logIn.Username, _logIn.UserPassword);






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


                    mediaPlayer.Stop();

                    if (System.IO.File.Exists("../../../Asserts/Files/musics.json"))
                    {
                        System.IO.File.Delete("../../../Asserts/Files/musics.json");

                    };



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


                        Musics = JsonConvert.DeserializeObject<ObservableCollection<Models.Data.Music>>(response);


                        if (MusicAlbums != null)
                        {

                            var lists = from ma in MusicAlbums
                                        join a in Albums on ma.AlbumId_forMusicAlbum equals a.IdAlbum
                                        join m in Musics on ma.MusicId_forMusicAlbum equals m.IdMusic
                                        where ma.AlbumId_forMusicAlbum == AlbumId_
                                        select new Models.Data.Music { IdMusic = m.IdMusic, MusicName = m.MusicName, ImageMusic = m.ImageMusic, MusicFile = m.MusicFile, IsPopularMusic = m.IsPopularMusic };



                            var myObservableCollection = new ObservableCollection<Models.Data.Music>(lists);


                            Musics = new ObservableCollection<Models.Data.Music>();

                            Musics = (ObservableCollection<Models.Data.Music>)myObservableCollection;

                            _Music_UC.MusicListbox.ItemsSource = null;
                            _Music_UC.MusicListbox.Items.Clear();
                            _Music_UC.MusicListbox.ItemsSource = Musics;





                        }

                    }
                         //FileWriteRead<Music>.ReadToFile("../../../Asserts/Files/musics.json", Musics);
                }

            };

        }


        async Task GetArtist(string username, string password)
        {
            using (var clientHandler = new HttpClientHandler())
            {
                using (var httpClient = new HttpClient(clientHandler))
                {

                    var response = await ConnectionAPI.GetArtist(httpClient, username, password, "https://localhost:7270/api/Authenticate/login");

                    Artists = JsonConvert.DeserializeObject<ObservableCollection<Artist>>(response);





                }
            }

        }




        async Task GetAlbum(string username, string password)
        {
            using (var clientHandler = new HttpClientHandler())
            {
                using (var httpClient = new HttpClient(clientHandler))
                {

                    var response = await ConnectionAPI.GetAlbum(httpClient, username, password, "https://localhost:7270/api/Authenticate/login");


                    Albums = JsonConvert.DeserializeObject<ObservableCollection<Album>>(response);


                    if (ArtistAlbums != null)
                    {


                        var lists = from aa in ArtistAlbums
                                    join a1 in Albums on aa.AlbumId_forArtistAlbum equals a1.IdAlbum
                                    join a2 in Artists on aa.ArtistId_forArtistAlbum equals a2.IdArtist
                                    where aa.ArtistId_forArtistAlbum == ArtistId_
                                    select new Sparrow_MusicCMS.Models.Data.Album { IdAlbum = a1.IdAlbum, AlbumName = a1.AlbumName, ImageAlbum = a1.ImageAlbum };



                        var myObservableCollection = new ObservableCollection<Sparrow_MusicCMS.Models.Data.Album>(lists);


                        Albums = new ObservableCollection<Sparrow_MusicCMS.Models.Data.Album>();

                        Albums = (ObservableCollection<Sparrow_MusicCMS.Models.Data.Album>)myObservableCollection;

                        _Music_UC.AlbumComboBox.ItemsSource = null;
                        _Music_UC.AlbumComboBox.Items.Clear();
                        _Music_UC.AlbumComboBox.ItemsSource = Albums;

                        _Music_UC.AlbumComboBox.SelectedItem= Album;

                    }



                }
            }

        }



        async Task GetArtistAlbum(string username, string password)
        {
            using (var clientHandler = new HttpClientHandler())
            {
                using (var httpClient = new HttpClient(clientHandler))
                {

                    var response = await ConnectionAPI.GetArtistAlbum(httpClient, username, password, "https://localhost:7270/api/Authenticate/login");


                    ArtistAlbums = JsonConvert.DeserializeObject<ObservableCollection<Sparrow_MusicCMS.Models.Data.ArtistAlbum>>(response);



                }
            }

        }



        async Task GetMusicAlbum(string username, string password)
        {
            using (var clientHandler = new HttpClientHandler())
            {
                using (var httpClient = new HttpClient(clientHandler))
                {

                    var response = await ConnectionAPI.GetMusicAlbum(httpClient, username, password, "https://localhost:7270/api/Authenticate/login");


                    MusicAlbums = JsonConvert.DeserializeObject<ObservableCollection<MusicAlbum>>(response);



                    if (MusicAlbums != null)
                    {






                        var lists = from ma in MusicAlbums
                                    join a in Albums on ma.AlbumId_forMusicAlbum equals a.IdAlbum
                                    join m in Musics on ma.MusicId_forMusicAlbum equals m.IdMusic
                                    where ma.AlbumId_forMusicAlbum == AlbumId_
                                    select new Models.Data.Music { IdMusic = m.IdMusic, MusicName = m.MusicName, ImageMusic = m.ImageMusic, MusicFile = m.MusicFile, IsPopularMusic = m.IsPopularMusic };



                        var myObservableCollection = new ObservableCollection<Models.Data.Music>(lists);


                        Musics = new ObservableCollection<Models.Data.Music>();

                        Musics = (ObservableCollection<Models.Data.Music>)myObservableCollection;

                        _Music_UC.MusicListbox.ItemsSource = null;
                        _Music_UC.MusicListbox.Items.Clear();
                        _Music_UC.MusicListbox.ItemsSource = Musics;





                    }


                }
            }

        }
    }


}

