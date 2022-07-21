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

        public string FormatReceivedData(string dataIn, int _sendTypeController)
        {
            switch (_sendTypeController)
            {
                case 0:
                    Console.WriteLine("It is a hex");
                    byte[] ba = Encoding.Default.GetBytes(dataIn);
                    var hexString = BitConverter.ToString(ba);
                    dataIn = hexString;
                    break;
                case 1:
                    Console.WriteLine("It is an Ascii");
                    break;
                case 2:
                    Console.WriteLine("It is an Binary");
                    byte[] da = Encoding.Default.GetBytes(dataIn);
                    string formattedDataIn = string.Join("  ", da.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
                    dataIn = formattedDataIn;
                    break;
                default:
                    break;

            }
            return dataIn;
        }


        public string FormatSendingData(string _dataOut, string _sendTypeController) 
        {
            if (_sendTypeController == "Hex")
            {
                string hex = _dataOut;

                String ascii = "";
                for (int i = 0; i < hex.Length; i += 2)
                {
                    String part = hex.Substring(i, 2);
                    char ch = (char)Convert.ToInt32(part, 16); ;
                    ascii = ascii + ch;
                }
                _dataOut = ascii;
            }
            else if (_sendTypeController == "Binary")
            {
                _dataOut = BinaryToASCII(_dataOut);
            }
            else if (_sendTypeController == "Ascii")
            {
                Console.WriteLine("This Workss");
            }


            return _dataOut;
        }
        public static string BinaryToASCII(string bin)
        {
            bin = bin.Replace(" ", "");
            string ascii = string.Empty;

            for (int i = 0; i < bin.Length; i += 8)
            {
                ascii += (char)BinaryToDecimal(bin.Substring(i, 8));
            }

            return ascii;
        }

        private static int BinaryToDecimal(string bin)
        {
            int binLength = bin.Length;
            double dec = 0;

            for (int i = 0; i < binLength; ++i)
            {
                dec += ((byte)bin[i] - 48) * Math.Pow(2, ((binLength - i) - 1));
            }

            return (int)dec;
        }

    }
    
}
