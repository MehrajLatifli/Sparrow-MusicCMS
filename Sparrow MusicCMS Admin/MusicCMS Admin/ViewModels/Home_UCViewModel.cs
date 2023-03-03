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
using System.Windows.Input;
using System.Windows;
using System.Windows.Data;

namespace MusicCMS_Admin.ViewModels
{
    public class Home_UCViewModel : BaseViewModel
    {



        public Home_UC _Home_UC { get; set; }


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


        DispatcherTimer timerGetMusicList = new DispatcherTimer();

        DispatcherTimer timer = new DispatcherTimer();


        private MediaPlayer mediaPlayer = new MediaPlayer();


        public RelayCommand MusicListboxMouseDoubleClick { get; set; }



        public RelayCommand MusicSearchCommand { get; set; }

        public RelayCommand RadioSearchCommand { get; set; }




        public RelayCommand RadioListboxMouseDoubleClick { get; set; }

        public RelayCommand ChangeRegistrationPositionCommand { get; set; }

        public RelayCommand RegistrationCommand { get; set; }


        public RelayCommand LoadedCommand { get; set; }

        public RelayCommand LogOutCommand { get; set; }



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


        string Password_ { get; set; }

        public string Password
        {
            get { return Password_; }
            set { Password_ = value; OnPropertyChanged("Password"); }
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

        bool hascreate = false;

        Semaphore semaphore = new Semaphore(0, 10, "semaphore_");
        Semaphore semaphore2 = new Semaphore(0, 10, "semaphore2_");


        public Home_UCViewModel()
        {


            timerGetMusicList.Tick += Timer_Tick; ;
            timerGetMusicList.Interval = TimeSpan.FromSeconds(1);


            timer.Tick += Timer_Tick1;
            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Start();


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

                _Home_UC.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (string.IsNullOrEmpty(_Home_UC.UsernameTextbox.Text))
                    {
                        _Home_UC.UsernameTextbox.Text = "Username";
                        _Home_UC.UsernameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
                    }

                    if (string.IsNullOrEmpty(_Home_UC.PasswordTextbox.Text))
                    {
                        _Home_UC.PasswordTextbox.Text = "Password";
                        _Home_UC.PasswordTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));

                    }

