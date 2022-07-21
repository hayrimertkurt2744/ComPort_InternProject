using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPort
{
    public partial class MainForm : Form
    {
        SerialCommunications comm;
        string previousType="Ascii";
        int receiveTypeController;
        public MainForm()
        {
            InitializeComponent();

            cBoxCOMPort.Items.Clear();
            cBoxCOMPort.Items.AddRange(SerialCommunications.GetPortNames());
            if(cBoxCOMPort.Items.Count != 0)
                cBoxCOMPort.SelectedIndex = 0;
            comm = new SerialCommunications(cBoxCOMPort.Text, cBoxBaudRate.Text, cBoxDataBit.Text, cBoxStopBit.Text, cBoxParityBit.Text);

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            
            comm.OpenPort();
            comm.dataReceivedEventHandler += ShowData;
            
            buttonClose.Enabled = true;
            buttonOpen.Enabled = false;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            
            comm.ClosePort();
            buttonClose.Enabled = false;
            buttonOpen.Enabled = true;
        }

        private void ShowData(object sender, string dataIn)
        {
            
            tBoxDataIn.Text += comm.FormatReceivedData(dataIn,receiveTypeController);


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            buttonClose.Enabled = false;

        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            
            comm.SendData(comm.FormatSendingData(tBoxDataOut.Text,previousType));
           
        }
        private void rButtonReceiveHex_CheckedChanged(object sender, EventArgs e)
        {
            receiveTypeController = 0;

        }

        private void rButtonReceiveAscii_CheckedChanged(object sender, EventArgs e)
        {
            receiveTypeController = 1;
        }

        private void rButtonReceiveBinary_CheckedChanged(object sender, EventArgs e)
        {
            receiveTypeController = 2;
        }


        private void rButtonSendHex_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (previousType == "Hex")
                {
                    Console.WriteLine("same type");

                }
                else if (previousType == "Ascii")
                {
                    byte[] ba = Encoding.Default.GetBytes(tBoxDataOut.Text);
                    var hexString = BitConverter.ToString(ba);
                    hexString = hexString.Replace("-", "");

                    tBoxDataOut.Text = hexString;
                }
                else if (previousType == "Binary")
                {

                    string dataAscii = BinaryToASCII(tBoxDataOut.Text);

                    byte[] ba = Encoding.Default.GetBytes(dataAscii);
                    var hexString = BitConverter.ToString(ba);
                    hexString = hexString.Replace("-", "");

                    tBoxDataOut.Text = hexString;

                }
                previousType = "Hex";
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid Conversion Type");

            }
           
        }

        private void rButtonSendAscii_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (previousType == "Ascii")
                {

                }
                else if (previousType == "Hex")
                {
                    string hex = tBoxDataOut.Text;

                    String ascii = "";
                    for (int i = 0; i < hex.Length; i += 2)
                    {
                        String part = hex.Substring(i, 2);
                        char ch = (char)Convert.ToInt32(part, 16); ;
                        ascii = ascii + ch;
                    }
                    tBoxDataOut.Text = ascii;

                }
                else if (previousType == "Binary")
                {
                    tBoxDataOut.Text= BinaryToASCII(tBoxDataOut.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Conversion Type");
                
            }
           
            previousType = "Ascii";
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


        private void rButtonSendBinary_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (previousType == "Binary")
                {
                    previousType = "Binary";
                }
                else if (previousType == "Hex")
                {
                    string hex = tBoxDataOut.Text;
                    String ascii = "";
                    for (int i = 0; i < hex.Length; i += 2)
                    {
                        String part = hex.Substring(i, 2);
                        char ch = (char)Convert.ToInt32(part, 16); ;
                        ascii = ascii + ch;
                    }
                    byte[] da = Encoding.Default.GetBytes(ascii);
                    string formattedDataIn = string.Join("  ", da.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
                    tBoxDataOut.Text = formattedDataIn;
                    previousType = "Binary";
                }
                else if (previousType == "Ascii")
                {
                    byte[] da = Encoding.Default.GetBytes(tBoxDataOut.Text);
                    string formattedDataIn = string.Join("  ", da.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
                    tBoxDataOut.Text = formattedDataIn;
                    previousType = "Binary";
                }
                previousType = "Binary";
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid Conversion Type");

            }
            
            
            
        }
        
    }
}
