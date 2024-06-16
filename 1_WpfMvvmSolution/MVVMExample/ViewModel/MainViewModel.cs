using MVVMExample.Commands;
using MVVMExample.Model;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MVVMExample.ViewModel
{
    public class MainViewModel : INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private MessageModel _messageModel;

        public ICommand UpdateMessageCommand { get; }

        public MainViewModel()
        {
            _messageModel = new MessageModel { Message = "Hello, World!" };
            UpdateMessageCommand = new RelayCommand(UpdateMessage);
        }

        public string Message
        {
            get => _messageModel.Message;
            set
            {
                if (_messageModel.Message != value)
                {
                    _messageModel.Message = value;
                    OnPropertyChanged();
                }
            }
        }

        private void UpdateMessage(object parameter)
        {
            Message = "Button Clicked!";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
