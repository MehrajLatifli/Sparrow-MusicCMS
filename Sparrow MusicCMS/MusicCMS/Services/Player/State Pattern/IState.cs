using MusicCMS.Models.Data;
using MusicCMS.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MusicCMS.Services.Player.State_Pattern
{
    public interface IState
    {
        void PlayButton(MediaPlayer mediaPlayer, ObservableCollection<Music> List, Player_UC mainWindow);
        void PauseButton(MediaPlayer mediaPlayer, ObservableCollection<Music> List, Player_UC mainWindow);
        void StopButton(MediaPlayer mediaPlayer, ObservableCollection<Music> List, Player_UC mainWindow);
        void AddButton(MediaPlayer mediaPlayer, string location, Player_UC mainWindow);

        void TimePlayer(MediaPlayer mediaPlayer, TimeSpan timeSpan, Player_UC mainWindow);

        void VolumeSet(MediaPlayer mediaPlayer, TimeSpan timeSpan, Player_UC mainWindow);

        void PreviousButton(MediaPlayer mediaPlayer, ObservableCollection<Music> List, Player_UC mainWindow);

        void NextButton(MediaPlayer mediaPlayer, ObservableCollection<Music> List, Player_UC mainWindow);
    }
}
