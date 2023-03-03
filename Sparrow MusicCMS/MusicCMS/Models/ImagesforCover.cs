using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS.Models
{
    public class ImagesforCover : INotifyPropertyChanged
    {

        private string _filePath1;


        public string FilePath1 { get { return _filePath1; } set { _filePath1 = value; OnPropertyChanged(); } }



        private string _filePath2;


        public string FilePath2 { get { return _filePath2; } set { _filePath2 = value; OnPropertyChanged(); } }




        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {

                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
