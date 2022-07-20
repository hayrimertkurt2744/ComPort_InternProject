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
        public int[] dataInDec;
        public int dataInLength;
        string dataFormat;

        public EventHandler<string> dataReceivedEventHandler;

        public SerialCommunications(string _PortName, string _BaudRate, string _DataBits, string _StopBitsText, string _ParityText,string _DataFormat)//constructor
        {
            serialPort = new SerialPort();
            serialPort.DataReceived += DataReceivedFunction;
            dataFormat = _DataFormat;

            serialPort.PortName = _PortName;
            serialPort.BaudRate = Convert.ToInt32(_BaudRate);
            serialPort.DataBits = Convert.ToInt32(_DataBits);
            serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _StopBitsText);
            serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), _ParityText);


        }

        private void DataReceivedFunction(object sender, SerialDataReceivedEventArgs e)
        {
            //string readData =  serialPort.ReadExisting();
            List<int> dataBuffer = new List<int>();
            while (serialPort.BytesToRead > 0) 
            {
                try
                {
                    dataBuffer.Add(serialPort.ReadByte());
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                   
                }
            }
            dataInLength = dataBuffer.Count();
            dataInDec = new int[dataInLength];
            dataInDec = dataBuffer.ToArray();
            dataReceivedEventHandler.Invoke(this, DataFormat(dataInDec,dataFormat));
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
            if (serialPort.IsOpen==true)
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
        public string DataFormat(int[] dataInput,string dataFormat) 
        {
            string strOut = "";

            if (dataFormat=="Hex")
            {
                foreach (int element in dataInput)
                {
                    strOut += Convert.ToString(element, 16) + "\t";
                }
            }
            else if(dataFormat == "Binary")
            {
                foreach (int element in dataInput)
                {
                    strOut += Convert.ToString(element, 2) + "\t";
                }
            }
            else if (dataFormat == "ASCII")
            {
                foreach (int element in dataInput)
                {
                    strOut += Convert.ToChar(element) + "\t";
                }
            }
            return strOut;
        }


    }
}
