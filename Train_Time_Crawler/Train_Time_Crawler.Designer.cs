namespace Train_Time_Crawler
{
    partial class Train_Time_Crawler
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
            this.label_Now_Time = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Train_Time_1 = new System.Windows.Forms.Label();
            this.label_Train_Time_2 = new System.Windows.Forms.Label();
            this.label_Train_Time_3 = new System.Windows.Forms.Label();
            this.button_Tese_Button = new System.Windows.Forms.Button();
            this.textBox_Msg = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button_Swap_Station = new System.Windows.Forms.Button();
            this.label_OriginStationID = new System.Windows.Forms.Label();
            this.label_DestinationStationID = new System.Windows.Forms.Label();
            this.pictureBox_YangMei = new System.Windows.Forms.PictureBox();
            this.pictureBox_TaoYuan = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_YangMei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TaoYuan)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Now_Time
            // 
            this.label_Now_Time.AutoSize = true;
            this.label_Now_Time.Font = new System.Drawing.Font("Microsoft JhengHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Now_Time.Location = new System.Drawing.Point(12, 25);
            this.label_Now_Time.Name = "label_Now_Time";
            this.label_Now_Time.Size = new System.Drawing.Size(157, 34);
            this.label_Now_Time.TabIndex = 0;
            this.label_Now_Time.Text = "XX : XX : XX";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "最接近的三班時間 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "班次                    出發時間";
            // 
            // label_Train_Time_1
            // 
            this.label_Train_Time_1.AutoSize = true;
            this.label_Train_Time_1.Location = new System.Drawing.Point(198, 148);
            this.label_Train_Time_1.Name = "label_Train_Time_1";
            this.label_Train_Time_1.Size = new System.Drawing.Size(224, 24);
            this.label_Train_Time_1.TabIndex = 4;
            this.label_Train_Time_1.Text = "班次                    出發時間";
            // 
            // label_Train_Time_2
            // 
            this.label_Train_Time_2.AutoSize = true;
            this.label_Train_Time_2.Location = new System.Drawing.Point(198, 172);
            this.label_Train_Time_2.Name = "label_Train_Time_2";
            this.label_Train_Time_2.Size = new System.Drawing.Size(224, 24);
            this.label_Train_Time_2.TabIndex = 5;
            this.label_Train_Time_2.Text = "班次                    出發時間";
            // 
            // label_Train_Time_3
            // 
            this.label_Train_Time_3.AutoSize = true;
            this.label_Train_Time_3.Location = new System.Drawing.Point(198, 196);
            this.label_Train_Time_3.Name = "label_Train_Time_3";
            this.label_Train_Time_3.Size = new System.Drawing.Size(224, 24);
            this.label_Train_Time_3.TabIndex = 6;
            this.label_Train_Time_3.Text = "班次                    出發時間";
            // 
            // button_Tese_Button
            // 
            this.button_Tese_Button.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_Tese_Button.Location = new System.Drawing.Point(0, 0);
            this.button_Tese_Button.Name = "button_Tese_Button";
            this.button_Tese_Button.Size = new System.Drawing.Size(411, 35);
            this.button_Tese_Button.TabIndex = 7;
            this.button_Tese_Button.Text = "Test Button";
            this.button_Tese_Button.UseVisualStyleBackColor = true;
            this.button_Tese_Button.Click += new System.EventHandler(this.button_Tese_Button_Click);
            // 
            // textBox_Msg
            // 
            this.textBox_Msg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_Msg.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Msg.Location = new System.Drawing.Point(6, 41);
            this.textBox_Msg.Multiline = true;
            this.textBox_Msg.Name = "textBox_Msg";
            this.textBox_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Msg.Size = new System.Drawing.Size(133, 0);
            this.textBox_Msg.TabIndex = 8;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(145, 41);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(255, 20);
            this.webBrowser1.TabIndex = 9;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // button_Swap_Station
            // 
            this.button_Swap_Station.Location = new System.Drawing.Point(269, 87);
            this.button_Swap_Station.Name = "button_Swap_Station";
            this.button_Swap_Station.Size = new System.Drawing.Size(78, 34);
            this.button_Swap_Station.TabIndex = 10;
            this.button_Swap_Station.Text = ">>>>";
            this.button_Swap_Station.UseVisualStyleBackColor = true;
            this.button_Swap_Station.Click += new System.EventHandler(this.button_Swap_Station_Click);
            // 
            // label_OriginStationID
            // 
            this.label_OriginStationID.AutoSize = true;
            this.label_OriginStationID.Location = new System.Drawing.Point(208, 92);
            this.label_OriginStationID.Name = "label_OriginStationID";
            this.label_OriginStationID.Size = new System.Drawing.Size(48, 24);
            this.label_OriginStationID.TabIndex = 13;
            this.label_OriginStationID.Text = "桃園";
            this.label_OriginStationID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_DestinationStationID
            // 
            this.label_DestinationStationID.AutoSize = true;
            this.label_DestinationStationID.Location = new System.Drawing.Point(363, 92);
            this.label_DestinationStationID.Name = "label_DestinationStationID";
            this.label_DestinationStationID.Size = new System.Drawing.Size(48, 24);
            this.label_DestinationStationID.TabIndex = 14;
            this.label_DestinationStationID.Text = "楊梅";
            this.label_DestinationStationID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox_YangMei
            // 
            this.pictureBox_YangMei.Image = global::Train_Time_Crawler.Properties.Resources.Yangmei_;
            this.pictureBox_YangMei.Location = new System.Drawing.Point(353, 25);
            this.pictureBox_YangMei.Name = "pictureBox_YangMei";
            this.pictureBox_YangMei.Size = new System.Drawing.Size(64, 64);
            this.pictureBox_YangMei.TabIndex = 16;
            this.pictureBox_YangMei.TabStop = false;
            // 
            // pictureBox_TaoYuan
            // 
            this.pictureBox_TaoYuan.Image = global::Train_Time_Crawler.Properties.Resources.Taoyuan;
            this.pictureBox_TaoYuan.Location = new System.Drawing.Point(199, 25);
            this.pictureBox_TaoYuan.Name = "pictureBox_TaoYuan";
            this.pictureBox_TaoYuan.Size = new System.Drawing.Size(64, 64);
            this.pictureBox_TaoYuan.TabIndex = 15;
            this.pictureBox_TaoYuan.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button_Tese_Button);
            this.panel1.Controls.Add(this.textBox_Msg);
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Location = new System.Drawing.Point(12, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 0);
            this.panel1.TabIndex = 17;
            // 
            // Train_Time_Crawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 225);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox_YangMei);
            this.Controls.Add(this.pictureBox_TaoYuan);
            this.Controls.Add(this.label_DestinationStationID);
            this.Controls.Add(this.label_OriginStationID);
            this.Controls.Add(this.button_Swap_Station);
            this.Controls.Add(this.label_Train_Time_3);
            this.Controls.Add(this.label_Train_Time_2);
            this.Controls.Add(this.label_Train_Time_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Now_Time);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Train_Time_Crawler";
            this.Text = "火車時刻 簡表";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Train_Time_Crawler_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_YangMei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TaoYuan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Now_Time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Train_Time_1;
        private System.Windows.Forms.Label label_Train_Time_2;
        private System.Windows.Forms.Label label_Train_Time_3;
        private System.Windows.Forms.Button button_Tese_Button;
        private System.Windows.Forms.TextBox textBox_Msg;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button_Swap_Station;
        private System.Windows.Forms.Label label_OriginStationID;
        private System.Windows.Forms.Label label_DestinationStationID;
        private System.Windows.Forms.PictureBox pictureBox_TaoYuan;
        private System.Windows.Forms.PictureBox pictureBox_YangMei;
        private System.Windows.Forms.Panel panel1;
    }
}

