using MusicCMS_Admin.Command;
using MusicCMS_Admin.Models;
using MusicCMS_Admin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_Admin.ViewModels
{
    public class StartViewModel : BaseViewModel
    {

        public ObservableCollection<ImagesforCover> _ImagesforCover_List { get; set; }
        public ObservableCollection<ImagesforCover> ImagesforCover_List { get { return _ImagesforCover_List; } set { _ImagesforCover_List = value; OnPropertyChanged(); } }

        private ImagesforCover _ImagesforCovers { get; set; }

        public ImagesforCover ImagesforCovers { get { return _ImagesforCovers; } set { _ImagesforCovers = value; OnPropertyChanged(); } }


        public Repo_CovertPhoto CovertPhotoRepository { get; set; }

        public RelayCommand CloseStartWindowCommand { get; set; }


        public StartWindow _StartWindow { get; set; }
        public UserPanelWindow _UserPanelWindow { get; set; }

        public UserPanelViewModel _UserPanelViewModel { get; set; }






        public StartViewModel()
        {


            CovertPhotoRepository = new Repo_CovertPhoto();
            ImagesforCover_List = new ObservableCollection<ImagesforCover>(CovertPhotoRepository.GetAll());

            ImagesforCovers = new ImagesforCover
            {
                FilePath1 = "../../Asserts/Images/Images/Logo.gif",
                FilePath2 = "../../Asserts/Images/Images/Logo.gif",

            };




            CloseStartWindowCommand = new RelayCommand((e) =>
            {
                Task.Run(() =>
                {

                    _StartWindow.Dispatcher.BeginInvoke(new Action(() =>
                    {


                        if (_StartWindow.StartProgressBar.Value == 100)
                        {
                            _StartWindow.Hide();


                            var UserPanelWindow = new UserPanelWindow();

                            _UserPanelViewModel = new UserPanelViewModel();

                            _UserPanelViewModel._UserPanelWindow = UserPanelWindow;


                            UserPanelWindow.ShowDialog();
                        }

                    }));
                });

            });

        }


    }
}
