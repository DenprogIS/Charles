namespace CharlesNewVersion
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.recogButton = new System.Windows.Forms.PictureBox();
            this.buttonStartStopLearning = new System.Windows.Forms.Button();
            this.recognitionTimer = new System.Windows.Forms.Timer(this.components);
            this.backButton = new System.Windows.Forms.Button();
            this.serialPortArduino = new System.IO.Ports.SerialPort(this.components);
            this.selfLearning = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.commandShow = new System.Windows.Forms.TextBox();
            this.UIToolsBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.showEndContent = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.showBeginContent = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.showEndPath = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.showBeginPath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.recogButton)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // recogButton
            // 
            this.recogButton.Image = global::CharlesNewVersion.Properties.Resources.mic;
            this.recogButton.Location = new System.Drawing.Point(15, 10);
            this.recogButton.Name = "recogButton";
            this.recogButton.Size = new System.Drawing.Size(101, 102);
            this.recogButton.TabIndex = 3;
            this.recogButton.TabStop = false;
            this.recogButton.Click += new System.EventHandler(this.recogButton_Click);
            // 
            // buttonStartStopLearning
            // 
            this.buttonStartStopLearning.Location = new System.Drawing.Point(6, 143);
            this.buttonStartStopLearning.Name = "buttonStartStopLearning";
            this.buttonStartStopLearning.Size = new System.Drawing.Size(119, 23);
            this.buttonStartStopLearning.TabIndex = 4;
            this.buttonStartStopLearning.Text = "Начать обучение";
            this.buttonStartStopLearning.UseVisualStyleBackColor = true;
            this.buttonStartStopLearning.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // recognitionTimer
            // 
            this.recognitionTimer.Interval = 400;
            this.recognitionTimer.Tick += new System.EventHandler(this.recognitionTimer_Tick);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(15, 169);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(101, 23);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // selfLearning
            // 
            this.selfLearning.Tick += new System.EventHandler(this.selfLearning_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.commandShow);
            this.groupBox1.Controls.Add(this.recogButton);
            this.groupBox1.Controls.Add(this.backButton);
            this.groupBox1.Controls.Add(this.buttonStartStopLearning);
            this.groupBox1.Location = new System.Drawing.Point(566, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 198);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // commandShow
            // 
            this.commandShow.Location = new System.Drawing.Point(6, 117);
            this.commandShow.Name = "commandShow";
            this.commandShow.Size = new System.Drawing.Size(119, 20);
            this.commandShow.TabIndex = 7;
            // 
            // UIToolsBox
            // 
            this.UIToolsBox.FormattingEnabled = true;
            this.UIToolsBox.Location = new System.Drawing.Point(125, 12);
            this.UIToolsBox.Name = "UIToolsBox";
            this.UIToolsBox.Size = new System.Drawing.Size(121, 21);
            this.UIToolsBox.TabIndex = 8;
            this.UIToolsBox.SelectedIndexChanged += new System.EventHandler(this.UIToolsBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(547, 330);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.showEndContent);
            this.groupBox6.Location = new System.Drawing.Point(6, 247);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(535, 70);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Конечное содержание папки";
            // 
            // showEndContent
            // 
            this.showEndContent.AutoSize = true;
            this.showEndContent.Location = new System.Drawing.Point(6, 16);
            this.showEndContent.Name = "showEndContent";
            this.showEndContent.Size = new System.Drawing.Size(0, 13);
            this.showEndContent.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.showBeginContent);
            this.groupBox5.Location = new System.Drawing.Point(6, 171);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(535, 70);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Начальное содержание папки";
            // 
            // showBeginContent
            // 
            this.showBeginContent.AutoSize = true;
            this.showBeginContent.Location = new System.Drawing.Point(6, 16);
            this.showBeginContent.Name = "showBeginContent";
            this.showBeginContent.Size = new System.Drawing.Size(0, 13);
            this.showBeginContent.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.showEndPath);
            this.groupBox4.Location = new System.Drawing.Point(6, 95);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(535, 70);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Конечный путь";
            // 
            // showEndPath
            // 
            this.showEndPath.AutoSize = true;
            this.showEndPath.Location = new System.Drawing.Point(6, 15);
            this.showEndPath.Name = "showEndPath";
            this.showEndPath.Size = new System.Drawing.Size(0, 13);
            this.showEndPath.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.showBeginPath);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(535, 70);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Начальный путь";
            // 
            // showBeginPath
            // 
            this.showBeginPath.AutoSize = true;
            this.showBeginPath.Location = new System.Drawing.Point(6, 16);
            this.showBeginPath.Name = "showBeginPath";
            this.showBeginPath.Size = new System.Drawing.Size(0, 13);
            this.showBeginPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Инструмент:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 379);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.UIToolsBox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Charles";
            ((System.ComponentModel.ISupportInitialize)(this.recogButton)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox recogButton;
        private System.Windows.Forms.Button buttonStartStopLearning;
        private System.Windows.Forms.Timer recognitionTimer;
        private System.Windows.Forms.Button backButton;
        private System.IO.Ports.SerialPort serialPortArduino;
        private System.Windows.Forms.Timer selfLearning;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox UIToolsBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label showEndContent;
        private System.Windows.Forms.Label showBeginContent;
        private System.Windows.Forms.Label showEndPath;
        private System.Windows.Forms.Label showBeginPath;
        private System.Windows.Forms.TextBox commandShow;
        private System.Windows.Forms.Label label1;

    }
}

