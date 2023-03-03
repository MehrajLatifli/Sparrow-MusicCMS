using MusicCMS_Admin.Models.Data;
using MusicCMS_Admin.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MusicCMS_Admin.Services.Player.State_Pattern
{
    public class VolumeState : IState
    {
        MediaPlayer MediaPlayer { get; set; }
        public VolumeState(MediaPlayer mediaPlayer)
        {
            MediaPlayer = mediaPlayer;
        }

        public void AddButton(MediaPlayer mediaPlayer, string location, Player_UC mainWindow)
        {
            MessageBox.Show($"TimeState can not control Add");
        }

        public void PauseButton(MediaPlayer mediaPlayer, ObservableCollection<Music> FileList, Player_UC mainWindow)
        {
            MessageBox.Show($"TimeState can not control Pause");
        }

        public void PlayButton(MediaPlayer mediaPlayer, ObservableCollection<Music> FileList, Player_UC mainWindow)
        {
            MessageBox.Show($"TimeState can not control Play");
        }

        public void StopButton(MediaPlayer mediaPlayer, ObservableCollection<Music> FileList, Player_UC mainWindow)
        {
            MessageBox.Show($"TimeState can not control Stop");
        }

        public void TimePlayer(MediaPlayer mediaPlayer, TimeSpan timeSpan, Player_UC mainWindow)
        {

            MessageBox.Show($"TimeState can not control Time");
        }

        public void PreviousButton(MediaPlayer mediaPlayer, ObservableCollection<Music> List, Player_UC mainWindow)
        {
            MessageBox.Show($"TimeState can not control Previous");
        }

        public void NextButton(MediaPlayer mediaPlayer, ObservableCollection<Music> List, Player_UC mainWindow)
        {
            MessageBox.Show($"TimeState can not control Next");
        }

        public void VolumeSet(MediaPlayer mediaPlayer, TimeSpan timeSpan, Player_UC mainWindow)
        {
            MessageBox.Show($"TimeState can not volume");
        }
    }
}
