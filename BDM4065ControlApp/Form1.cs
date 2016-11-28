namespace BDM4065ControlApp
{
    using Gma.System.MouseKeyHook;
    using System;
    using System.IO.Ports;
    using System.Threading;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private byte[] msgHeader = new byte[] { 0xA6, 0x01, 0x00, 0x00, 0x00 };

        private SerialPort comPort;

        private PowerState powerState = PowerState.Off;
        private InputSourceNumber currentSource = InputSourceNumber.VGA;
        private byte volume = 0;
        private IKeyboardMouseEvents m_GlobalHook;
        public Boolean closable = false;

        public void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyUp += GlobalHookKeyUp;
        }
  
        public void Unsubscribe()
        {
            m_GlobalHook.KeyUp -= GlobalHookKeyUp;
            m_GlobalHook.Dispose();
        }

        private void GlobalHookKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add: //Volume Up
                    if (VolumeUpDown.Maximum > VolumeUpDown.Value + 5) {
                        VolumeUpDown.Value = VolumeUpDown.Value + 5;
                        this.SetVolume((byte)VolumeUpDown.Value);
                    } else {
                        this.SetVolume((byte)100);
                    }
                    break;
                case Keys.Subtract: //Volume Down
                    if (VolumeUpDown.Minimum < VolumeUpDown.Value - 5)
                    {
                        VolumeUpDown.Value = VolumeUpDown.Value - 5;
                        this.SetVolume((byte)VolumeUpDown.Value);
                    } else {
                        this.SetVolume((byte)0);
                    }
                    break;
                case Keys.NumPad0: //Power Toggle
                    if (powerState == PowerState.Off) {this.SetPowerState(PowerState.On);} else {this.SetPowerState(PowerState.Off);}
                    break;
                case Keys.NumPad1: //VGA
                    this.SetInputSource(InputSourceType.VGA, InputSourceNumber.VGA);
                    break;
                case Keys.NumPad2: //DP
                    this.SetInputSource(InputSourceType.DisplayPort, InputSourceNumber.DP);
                    break;
                case Keys.NumPad3: //MiniDP
                    this.SetInputSource(InputSourceType.DisplayPort, InputSourceNumber.miniDP);
                    break;
                case Keys.NumPad4: //HDMI
                    this.SetInputSource(InputSourceType.HDMI, InputSourceNumber.HDMI);
                    break;
                case Keys.NumPad5: //HDMI
                    this.SetInputSource(InputSourceType.HDMI, InputSourceNumber.MHLHDMI2);
                    break;
            }
        }

        public Form1()
        {
            this.InitializeComponent();
            var timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(this.RefreshTick);
            timer.Interval = 5000; // 5 seconds
            timer.Start();
        }

        private enum MessageSet : byte
        {
            SerialCodeGet = 0x15,
            PowerStateSet = 0x18,
            PowerStateGet = 0x19,
            VolumeSet = 0x44,
            VolumeGet = 0x45,
            InputSourceSet = 0xAC,
            CurrentSourceGet = 0xAD,
        }

        private enum PowerState : byte
        {
            Off = 0x01,
            On = 0x02,
        }

        private enum InputSourceType : byte
        {
            Video = 0x01,
            SVideo = 0x02,
            DVDHD = 0x03,
            RGBHV = 0x04,
            VGA = 0x05,
            HDMI = 0x06,
            DVI = 0x07,
            CardOPS = 0x08,
            DisplayPort = 0x09
        }

        private enum InputSourceNumber : byte
        {
            VGA = 0x00,
            DVI = 0x01,
            HDMI = 0x02,
            MHLHDMI2 = 0x03,
            DP = 0x04,
            miniDP = 0x05,
        }

        private void RefreshTick(object sender, EventArgs e)
        {
           this.RefreshData();
        }

        private int SendMessage(byte[] msgData, ref byte[] msgReport)
        {
            msgReport = null;

            byte[] msg = new byte[this.msgHeader.Length + msgData.Length];
            System.Buffer.BlockCopy(this.msgHeader, 0, msg, 0, this.msgHeader.Length);

            System.Buffer.BlockCopy(msgData, 0, msg, this.msgHeader.Length, msgData.Length);
            msg[msg.Length - 1] = this.CheckSum(msg);
            try
            {
                this.comPort.Write(msg, 0, msg.Length);
                Thread.Sleep(50);
                if (this.comPort.BytesToRead > 0)
                {
                    byte[] responseMsg = new byte[this.comPort.BytesToRead];
                    this.comPort.Read(responseMsg, 0, this.comPort.BytesToRead);
                    if (this.CheckSum(responseMsg) == responseMsg[responseMsg.Length - 1])
                    {
                        msgReport = new byte[responseMsg[4] - 2];
                        System.Buffer.BlockCopy(responseMsg, 6, msgReport, 0, responseMsg[4] - 2);
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 2;
                }
            }
            catch
            {
                return 2;
            }

        }

        private byte CheckSum(byte[] msg)
        {
            byte hashValue = 0;
            for (int i = 0; i < msg.Length - 1; i++)
            {
                hashValue ^= msg[i];
            }
            return hashValue;
        }

        private int SetInputSource(InputSourceType sourceType, InputSourceNumber sourceNumber)
        {
            byte[] msgData = new byte[] 
            { 
                0x07, 
                0x01, 
                (byte)MessageSet.InputSourceSet, 
                (byte)sourceType, 
                (byte)sourceNumber, 
                0x01, 
                0x00, 
                0x00
            };

            byte[] responseData = null;

            if (this.SendMessage(msgData, ref responseData) == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private int GetCurrentSource()
        {
            byte[] msgData = new byte[] 
            { 
                0x03, 
                0x01, 
                (byte)MessageSet.CurrentSourceGet, 
                0x00
            };

            byte[] msgReport = null;

            if (this.SendMessage(msgData, ref msgReport) == 0)
            {
                this.currentSource = (InputSourceNumber)msgReport[2];

                return 0;
            }
            else
            {
                return 1;
            }
        }

        private int GetVolume()
        {
            byte[] msgData = new byte[] 
            { 
                0x03, 
                0x01, 
                (byte)MessageSet.VolumeGet, 
                0x00
            };

            byte[] msgReport = null;

            if (this.SendMessage(msgData, ref msgReport) == 0)
            {
                this.volume = msgReport[1];
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private int GetPowerState()
        {
            byte[] msgData = new byte[] 
            { 
                0x03, 
                0x01, 
                (byte)MessageSet.PowerStateGet, 
                0x00
            };

            byte[] msgReport = null;

            if (this.SendMessage(msgData, ref msgReport) == 0)
            {
                this.powerState = (PowerState)msgReport[1];
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args[1].Contains("COM")) {
                 comPort = new SerialPort(args[1]);
                this.comPort.BaudRate = 9600;
                this.comPort.DataBits = 8;
                this.comPort.Parity = Parity.None;
                this.comPort.StopBits = StopBits.One;
                this.comPort.Handshake = Handshake.None;
                this.comPort.ReadTimeout = 100;
                try
                {
                    this.comPort.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid COM Port");
                }
                
            } else
            {
                MessageBox.Show("Add desired COM port as command line argument");
                closable = true;
                Application.Exit();
            }
            this.RefreshData();
            Subscribe();
            this.Opacity = 0;
            ShowInTaskbar = false;
        }

        private void RefreshData()
        {
            PowerStateGroupBox.Enabled = this.GetPowerState() == 0;
            PowerStateOffButton.Enabled = this.powerState != PowerState.Off;
            PowerStateOnButton.Enabled = this.powerState != PowerState.On;
            VolumeGroupBox.Enabled = this.GetVolume() == 0;
            VolumeUpDown.Value = this.volume;
        }

        private void PowerStateOffButton_Click(object sender, EventArgs e)
        {
            PowerStateOffButton.Enabled = false;
            this.SetPowerState(PowerState.Off);
        }

        private void PowerStateOnButton_Click(object sender, EventArgs e)
        {
            PowerStateOnButton.Enabled = false;
            this.SetPowerState(PowerState.On);
        }

        private int SetPowerState(PowerState powerState)
        {
            byte[] msgData = new byte[] 
            { 
                0x04, 
                0x01, 
                (byte)MessageSet.PowerStateSet, 
                (byte)powerState, 
                0x00
            };

            byte[] responseData = null;

            if (this.SendMessage(msgData, ref responseData) == 0)
            {
                Thread.Sleep(250);

                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void VolumeResetButton_Click(object sender, EventArgs e)
        {
            this.SetVolume(30);
        }

        private int SetVolume(byte volume)
        {
            byte[] msgData = new byte[]
            {
                0x04,
                0x01,
                (byte)MessageSet.VolumeSet,
                volume,
                0x00
            };

            byte[] responseData = null;

            if (this.SendMessage(msgData, ref responseData) == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void VolumeUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.SetVolume((byte)VolumeUpDown.Value);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Opacity = 1;
            this.ShowInTaskbar = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closable = true;
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closable == false) {
                this.Opacity = 0;
                ShowInTaskbar = false;
                e.Cancel = true;
            }
        }
    }
}
 