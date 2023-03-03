using MusicCMS.Command;
using MusicCMS.Helpers;
using MusicCMS.Models;
using MusicCMS.Models.Data;
using MusicCMS.ViewModels;
using MusicCMS.Views.Helper_Views.Notification_Views;
using MusicCMS.Views.UserControls;
using Newtonsoft.Json;
using Sparrow_MusicCMS.Helpers;
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

namespace Sparrow_MusicCMS.ViewModels
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



        //HttpClientHandler clientHandler = new HttpClientHandler();


        DispatcherTimer timerGetdata = new DispatcherTimer();


        private MediaPlayer mediaPlayer = new MediaPlayer();


        public RelayCommand RadioListboxMouseDoubleClick { get; set; }



        public RelayCommand RadioCollectionSearchCommand { get; set; }



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

        string artistId_ { get; set; }
        public string ArtistId_
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

        string albumId_ { get; set; }
        public string AlbumId_
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









        public Radio_UCViewModel()
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

                _Radio_UC.Dispatcher.BeginInvoke(new Action(() =>
                {
                    _logIn = new LogIn();

                    timerGetdata.Start();



                }));
            });





            RadioListboxMouseDoubleClick = new RelayCommand((e) =>
            {
                _Radio_UC.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (_Radio_UC.RadioListbox.SelectedItem != null)
                    {

                        ListSelectedItem = _Radio_UC.RadioListbox.SelectedItem as dynamic;

                        IdFile_ = ListSelectedItem.IdRadio.ToString();
                        FilePath_ = ListSelectedItem.RadioFile.ToString();

                        FileName_ = ListSelectedItem.RadioName.ToString();

                        FileImage_ = ListSelectedItem.ImageRadio.ToString();

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



            RadioCollectionSearchCommand = new RelayCommand((e) =>
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
                            //var str = char.ToUpper(_Radio_UC.SearchTextboxForRadioListbox.Text.ElementAt(0)) + _Radio_UC.SearchTextboxForRadioListbox.Text.ToLower().Substring(1);

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


            });







        }




        private void Timer_Tick(object? sender, EventArgs e)
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



                        _Radio_UC.RadioListbox.ItemsSource = RadioCollection;


                        //if (_Radio_UC.RadioListbox.ItemsSource!=null)
                        //{

                        //_Radio_UC.RadioListbox.ItemsSource = RadioCollection;
                        //}




                        await GetRadio(_logIn.Username, _logIn.UserPassword);




                    }
                    catch (Exception)
                    {

                    }



                    //var fi = _Radio_UC.GetType().GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
                    //if (fi != null)
                    //{
                    //    object obj = fi.GetValue(_Radio_UC);
                    //    PropertyInfo pi = _Radio_UC.RadioListbox.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
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


                    mediaPlayer.Stop();

                    if (System.IO.File.Exists("../../../Asserts/Files/RadioCollection.json"))
                    {
                        System.IO.File.Delete("../../../Asserts/Files/RadioCollection.json");

                    };



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
                    //FileWriteRead<Radio>.ReadToFile("../../../Asserts/Files/RadioCollection.json", RadioCollection);
                }

            };

        }









    }
}
