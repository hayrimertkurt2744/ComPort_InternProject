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
        int sendTypeController;
        int receiveTypeController;
        //string chosenReceiverType;
        //------------------------public event EventHandler<string> dataReceiveFormatEventHandler;
        public MainForm()
        {
            InitializeComponent();

            cBoxCOMPort.Items.Clear();
            cBoxCOMPort.Items.AddRange(SerialCommunications.GetPortNames());
            if(cBoxCOMPort.Items.Count != 0)
                cBoxCOMPort.SelectedIndex = 0;

            //cBoxSendFormat.SelectedIndex = 0;
            //cBoxReceiveFormat.SelectedIndex = 2;

            comm = new SerialCommunications(cBoxCOMPort.Text, cBoxBaudRate.Text, cBoxDataBit.Text, cBoxStopBit.Text, cBoxParityBit.Text/*, cBoxReceiveFormat.Text*/);
            //comm.dataFormat = cBoxReceiveFormat.Text;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            //comm.PortSettingsHandler(cBoxCOMPort.Text, cBoxBaudRate.Text, cBoxDataBit.Text, cBoxStopBit.Text, cBoxParityBit.Text);
            
            comm.OpenPort();
            comm.dataReceivedEventHandler += ShowData;
            /*-------------------------dataReceiveFormatEventHandler += comm.DataFormat;*/
            
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
            
            tBoxDataIn.Text += FormatData(dataIn,sendTypeController);


        }

        private string FormatData(string dataIn,int _sendTypeController)
        {
            switch (_sendTypeController)
            {
                case 0:
                    Console.WriteLine("It is a hex");
                    byte[] ba = Encoding.Default.GetBytes(dataIn);
                    var hexString = BitConverter.ToString(ba);
                    //tBoxDataIn.Text += hexString;
                    dataIn = hexString;
                    return hexString;
                    break;

                case 1:
                    Console.WriteLine("It is an Ascii");
                    //tBoxDataIn.Text += dataIn;
                    break;
                case 2:
                    Console.WriteLine("It is an Binary");
                    byte[] da = Encoding.Default.GetBytes(dataIn);
                    //tBoxDataIn.Text += string.Join("  ", da.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
                    string formattedDataIn= string.Join("  ", da.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
                    dataIn = formattedDataIn;
                    break;
                default:
                    break;
                    
            }
            return dataIn;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            buttonClose.Enabled = false;

        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            
            comm.SendData(FormatData(tBoxDataOut.Text, sendTypeController));
           
        }

        private void cBoxReceiveFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Console.WriteLine("this works");

            ComboBox senderCb = (ComboBox)sender;
            string comboboxStr = senderCb.Text;

            //--------------------------dataReceiveFormatEventHandler?.Invoke(this, receiveType);
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
            sendTypeController = 0;
        }

        private void rButtonSendAscii_CheckedChanged(object sender, EventArgs e)
        {
            sendTypeController = 1;
        }

        private void rButtonSendBinary_CheckedChanged(object sender, EventArgs e)
        {
            sendTypeController = 2;
        }
    }
}
