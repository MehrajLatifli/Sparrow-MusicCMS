using MusicCMS_Admin.Models.Data;
using MusicCMS_Admin.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MusicCMS_Admin.Services.Player.State_Pattern
{
    public class Player
    {
        public IState _State { get; set; }



        public Player(IState State)
        {
            _State = State;

        }
        public void Add(MediaPlayer mediaPlayer, string location, Player_UC mainWindow)
        {
            _State.AddButton(mediaPlayer, location, mainWindow);
        }

        public void Play(MediaPlayer mediaPlayer, ObservableCollection<Music> FileList, Player_UC mainWindow)
        {

            _State.PlayButton(mediaPlayer, FileList, mainWindow);


        }

        public void Next(MediaPlayer mediaPlayer, ObservableCollection<Music> FileList, Player_UC mainWindow)
        {

            _State.PlayButton(mediaPlayer, FileList, mainWindow);


        }

        public void Previous(MediaPlayer mediaPlayer, ObservableCollection<Music> FileList, Player_UC mainWindow)
        {

            _State.PlayButton(mediaPlayer, FileList, mainWindow);


        }

        public void Pause(MediaPlayer mediaPlayer, ObservableCollection<Music> FileList, Player_UC mainWindow)
        {
            _State.PauseButton(mediaPlayer, FileList, mainWindow);
        }

        public void Stop(MediaPlayer mediaPlayer, ObservableCollection<Music> FileList, Player_UC mainWindow)
        {
            _State.StopButton(mediaPlayer, FileList, mainWindow);
        }

        public void Time(MediaPlayer mediaPlayer, TimeSpan timeSpan, Player_UC mainWindow)
        {
            _State.TimePlayer(mediaPlayer, timeSpan, mainWindow);
        }

        public void Volume(MediaPlayer mediaPlayer, TimeSpan timeSpan, Player_UC mainWindow)
        {
            _State.VolumeSet(mediaPlayer, timeSpan, mainWindow);
        }
    }
}
