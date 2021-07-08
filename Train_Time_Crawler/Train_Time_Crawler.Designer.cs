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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Train_Time_1 = new System.Windows.Forms.Label();
            this.label_Train_Time_2 = new System.Windows.Forms.Label();
            this.label_Train_Time_3 = new System.Windows.Forms.Label();
            this.button_Tese_Button = new System.Windows.Forms.Button();
            this.textBox_Msg = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // label_Now_Time
            // 
            this.label_Now_Time.AutoSize = true;
            this.label_Now_Time.Location = new System.Drawing.Point(39, 49);
            this.label_Now_Time.Name = "label_Now_Time";
            this.label_Now_Time.Size = new System.Drawing.Size(110, 24);
            this.label_Now_Time.TabIndex = 0;
            this.label_Now_Time.Text = "XX : XX : XX";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "最接近的三班時間 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "桃園      ------>      楊梅";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "班次                    出發時間";
            // 
            // label_Train_Time_1
            // 
            this.label_Train_Time_1.AutoSize = true;
            this.label_Train_Time_1.Location = new System.Drawing.Point(193, 90);
            this.label_Train_Time_1.Name = "label_Train_Time_1";
            this.label_Train_Time_1.Size = new System.Drawing.Size(224, 24);
            this.label_Train_Time_1.TabIndex = 4;
            this.label_Train_Time_1.Text = "班次                    出發時間";
            // 
            // label_Train_Time_2
            // 
            this.label_Train_Time_2.AutoSize = true;
            this.label_Train_Time_2.Location = new System.Drawing.Point(193, 114);
            this.label_Train_Time_2.Name = "label_Train_Time_2";
            this.label_Train_Time_2.Size = new System.Drawing.Size(224, 24);
            this.label_Train_Time_2.TabIndex = 5;
            this.label_Train_Time_2.Text = "班次                    出發時間";
            // 
            // label_Train_Time_3
            // 
            this.label_Train_Time_3.AutoSize = true;
            this.label_Train_Time_3.Location = new System.Drawing.Point(193, 138);
            this.label_Train_Time_3.Name = "label_Train_Time_3";
            this.label_Train_Time_3.Size = new System.Drawing.Size(224, 24);
            this.label_Train_Time_3.TabIndex = 6;
            this.label_Train_Time_3.Text = "班次                    出發時間";
            // 
            // button_Tese_Button
            // 
            this.button_Tese_Button.Location = new System.Drawing.Point(423, 115);
            this.button_Tese_Button.Name = "button_Tese_Button";
            this.button_Tese_Button.Size = new System.Drawing.Size(121, 56);
            this.button_Tese_Button.TabIndex = 7;
            this.button_Tese_Button.Text = "Test Button";
            this.button_Tese_Button.UseVisualStyleBackColor = true;
            this.button_Tese_Button.Click += new System.EventHandler(this.button_Tese_Button_Click);
            // 
            // textBox_Msg
            // 
            this.textBox_Msg.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Msg.Location = new System.Drawing.Point(16, 177);
            this.textBox_Msg.Multiline = true;
            this.textBox_Msg.Name = "textBox_Msg";
            this.textBox_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Msg.Size = new System.Drawing.Size(133, 420);
            this.textBox_Msg.TabIndex = 8;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(155, 177);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(389, 420);
            this.webBrowser1.TabIndex = 9;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // Train_Time_Crawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 165);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.textBox_Msg);
            this.Controls.Add(this.button_Tese_Button);
            this.Controls.Add(this.label_Train_Time_3);
            this.Controls.Add(this.label_Train_Time_2);
            this.Controls.Add(this.label_Train_Time_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Now_Time);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Train_Time_Crawler";
            this.Text = "火車時刻 簡表";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Train_Time_Crawler_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Now_Time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Train_Time_1;
        private System.Windows.Forms.Label label_Train_Time_2;
        private System.Windows.Forms.Label label_Train_Time_3;
        private System.Windows.Forms.Button button_Tese_Button;
        private System.Windows.Forms.TextBox textBox_Msg;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}