                    if (string.IsNullOrEmpty(EmailtextBox.Text))
                    {
                        EmailtextBox.Text = "Email address";
                        EmailtextBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));

                    }




                    PasswordToHiddenCharactersConverter passwordToHiddenCharactersConverter = new PasswordToHiddenCharactersConverter();

                    Binding bindings = new Binding();
                    bindings.Path = new PropertyPath("Password");
                    bindings.Mode = BindingMode.TwoWay;
                    bindings.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    bindings.Converter = passwordToHiddenCharactersConverter;

                    _Home_UC.PasswordTextbox.SetBinding(TextBox.TextProperty, bindings);




                    _Home_UC.UsernameTextbox.MouseEnter += UsernameTextbox_MouseEnter;
                    _Home_UC.UsernameTextbox.MouseLeave += UsernameTextbox_MouseLeave;

                    _Home_UC.PasswordTextbox.MouseEnter += PasswordTextbox_MouseEnter;
                    _Home_UC.PasswordTextbox.MouseLeave += PasswordTextbox_MouseLeave;



                }));
            });





            MusicListboxMouseDoubleClick = new RelayCommand((e) =>
            {
                _Home_UC.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (_Home_UC.MusicListbox.SelectedItem != null)
                    {

                        ListSelectedItem = _Home_UC.MusicListbox.SelectedItem as dynamic;

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


                            _Home_UC.ellipsegrid.Visibility = Visibility.Visible;
                            _Home_UC.Usernameborder.Visibility = Visibility.Hidden;
                            _Home_UC.Passwordborder.Visibility = Visibility.Hidden;

                        }

                        else
                        {
                            sizecount = sizecount + 80;


                            _Home_UC.ellipsegrid.Visibility = Visibility.Visible;
                            _Home_UC.Usernameborder.Visibility = Visibility.Hidden;
                            _Home_UC.Passwordborder.Visibility = Visibility.Hidden;
                        }

                        if (ToastNotificationWindowIndex > 0)
                        {



                            if (ToastNotificationWindowList.ElementAt(ToastNotificationWindowIndex - 1).Close_ == true)
                            {

                                sizecount = 5;

                                _Home_UC.ellipsegrid.Visibility = Visibility.Visible;
                                _Home_UC.Usernameborder.Visibility = Visibility.Hidden;
                                _Home_UC.Passwordborder.Visibility = Visibility.Hidden;

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
                _Home_UC.Dispatcher.InvokeAsync(new Action(() =>
                {
                    timerGetMusicList.Stop();

                        if (Musics != null)
                        {


                            _Home_UC.MusicListbox.ItemsSource = null;

                            if (string.IsNullOrEmpty(_Home_UC.SearchTextboxForMusicListbox.Text) == false)
                            {
                                _Home_UC.MusicListbox.ItemsSource = null;
                                _Home_UC.MusicListbox.Items.Clear();

                                foreach (var item in Musics)
                                {
                                    //var str = char.ToUpper(_Home_UC.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _Home_UC.SearchTextboxForMusicListbox.Text.ToLower().Substring(1);

                                    var str = char.ToUpper(_Home_UC.SearchTextboxForMusicListbox.Text.ElementAt(0)) + _Home_UC.SearchTextboxForMusicListbox.Text.Substring(1);

                                    Debug.WriteLine(str);

                                    if (item.MusicName.Contains(str))
                                    {

                                        _Home_UC.MusicListbox.Items.Add(item);

                                    }
                                    _Home_UC.MusicListbox.ItemsSource = null;
                                }
                            }

                            else
                            {
                                _Home_UC.MusicListbox.Items.Clear();

                                foreach (var item in Musics)
                                {

                                    _Home_UC.MusicListbox.Items.Add(item);


                                }
                            }

                        }
                    

                }));

            });



            RadioListboxMouseDoubleClick = new RelayCommand((e) =>
            {
                _Home_UC.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (_Home_UC.RadioListbox.SelectedItem != null)
                    {


                        ListSelectedItem = _Home_UC.RadioListbox.SelectedItem as dynamic;

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

                            _Home_UC.ellipsegrid.Visibility = Visibility.Visible;
                            _Home_UC.Usernameborder.Visibility = Visibility.Hidden;
                            _Home_UC.Passwordborder.Visibility = Visibility.Hidden;
                        }

                        else
                        {
                            sizecount = sizecount + 80;

                            _Home_UC.ellipsegrid.Visibility = Visibility.Visible;
                            _Home_UC.Usernameborder.Visibility = Visibility.Hidden;
                            _Home_UC.Passwordborder.Visibility = Visibility.Hidden;
                        }

                        if (ToastNotificationWindowIndex > 0)
                        {



                            if (ToastNotificationWindowList.ElementAt(ToastNotificationWindowIndex - 1).Close_ == true)
                            {

                                sizecount = 5;

                                _Home_UC.ellipsegrid.Visibility = Visibility.Visible;
                                _Home_UC.Usernameborder.Visibility = Visibility.Hidden;
                                _Home_UC.Passwordborder.Visibility = Visibility.Hidden;
                            }
                        }


                        ToastNotificationWindowIndex++;





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



            RadioSearchCommand = new RelayCommand((e) =>
            {
                _Home_UC.Dispatcher.InvokeAsync(new Action(() =>
                {

                    if (RadioCollection != null)
                        {


                            _Home_UC.RadioListbox.ItemsSource = null;

                            if (string.IsNullOrEmpty(_Home_UC.SearchTextboxForRadioListbox.Text) == false)
                            {
                                _Home_UC.RadioListbox.ItemsSource = null;
                                _Home_UC.RadioListbox.Items.Clear();

                                foreach (var item in RadioCollection)
                                {

                                    var str = char.ToUpper(_Home_UC.SearchTextboxForRadioListbox.Text.ElementAt(0)) + _Home_UC.SearchTextboxForRadioListbox.Text.Substring(1);

                                    Debug.WriteLine(str);

                                    if (item.RadioName.Contains(str))
                                    {

                                        _Home_UC.RadioListbox.Items.Add(item);
                                    }
                                    _Home_UC.RadioListbox.ItemsSource = null;
                                }
                            }

                            else
                            {
                                _Home_UC.RadioListbox.Items.Clear();

                                foreach (var item in RadioCollection)
                                {

                                    _Home_UC.RadioListbox.Items.Add(item);


                                }
                            }

                        
                    }

                }));

            });



            ChangeRegistrationPositionCommand = new RelayCommand((e) =>
            {

                _Home_UC.Dispatcher.BeginInvoke(new Action(() =>
                {
                    changeRegistrationCount++;

                    if (changeRegistrationCount % 2 != 0)
                    {

                        _Home_UC.RegistrationButtonTextblock.Text = "Log In";

                        _Home_UC.RegistrationKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.LockOpen;



                        EmailtextBox.Text = String.Empty;



                        _Home_UC.FormGrid.Children.Remove(border);

                        _Home_UC.RegistrationGrid.SetValue(Grid.RowProperty, 2);




                    }
                    else
                    {

                        _Home_UC.RegistrationButtonTextblock.Text = "Create account";

                        _Home_UC.RegistrationKind.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Account;




                        border.Name = "Emailborder";
                        border.Visibility = Visibility.Visible;
                        border.CornerRadius = new CornerRadius(20);
                        Color color = Colors.White;
                        border.BorderBrush = new SolidColorBrush(color);
                        Color color2 = Colors.Transparent;
                        border.Background = new SolidColorBrush(color2);
                        border.BorderThickness = new Thickness(5);
                        border.Margin = new Thickness(10, 10, 10, 10);

                        border.SetValue(Grid.RowProperty, 2);

                        EmailtextBox.Style = (Style)EmailtextBox.FindResource("TextBoxStyle1");
                        EmailtextBox.Name = "EmailTextbox";
                        EmailtextBox.FontWeight = FontWeights.Bold;
                        EmailtextBox.VerticalContentAlignment = VerticalAlignment.Center;
                        EmailtextBox.IsUndoEnabled = false;
                        EmailtextBox.AcceptsReturn = true;
                        EmailtextBox.AcceptsTab = true;
                        EmailtextBox.Focusable = true;
                        EmailtextBox.TextWrapping = TextWrapping.WrapWithOverflow;
                        EmailtextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
                        EmailtextBox.Padding = new Thickness(10, 0, 0, 0);
                        EmailtextBox.Margin = new Thickness(0, 0, 0, 0);
                        EmailtextBox.FontSize = 25;
                        EmailtextBox.Text = String.Empty;
                        EmailtextBox.MaxLength = 20;
                        EmailtextBox.MaxLines = 20;

                        EmailtextBox.MouseEnter += TextBox_MouseEnter; ;

                        EmailtextBox.MouseLeave += TextBox_MouseLeave; ;


                        border.Child = EmailtextBox;




                        _Home_UC.FormGrid.Children.Add(border);


                        _Home_UC.RegistrationGrid.SetValue(Grid.RowProperty, 3);




                    }

                }));
            });



            RegistrationCommand = new RelayCommand((e) =>
            {

                _Home_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {


                    if (_Home_UC.RegistrationButtonTextblock.Text != "Create account")
                    {

                        if (PasswordValidator.IsValidPassword(Password))
                        {



                            _Home_UC.ChangeRegistrationPositionButton.Visibility = Visibility.Hidden;
                            _Home_UC.RegistrationButton.Visibility = Visibility.Hidden;
                            _Home_UC.UsernameTextbox.IsEnabled = false;
                            _Home_UC.PasswordTextbox.IsEnabled = false;



                            Task.Run(() =>
                            {


                                var task = new Task(async () => { await LogInAccount(Password); });
                                task.Start();



                            });



                            _Home_UC.LogOutPositionButton.Visibility = Visibility.Visible;


                        }
                        else
                        {
                            ToastNotificationWindow = new ToastNotificationWindow(" Passwords must have at least one non alphanumeric character., \n Passwords must have at least one digit ('0'-'9')., \n Passwords must have at least one", "../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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

                    else
                    {

                        if (PasswordValidator.IsValidPassword(Password))
                        {
                            _Home_UC.ChangeRegistrationPositionButton.Visibility = Visibility.Hidden;
                            _Home_UC.RegistrationButton.Visibility = Visibility.Hidden;
                            _Home_UC.UsernameTextbox.IsEnabled = false;
                            _Home_UC.PasswordTextbox.IsEnabled = false;
                            EmailtextBox.IsEnabled = false;


                            Task.Run(() =>
                            {
                                var task = new Task(async () => { await CreateAccount(Password); });
                                task.Start();
                            });



                            _Home_UC.LogOutPositionButton.Visibility = Visibility.Visible;

                        }
                        else
                        {
                            ToastNotificationWindow = new ToastNotificationWindow(" Passwords must have at least one non alphanumeric character., \n Passwords must have at least one digit ('0'-'9')., \n Passwords must have at least one", "../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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



                }));
            });




            LogOutCommand = new RelayCommand((e) =>
            {

                _Home_UC.Dispatcher.BeginInvoke(new Action(() =>
                {

                    try
                    {
                        var s = semaphore;


                        bool st = false;

                        while (!st)
                        {
                            if (s.WaitOne(200))
                            {
                                try
                                {



                                    Task.Run(async () =>
                                    {

                                        _Home_UC.Dispatcher.BeginInvoke(new Action(() =>
                                        {



                                            _Home_UC.SearchTextboxForMusicListbox.Text = string.Empty;
                                            _Home_UC.SearchTextboxForRadioListbox.Text = string.Empty;

                                            _Home_UC.UsernameTextbox.Text = String.Empty;
                                            _Home_UC.PasswordTextbox.Text = String.Empty;
                                            EmailtextBox.Text = String.Empty;

                                            _Home_UC.ChangeRegistrationPositionButton.Visibility = Visibility.Visible;
                                            _Home_UC.RegistrationButton.Visibility = Visibility.Visible;
                                            _Home_UC.UsernameTextbox.IsEnabled = true;
                                            _Home_UC.PasswordTextbox.IsEnabled = true;
                                            EmailtextBox.IsEnabled = true;

                                            _Home_UC.LogOutPositionButton.Visibility = Visibility.Hidden;


                                        }));


                                    });




                                }
                                finally
                                {

                                    st = true;

                                }
                            }

                            else
                            {
                                try
                                {
                                    s.Release();
                                }
                                catch (Exception)
                                {


                                }
                            }
                        }


                        var s2 = semaphore;


                        bool st2 = false;

                        while (!st2)
                        {
                            if (s2.WaitOne(200))
                            {
                                try
                                {






                                    var task = Task.Run(async () => { await LogOutAccount(Password); });


                                    _Home_UC.ellipsegrid.Visibility = Visibility.Hidden;
                                    _Home_UC.Usernameborder.Visibility = Visibility.Visible;
                                    _Home_UC.Passwordborder.Visibility = Visibility.Visible;

                                }
                                finally
                                {

                                    st2 = true;

                                }
                            }

                            else
                            {
                                try
                                {
                                    s2.Release();
                                }
                                catch (Exception)
                                {


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

        private void Timer_Tick1(object? sender, EventArgs e)
        {
            _Home_UC.Dispatcher.BeginInvoke(new Action(async () =>
            {

                string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                logincheck = JsonConvert.DeserializeObject<bool>(data2);

                if (logincheck == true)
                {

                    await GetMusic(Password);

                    ////await GetPopularMusic();


                    await GetRadio(Password);







                    if (string.IsNullOrEmpty(_Home_UC.SearchTextboxForMusicListbox.Text))
                    {
                        _Home_UC.SearchTextboxForMusicListbox.Text = "  ";
                        _Home_UC.SearchTextboxForMusicListbox.Text = string.Empty;
                    }


                    if (string.IsNullOrEmpty(_Home_UC.SearchTextboxForRadioListbox.Text))
                    {
                        _Home_UC.SearchTextboxForRadioListbox.Text = "  ";
                        _Home_UC.SearchTextboxForRadioListbox.Text = string.Empty;
                    }


                    [DllImport("kernel32.dll")]
                    static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

                    SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);


                    timerGetMusicList.Stop();
                }


            }));

        }

        private void PasswordTextbox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_Home_UC.PasswordTextbox.Text))
            {
                _Home_UC.PasswordTextbox.Text = "Password";
                _Home_UC.PasswordTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
            }
        }

        private void PasswordTextbox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (_Home_UC.PasswordTextbox.Text == "Password")
            {
                _Home_UC.PasswordTextbox.Text = "";
                _Home_UC.PasswordTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }

        private void UsernameTextbox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_Home_UC.UsernameTextbox.Text))
            {
                _Home_UC.UsernameTextbox.Text = "Username";
                _Home_UC.UsernameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
            }
        }

        private void UsernameTextbox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (_Home_UC.UsernameTextbox.Text == "Username")
            {
                _Home_UC.UsernameTextbox.Text = "";
                _Home_UC.UsernameTextbox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }

        private void TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(EmailtextBox.Text))
            {
                EmailtextBox.Text = "Email address";
                EmailtextBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 168, 91));
            }
        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (EmailtextBox.Text == "Email address")
            {
                EmailtextBox.Text = "";
                EmailtextBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }





        private void Timer_Tick(object? sender, EventArgs e)
        {
            _Home_UC.Dispatcher.BeginInvoke(new Action(async () =>
            {
                if (hascreate == false)
                {

                    await GetMusic(Password);

                    ////await GetPopularMusic();


                    await GetRadio(Password);




                    if (string.IsNullOrEmpty(_Home_UC.SearchTextboxForMusicListbox.Text))
                    {
                        _Home_UC.SearchTextboxForMusicListbox.Text = "  ";
                        _Home_UC.SearchTextboxForMusicListbox.Text = string.Empty;
                    }


                    if (string.IsNullOrEmpty(_Home_UC.SearchTextboxForRadioListbox.Text))
                    {
                        _Home_UC.SearchTextboxForRadioListbox.Text = "  ";
                        _Home_UC.SearchTextboxForRadioListbox.Text = string.Empty;
                    }


                    //var fi = _Home_UC.GetType().GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
                    //if (fi != null)
                    //{
                    //    object obj = fi.GetValue(_Home_UC);
                    //    PropertyInfo pi = _Home_UC.MusicListbox.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                    //    EventHandlerList list = (EventHandlerList)pi.GetValue(_Home_UC, null);
                    //    list.RemoveHandler(obj, list[obj]);
                    //}

                    [DllImport("kernel32.dll")]
                    static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

                    SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);

                }


            }));

        }




        async Task GetMusic(string Password)
        {

            try
            {


                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        var response = await ConnectionAPI.GetMusic(httpClient, _Home_UC.UsernameTextbox.Text, Password, "https://localhost:7270/api/Authenticate/login");



                        Musics = JsonConvert.DeserializeObject<ObservableCollection<Music>>(response);



                        //FileWriteRead<Music>.WriteToFile("../../../Asserts/Files/musics.json", Musics);




                        //using (var streamReader = new StreamReader(response))
                        //using (var jsonReader = new JsonTextReader(streamReader))
                        //using (var streamWriter = System.IO.File.CreateText("../../../Asserts/Files/musics.json"))
                        //using (var jsonTextWriter = new JsonTextWriter(streamWriter))
                        //{
                        //    jsonTextWriter.Formatting = Formatting.Indented;

                        //    while (jsonReader.Read())
                        //    {
                        //        jsonTextWriter.WriteToken(jsonReader);
                        //    }
                        //}
                    }
                }
            }
            catch (Exception)
            {

            }

        }


        async Task GetRadio(string Password)
        {
            try
            {


                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        var response = await ConnectionAPI.GetRadio(httpClient, _Home_UC.UsernameTextbox.Text, Password, "https://localhost:7270/api/Authenticate/login");



                        RadioCollection = JsonConvert.DeserializeObject<ObservableCollection<Radio>>(response);


           


                        //FileWriteRead<Radio>.WriteToFile("../../../Asserts/Files/RadioCollection.json", RadioCollection);
                    }
                }
            }
            catch (Exception)
            {


            }
        }






        async Task CreateAccount(string Password)
        {

            _Home_UC.Dispatcher.BeginInvoke(new Action(async () =>
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {

                        if (PasswordValidator.IsValidPassword(Password))
                        {
                            hascreate = true;

                            logincheck = true;

                            if (logincheck == true)
                            {
                                timerGetMusicList.Stop();

                                Task.Delay(1000);

                                timerGetMusicList.Start();

                                var response_ = await ConnectionAPI.Registration(httpClient, _Home_UC.UsernameTextbox.Text, Password, EmailtextBox.Text, "https://localhost:7270/api/Authenticate/register");

                                UserAccounts = JsonConvert.DeserializeObject<ObservableCollection<UserAccount>>(response_);

                                _Home_UC.MusicListbox.ItemsSource = null;
                                _Home_UC.RadioListbox.ItemsSource = null;

                                //var response2 = await ConnectionAPI.GetMusic(httpClient, _Home_UC.UsernameTextbox.Text, _Home_UC.PasswordTextbox.Text, "https://localhost:7270/api/Authenticate/login");

                                //Musics = JsonConvert.DeserializeObject<ObservableCollection<Music>>(response2);


                                //var response3 = await ConnectionAPI.GetRadio(httpClient, _Home_UC.UsernameTextbox.Text, _Home_UC.PasswordTextbox.Text, "https://localhost:7270/api/Authenticate/login");

                                //RadioCollection = JsonConvert.DeserializeObject<ObservableCollection<Radio>>(response3);

                                //_Home_UC.MusicListbox.ItemsSource = Musics;
                                //_Home_UC.RadioListbox.ItemsSource = RadioCollection;

                                mre.Set();

                                logincheck = false;

                            }

                            if (logincheck == false)
                            {
                                timerGetMusicList.Stop();
                                _Home_UC.UsernameTextbox.Text = String.Empty;
                                _Home_UC.PasswordTextbox.Text = String.Empty;
                                EmailtextBox.Text = String.Empty;

                                _Home_UC.MusicListbox.ItemsSource = null;
                                _Home_UC.RadioListbox.ItemsSource = null;

                                Musics = null;
                                RadioCollection = null;
                                mediaPlayer.Stop();

                                Thread.Sleep(100);
                                mre.Reset();
                            }
                        }

                        else
                        {
                            //_ToastNotificationWindow = new ToastNotificationWindow(" Passwords must have at least one non alphanumeric character., \n Passwords must have at least one digit ('0'-'9')., \n Passwords must have at least one", "../../../Asserts/Images/Logo/Main logo/LOGO-ag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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


                    }
                }

            }));
        }

        async Task LogInAccount(string Password)
        {

            _Home_UC.Dispatcher.BeginInvoke(new Action(async () =>
            {


                using (var clientHandler = new HttpClientHandler())
                {
                    using (var httpClient = new HttpClient(clientHandler))
                    {


                        if (PasswordValidator.IsValidPassword(Password))
                        {
                            hascreate = false;






                            if (cts.IsCancellationRequested)
                            {
                                cts = new CancellationTokenSource();

                                var response = await ConnectionAPI.LogiIn(httpClient, _Home_UC.UsernameTextbox.Text, Password, EmailtextBox.Text, "https://localhost:7270/api/Authenticate/login", cts);

                                if (response != "[]")
                                {

                                    UserAccounts = JsonConvert.DeserializeObject<ObservableCollection<UserAccount>>(response);

                                    if (UserAccounts != null)
                                    {

                                        if (UserAccounts.Any(u => u.Username == _Home_UC.UsernameTextbox.Text && u.UserPassword == Password))
                                        {



                                            var u = UserAccounts.Where(u => u.Username == _Home_UC.UsernameTextbox.Text && u.UserPassword == Password).FirstOrDefault();

                                            _logIn = new LogIn()
                                            {
                                                IdUserAccount = u.IdUserAccount,
                                                Username = u.Username,
                                                UserPassword = u.UserPassword
                                            };


                                            _logIn.Serialize(_logIn, "../../../Asserts/Files/_logIn.json");

                                            logincheck = true;

                                            if (logincheck == true)
                                            {



                                                var f = Newtonsoft.Json.Formatting.Indented;
                                                string data = JsonConvert.SerializeObject(logincheck, f);

                                                System.IO.File.WriteAllText("../../../Asserts/Files/logincheck.json", data);

                                                timerGetMusicList.Stop();

                                                Task.Delay(1000);

                                                timerGetMusicList.Start();


                                                var response2 = await ConnectionAPI.GetMusic(httpClient, _Home_UC.UsernameTextbox.Text, Password, "https://localhost:7270/api/Authenticate/login");

                                                Musics = JsonConvert.DeserializeObject<ObservableCollection<Music>>(response2);


                                                var response3 = await ConnectionAPI.GetRadio(httpClient, _Home_UC.UsernameTextbox.Text, Password, "https://localhost:7270/api/Authenticate/login");

                                                RadioCollection = JsonConvert.DeserializeObject<ObservableCollection<Radio>>(response3);

                                                _Home_UC.MusicListbox.ItemsSource = null;
                                                _Home_UC.RadioListbox.ItemsSource = null;
                                                _Home_UC.MusicListbox.Items.Clear();
                                                _Home_UC.RadioListbox.Items.Clear();
                                                _Home_UC.MusicListbox.ItemsSource = Musics;
                                                _Home_UC.RadioListbox.ItemsSource = RadioCollection;

                                                _Home_UC.ellipsegrid.Visibility = Visibility.Visible;
                                                _Home_UC.Usernameborder.Visibility = Visibility.Hidden;
                                                _Home_UC.Passwordborder.Visibility = Visibility.Hidden;

                                                if (UserAccounts != null)
                                                {
                                                    if (UserAccounts.Any(u => u.Username == _Home_UC.UsernameTextbox.Text && u.UserPassword == Password))
                                                    {
                                                        //_ToastNotificationWindow = new ToastNotificationWindow(_Home_UC.UsernameTextbox.Text, "../../../Asserts/Images/Logo/Main logo/LOGO-ag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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
                                                }
                                                if (UserAccounts == null)
                                                {
                                                    logincheck = false;



                                                    if (logincheck == false)
                                                    {
                                                        timerGetMusicList.Stop();




                                                        _Home_UC.MusicListbox.ItemsSource = null;
                                                        _Home_UC.RadioListbox.ItemsSource = null;

                                                        Musics = null;
                                                        RadioCollection = null;

                                                        mediaPlayer.Stop();


                                                        Thread.Sleep(100);
                                                        mre.Reset();
                                                    }


                                                    //_ToastNotificationWindow = new ToastNotificationWindow("Username or Password is incorrect.", "../../../Asserts/Images/Logo/Main logo/LOGO-ag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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


                                                Thread.Sleep(100);
                                                mre.Set();


                                            }
                                            if (logincheck == false)
                                            {

                                                var f = Newtonsoft.Json.Formatting.Indented;
                                                string data = JsonConvert.SerializeObject(logincheck, f);

                                                System.IO.File.WriteAllText("../../../Asserts/Files/logincheck.json", data);


                                                timerGetMusicList.Stop();
                                                _Home_UC.UsernameTextbox.Text = String.Empty;
                                                _Home_UC.PasswordTextbox.Text = String.Empty;
                                                EmailtextBox.Text = String.Empty;

                                                _Home_UC.MusicListbox.ItemsSource = null;
                                                _Home_UC.RadioListbox.ItemsSource = null;

                                                Musics = null;
                                                RadioCollection = null;

                                                mediaPlayer.Stop();

                                                mre.Reset();
                                            }
                                        }

                                    }

                                    else
                                    {
                                        ToastNotificationWindow = new ToastNotificationWindow("You made an input error.", "../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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

                                else
                                {
                                    ToastNotificationWindow = new ToastNotificationWindow("User does not exist.", "../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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

                            else
                            {


                                var response = await ConnectionAPI.LogiIn(httpClient, _Home_UC.UsernameTextbox.Text, Password, EmailtextBox.Text, "https://localhost:7270/api/Authenticate/login", cts);

                                if (response != "[]")
                                {
                                    UserAccounts = JsonConvert.DeserializeObject<ObservableCollection<UserAccount>>(response);

                                    if (UserAccounts != null)
                                    {
                                        if (UserAccounts.Any(u => u.Username == _Home_UC.UsernameTextbox.Text && u.UserPassword == Password))
                                        {


                                            var u = UserAccounts.Where(u => u.Username == _Home_UC.UsernameTextbox.Text && u.UserPassword == Password).FirstOrDefault();

                                            _logIn = new LogIn()
                                            {
                                                IdUserAccount = u.IdUserAccount,
                                                Username = u.Username,
                                                UserPassword = u.UserPassword
                                            };





                                            _logIn.Serialize(_logIn, "../../../Asserts/Files/_logIn.json");

                                            logincheck = true;

                                            if (logincheck == true)
                                            {


                                                var f = Newtonsoft.Json.Formatting.Indented;
                                                string data = JsonConvert.SerializeObject(logincheck, f);

                                                System.IO.File.WriteAllText("../../../Asserts/Files/logincheck.json", data);

                                                timerGetMusicList.Stop();

                                                Task.Delay(1000);

                                                timerGetMusicList.Start();


                                                var response2 = await ConnectionAPI.GetMusic(httpClient, _Home_UC.UsernameTextbox.Text, Password, "https://localhost:7270/api/Authenticate/login");

                                                Musics = JsonConvert.DeserializeObject<ObservableCollection<Music>>(response2);


                                                var response3 = await ConnectionAPI.GetRadio(httpClient, _Home_UC.UsernameTextbox.Text, Password, "https://localhost:7270/api/Authenticate/login");

                                                RadioCollection = JsonConvert.DeserializeObject<ObservableCollection<Radio>>(response3);

                                                _Home_UC.MusicListbox.ItemsSource = Musics;
                                                _Home_UC.RadioListbox.ItemsSource = RadioCollection;

                                                _Home_UC.ellipsegrid.Visibility = Visibility.Visible;
                                                _Home_UC.Usernameborder.Visibility = Visibility.Hidden;
                                                _Home_UC.Passwordborder.Visibility = Visibility.Hidden;

                                                if (UserAccounts != null)
                                                {
                                                    if (UserAccounts.Any(u => u.Username == _Home_UC.UsernameTextbox.Text && u.UserPassword == Password))
                                                    {
                                                        //_ToastNotificationWindow = new ToastNotificationWindow(_Home_UC.UsernameTextbox.Text, "../../../Asserts/Images/Logo/Main logo/LOGO-ag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#03BF69"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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
                                                }
                                                if (UserAccounts == null)
                                                {
                                                    logincheck = false;



                                                    if (logincheck == false)
                                                    {
                                                        timerGetMusicList.Stop();




                                                        _Home_UC.MusicListbox.ItemsSource = null;
                                                        _Home_UC.RadioListbox.ItemsSource = null;

                                                        Musics = null;
                                                        RadioCollection = null;

                                                        mediaPlayer.Stop();

                                                        Thread.Sleep(100);
                                                        mre.Reset();
                                                    }


                                                    //_ToastNotificationWindow = new ToastNotificationWindow("Username or Password is incorrect.", "../../../Asserts/Images/Logo/Main logo/LOGO-ag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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



                                                Thread.Sleep(100);
                                                mre.Set();


                                            }
                                            if (logincheck == false)
                                            {

                                                var f = Newtonsoft.Json.Formatting.Indented;
                                                string data = JsonConvert.SerializeObject(logincheck, f);

                                                System.IO.File.WriteAllText("../../../Asserts/Files/logincheck.json", data);


                                                timerGetMusicList.Stop();
                                                _Home_UC.UsernameTextbox.Text = String.Empty;
                                                _Home_UC.PasswordTextbox.Text = String.Empty;
                                                EmailtextBox.Text = String.Empty;

                                                _Home_UC.MusicListbox.ItemsSource = null;
                                                _Home_UC.RadioListbox.ItemsSource = null;

                                                Musics = null;
                                                RadioCollection = null;

                                                mediaPlayer.Stop();

                                                mre.Reset();
                                            }

                                        }

                                    }

                                    else
                                    {
                                        ToastNotificationWindow = new ToastNotificationWindow("You made an input error.", "../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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

                                else
                                {
                                    ToastNotificationWindow = new ToastNotificationWindow("User does not exist.", "../../../Asserts/Images/Logo/Mainlogo/LOGOag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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
                        }

                        else
                        {

                            //_ToastNotificationWindow = new ToastNotificationWindow(" Passwords must have at least one non alphanumeric character., \n Passwords must have at least one digit ('0'-'9')., \n Passwords must have at least one", "../../../Asserts/Images/Logo/Main logo/LOGO-ag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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




                    }

                }




            }));
        }



        async Task LogOutAccount(string Password)
        {

            Task.Run(async () =>
            {

                _Home_UC.Dispatcher.BeginInvoke(new Action(async () =>
                {


                    using (var clientHandler = new HttpClientHandler())
                    {
                        using (var httpClient = new HttpClient(clientHandler))
                        {


                            if (PasswordValidator.IsValidPassword(Password))
                            {
                                var response = await ConnectionAPI.LogOut(httpClient, _Home_UC.UsernameTextbox.Text, Password, EmailtextBox.Text, "https://localhost:7270/api/Authenticate/logout");


                                logincheck = false;



                                if (logincheck == false)
                                {

                                    var f = Newtonsoft.Json.Formatting.Indented;
                                    string data = JsonConvert.SerializeObject(logincheck, f);

                                    System.IO.File.WriteAllText("../../../Asserts/Files/logincheck.json", data);

                                    timerGetMusicList.Stop();



                                    mediaPlayer.Stop();


                                    file = new File();
                                    file.Serialize(file, "../../../Asserts/Files/file.json");
                                    file = await file.DeSerialize("../../../Asserts/Files/file.json");

                                    Musics = null;
                                    RadioCollection = null;

                                    _Home_UC.MusicListbox.ItemsSource = null;
                                    _Home_UC.RadioListbox.ItemsSource = null;
                                    _Home_UC.RadioListbox.Items.Clear();
                                    _Home_UC.MusicListbox.Items.Clear();

                                    cts.Cancel();

                                    Thread.Sleep(100);
                                    mre.Reset();

                                    _Home_UC.ellipsegrid.Visibility = Visibility.Collapsed;
                                    _Home_UC.Usernameborder.Visibility = Visibility.Visible;
                                    _Home_UC.Passwordborder.Visibility = Visibility.Visible;

                                    //_ToastNotificationWindow = new ToastNotificationWindow(" Passwords must have at least one non alphanumeric character., \n Passwords must have at least one digit ('0'-'9')., \n Passwords must have at least one", "../../../Asserts/Images/Logo/Main logo/LOGO-ag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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
                            }
                            else
                            {
                                //_ToastNotificationWindow = new ToastNotificationWindow(" Passwords must have at least one non alphanumeric character., \n Passwords must have at least one digit ('0'-'9')., \n Passwords must have at least one", "../../../Asserts/Images/Logo/Main logo/LOGO-ag.png", (Color)System.Windows.Media.ColorConverter.ConvertFromString("#861B2D"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"), sizecount);
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



                        }

                    }




                }));

            });
        }




    }


}
