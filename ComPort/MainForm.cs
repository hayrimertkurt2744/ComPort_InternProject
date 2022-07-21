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
        TypeConversion conversion;
        string previousType="Ascii";
        
        public MainForm()
        {
            InitializeComponent();

            cBoxCOMPort.Items.Clear();
            cBoxCOMPort.Items.AddRange(SerialCommunications.GetPortNames());
            if(cBoxCOMPort.Items.Count != 0)
                cBoxCOMPort.SelectedIndex = 0;
            comm = new SerialCommunications(cBoxCOMPort.Text, cBoxBaudRate.Text, cBoxDataBit.Text, cBoxStopBit.Text, cBoxParityBit.Text);
            conversion = new TypeConversion();

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
            
            tBoxDataIn.Text += conversion.FormatReceivedData(dataIn);


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            buttonClose.Enabled = false;

        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            
            comm.SendData(conversion.FormatSendingData(tBoxDataOut.Text,previousType));
           
        }
        private void rButtonReceiveHex_CheckedChanged(object sender, EventArgs e)
        {
            //receiveTypeController = 0;
            conversion.dataType = TypeConversion.DataType.Hex;

        }

        private void rButtonReceiveAscii_CheckedChanged(object sender, EventArgs e)
        {
            // receiveTypeController = 1;
            conversion.dataType =  TypeConversion.DataType.Ascii;
        }

        private void rButtonReceiveBinary_CheckedChanged(object sender, EventArgs e)
        {
            //receiveTypeController = 2;
            conversion.dataType =  TypeConversion.DataType.Binary;
        }


        private void rButtonSendHex_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tBoxDataOut.Text = conversion.ConvertToHex(tBoxDataOut.Text, previousType);
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
                tBoxDataOut.Text = conversion.ConvertToAscii(tBoxDataOut.Text, previousType);
                previousType = "Ascii";
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Conversion Type");
            }

        }


        private void rButtonSendBinary_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tBoxDataOut.Text = conversion.ConvertToBinary(tBoxDataOut.Text, previousType);
                previousType = "Binary";
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Conversion Type");
            }
    
        }

    }
}
