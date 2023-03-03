using MusicCMS.Models;
using MusicCMS.Models.Data;
using MusicCMS.Services.Player.State_Pattern;
using MusicCMS.ViewModels;
using MusicCMS.Views.Helper_Views.Notification_Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MusicCMS.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Player_UC.xaml
    /// </summary>
    public partial class Player_UC : UserControl
    {
        DispatcherTimer timer = new DispatcherTimer();

        Player_UCViewModel vm { get; set; }


        string IdFile_ { get; set; }

        Playerwork _playerwork { get; set; }

        bool logincheck { get; set; }

        public Player_UC()
        {

              vm = new Player_UCViewModel() { _Player_UC = this };


            _playerwork=new Playerwork();


            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
            timer.Start();

            this.DataContext = vm;



            InitializeComponent();
        }

        private async void Timer_Tick(object? sender, EventArgs e)
        {
            if (_playerwork != null)
            {
                


            _playerwork = await _playerwork.DeSerialize("../../../Asserts/Files/player.json");

       

                string data2 = System.IO.File.ReadAllText("../../../Asserts/Files/logincheck.json");
                logincheck = JsonConvert.DeserializeObject<bool>(data2);

                if (logincheck == false)
                {
                    vm.mediaPlayer.Stop();
                        vm.mediaPlayer=new MediaPlayer();
                    vm.nextpreviouscount = 0;
                }

                if (_playerwork != null)
                {
                    if (_playerwork.playerstatus == true)
                    {
                        if (logincheck == true)
                        {

                           await vm.PlayMusic();

                            await vm.PlayRadio();


                            //if ((vm != null) && (vm.PlayPauseMusicCommand.CanExecute(null)))
                            //{

                            //    vm.PlayPauseMusicCommand.Execute(null);
                            //}
                        }


                    }
                }

            }

        }


    }
}
