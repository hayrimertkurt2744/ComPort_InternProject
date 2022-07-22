using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPort
{
    public class SerialCommunications
    {
       
        public SerialPort serialPort;
        public string[] ports;
        public string dataFormat;
        List<int> dataBuffer = new List<int>();

        public event EventHandler<string> dataReceivedEventHandler;
        

        public SerialCommunications(string _PortName, string _BaudRate, string _DataBits, string _StopBitsText, string _ParityText)//constructor
        {
                serialPort = new SerialPort();
           
                serialPort.DataReceived += DataReceivedFunction;
                serialPort.PortName = _PortName;
                serialPort.BaudRate = Convert.ToInt32(_BaudRate);
                serialPort.DataBits = Convert.ToInt32(_DataBits);
                serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _StopBitsText);
                serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), _ParityText);

           
           

        }

        public void DataReceivedFunction(object sender, SerialDataReceivedEventArgs e)
        {
            string readData = serialPort.ReadExisting();
            
            
            dataReceivedEventHandler.Invoke(this,readData);
        }

        public void OpenPort()
        {
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }
        }
        public void ClosePort()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
        public void SendData(string DataOUT) 
        {

            if (serialPort.IsOpen)
            {
                serialPort.Write(DataOUT);
            }

        }

        public static string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }

        

    }
    
}
