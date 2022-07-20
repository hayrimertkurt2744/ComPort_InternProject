
namespace ComPort
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxCOMPort = new System.Windows.Forms.ComboBox();
            this.cBoxStopBit = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cBoxParityBit = new System.Windows.Forms.ComboBox();
            this.cBoxDataBit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBoxDataOut = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.tBoxDataIn = new System.Windows.Forms.TextBox();
            this.cBoxSendFormat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cBoxReceiveFormat = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(25, 317);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "Open Port";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM Ports";
            // 
            // cBoxCOMPort
            // 
            this.cBoxCOMPort.FormattingEnabled = true;
            this.cBoxCOMPort.Location = new System.Drawing.Point(111, 60);
            this.cBoxCOMPort.Name = "cBoxCOMPort";
            this.cBoxCOMPort.Size = new System.Drawing.Size(121, 21);
            this.cBoxCOMPort.TabIndex = 2;
            // 
            // cBoxStopBit
            // 
            this.cBoxStopBit.FormattingEnabled = true;
            this.cBoxStopBit.Items.AddRange(new object[] {
            "One"});
            this.cBoxStopBit.Location = new System.Drawing.Point(111, 218);
            this.cBoxStopBit.Name = "cBoxStopBit";
            this.cBoxStopBit.Size = new System.Drawing.Size(121, 21);
            this.cBoxStopBit.TabIndex = 4;
            this.cBoxStopBit.Text = "One";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "StopBits";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Baud Rate";
            // 
            // cBoxBaudRate
            // 
            this.cBoxBaudRate.FormattingEnabled = true;
            this.cBoxBaudRate.Items.AddRange(new object[] {
            "9600",
            "4800"});
            this.cBoxBaudRate.Location = new System.Drawing.Point(111, 117);
            this.cBoxBaudRate.Name = "cBoxBaudRate";
            this.cBoxBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cBoxBaudRate.TabIndex = 4;
            this.cBoxBaudRate.Text = "9600";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Parity Bits";
            // 
            // cBoxParityBit
            // 
            this.cBoxParityBit.FormattingEnabled = true;
            this.cBoxParityBit.Items.AddRange(new object[] {
            "None"});
            this.cBoxParityBit.Location = new System.Drawing.Point(111, 264);
            this.cBoxParityBit.Name = "cBoxParityBit";
            this.cBoxParityBit.Size = new System.Drawing.Size(121, 21);
            this.cBoxParityBit.TabIndex = 6;
            this.cBoxParityBit.Text = "None";
            // 
            // cBoxDataBit
            // 
            this.cBoxDataBit.FormattingEnabled = true;
            this.cBoxDataBit.Items.AddRange(new object[] {
            "8",
            "6",
            "5"});
            this.cBoxDataBit.Location = new System.Drawing.Point(111, 172);
            this.cBoxDataBit.Name = "cBoxDataBit";
            this.cBoxDataBit.Size = new System.Drawing.Size(121, 21);
            this.cBoxDataBit.TabIndex = 8;
            this.cBoxDataBit.Text = "8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data Bits";
            // 
            // tBoxDataOut
            // 
            this.tBoxDataOut.Location = new System.Drawing.Point(299, 60);
            this.tBoxDataOut.Multiline = true;
            this.tBoxDataOut.Name = "tBoxDataOut";
            this.tBoxDataOut.Size = new System.Drawing.Size(209, 225);
            this.tBoxDataOut.TabIndex = 9;
            this.tBoxDataOut.Text = "   ";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(362, 317);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 10;
            this.buttonSend.Text = "Send Data";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(157, 317);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 11;
            this.buttonClose.Text = "Close Port";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // tBoxDataIn
            // 
            this.tBoxDataIn.Location = new System.Drawing.Point(572, 63);
            this.tBoxDataIn.Multiline = true;
            this.tBoxDataIn.Name = "tBoxDataIn";
            this.tBoxDataIn.Size = new System.Drawing.Size(209, 225);
            this.tBoxDataIn.TabIndex = 12;
            this.tBoxDataIn.Text = "   ";
            // 
            // cBoxSendFormat
            // 
            this.cBoxSendFormat.FormattingEnabled = true;
            this.cBoxSendFormat.Items.AddRange(new object[] {
            "Hex",
            "ASCII",
            "Binary"});
            this.cBoxSendFormat.Location = new System.Drawing.Point(387, 12);
            this.cBoxSendFormat.Name = "cBoxSendFormat";
            this.cBoxSendFormat.Size = new System.Drawing.Size(121, 21);
            this.cBoxSendFormat.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Send Format";
            // 
            // cBoxReceiveFormat
            // 
            this.cBoxReceiveFormat.FormattingEnabled = true;
            this.cBoxReceiveFormat.Items.AddRange(new object[] {
            "Hex",
            "ASCII",
            "Binary"});
            this.cBoxReceiveFormat.Location = new System.Drawing.Point(660, 12);
            this.cBoxReceiveFormat.Name = "cBoxReceiveFormat";
            this.cBoxReceiveFormat.Size = new System.Drawing.Size(121, 21);
            this.cBoxReceiveFormat.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(571, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Receive Format";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 364);
            this.Controls.Add(this.cBoxReceiveFormat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cBoxSendFormat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tBoxDataIn);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.tBoxDataOut);
            this.Controls.Add(this.cBoxDataBit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cBoxParityBit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cBoxBaudRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cBoxStopBit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBoxCOMPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOpen);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxCOMPort;
        private System.Windows.Forms.ComboBox cBoxStopBit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxBaudRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBoxParityBit;
        private System.Windows.Forms.ComboBox cBoxDataBit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBoxDataOut;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox tBoxDataIn;
        private System.Windows.Forms.ComboBox cBoxSendFormat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cBoxReceiveFormat;
        private System.Windows.Forms.Label label7;
    }
}