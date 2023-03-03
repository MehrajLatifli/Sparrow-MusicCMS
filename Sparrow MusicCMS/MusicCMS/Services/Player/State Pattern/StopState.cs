using MusicCMS.Models.Data;
using MusicCMS.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MusicCMS.Services.Player.State_Pattern
{
    public class StopState : IState
    {
        MediaPlayer MediaPlayer { get; set; }
        public StopState(MediaPlayer mediaPlayer)
        {
            MediaPlayer = mediaPlayer;
        }

        public void PlayButton(MediaPlayer mediaPlayer, ObservableCollection<Music> List, Player_UC mainWindow)
        {

            MessageBox.Show($"StopState can not control Play");
        }


        public void PauseButton(MediaPlayer mediaPlayer, ObservableCollection<Music> List, Player_UC mainWindow)
        {
            MessageBox.Show($"StopState can not control Pause");
        }

        public void StopButton(MediaPlayer mediaPlayer, ObservableCollection<Music> List, Player_UC mainWindow)
        {
            MediaPlayer.Stop();
        }

        public void AddButton(MediaPlayer mediaPlayer, string location, Player_UC mainWindow)
        {
            MessageBox.Show($"StopState can not control Add");
        }

        public void TimePlayer(MediaPlayer mediaPlayer, TimeSpan timeSpan, Player_UC mainWindow)
        {
            MessageBox.Show($"StopState can not control Time");
        }

        public void PreviousButton(MediaPlayer mediaPlayer, ObservableCollection<Music> List, Player_UC mainWindow)
        {
            MessageBox.Show($"StopState can not control Previous");
        }

        public void NextButton(MediaPlayer mediaPlayer, ObservableCollection<Music> List, Player_UC mainWindow)
        {
            MessageBox.Show($"StopState can not control Next");
        }

        public void VolumeSet(MediaPlayer mediaPlayer, TimeSpan timeSpan, Player_UC mainWindow)
        {
            MessageBox.Show($"StopState can not control Volume");
        }
    }
}
