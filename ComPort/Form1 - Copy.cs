using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ComPort
{
    
    public partial class Form1 : Form
    {
        SerialCom serialCom = new SerialCom();
        
        bool sendWithWrite;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SerialPort serialPort1 = serialCom._serialPort1;
            //string dataIN =serialCom.;
            cBoxCOMPORT.Items.AddRange(serialCom.portNames);
            cBoxCOMPORT.SelectedIndex = 0;

            serialCom.dataInAlwaysUpdate = chBoxAlwaysUpdate.Checked;
            serialCom.dataInAddToOldData = chBoxAddToOldData.Checked;

            //string[] ports = SerialPort.GetPortNames();
            //cBoxCOMPORT.Items.AddRange(ports);
            //-----form settings------
            serialCom.OnFormLoad();

            btnOpen.Enabled = true;
            btnClose.Enabled = false;

            chBoxDtrEnable.Checked = false;
            chBoxRtsEnable.Checked = false;
            btnSendData.Enabled = false;

            chBoxWrite.Checked = false;
            chBoxWriteLine.Checked = false;
            sendWithWrite = true;

            chBoxAlwaysUpdate.Checked = false;
            chBoxAddToOldData.Checked = true;
            //---------------------------





        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {   
                serialCom.OpenPort(cBoxCOMPORT.Text, cBoxBaudRate.Text, cBoxDataBits.Text, cBoxStopBits.Text,cBoxParityBits.Text);

                progressBar1.Value = 100;

                btnOpen.Enabled = false;
                btnClose.Enabled = true;

                lblStatusCom.Text = "ON";

            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                lblStatusCom.Text = "OFF";
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            if (serialCom._serialPort1.IsOpen)//---------------------------
            {
                serialCom.ClosePort();

                //serialPort1.Close();
                progressBar1.Value = 0;

                btnOpen.Enabled = true;
                btnClose.Enabled = false;

                lblStatusCom.Text = "OFF";

            }
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            serialCom.SendData(tBoxDataOut.Text, sendWithWrite);
        }

        private void cBoxStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chBoxDtrEnable_CheckedChanged(object sender, EventArgs e)
        {
            serialCom.DtrHandler(chBoxDtrEnable.Checked);
            
        }

        private void chBoxRtsEnable_CheckedChanged(object sender, EventArgs e)
        {
            serialCom.RtsHandler(chBoxRtsEnable.Checked);
           
        }

        private void btnClearDataOut_Click(object sender, EventArgs e)
        {
            if (tBoxDataOut.Text!="")
            {
                tBoxDataOut.Text = "";
            }
        }

        private void tBoxDataOut_TextChanged(object sender, EventArgs e)
        {
            int dataOutLength = tBoxDataOut.TextLength;
            lblDataOutLength.Text = string.Format("{0:00}", dataOutLength);
            if (chBoxUsingEnter.Checked)
            {
                tBoxDataOut.Text = tBoxDataOut.Text.Replace(Environment.NewLine, "");
            }
        }

        private void chBoxUsingButton_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxUsingButton.Checked)
            {
                btnSendData.Enabled = true;
            }
            else
            {
                btnSendData.Enabled = false;
            }
        }

        private void chBoxWriteLine_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxWriteLine.Checked)
            {
                sendWithWrite = false;
                chBoxWrite.Checked = false;
                chBoxWriteLine.Checked = true;
            }
        }

        private void chBoxWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxWrite.Checked)
            {
                sendWithWrite = true;
                chBoxWrite.Checked = true;
                chBoxWriteLine.Checked = false;
            }
        }

        private void tBoxDataOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (chBoxUsingEnter.Checked)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    serialCom.SendData(tBoxDataOut.Text, sendWithWrite);
                   
                }
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            serialCom.DataReceive(tBoxDataIN.Text, chBoxAlwaysUpdate.Checked, chBoxAddToOldData.Checked);
            Console.WriteLine(serialCom._dataIN);
            this.Invoke(new EventHandler(ShowData));

            if (chBoxAlwaysUpdate.Checked)
            {
                tBoxDataIN.Text = serialCom._dataIN;
            }
            else if (chBoxAddToOldData.Checked)
            {
                tBoxDataIN.Text += serialCom._dataIN;
            }
        }

        private void ShowData(object sender, EventArgs e)
        {
            
            int dataINLength= serialCom._dataIN.Length;
            lblDataInLength.Text = string.Format("{0:00}", dataINLength);

           
        }

        private void chBoxAlwaysUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxAlwaysUpdate.Checked)
            {
                chBoxAlwaysUpdate.Checked = true;
                chBoxAddToOldData.Checked = false;
            }
            else
            {
                chBoxAddToOldData.Checked = true;
            }
        }

        private void chBoxAddToOldData_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxAddToOldData.Checked)
            {
                chBoxAlwaysUpdate.Checked = false;
                chBoxAddToOldData.Checked = true;
            }
            else
            {
                chBoxAlwaysUpdate.Checked = true;
            }
        }

        private void btnClearDataIN_Click(object sender, EventArgs e)
        {
            if (tBoxDataIN.Text != "")
            {
                tBoxDataIN.Text = "";
            }
        }
    }
}
