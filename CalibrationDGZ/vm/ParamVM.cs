using modus.Common.UtilBox;
using modus.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CalibrationDGZ.vm
{
    public class ParamVM : BaseVM
    {

        private string? _COMx;
        public string? COMx
        {
            get => _COMx;
            set
            {
                if (value != _COMx)
                {
                    _COMx = value;
                    OnPropertyChanged();
                }
            }
        }
        private string? _BaudRate;
        public string? BaudRate
        {
            get => _BaudRate;
            set
            {
                if (value != _BaudRate)
                {
                    _BaudRate = SUse.MatchUInt(value) ? value : _BaudRate;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<string>? _ItemsSourceDataBit;
        public ObservableCollection<string>? ItemsSourceDataBit
        {
            get => _ItemsSourceDataBit;
            set
            {
                if (value != _ItemsSourceDataBit)
                {
                    _ItemsSourceDataBit = value;
                    OnPropertyChanged();
                }
            }
        }
        private string? _SelectedItemDataBit;
        public string? SelectedItemDataBit
        {
            get => _SelectedItemDataBit;
            set
            {
                if (value != _SelectedItemDataBit)
                {
                    _SelectedItemDataBit = value;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<string>? _ItemsSourceStopBit;
        public ObservableCollection<string>? ItemsSourceStopBit
        {
            get => _ItemsSourceStopBit;
            set
            {
                if (value != _ItemsSourceStopBit)
                {
                    _ItemsSourceStopBit = value;
                    OnPropertyChanged();
                }
            }
        }
        private string? _SelectedItemStopBit;
        public string? SelectedItemStopBit
        {
            get => _SelectedItemStopBit;
            set
            {
                if (value != _SelectedItemStopBit)
                {
                    _SelectedItemStopBit = value;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<string>? _ItemsSourceParity;
        public ObservableCollection<string>? ItemsSourceParity
        {
            get => _ItemsSourceParity;
            set
            {
                if (value != _ItemsSourceParity)
                {
                    _ItemsSourceParity = value;
                    OnPropertyChanged();
                }
            }
        }
        private string? _SelectedItemParity;
        public string? SelectedItemParity
        {
            get => _SelectedItemParity;
            set
            {
                if (value != _SelectedItemParity)
                {
                    _SelectedItemParity = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _CalibrationIsOn;
        public bool CalibrationIsOn
        {
            get => _CalibrationIsOn;
            set
            {
                if (value != _CalibrationIsOn)
                {
                    _CalibrationIsOn = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool _Leg1IsOn;
        public bool Leg1IsOn
        {
            get => _Leg1IsOn;
            set
            {
                if (value != _Leg1IsOn)
                {
                    _Leg1IsOn = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool _Leg2IsOn;
        public bool Leg2IsOn
        {
            get => _Leg2IsOn;
            set
            {
                if (value != _Leg2IsOn)
                {
                    _Leg2IsOn = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool _Leg3IsOn;
        public bool Leg3IsOn
        {
            get => _Leg3IsOn;
            set
            {
                if (value != _Leg3IsOn)
                {
                    _Leg3IsOn = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool _Leg4IsOn;
        public bool Leg4IsOn
        {
            get => _Leg4IsOn;
            set
            {
                if (value != _Leg4IsOn)
                {
                    _Leg4IsOn = value;
                    OnPropertyChanged();
                }
            }
        }
        private byte _dX;
        public byte dX
        {
            get => _dX;
            set
            {
                if (value != _dX)
                {
                    _dX = value;
                    OnPropertyChanged();
                }
            }
        }
        private byte _dY;
        public byte dY
        {
            get => _dY;
            set
            {
                if (value != _dY)
                {
                    _dY = value;
                    OnPropertyChanged();
                }
            }
        }
        private byte _dZ;
        public byte dZ
        {
            get => _dZ;
            set
            {
                if (value != _dZ)
                {
                    _dZ = value;
                    OnPropertyChanged();
                }
            }
        }
        private byte _dVX;
        public byte dVX
        {
            get => _dVX;
            set
            {
                if (value != _dVX)
                {
                    _dVX = value;
                    OnPropertyChanged();
                }
            }
        }
        private byte _dVY;
        public byte dVY
        {
            get => _dVY;
            set
            {
                if (value != _dVY)
                {
                    _dVY = value;
                    OnPropertyChanged();
                }
            }
        }

        private byte _dWZ;
        public byte dWZ
        {
            get => _dWZ;
            set
            {
                if (value != _dWZ)
                {
                    _dWZ = value;
                    OnPropertyChanged();
                }
            }
        }

        private ICommand? SaveBtn;
        public ICommand? SaveBtnCommand
        {
            get
            {
                return SaveBtn ??= new RelayCommand(param => SaveCmd());
            }
        }
        public ParamVM()
        {
            COMx = "COM1";
            BaudRate = "115200";
            ItemsSourceDataBit = new ObservableCollection<string> { "5", "6", "7", "8" };
            SelectedItemDataBit = "8";
            ItemsSourceStopBit = new ObservableCollection<string> { "1", "1.5", "2" };
            SelectedItemStopBit = "1";
            ItemsSourceParity = new ObservableCollection<string> { "None", "Odd", "Even", "Mark", "Space" };
            SelectedItemParity = "None";
            CalibrationIsOn = false;
            Leg1IsOn = false;
            Leg2IsOn = false;
            Leg3IsOn = false;
            Leg4IsOn = false;
            dX = 0x80;
            dY = 0x80;
            dZ = 0x80;
            dVX = 0x80;
            dVY = 0x80;
            dWZ = 0x80;
        }
        private void SaveCmd()
        {
            throw new NotImplementedException();
        }
        protected override void Second()
        {

        }
    }
}
