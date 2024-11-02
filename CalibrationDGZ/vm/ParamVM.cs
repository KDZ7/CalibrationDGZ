using CalibrationDGZ.m;
using modus.Common.UtilBox;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Windows;
using System.Windows.Input;

namespace CalibrationDGZ.vm
{
    public class ParamVM : BaseVM
    {

        private SerialPort? _SerialPort;

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
        private bool _ConnectedIsOn;
        public bool ConnectedIsOn
        {
            get => _ConnectedIsOn;
            set
            {
                if (value != _ConnectedIsOn)
                {
                    _ConnectedIsOn = value;
                    OnPropertyChanged();
                    if (_ConnectedIsOn)
                        initSerialPort();
                    else if (_SerialPort != null && _SerialPort.IsOpen)
                        _SerialPort.Close();
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
                    Send(0x04, value ? (byte)0x01 : (byte)0x00);
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
                    Send(0x20, value ? (byte)0x21 : (byte)0x11);
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
                    Send(0x20, value ? (byte)0x22 : (byte)0x12);
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
                    Send(0x20, value ? (byte)0x23 : (byte)0x13);
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
                    Send(0x20, value ? (byte)0x24 : (byte)0x14);
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
                    Send(0x33, value);
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
                    Send(0x34, value);
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
                    Send(0x35, value);
                }
            }
        }
        private byte _dRX;
        public byte dRX
        {
            get => _dRX;
            set
            {
                if (value != _dRX)
                {
                    _dRX = value;
                    OnPropertyChanged();
                    Send(0x36, value);
                }
            }
        }
        private byte _dRY;
        public byte dRY
        {
            get => _dRY;
            set
            {
                if (value != _dRY)
                {
                    _dRY = value;
                    OnPropertyChanged();
                    Send(0x37, value);
                }
            }
        }
        private byte _dRZ;
        public byte dRZ
        {
            get => _dRZ;
            set
            {
                if (value != _dRZ)
                {
                    _dRZ = value;
                    OnPropertyChanged();
                    Send(0x38, value);
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
                    Send(0x30, value);
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
                    Send(0x31, value);
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
                    Send(0x32, value);
                }
            }
        }

