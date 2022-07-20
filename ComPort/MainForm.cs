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
        public MainForm()
        {
            InitializeComponent();

            cBoxCOMPort.Items.Clear();
            cBoxCOMPort.Items.AddRange(SerialCommunications.GetPortNames());
            if(cBoxCOMPort.Items.Count != 0)
                cBoxCOMPort.SelectedIndex = 0;

            cBoxSendFormat.SelectedIndex = 0;
            cBoxReceiveFormat.SelectedIndex = 0;

            comm = new SerialCommunications(cBoxCOMPort.Text, cBoxBaudRate.Text, cBoxDataBit.Text, cBoxStopBit.Text, cBoxParityBit.Text,cBoxReceiveFormat.Text);

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            //comm.PortSettingsHandler(cBoxCOMPort.Text, cBoxBaudRate.Text, cBoxDataBit.Text, cBoxStopBit.Text, cBoxParityBit.Text);
            comm.dataReceivedEventHandler += ShowData;
            comm.OpenPort();
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
            int[] dataInDec = comm.TakeDataBufferInDec();

            string dataInFormatted = comm.DataFormat(dataInDec, cBoxReceiveFormat.Text);

            MessageBox.Show(dataInFormatted);
            MessageBox.Show(dataIn);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            buttonClose.Enabled = false;
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            
            comm.SendData(tBoxDataOut.Text);
           
        }

        
    }
}
