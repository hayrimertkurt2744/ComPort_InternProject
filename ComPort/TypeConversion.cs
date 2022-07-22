using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPort
{
    class TypeConversion
    {
        public string currentConversionType;
        public enum DataType 
        {
            Hex,
            Ascii,
            Binary
        }
        public enum PreviousDataType 
        {
            Hex,
            Ascii,
            Binary
        }
        public DataType dataType;
        public PreviousDataType previousDataType =PreviousDataType.Ascii;

        public string FormatReceivedData(string dataIn)
        {
            int i = (int)dataType;
            switch (i)
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


        public string FormatSendingData(string _dataOut )
        {
            string _sendTypeController = previousDataType.ToString();

            try
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
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid type");
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
        public string ConvertToBinary(string _DataOut) 
        {
            
            string _previousType = previousDataType.ToString();

            if (_previousType == "Binary")
            {
                //_previousType = "Binary";
                previousDataType = PreviousDataType.Binary;

            }
            else if (_previousType == "Hex")
            {
                string hex = _DataOut;
                String ascii = "";
                for (int i = 0; i < hex.Length; i += 2)
                {
                    String part = hex.Substring(i, 2);
                    char ch = (char)Convert.ToInt32(part, 16); ;
                    ascii = ascii + ch;
                }
                byte[] da = Encoding.Default.GetBytes(ascii);
                string formattedDataIn = string.Join("  ", da.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
                _DataOut = formattedDataIn;
                //_previousType = "Binary";
                previousDataType = PreviousDataType.Binary;
            }
            else if (_previousType == "Ascii")
            {
                byte[] da = Encoding.Default.GetBytes(_DataOut);
                string formattedDataIn = string.Join("  ", da.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
                _DataOut = formattedDataIn;
                //_previousType = "Binary";
                previousDataType = PreviousDataType.Binary;
            }
            //_previousType = "Binary";
            previousDataType = PreviousDataType.Binary;
            //currentConversionType = _previousType;
            
            return _DataOut;
            

        }
        public string ConvertToAscii(string _DataOut) 
        {
            string _previousType = previousDataType.ToString();
           
            if (_previousType == "Ascii")
            {
                //_previousType = "Ascii";
                previousDataType = PreviousDataType.Ascii;
            }
            else if (_previousType == "Hex")
            {
                string hex = _DataOut;

                String ascii = "";
                for (int i = 0; i < hex.Length; i += 2)
                {
                    String part = hex.Substring(i, 2);
                    char ch = (char)Convert.ToInt32(part, 16); ;
                    ascii = ascii + ch;
                }
                _DataOut = ascii;
                //_previousType = "Ascii";
                previousDataType = PreviousDataType.Ascii;

            }
            else if (_previousType == "Binary")
            {
                _DataOut = BinaryToASCII(_DataOut);

                //_previousType = "Ascii";
                previousDataType = PreviousDataType.Ascii;
            }
            return _DataOut;


        }

        public string ConvertToHex(string _DataOut)
        {
            string _previousType = previousDataType.ToString();

            if (_previousType == "Hex")
            {
                Console.WriteLine("same type");
                previousDataType = PreviousDataType.Hex;

            }
            else if (_previousType == "Ascii")
            {
                byte[] ba = Encoding.Default.GetBytes(_DataOut);
                var hexString = BitConverter.ToString(ba);
                hexString = hexString.Replace("-", "");
                _DataOut = hexString;
                previousDataType = PreviousDataType.Hex;
            }
            else if (_previousType == "Binary")
            {

                string dataAscii = BinaryToASCII(_DataOut);

                byte[] ba = Encoding.Default.GetBytes(dataAscii);
                var hexString = BitConverter.ToString(ba);
                hexString = hexString.Replace("-", "");
                _DataOut = hexString;
                previousDataType = PreviousDataType.Hex;

            }
            
            return _DataOut;


        }

    }
}
