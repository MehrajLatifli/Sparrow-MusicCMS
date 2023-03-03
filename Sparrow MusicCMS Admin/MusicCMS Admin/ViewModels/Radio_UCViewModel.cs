using MusicCMS_Admin.Command;
using MusicCMS_Admin.Helpers;
using MusicCMS_Admin.Models.Data;
using MusicCMS_Admin.Models;
using MusicCMS_Admin.Views.Helper_Views.Notification_Views;
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
using MusicCMS_Admin.Views.UserControls;
using System.Net;
using System.Security.Authentication;
using System.Windows;

namespace MusicCMS_Admin.ViewModels
{

    public class Radio_UCViewModel : BaseViewModel
    {


        public Radio_UC _Radio_UC { get; set; }

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


        public RelayCommand RadioListboxMouseDoubleClick { get; set; }

        public RelayCommand RadioSearchCommand { get; set; }

        public RelayCommand CreateRadioCommand { get; set; }


        public RelayCommand LoadedCommand { get; set; }


        public RelayCommand DeleteRadioCommand { get; set; }





        public int playpausecount = 0;

        int nextpreviouscount = 0;





        int userAccountId_forPlaylist_ { get; set; }


        int idRadio_ { get; set; }

        string radioName_ { get; set; }

        string imageRadio_ { get; set; }

        string radioFile_ { get; set; }

        string radioDescription_ { get; set; }

        string radioCountry_ { get; set; }

        public int IdRadio_
        {
            get { return idRadio_; }
            set { idRadio_ = value; OnPropertyChanged(); }
        }

        public string RadioName_
        {
            get { return radioName_; }
            set { radioName_ = value; OnPropertyChanged(); }
        }

        public string ImageRadio_
        {
            get { return imageRadio_; }
            set { imageRadio_ = value; OnPropertyChanged(); }
        }

        public string RadioFile_
        {
            get { return radioFile_; }
            set { radioFile_ = value; OnPropertyChanged(); }
        }
        public string RadioDescription_
        {
            get { return radioDescription_; }
            set { radioDescription_ = value; OnPropertyChanged(); }
        }

