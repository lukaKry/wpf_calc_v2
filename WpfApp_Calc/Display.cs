using System;
using System.ComponentModel;

namespace WpfApp_Calc
{
    public class Display : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                PropertyChanged?.Invoke(this, new(nameof(Content)));
            }
        }


        public void AddToDisplay(string input)
        {
            Content += input;
        }

        public void ClearDisplay()
        {
            Content = "";
        }

        public void ChangeDisplay(string input)
        {
            Content = input;
        }
    }
}