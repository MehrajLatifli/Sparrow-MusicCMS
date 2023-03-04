using MusicCMS_Admin.Command;
using MusicCMS_Admin.Helpers;
using MusicCMS_Admin.Models.Data;
using MusicCMS_Admin.Models;
using MusicCMS_Admin.Views.Helper_Views.Notification_Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Threading;
using MusicCMS_Admin.Views.UserControls;
using MusicCMS_Admin.Services.Player.State_Pattern;
using System.Windows;
using System.Diagnostics;
using System.Net;

namespace MusicCMS_Admin.ViewModels
{
    class Player_UCViewModel : BaseViewModel
    {


        public Home_UC _Home_UC { get; set; }

        public Home_UCViewModel _Home_UCViewModel { get; set; }

        public MediaPlayer mediaPlayer { get; set; }

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

        File _file { get; set; }

        public File file { get { return _file; } set { _file = value; OnPropertyChanged(); } }


        Playerwork _playerwork { get; set; }

        public Playerwork playerwork { get { return _playerwork; } set { _playerwork = value; OnPropertyChanged(); } }


        LogIn _logIn { get; set; }

        bool logincheck { get; set; }


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

        private double _sizecount;
        public double sizecount
        {

            get { return _sizecount; }
            set { _sizecount = value; OnPropertyChanged(); }

        }

        public RelayCommand LoadedCommand { get; set; }

        public RelayCommand PlayerMusicTimelineCommand { get; set; }

        public RelayCommand PlayPauseMusicCommand { get; set; }

        public RelayCommand NextMusicCommand { get; set; }

        public RelayCommand PreviousMusicCommand { get; set; }

        public RelayCommand MuteOrUnMuteVolumeCommand { get; set; }

        public RelayCommand PlayerVolumeCommand { get; set; }

        public Player_UC _Player_UC { get; set; }

        public DispatcherTimer timerMusic = new DispatcherTimer();

        DispatcherTimer timerMusic2 = new DispatcherTimer();


        private double _volume; // Range [ 0.0 .. 1.0 ], bind to slider.
        public double Volume
        {
            get => _volume;
            set
            {
                if (value != _volume)
                {
                    _volume = value;
                    OnPropertyChanged(nameof(Volume));
                    OnPropertyChanged(nameof(VolumeDisplay));
                }
            }
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


        public double VolumeDisplay
        {
            get => 100.0 * _volume;
            set => Volume = value / 100.0;
        }

        public int playpausecount = 0;

        public int nextpreviouscount = 0;

        int muteunmutecount = 0;


        public Player_UCViewModel()
        {
            file = new File();

            _logIn = new LogIn();

            playerwork = new Playerwork();

            mediaPlayer = new MediaPlayer();

            ToastNotificationWindowList = new ObservableCollection<ToastNotificationWindow>();


            timerMusic2.Interval = TimeSpan.FromSeconds(1);
            timerMusic2.Tick += TimerMusic2_Tick; ;


            LoadedCommand = new RelayCommand((e) =>
            {
                _Player_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {
                    //[DllImport("kernel32.dll")]
                    // static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

                    //SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);

                    timerMusic2.Start();


                    playerwork = await playerwork.DeSerialize("../../../Asserts/Files/player.json");
                }));

            });


            PlayerMusicTimelineCommand = new RelayCommand((e) =>
            {

                mediaPlayer.Position = TimeSpan.FromSeconds(_Player_UC.TimeSlider.Value);

            });


            PlayPauseMusicCommand = new RelayCommand((e) =>
            {
                _Player_UC.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (Musics != null)
                    {
                        string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                        logincheck = JsonConvert.DeserializeObject<bool>(data2);



                        ++playpausecount;

                        if (playpausecount % 2 == 0)
                        {
                            Player play = new Player(new PauseState(mediaPlayer));

                            play.Pause(mediaPlayer, Musics, _Player_UC);


                            _Player_UC.PlayPauseKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Play;



                            if (mediaPlayer.Source == null)
                            {



                                ToastNotificationWindowIndex++;


                                ToastNotificationWindow = new ToastNotificationWindow("No file selected...", "../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF4500"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
                                ToastNotificationWindow.Show();

                                var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;

                                if (ToastNotificationWindow.Top <= 0)
                                {
                                    sizecount = 5;
                                }

                                else
                                {

                                    //sizecount = sizecount + 80;
                                }


                                _Player_UC.PlayPauseKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Play;



                            }
                        }

                        else
                        {


                            Player play = new Player(new PlayState(mediaPlayer));

                            play.Play(mediaPlayer, Musics, _Player_UC);

                            _Player_UC.PlayPauseKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Pause;


                            Timer();






                        }

                    }

                    if (mediaPlayer.Source == null)
                    {


                        ToastNotificationWindowIndex++;


                        ToastNotificationWindow = new ToastNotificationWindow("No file selected...", "../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF4500"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
                        ToastNotificationWindow.Show();

                        var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;

                        if (ToastNotificationWindow.Top <= 0)
                        {
                            sizecount = 5;
                        }

                        else
                        {

                            //sizecount = sizecount + 80;
                        }

                        _Player_UC.PlayPauseKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Play;

                    }

                }));
            });


