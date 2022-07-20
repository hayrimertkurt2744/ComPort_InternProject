using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;



namespace ComPort
{

    public class SerialCom
    {
        public string[] portNames = SerialPort.GetPortNames();
        public SerialPort _serialPort1 = new SerialPort();
        public string _dataIN;
        public string dataInFormatted;
        public int dataINLength;
        public bool dataInAlwaysUpdate;
        public bool dataInAddToOldData;


        public void OpenPort(string _PortName,string _BaudRate,string _DataBits,string _StopBitsText,string _ParityText)
        {
            _serialPort1.PortName = _PortName;
            _serialPort1.BaudRate = Convert.ToInt32(_BaudRate);
            _serialPort1.DataBits = Convert.ToInt32(_DataBits);
            _serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _StopBitsText);
            _serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), _ParityText);

           

            _serialPort1.Open();

        }
        public void ClosePort()
        {
            
          _serialPort1.Close();
            
            
        }
        public  void OnFormLoad() 
        {
            _serialPort1.DtrEnable = false;
            _serialPort1.RtsEnable = false;
        }
        public void SendData(string dataOUT,bool _sendWithWrite) 
        {
            if (_serialPort1.IsOpen)
            {
                if (_sendWithWrite == false)
                {
                    _serialPort1.WriteLine(dataOUT);

                }
                else if (_sendWithWrite == true)
                {
                    _serialPort1.Write(dataOUT);
                }
            }
        }
        public void DtrHandler(bool checkBoxValue) 
        {
            if (checkBoxValue)
            {
                _serialPort1.DtrEnable = true;
            }
            else
            {
                _serialPort1.DtrEnable = false;
            }
        }
        public void RtsHandler(bool checkBoxValue)
        {
            if (checkBoxValue)
            {
                _serialPort1.RtsEnable = true;
            }
            else
            {
                _serialPort1.RtsEnable = false;
            }
        }
        public void DataReceive(string dataIN,bool isAlwaysUpdate,bool isAddToOldData) 
        {

            _dataIN = _serialPort1.ReadExisting();
            dataIN= string.Format("{0:00}", dataINLength);
            

        }
        
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e) 
        {
            _dataIN = _serialPort1.ReadExisting();
            _serialPort1.DataReceived += new SerialDataReceivedEventHandler(ShowData);
           
        }
        private void ShowData(object sender, EventArgs e)
        {
            int dataINLength = _dataIN.Length;
            dataInFormatted = string.Format("{0:00}", dataINLength);

            if (dataInAlwaysUpdate)
            {
                dataInFormatted = _dataIN;
            }
            else if(dataInAddToOldData)
            {
                dataInFormatted += _dataIN;
            }
        }

    }
   
   
}
   
