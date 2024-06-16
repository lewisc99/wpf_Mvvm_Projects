using AdvancedMVVMExample.Commands;
using AdvancedMVVMExample.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdvancedMVVMExample.ViewModel
{
    public class CalculationViewModel : INotifyPropertyChanged
    {
        private CalculationModel _calculationModel;

        public CalculationViewModel()
        {
            _calculationModel = new CalculationModel();
            CalculateCommand = new RelayCommand(Calculate);
        }

        public double Input1
        {
            get => _calculationModel.Input1;
            set
            {
                if (_calculationModel.Input1 != value)
                {
                    _calculationModel.Input1 = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Input2
        {
            get => _calculationModel.Input2;
            set
            {
                if (_calculationModel.Input2 != value)
                {
                    _calculationModel.Input2 = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Result
        {
            get => _calculationModel.Result;
            private set
            {
                if (_calculationModel.Result != value)
                {
                    _calculationModel.Result = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CalculateCommand { get; }

        private void Calculate(object parameter)
        {
            Result = Input1 + Input2;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