        private byte _ServoID11;
        public byte ServoID11
        {
            get => _ServoID11;
            set
            {
                if (value != _ServoID11)
                {
                    _ServoID11 = value;
                    OnPropertyChanged();
                    Send(0x50, value);
                }
            }
        }
        private byte _ServoID12;
        public byte ServoID12
        {
            get => _ServoID12;
            set
            {
                if (value != _ServoID12)
                {
                    _ServoID12 = value;
                    OnPropertyChanged();
                    Send(0x51, value);
                }
            }
        }
        private byte _ServoID13;
        public byte ServoID13
        {
            get => _ServoID13;
            set
            {
                if (value != _ServoID13)
                {
                    _ServoID13 = value;
                    OnPropertyChanged();
                    Send(0x52, value);
                }
            }
        }
        private byte _ServoID21;
        public byte ServoID21
        {
            get => _ServoID21;
            set
            {
                if (value != _ServoID21)
                {
                    _ServoID21 = value;
                    OnPropertyChanged();
                    Send(0x53, value);
                }
            }
        }
        private byte _ServoID22;
        public byte ServoID22
        {
            get => _ServoID22;
            set
            {
                if (value != _ServoID22)
                {
                    _ServoID22 = value;
                    OnPropertyChanged();
                    Send(0x54, value);
                }
            }
        }
        private byte _ServoID23;
        public byte ServoID23
        {
            get => _ServoID23;
            set
            {
                if (value != _ServoID23)
                {
                    _ServoID23 = value;
                    OnPropertyChanged();
                    Send(0x55, value);
                }
            }
        }
        private byte _ServoID31;
        public byte ServoID31
        {
            get => _ServoID31;
            set
            {
                if (value != _ServoID31)
                {
                    _ServoID31 = value;
                    OnPropertyChanged();
                    Send(0x56, value);
                }
            }
        }
        private byte _ServoID32;
        public byte ServoID32
        {
            get => _ServoID32;
            set
            {
                if (value != _ServoID32)
                {
                    _ServoID32 = value;
                    OnPropertyChanged();
                    Send(0x57, value);
                }
            }
        }
        private byte _ServoID33;
        public byte ServoID33
        {
            get => _ServoID33;
            set
            {
                if (value != _ServoID33)
                {
                    _ServoID33 = value;
                    OnPropertyChanged();
                    Send(0x58, value);
                }
            }
        }
        private byte _ServoID41;
        public byte ServoID41
        {
            get => _ServoID41;
            set
            {
                if (value != _ServoID41)
                {
                    _ServoID41 = value;
                    OnPropertyChanged();
                    Send(0x59, value);
                }
            }
        }
        private byte _ServoID42;
        public byte ServoID42
        {
            get => _ServoID42;
            set
            {
                if (value != _ServoID42)
                {
                    _ServoID42 = value;
                    OnPropertyChanged();
                    Send(0x5A, value);
                }
            }
        }
        private byte _ServoID43;
        public byte ServoID43
        {
            get => _ServoID43;
            set
            {
                if (value != _ServoID43)
                {
                    _ServoID43 = value;
                    OnPropertyChanged();
                    Send(0x5B, value);
                }
            }
        }
        private ICommand? _Save;
        public ICommand? Save
        {
            get { return _Save ??= new RelayCommand(param => SaveExecute()); }
        }
        public ParamVM()
        {
            COMx = "COM6";
            BaudRate = "115200";
            ItemsSourceDataBit = new ObservableCollection<string> { "5", "6", "7", "8" };
            SelectedItemDataBit = "8";
            ItemsSourceStopBit = new ObservableCollection<string> { "0", "1", "1.5", "2" };
            SelectedItemStopBit = "1";
            ItemsSourceParity = new ObservableCollection<string> { "None", "Odd", "Even", "Mark", "Space" };
            SelectedItemParity = "None";
            ConnectedIsOn = false;
            Reset();
        }
        protected override void Second()
        {
            if (_SerialPort?.IsOpen != true)
            {
                ConnectedIsOn = false;
                Reset();
                return;
            }
        }
        private void initSerialPort()
        {
            _SerialPort = new SerialPort
            {
                PortName = COMx,
                BaudRate = int.Parse(BaudRate ?? "115200"),
                DataBits = SelectedItemDataBit switch
                {
                    "5" => 5,
                    "6" => 6,
                    "7" => 7,
                    "8" => 8,
                    _ => 8
                },
                StopBits = SelectedItemStopBit switch
                {
                    "0" => StopBits.None,
                    "1" => StopBits.One,
                    "1.5" => StopBits.OnePointFive,
                    "2" => StopBits.Two,
                    _ => StopBits.One
                },
                Parity = SelectedItemParity switch
                {
                    "None" => Parity.None,
                    "Odd" => Parity.Odd,
                    "Even" => Parity.Even,
                    "Mark" => Parity.Mark,
                    "Space" => Parity.Space,
                    _ => Parity.None
                },
                Handshake = Handshake.None,
                ReadTimeout = 500,
                WriteTimeout = 500
            };
            try
            {
                if (!_SerialPort.IsOpen)
                {
                    _SerialPort.Open();
                    Fetch();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _ConnectedIsOn = false;
            }
        }
        private void Send(byte address, byte data)
        {
            if (_SerialPort?.IsOpen != true)
                return;

            var frame = new Frame(type: 0x01, firstAddress: address, data: new byte[] { data });
            try
            {
                byte[] bufs = frame.ToArrayByte();
                _SerialPort?.Write(bufs, 0, bufs.Length);
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _ConnectedIsOn = false;
            }
        }
        private byte[] SendRead(byte address, byte data)
        {
            if (_SerialPort?.IsOpen != true)
                return new byte[0];

            var frame = new Frame(type: 0x02, firstAddress: address, data: new byte[] { data });
            try
            {
                byte[] bufs_send = frame.ToArrayByte();
                _SerialPort?.Write(bufs_send, 0, bufs_send.Length);
                Thread.Sleep(100);
                if (_SerialPort?.BytesToRead <= 0)
                    throw new TimeoutException("No response from the device");
                byte[] bufs_recv = new byte[_SerialPort!.BytesToRead];
                _SerialPort.Read(bufs_recv, 0, bufs_recv.Length);
                if (bufs_recv.Length < 8)
                    throw new InvalidOperationException("Invalid response frame length.");
                if (bufs_recv[0] != 0x55 || bufs_recv[1] != 0x00)
                    throw new InvalidOperationException("Invalid response frame header.");

                byte cchecksum = (byte)(~(bufs_recv[2] + bufs_recv[3] + bufs_recv[4] + bufs_recv.Skip(5).Take(bufs_recv.Length - 8).Sum(x => x)) & 0xFF);
                byte checksum = bufs_recv[bufs_recv.Length - 3];
                if (cchecksum != checksum)
                    throw new InvalidOperationException("Checksum mismatch.");

                return bufs_recv.Skip(5).Take(bufs_recv.Length - 8).ToArray();

            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new byte[0];
            }
        }
        private void SaveExecute()
        {
            if (_SerialPort?.IsOpen != true)
                return;
            Fetch();
            CalibrationIsOn = false;
            Send(0x21, 0x01);
        }

        private void Reset()
        {
            CalibrationIsOn = false;
            Leg1IsOn = false;
            Leg2IsOn = false;
            Leg3IsOn = false;
            Leg4IsOn = false;
            dX = 0x80;
            dY = 0x80;
            dZ = 0x80;
            dRX = 0x80;
            dRY = 0x80;
            dRZ = 0x80;
            dVX = 0x80;
            dVY = 0x80;
            dWZ = 0x80;
        }

        private void Fetch()
        {
            byte[] bufs = SendRead(0x50, 0x0C);
            if (bufs.Length < 12)
                return;
            ServoID11 = bufs[0];
            ServoID12 = bufs[1];
            ServoID13 = bufs[2];
            ServoID21 = bufs[3];
            ServoID22 = bufs[4];
            ServoID23 = bufs[5];
            ServoID31 = bufs[6];
            ServoID32 = bufs[7];
            ServoID33 = bufs[8];
            ServoID41 = bufs[9];
            ServoID42 = bufs[10];
            ServoID43 = bufs[11];
        }
    }
}