        public string RadioCountry_
        {
            get { return radioCountry_; }
            set { radioCountry_ = value; OnPropertyChanged(); }
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

        public Radio_UCViewModel()
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

                _Radio_UC.Dispatcher.InvokeAsync(new Action(async () =>
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


                    if (string.IsNullOrEmpty(_Radio_UC.RadioNameTextbox.Text))
                    {
                        _Radio_UC.RadioNameTextbox.Text = "Radio name";
                        _Radio_UC.RadioNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
                    }

                    if (string.IsNullOrEmpty(_Radio_UC.RadioFileTextbox.Text))
                    {
                        _Radio_UC.RadioFileTextbox.Text = "Radio file";
                        _Radio_UC.RadioFileTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
                    }





                    _Radio_UC.RadioNameTextbox.MouseEnter += RadioNameTextbox_MouseEnter;
                    _Radio_UC.RadioNameTextbox.MouseLeave += RadioNameTextbox_MouseLeave;

                    _Radio_UC.RadioFileTextbox.MouseEnter += RadioFileTextbox_MouseEnter;
                    _Radio_UC.RadioFileTextbox.MouseLeave += RadioFileTextbox_MouseLeave;

                    _Radio_UC.RadioDescriptionTextbox.MouseEnter += RadioDescriptionTextbox_MouseEnter;
                    _Radio_UC.RadioDescriptionTextbox.MouseLeave += RadioDescriptionTextbox_MouseLeave;

                    _Radio_UC.RadioCountryTextbox.MouseEnter += RadioCountryTextbox_MouseEnter;
                    _Radio_UC.RadioCountryTextbox.MouseLeave += RadioCountryTextbox_MouseLeave;


                }));

            });


            RadioSearchCommand = new RelayCommand((e) =>
            {

                _Radio_UC.Dispatcher.InvokeAsync(new Action(() =>
                {



                    if (RadioCollection != null)
                    {


                        _Radio_UC.RadioListbox.ItemsSource = null;

                        if (string.IsNullOrEmpty(_Radio_UC.SearchTextboxForRadioListbox.Text) == false)
                        {
                            _Radio_UC.RadioListbox.ItemsSource = null;
                            _Radio_UC.RadioListbox.Items.Clear();
                            foreach (var item in RadioCollection)
                            {
                                //var str = char.ToUpper(_Radio_UC.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _Radio_UC.SearchTextboxForMusicListbox.Text.ToLower().Substring(1);

                                var str = char.ToUpper(_Radio_UC.SearchTextboxForRadioListbox.Text.ElementAt(0)) + _Radio_UC.SearchTextboxForRadioListbox.Text.Substring(1);

                                Debug.WriteLine(str);

                                if (item.RadioName.Contains(str))
                                {

                                    _Radio_UC.RadioListbox.Items.Add(item);
                                }
                                _Radio_UC.RadioListbox.ItemsSource = null;
                            }
                        }

                        else
                        {
                            _Radio_UC.RadioListbox.Items.Clear();

                            foreach (var item in RadioCollection)
                            {

                                _Radio_UC.RadioListbox.Items.Add(item);


                            }
                        }

                    }



                }));

            });


            RadioListboxMouseDoubleClick = new RelayCommand((e) =>
            {
                _Radio_UC.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (_Radio_UC.RadioListbox.SelectedItem != null)
                    {


                        ListSelectedItem = _Radio_UC.RadioListbox.SelectedItem as dynamic;

                        IdRadio_ = ListSelectedItem.IdRadio;
                        RadioFile_ = ListSelectedItem.RadioFile.ToString();

                        RadioName_ = ListSelectedItem.RadioName.ToString();

                        ImageRadio_ = ListSelectedItem.ImageRadio.ToString();

                        file = new File()
                        {
                            FileName = RadioName_,
                            FilePath = RadioFile_,
                            FileImage = ImageRadio_,
                            IdFile = IdRadio_.ToString(),

                        };


                        playerwork = new Playerwork()
                        {

                            IdMusic = IdRadio_.ToString(),
                            playerstatus = true,

                        };


                        Radio = new Radio()
                        {
                            IdRadio = IdRadio_,
                            RadioName = RadioName_,
                            ImageRadio = ImageRadio_,
                            RadioFile = RadioFile_,
                            RadioDescription = RadioDescription_,
                            RadioCountry = RadioCountry_,
                        };


                        if (Radio != null)
                        {



                            playerwork.Serialize(playerwork, "../../../Asserts/Files/player.json");


                            file.Serialize(file, "../../../Asserts/Files/file.json");



                            ToastNotificationWindow = new ToastNotificationWindow(RadioName_, ImageRadio_, (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);

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


                        //_ToastNotificationWindow = new ToastNotificationWindow(FileName, FileImage, (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
                        //_ToastNotificationWindow.Show();



                        //if (_ToastNotificationWindow.Top <= 0)
                        //{
                        //    sizecount = 5;
                        //}

                        //else
                        //{
                        //    //sizecount = sizecount + 80;
                        //}
                    }

                }));


            });


            CreateRadioCommand = new RelayCommand((e) =>
            {

                _Radio_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {
                    if (logincheck == true)
                    {

                        _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");


                        Radio = new Radio()
                        {
                            RadioName = _Radio_UC.RadioNameTextbox.Text,
                            ImageRadio = "../../../Asserts/Images/Images/radio_wqoalt.png",
                            RadioFile = _Radio_UC.RadioFileTextbox.Text,
                            RadioDescription=_Radio_UC.RadioDescriptionTextbox.Text,
                            RadioCountry = _Radio_UC.RadioCountryTextbox.Text

                        };

                        if (Radio != null)
                        {
                            await PostRadio(_logIn.Username, _logIn.UserPassword, Radio);




                        }
                    }
                }));

            });




            DeleteRadioCommand = new RelayCommand((e) =>
            {


                _Radio_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {

                    try
                    {



                        Task.Run(async () =>
                        {

                            _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");

                        });

                        if (_logIn != null)
                        {

                            ListSelectedItem = _Radio_UC.RadioListbox.SelectedItem as dynamic;


                            IdRadio_ = ListSelectedItem.IdRadio;
                            RadioName_ = ListSelectedItem.RadioName;
                            ImageRadio_ = ListSelectedItem.ImageRadio;
                            RadioFile_ = ListSelectedItem.RadioFile;
                            RadioDescription_ = ListSelectedItem.RadioDescription;
                            RadioCountry_ = ListSelectedItem.RadioCountry;


                            Radio = new Radio()
                            {
                                IdRadio = IdRadio_,
                                RadioName = RadioName_,
                                ImageRadio = ImageRadio_,
                                RadioFile = RadioFile_,
                                RadioDescription = RadioDescription_,
                                RadioCountry = RadioCountry_,
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

                            if (Radio != null)
                            {

                                await DeleteRadio(_logIn.Username, _logIn.UserPassword, Radio);
                            }




                        }
                    }
                    catch (Exception)
                    {

                    }
                }));

            });





        }



        async Task DeleteRadio(string username, string password, Radio radio)
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


                        await ConnectionAPI.DeleteRadio(httpClient, username, password, "https://localhost:7270/api/Authenticate/login", radio);


                        //Task.Run(() =>
                        //{


                        //    FileWriteRead<Playlist>.WriteToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);

                        //});


                        ToastNotificationWindow = new ToastNotificationWindow($"{radio.RadioName} has been deleted.", $"../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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


        async Task PostRadio(string username, string password, Radio radio)
        {
            if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        await ConnectionAPI.PostRadio(httpClient, username, password, "https://localhost:7270/api/Authenticate/login", radio);

                        //Task.Run(() =>
                        //{


                        //    FileWriteRead<Playlist>.WriteToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);

                        //});


                        ToastNotificationWindow = new ToastNotificationWindow("A radio named" + " " + radio.RadioName + " " + "has been created.", radio.ImageRadio, (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);

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


        private void RadioFileTextbox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_Radio_UC.RadioFileTextbox.Text))
            {
                _Radio_UC.RadioFileTextbox.Text = "Radio file";
                _Radio_UC.RadioFileTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
            }
        }

        private void RadioFileTextbox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_Radio_UC.RadioFileTextbox.Text == "Radio file")
            {
                _Radio_UC.RadioFileTextbox.Text = "";
                _Radio_UC.RadioFileTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }

        private void RadioNameTextbox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_Radio_UC.RadioNameTextbox.Text))
            {
                _Radio_UC.RadioNameTextbox.Text = "Radio name";
                _Radio_UC.RadioNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
            }
        }

        private void RadioNameTextbox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_Radio_UC.RadioNameTextbox.Text == "Radio name")
            {
                _Radio_UC.RadioNameTextbox.Text = "";
                _Radio_UC.RadioNameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }


        private void RadioCountryTextbox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_Radio_UC.RadioCountryTextbox.Text))
            {
                _Radio_UC.RadioCountryTextbox.Text = "Radio country";
                _Radio_UC.RadioCountryTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
            }
        }

        private void RadioCountryTextbox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_Radio_UC.RadioCountryTextbox.Text == "Radio country")
            {
                _Radio_UC.RadioCountryTextbox.Text = "";
                _Radio_UC.RadioCountryTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }

        private void RadioDescriptionTextbox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_Radio_UC.RadioDescriptionTextbox.Text))
            {
                _Radio_UC.RadioDescriptionTextbox.Text = "Radio description";
                _Radio_UC.RadioDescriptionTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
            }
        }

        private void RadioDescriptionTextbox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_Radio_UC.RadioDescriptionTextbox.Text == "Radio description")
            {
                _Radio_UC.RadioDescriptionTextbox.Text = "";
                _Radio_UC.RadioDescriptionTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }



        private void TimerGetList_Tick(object? sender, EventArgs e)
        {
            _Radio_UC.Dispatcher.BeginInvoke(new Action(async () =>
            {

                string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                logincheck = JsonConvert.DeserializeObject<bool>(data2);

                if (logincheck == true)
                {

                    try
                    {


                        _logIn = await _logIn.DeSerialize("../../../Asserts/Files/_login.json");



                        await GetRadio(_logIn.Username, _logIn.UserPassword);

                        if (string.IsNullOrEmpty(_Radio_UC.SearchTextboxForRadioListbox.Text))
                        {
                            _Radio_UC.SearchTextboxForRadioListbox.Text = "  ";
                            _Radio_UC.SearchTextboxForRadioListbox.Text = string.Empty;
                        }


                        //if (_Radio_UC.MusicListbox.ItemsSource!=null)
                        //{

                        //_Radio_UC.MusicListbox.ItemsSource = Musics;
                        //}





                    }
                    catch (Exception)
                    {

                    }



                    //var fi = _Radio_UC.GetType().GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
                    //if (fi != null)
                    //{
                    //    object obj = fi.GetValue(_Radio_UC);
                    //    PropertyInfo pi = _Radio_UC.MusicListbox.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                    //    EventHandlerList list = (EventHandlerList)pi.GetValue(_Radio_UC, null);
                    //    list.RemoveHandler(obj, list[obj]);
                    //}


                    [DllImport("kernel32.dll")]
                    static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

                    SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);

                }
                else
                {
                    _Radio_UC.RadioListbox.ItemsSource = null;
                    _Radio_UC.RadioListbox.Items.Clear();



                }


            }));
        }


        async Task GetRadio(string username, string password)
        {
            if (System.IO.File.Exists("../../../Asserts/Files/_logIn.json"))
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        var response = await ConnectionAPI.GetRadio(httpClient, username, password, "https://localhost:7270/api/Authenticate/login");


                        RadioCollection = JsonConvert.DeserializeObject<ObservableCollection<Radio>>(response);
                    }

                    //FileWriteRead<Playlist>.ReadToFile("../../../Asserts/Files/playlist.json", PlaylistCollection);
                }

            };
        }



    }


}