            NextMusicCommand = new RelayCommand((e) =>
            {

                _Player_UC.Dispatcher.BeginInvoke(new Action(() =>
                {

                    if (Musics != null)
                    {


                        nextpreviouscount++;


                        if (nextpreviouscount >= Musics.Count)
                        {
                            nextpreviouscount = Musics.Count - 1;

                        }

                        else
                        {
                            _Player_UC.PlayPauseKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Pause;


                            FilePath_ = Musics.ElementAt(nextpreviouscount).MusicFile;

                            FileName_ = Musics.ElementAt(nextpreviouscount).MusicName;

                            FileImage_ = Musics.ElementAt(nextpreviouscount).ImageMusic;

                            mediaPlayer.Open(new Uri(FilePath_, UriKind.RelativeOrAbsolute));


                            Player play = new Player(new PlayState(mediaPlayer));

                            play.Next(mediaPlayer, Musics, _Player_UC);



                            file = new File()
                            {
                                FileName = FileName_,
                                FilePath = FilePath_,
                                FileImage = FileImage_,
                                IdFile = IdFile_

                            };

                            file.Serialize(file, "../../../Asserts/Files/file.json");

                            _Player_UC.TitleText.Text = FileName_;

                            _Player_UC.Musicplayerimage.ImageSource = new BitmapImage(new Uri(FileImage_, UriKind.RelativeOrAbsolute));




                            ToastNotificationWindow = new ToastNotificationWindow(FileName_, FileImage_, (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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


                    if (mediaPlayer.Source == null)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            ToastNotificationWindow = new ToastNotificationWindow("No file selected", "../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF4500"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
                            ToastNotificationWindow.Show();

                            if (ToastNotificationWindow.Top <= 0)
                            {
                                sizecount = 5;
                            }

                            else
                            {
                                //sizecount = sizecount + 80;
                            }

                            break;
                        }

                    }

                }));
            });


            PreviousMusicCommand = new RelayCommand((e) =>
            {

                _Player_UC.Dispatcher.BeginInvoke(new Action(() =>
                {

                    if (Musics != null)
                    {

                        nextpreviouscount--;



                        if (nextpreviouscount < 0)
                        {
                            nextpreviouscount = 0;
                        }

                        else
                        {

                            _Player_UC.PlayPauseKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Pause;

                            FilePath_ = Musics.ElementAt(nextpreviouscount).MusicFile;

                            FileName_ = Musics.ElementAt(nextpreviouscount).MusicName;

                            FileImage_ = Musics.ElementAt(nextpreviouscount).ImageMusic;

                            mediaPlayer.Open(new Uri(FilePath_, UriKind.RelativeOrAbsolute));


                            Player play = new Player(new PlayState(mediaPlayer));


                            play.Next(mediaPlayer, Musics, _Player_UC);

                            file = new File()
                            {
                                FileName = FileName_,
                                FilePath = FilePath_,
                                FileImage = FileImage_,
                                IdFile = IdFile_

                            };

                            file.Serialize(file, "../../../Asserts/Files/file.json");

                            _Player_UC.TitleText.Text = FileName_;

                            _Player_UC.Musicplayerimage.ImageSource = new BitmapImage(new Uri(FileImage_, UriKind.RelativeOrAbsolute));




                            ToastNotificationWindow = new ToastNotificationWindow(FileName_, FileImage_, (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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


                    if (mediaPlayer.Source == null)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            ToastNotificationWindow = new ToastNotificationWindow("No file selected", "../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF4500"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
                            ToastNotificationWindow.Show();

                            if (ToastNotificationWindow.Top <= 0)
                            {
                                sizecount = 5;
                            }

                            else
                            {
                                //sizecount = sizecount + 80;
                            }

                            break;
                        }

                    }
                }));
            });



            MuteOrUnMuteVolumeCommand = new RelayCommand((e) =>
            {
                ++muteunmutecount;


                if (muteunmutecount % 2 != 0)
                {
                    _Player_UC.MuteOrUnMuteVolumeKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.VolumeMute;

                    _Player_UC.volueslider.Value = 0;
                }
                else
                {
                    _Player_UC.MuteOrUnMuteVolumeKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.VolumeMedium;

                    _Player_UC.volueslider.Value = _Player_UC.volueslider.Maximum / 2;




                }
            });


            PlayerVolumeCommand = new RelayCommand((e) =>
            {

                RoutedPropertyChangedEventArgs<double> args = (RoutedPropertyChangedEventArgs<double>)e;

                _Player_UC.volueslider.Value = VolumeDisplay;

                mediaPlayer.Volume = (double)_Player_UC.volueslider.Value;



                if (mediaPlayer.Volume <= _Player_UC.volueslider.Maximum / 2)
                {
                    _Player_UC.MuteOrUnMuteVolumeKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.VolumeMedium;
                }

                if (mediaPlayer.Volume > _Player_UC.volueslider.Maximum / 2)
                {
                    _Player_UC.MuteOrUnMuteVolumeKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.VolumeHigh;
                }

                if (mediaPlayer.Volume == 0.0000000000000000000000)
                {
                    _Player_UC.MuteOrUnMuteVolumeKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.VolumeMute;
                }

                Debug.WriteLine(_Player_UC.volueslider.Value);
            });


        }

        private async void TimerMusic2_Tick(object? sender, EventArgs e)
        {

            _Player_UC.Dispatcher.BeginInvoke(new Action(async () =>
            {

                Task.Run(() =>
                {
                    var task = new Task(async () => { await LogInCheck(); });

                    task.Start();



                });


                string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                logincheck = JsonConvert.DeserializeObject<bool>(data2);

                _playerwork = new Playerwork();

                _playerwork= await _playerwork.DeSerialize("../../../Asserts/Files/player.json");

                if (_playerwork.IdMusic == null)
                {
                    mediaPlayer.Stop();

                    _Player_UC.Musicplayerimage.ImageSource = new BitmapImage(new Uri("../../../Asserts/Images/Logo/Mainlogo/default.png", UriKind.RelativeOrAbsolute));

                    //FileName_= file.MusicName;

                    _Player_UC.TitleText.Text = string.Empty;

                    _Player_UC.MusicTimeText.Text = string.Empty;

                }


                if (logincheck == false)
                {


                    Musics = null;
                    RadioCollection = null;
                    mediaPlayer.Stop();

                    file = new File();
                    file.Serialize(file, "../../../Asserts/Files/file.json");

                    Task.WaitAll(Task.Delay(1));

                    file = await file.DeSerialize("../../../Asserts/Files/file.json");

                    _Player_UC.PlayPauseKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Play;

                    _logIn = new LogIn();
                    _logIn.Serialize(_logIn, "../../../Asserts/Files/_logIn.json");

                    Task.WaitAll(Task.Delay(1));

                    _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_logIn.json");

                    Task.WaitAll(Task.Delay(1));



                }
                else
                {
                    if (Musics != null && RadioCollection != null)
                    {

                        if (file != null)
                        {


                            file = await file.DeSerialize("../../../Asserts/Files/file.json");


                            var m = Musics.Where(u => u.MusicName == file.FileName && u.ImageMusic == file.FileImage).FirstOrDefault();

                            if (m != null)
                            {
                                _Player_UC.Musicplayerimage.ImageSource = new BitmapImage(new Uri(m.ImageMusic, UriKind.RelativeOrAbsolute));

                                //FileName_= file.MusicName;

                                _Player_UC.TitleText.Text = m.MusicName;
                            }

                            var r = RadioCollection.Where(u => u.RadioName == file.FileName && u.ImageRadio == file.FileImage).FirstOrDefault();

                            if (r != null)
                            {
                                _Player_UC.Musicplayerimage.ImageSource = new BitmapImage(new Uri(r.ImageRadio, UriKind.RelativeOrAbsolute));

                                //FileName_= file.MusicName;

                                _Player_UC.TitleText.Text = r.RadioName;
                            }

                        }
                    }
                }


            }));


        }



        async Task LogInCheck()
        {
            using (var clientHandler = new HttpClientHandler())
            {
                using (var httpClient = new HttpClient(clientHandler))
                {


                    _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_logIn.json");


                    var response = ConnectionAPI.GetMusic(httpClient, _logIn.Username, _logIn.UserPassword, "https://localhost:7270/api/Authenticate/login").Result;

                    Musics = JsonConvert.DeserializeObject<ObservableCollection<Music>>(response);


                    var response2 = ConnectionAPI.GetRadio(httpClient, _logIn.Username, _logIn.UserPassword, "https://localhost:7270/api/Authenticate/login").Result;

                    RadioCollection = JsonConvert.DeserializeObject<ObservableCollection<Radio>>(response2);




                    if (Musics == null && RadioCollection == null)
                    {


                        _Player_UC.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            _Player_UC.Musicplayerimage.ImageSource = new BitmapImage(new Uri("../../../Asserts/Images/Logo/Mainlogo/default.png", UriKind.RelativeOrAbsolute));

                            //FileName_= file.MusicName;

                            _Player_UC.TitleText.Text = string.Empty;

                            _Player_UC.MusicTimeText.Text = string.Empty;

                            mediaPlayer.Stop();
                        }));
                    }


                }
            }
        }

        public async Task PlayRadio()
        {

            _Player_UC.Dispatcher.BeginInvoke(new Action(async () =>
            {
                string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                logincheck = JsonConvert.DeserializeObject<bool>(data2);

                if (logincheck == true)
                {
                    _Player_UC.volueslider.Value = 0.5;

                    //this.volueslider.Value = 0.5;

                    file = await file.DeSerialize("../../../Asserts/Files/file.json");

                    if (file.FilePath != null)
                    {
                        if (HttpValidation(file.FilePath) != false)
                        {
                            mediaPlayer.Open(new Uri(file.FilePath, UriKind.RelativeOrAbsolute));


                            Player play = new Player(new PlayState(mediaPlayer));

                            play.Play(mediaPlayer, Musics, _Player_UC);

                            _Player_UC.PlayPauseKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Pause;


                            playerwork = new Playerwork()
                            {

                                IdMusic = file.IdFile,
                                playerstatus = false,

                            };

                            playerwork.Serialize(playerwork, "../../../Asserts/Files/player.json");

                            Task.Run(() =>
                            {
                                var task = new Task(async () => { await Timer(); });
                                task.Start();


                            });
                        }
                    }
                }

            }));

        }
        public async Task PlayMusic()
        {

            _Player_UC.Dispatcher.BeginInvoke(new Action(async () =>
            {
                string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                logincheck = JsonConvert.DeserializeObject<bool>(data2);

                if (logincheck == true)
                {


                    _Player_UC.volueslider.Value = 0.5;

                    file = await file.DeSerialize("../../../Asserts/Files/file.json");


                    if (file.FilePath != null)
                    {

                        if (HttpValidation(file.FilePath) != false)
                        {



                            mediaPlayer.Open(new Uri(file.FilePath, UriKind.RelativeOrAbsolute));


                            Player play = new Player(new PlayState(mediaPlayer));

                            play.Play(mediaPlayer, Musics, _Player_UC);

                            _Player_UC.PlayPauseKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Pause;


                            playerwork = new Playerwork()
                            {

                                IdMusic = file.IdFile,
                                playerstatus = false,

                            };

                            playerwork.Serialize(playerwork, "../../../Asserts/Files/player.json");

                            Task.Run(() =>
                            {
                                var task = new Task(async () => { await Timer(); });
                                task.Start();
                            });
                        }


                    }
                }

            }));



        }


        private bool HttpValidation(string URL)
        {
            if (!string.IsNullOrEmpty(URL) && Uri.IsWellFormedUriString(URL, UriKind.RelativeOrAbsolute))
            {


                Uri urlToCheck = new Uri(URL);
                WebRequest request = WebRequest.Create(urlToCheck);
                request.Timeout = 5000;

                WebResponse response;
                try
                {
                    response = request.GetResponse();
                }
                catch (Exception ex)
                {


                    ToastNotificationWindowIndex++;


                    ToastNotificationWindow = new ToastNotificationWindow($"{ex.Message}", "../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF4500"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
                    ToastNotificationWindow.Show();

                    var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;

                    if (ToastNotificationWindow.Top <= 0)
                    {
                        sizecount = 5;
                    }

                    else
                    {

                        //sizecount = sizecount + 80;
                    }


                    _Player_UC.PlayPauseKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Play;


                    return false; //url does not exist or have some error
                }

            }
            else
            {

                ToastNotificationWindowIndex++;


                ToastNotificationWindow = new ToastNotificationWindow($"Link broken", "../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF4500"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
                ToastNotificationWindow.Show();

                var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;

                if (ToastNotificationWindow.Top <= 0)
                {
                    sizecount = 5;
                }

                else
                {

                    //sizecount = sizecount + 80;
                }


                _Player_UC.PlayPauseKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Play;
            }
            return true;
        }


        async Task Timer()
        {
            timerMusic.Interval = TimeSpan.FromSeconds(1);
            timerMusic.Tick += TimerMusic_Tick;
            timerMusic.Start();
        }

        private void TimerMusic_Tick(object? sender, EventArgs e)
        {
            try
            {
                if (mediaPlayer.Source != null)
                {
                    TimeSpan ts = new TimeSpan();

                    Player play = new Player(new TimeState(mediaPlayer));
                    play.Time(mediaPlayer, ts, _Player_UC);


                }

            }
            catch (Exception)
            {


            }
        }


    }
}
