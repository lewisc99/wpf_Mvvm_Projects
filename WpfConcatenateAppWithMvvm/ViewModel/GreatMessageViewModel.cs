using System;
using System.ComponentModel;
using System.Windows.Input;
using WpfConcatenateAppWithMvvm.Commands;
using WpfConcatenateAppWithMvvm.Models;

namespace WpfConcatenateAppWithMvvm.ViewModel
{
    public class GreatMessageViewModel : INotifyPropertyChanged
    {
        private GreatMessage _model;

        public string Input1
        {
            get { return _model.Input1; }
            set
            {
                _model.Input1 = value;
                OnPropertyChanged(nameof(Input1));
                OnPropertyChanged(nameof(CanGenerateMessage)); // Update button enable/disable state
            }
        }

        public string Input2
        {
            get { return _model.Input2; }
            set
            {
                _model.Input2 = value;
                OnPropertyChanged(nameof(Input2));
                OnPropertyChanged(nameof(CanGenerateMessage)); // Update button enable/disable state
            }
        }

        public string ConcatenatedMessage
        {
            get { return _model.ConcatenatedMessage; }
            set { _model.ConcatenatedMessage = value; OnPropertyChanged(nameof(ConcatenatedMessage)); }
        }

        public bool CanGenerateMessage => !string.IsNullOrEmpty(Input1) && !string.IsNullOrEmpty(Input2);

        public ICommand GenerateMessageCommand { get; }

        public GreatMessageViewModel()
        {
            _model = new GreatMessage();
            GenerateMessageCommand = new RelayCommand(GenerateMessage);
        }

        private void GenerateMessage()
        {
            ConcatenatedMessage = String.Concat("Your great message: ", Input1, " ", Input2);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
