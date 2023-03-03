using MusicCMS_Admin.Models.Data;
using MusicCMS_Admin.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace MusicCMS_Admin.Services.Player.State_Pattern
{
    public class TimeState : IState
    {
        MediaPlayer MediaPlayer { get; set; }
        public TimeState(MediaPlayer mediaPlayer)
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
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {


                mainWindow.MusicTimeText.Text = string.Format("{0}\t \t  \t  \t  \t  \t                 {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));


                mainWindow.TimeSlider.Visibility = Visibility.Visible;

                mainWindow.MusicTimeText.Visibility = Visibility.Visible;

                timeSpan = mediaPlayer.NaturalDuration.TimeSpan;

                mainWindow.TimeSlider.Minimum = 0;
                mainWindow.TimeSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                mainWindow.TimeSlider.SmallChange = 1;
                mainWindow.TimeSlider.LargeChange = Math.Min(10, timeSpan.Seconds / 10);

                mainWindow.TimeSlider.Value = mediaPlayer.Position.TotalSeconds;


            }
            else
            {

                mainWindow.TimeSlider.Visibility = Visibility.Visible;
                mainWindow.MusicTimeText.Visibility = Visibility.Hidden;

            }
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
            MessageBox.Show($"TimeState can not control Volume");
        }
    }
}
